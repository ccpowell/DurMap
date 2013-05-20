// The following comments are for JSLint.
// Do NOT remove them!
// see http://www.jslint.com/
/*jslint browser: true, debug: true, devel: true, white: true, plusplus: true, maxerr: 100, unparam: true, indent: 4 */
/*global $: false, define: false, ko: false, Microsoft: false */

define(['durandal/app', 'durandal/system', 'viewmodels/reportType', 'viewmodels/persons'], function (app, system, reportType, persons) {
    "use strict";
    var self = {
        map: null,
        reportBegin: ko.observable(new Date("2/1/2012")),
        reportEnd: ko.observable(new Date("3/1/2012")),
        reportDays: 365,
        reportMinDate: new Date("12/25/2011")
    };


    function viewAttached(view) {
        var div = $(view).find('div.map-container').get(0),
            slider = $(view).find('div.report-date-slider');
        system.log("map attaching");
        if (self.map) {
            system.log("map is made!");
        } else {
            system.log("creating map");
            if (!div) {
                system.log("ERROR! could not find mapDiv");
            }
            self.map = new Microsoft.Maps.Map(div, {
                //AgC2Es49yUnBEY3Wev3y6qlN6MNFGYFMInS-w7MsUnKJs0gUtsvzYexB0JsvUFmr
                //AjtUzWJBHlI3Ma_Ke6Qv2fGRXEs0ua5hUQi54ECwfXTiWsitll4AkETZDihjcfeI ISDK
                //AqFS5IR76tuVDO7gUl9YncTj1GHOkrJC00Ol_qz1qJNG31f4Ie9Utw8TZEF0mEIX
                //AjVI0TPKHqwalgzvnmlL3S3IC_UiHnxKcpRCNUtRNXbZenP1a-3uwADNDVJkwN3i
                credentials: "Ar4tBcd2Q3r9Lc4KWjZQj-cI9Hrf9CcVf3gNZ-eX-3iHB8dQPIRXgsLaGOcVIJtS",
                center: new Microsoft.Maps.Location(40, -95),
                zoom: 4
            });
        }
    }

    function getReport(x, y) {
        system.log("get report " + self.reportType.reportType() + ", person = " + self.persons.personSelected());
    }

    // we keep access to the viewmodels for the reportType and region list.
    $.extend(self, {
        getReport: getReport,
        viewAttached: viewAttached,
        reportType: reportType,
        persons: persons
    });

    return self;
});