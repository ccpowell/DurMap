// The following comments are for JSLint.
// Do NOT remove them!
// see http://www.jslint.com/
/*jslint browser: true, debug: true, devel: true, white: true, plusplus: true, maxerr: 100, unparam: true, indent: 4 */
/*global $: false, define: false, ko: false */

define(['durandal/widget', 'durandal/system'],
    function (widget, system) {
        "use strict";
        var ctor;

        function copyDate(d) {
            return new Date(d.toDateString());
        }

        function addDays(d, n) {
            d.setDate(d.getDate() + n);
        }

        // minDate is javascript Date or string
        // days is number of days in range
        // beginDate should be an observable date
        // endDate should be an observable date
        ctor = function (element, settings) {
            var maxDate;
            this.minDate = new Date(settings.minDate.toString());
            this.days = settings.days || 100;

            maxDate = copyDate(this.minDate);
            addDays(maxDate, this.days);
            this.beginDate = settings.beginDate || ko.observable(settings.minDate);
            this.endDate = settings.endDate || ko.observable(maxDate);
            this.value = [this.daysFromMin(this.beginDate()), this.daysFromMin(this.endDate())];
        };

        // get number of days from minDate
        ctor.prototype.daysFromMin = function (d) {
            var date = copyDate(this.minDate), i;
            for (i = 0; i <= this.days + 1; i++) {
                addDays(date, 1);
                if (date > d) {
                    return i;
                }
            }
            return -1;
        };

        ctor.prototype.formatSliderDate = function (value) {
            var date = copyDate(this.minDate);
            addDays(date, value);
            return date.toDateString();
        };

        ctor.prototype.sliderDate = function (value) {
            var date = copyDate(this.minDate);
            addDays(date, value);
            return date;
        }

        ctor.prototype.sliderStop = function (e) {
        };

        ctor.prototype.slide = function (e) {
            // check e.value against this.value to see which value(s) changed
            if (e.value[0] !== this.value[0]) {
                this.beginDate(this.sliderDate(e.value[0]));
                system.log("begin slider date " + this.beginDate());
            }
            if (e.value[1] !== this.value[1]) {
                this.endDate(this.sliderDate(e.value[1]));
                system.log("end slider date " + this.endDate());
            }
            //save for later
            this.value = e.value;
        };

        ctor.prototype.viewAttached = function (view) {
            $(view).slider({
                min: 0,
                max: this.days,
                //formater: $.proxy(this.formatSliderDate, this),
                tooltip: 'hide',
                value: this.value
            })
            .on('slideStop', $.proxy(this.sliderStop, this))
            .on('slide', $.proxy(this.slide, this));
        };

        return ctor;
    });