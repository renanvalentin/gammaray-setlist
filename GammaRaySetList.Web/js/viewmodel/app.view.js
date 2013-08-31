/// <reference path="../libs/underscore/underscore.js" />
/// <reference path="../libs/knockoutjs/knockout-2.3.0.js" />
/*global ko, jQuery, _, ENTER_KEY */

var app = app || {};

(function ($) {
    'use strict';

    var appVM = function () {
        var _bands = ko.observableArray(),
            _band = ko.observable(),
            _song = ko.observable(),
            _bandList = ko.observableArray(),

            newSong = function () {
                var songItem = {
                    id: 0,
                    name: _song(),
                    listened: false,
                    band: ko.toJS(_band())
                };

                addToList(songItem);
                saveSong(songItem);
                reset();
            },

            reset = function () {
                _song(null);
                _band(null);
            },

            addToList = function (song) {
                var index = -1;

                _.each(_bandList(), function (item, i) {
                    if (item.id == _band().id) {
                        index = i;
                        return false;
                    }
                });

                if (index === -1) {
                    var bandItem = {
                        name: _band().name,
                        id: _band().id,
                        songs: ko.observableArray([
                            songItem
                        ])
                    };

                    _bandList.push(bandItem);
                } else {
                    _bandList()[index].songs.push(songItem);
                }
            },

            saveSong = function (song) {

            },

            updateListened = function (e, f) {
                console.log(e);
                console.log(f);
                return true;
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

                _bands(data);

                _bandList.subscribe(updateListened);
            };

        initialize();

        return {
            bands: _bands,
            band: _band,
            song: _song,
            bandList: _bandList,
            newSong: newSong,
            updateListened: updateListened
        };
    };

    app.viewModel = new appVM();
})();