/// <reference path="../libs/underscore/underscore.js" />
/// <reference path="../libs/knockoutjs/knockout-2.3.0.js" />
/*global ko, jQuery, _, ENTER_KEY */

var app = app || {};

(function ($) {
    'use strict';

    var appVM = function () {
        var bands = ko.observableArray(),
            band = ko.observable(),
            song = ko.observable(),
            bandList = ko.observableArray(),

            newSong = function () {
                var index = -1;

                 _.each(bandList(), function (item, i) {
                     if (item.id == band().id) {
                         index = i;
                         return false;
                     }
                });

                var songItem = {
                    name: song(),
                    listened: false
                };

                if (index === -1) {
                    var bandItem = {
                        name: band().name,
                        id: band().id,
                        songs: ko.observableArray([
                            songItem
                        ])
                    };

                    bandList.push(bandItem);
                } else {
                    bandList()[index].songs.push(songItem);
                }

                reset();
            },

            reset = function () {
                song(null);
                band(null);
            },

            initialize = function () {
                var data = [
                    {
                        id: 1,
                        name: "Helloween"
                    },

                    {
                        id: 2,
                        name: "Gamma Ray"
                    }
                ];

                bands(data);
            };

        initialize();

        return {
            bands: bands,
            band: band,
            song: song,
            bandList: bandList,
            newSong: newSong
        };
    };

    app.viewModel = new appVM();
})();