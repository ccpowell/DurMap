define(['durandal/app', 'durandal/system'], function (app, system) {
    var map;

    return {
        map: map,
        viewAttached: function (view) {
            var div = document.getElementById("mapDiv");
            system.log("map attaching");
            if (map === undefined) {
                system.log("map is not defined");
            }
            if (map === null) {
                system.log("map is null");
            }
            if (map) {
                system.log("map is made!");
            } else {
                system.log("creating map");
                if (!div) {
                    system.log("ERROR! could not find mapDiv");
                }
                map = new Microsoft.Maps.Map(div, {
                    credentials: "AqFS5IR76tuVDO7gUl9YncTj1GHOkrJC00Ol_qz1qJNG31f4Ie9Utw8TZEF0mEIX",
                    center: new Microsoft.Maps.Location(45.5, -122.5),
                    zoom: 7
                });
            }
        }
    };
});