// The following comments are for JSLint.
// Do NOT remove them!
// see http://www.jslint.com/
/*jslint browser: true, debug: true, devel: true, white: true, plusplus: true, maxerr: 100, unparam: true, indent: 4 */
/*global $: false, define: false, ko: false, Microsoft: false */

define(['durandal/app', 'durandal/system', 'viewmodels/reportType', 'viewmodels/persons'], function (app, system, reportType, persons) {
    "use strict";
    var self = {
        map: null
    };

    function viewAttached(view) {
        var div = $(view).find('div.map-container').get(0);
        system.log("map attaching");
        if (self.map === undefined) {
            system.log("map is not defined");
        }
        if (self.map === null) {
            system.log("map is null");
        }
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
                credentials: "AjtUzWJBHlI3Ma_Ke6Qv2fGRXEs0ua5hUQi54ECwfXTiWsitll4AkETZDihjcfeI",
                center: new Microsoft.Maps.Location(40, -95),
                zoom: 4
            });
        }
    }

    function getReport(x, y) {
        system.log("get report " + self.reportType.reportType()  + ", person = " + self.persons.personSelected());
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