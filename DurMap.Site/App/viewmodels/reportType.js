// The following comments are for JSLint.
// Do NOT remove them!
// see http://www.jslint.com/
/*jslint browser: true, debug: true, devel: true, white: true, plusplus: true, maxerr: 100, unparam: true, indent: 4 */
/*global jQuery: false, $: false, define: false, ko: false, Microsoft: false */

define(['durandal/system'], function (system) {
    "use strict";
    var self = {
        categories: ko.observableArray([{ name: "loading...", reports: [] }]),
        reportType: ko.observable("nothing selected")
    };

    function initializeCategories() {
        self.categories.removeAll();
        self.categories.push({ name: 'Some Type of Thing', reports: [{ name: 'Some Report 1' }, { name: 'Some Report 2'}] });
        self.categories.push({ name: 'Another Thing', reports: [{ name: 'Another Report 1' }, { name: 'Another Report 2'}] });
        self.categories.push({ name: 'Yet Another Thing', reports: [{ name: 'Summary' }, { name: 'Final Report'}] });
        self.reportType("...");
    }

    // calling initializePersons in the thread seems to bollix up knockout
    // if using the network, this won't matter
    self.viewAttached = function (view) {
        window.setTimeout(initializeCategories, 100);
    };
    return self;
});