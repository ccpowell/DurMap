// The following comments are for JSLint.
// Do NOT remove them!
// see http://www.jslint.com/
/*jslint browser: true, debug: true, devel: true, white: true, plusplus: true, maxerr: 100, unparam: true, indent: 4 */
/*global $: false, define: false, ko: false, Microsoft: false */

define(['durandal/app', 'durandal/system', 'durandal/http', 'viewmodels/reportType', 'viewmodels/persons'],
    function (app, system, http, reportType, persons) {
        "use strict";
        var mm = Microsoft.Maps,

        // Bing map
            map = null,

        // state borders on the map
            ecStates = new mm.EntityCollection({ zIndex: 2 }),

        // state border data in geoJSON
            dataStates = null,

        // viewmodel
            self = {
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
            if (map) {
                system.log("map is made!");
            } else {
                system.log("creating map");
                if (!div) {
                    system.log("ERROR! could not find mapDiv");
                }
                map = new Microsoft.Maps.Map(div, {
                    credentials: "Ar4tBcd2Q3r9Lc4KWjZQj-cI9Hrf9CcVf3gNZ-eX-3iHB8dQPIRXgsLaGOcVIJtS",
                    center: new Microsoft.Maps.Location(40, -95),
                    zoom: 4
                });
                map.entities.push(ecStates);
            }
        }

        function getReport(x, y) {
            system.log("get report " + self.reportType.reportType() + ", person = " + self.persons.personSelected());
        }


        function getCurrentMapView() {
            var view = {
                zoom: map.getZoom(),
                bounds: map.getBounds()
            };
            return view;
        }

        // get states in the current view of the map
        // return a promise
        function getStatesInMap() {
            var view = getCurrentMapView();
            return http.post('/operations/misc/GetStates', view);
        }

        function renderStates() {
            var scale;
            ecStates.clear();

            if (!dataStates) {
                return;
            }

            // draw each state
            $.each(dataStates.features, function (index, feature) {
                polygonStyle = {
                    fillColor: new mm.Color(128, 100, 100, 100),
                    strokeColor: new mm.Color(200, 0, 0, 0),
                    strokeThickness: 2
                };

                function createPrimitive(index, poly) {
                    // draw only the first (exterior) polygon
                    var locations = [], polygon;
                    $.each(poly[0], function (cindex, coord) {
                        var location = new mm.Location(coord[1], coord[0]);
                        locations.push(location);
                    });

                    polygon = new mm.Polygon(locations, polygonStyle);
                    polygon.properties = feature.properties;

                    //mm.Events.addHandler(polygon, "mouseover", countyMouseover);
                    //mm.Events.addHandler(polygon, "mouseout", countyMouseout);
                    //mm.Events.addHandler(polygon, "click", countyMouseClick);

                    ecStates.push(polygon);
                }

                // draw each polygon in a county (e.g. islands)
                $.each(feature.geometry.coordinates, createPrimitive);
            });
        }

        function kluge() {
            getStatesInMap()
                .then(function (data) {
                    system.log("got states");
                    dataStates = data;
                    renderStates();
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