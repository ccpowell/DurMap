﻿// The following comments are for JSLint.
// Do NOT remove them!
// see http://www.jslint.com/
/*jslint browser: true, debug: true, devel: true, white: true, plusplus: true, maxerr: 100, unparam: true, indent: 4 */
/*global $: false, define: false, ko: false */

define(['durandal/system'], function (system) {
    "use strict";
    var self = {
        regions: ko.observableArray([]),
        personSelected: ko.observable("nobody selected")
    };

    function initializePersons() {
        self.regions.push({ name: "East Coast", persons: ["Harry", "Sally"] });
        self.regions.push({ name: "West Coast", persons: ["Joe", "John", "Alice", "Ho"] });
        system.log("regions loaded");
    }

    // TODO: this should work
    //self.viewAttached = initializePersons;
    initializePersons();
    return self;
});