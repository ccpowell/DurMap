// The following comments are for JSLint.
// Do NOT remove them!
// see http://www.jslint.com/
/*jslint browser: true, debug: true, devel: true, white: true, plusplus: true, maxerr: 100, unparam: true, indent: 4 */
/*global $: false, define: false, ko: false, Microsoft: false */

define(['durandal/app', 'durandal/system', 'durandal/http', 'viewmodels/reportType', 'viewmodels/persons'],
    function (app, system, http, reportType, persons) {
        "use strict";
        var self = {
            map: null,
            reportBegin: ko.observable(new Date("2/1/2012")),
            reportEnd: ko.observable(new Date("3/1/2012")),
            reportDays: 365,
            reportMinDate: new Date("12/25/2011")
        };

        function reportDateChanged(ev) {
            system.log("report date changed");
        }

        // create map when DOM becomes visible
        function viewAttached(view) {
            var div = $(view).find('div.map-container').get(0);
            system.log("map attaching");
            if (self.map) {
                system.log("map is made!");
            } else {
                system.log("creating map");
                if (!div) {
                    system.log("ERROR! could not find mapDiv");
                }
                self.map = new Microsoft.Maps.Map(div, {
                    credentials: "Ar4tBcd2Q3r9Lc4KWjZQj-cI9Hrf9CcVf3gNZ-eX-3iHB8dQPIRXgsLaGOcVIJtS",
                    center: new Microsoft.Maps.Location(40, -95),
                    zoom: 4
                });
            }
        }

        function getReport(x, y) {
            system.log("get report " + self.reportType.reportType() + ", person = " + self.persons.personSelected());
        }


        function getCurrentMapView() {
            var view = {
                zoom: self.map.getZoom(),
                bounds: self.map.getBounds()
            };
            return view;
        }

        // get states in the current view of the map
        // return a promise
        function getStatesInMap() {
            var view = getCurrentMapView();
            return http.post('/operations/misc/GetStates', view);
        }

        function kluge() {
            getStatesInMap()
                .then(function (data) {
                    system.log("got states");
                });
        }

        // we keep access to the viewmodels for the reportType and region list.
        $.extend(self, {
            getReport: getReport,
            viewAttached: viewAttached,
            reportType: reportType,
            persons: persons,
            reportDateChanged: reportDateChanged,
            kluge: kluge
        });

        return self;
    });