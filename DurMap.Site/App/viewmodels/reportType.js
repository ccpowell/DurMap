// The following comments are for JSLint.
// Do NOT remove them!
// see http://www.jslint.com/
/*jslint browser: true, debug: true, devel: true, white: true, plusplus: true, maxerr: 100, unparam: true, indent: 4 */
/*global jQuery: false, $: false, define: false, ko: false, Microsoft: false */

define(['durandal/system'], function (system) {
    "use strict";

    function initializeReportTypes() {
        var i, reports = [];
        for (i = 0; i < 25; i++) {
            reports.push({
                name: i.toString()
            });
        }
        return reports;
    }

    return {
        reports: initializeReportTypes(),
        reportType: ko.observable("nothing selected")
    };
});