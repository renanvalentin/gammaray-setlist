/// <reference path="../libs/underscore/underscore.js" />
/// <reference path="../libs/jquery/jquery-2.0.3.js" />
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
                if (!_song() || !_band()) {
                    toastr.error('fields cannot be null!');
                    return false;
                }

                var songItem = ko.observable({
                    id: 0,
                    name: _song(),
                    listened: false,
                    band: {
                        id: _band().id
                    }
                });

                addToList(songItem);
                saveSong(songItem);
                reset();
            },

            reset = function () {
                _song(null);
            },

            addToList = function (songItem) {
                var index = -1;

                _.each(_bandList(), function (item, i) {
                    if (item.id() == _band().id) {
                        index = i;
                        return false;
                    }
                });

                if (index === -1) {
                    var bandItem = {
                        name: ko.observable(_band().name),
                        id: ko.observable( _band().id),
                        songs: ko.observableArray([
                            songItem
                        ])
                    };

                    _bandList.push(bandItem);
                } else {
                    _bandList()[index].songs().push(songItem());
                    _bandList()[index].songs.valueHasMutated();
                }
            },

            saveSong = function (song) {
                $.ajax({
                    url: '/api/song',
                    type: "post",
                    contentType: 'application/json',
                    data: ko.toJSON(song)
                }).done(function (data) {
                    song().id = data.id;
                    toastr.success('new song added to list!');
                });
            },

            updateListened = function (song) {
                $.ajax({
                    url: '/api/song',
                    type: "put",
                    contentType: 'application/json',
                    data: ko.toJSON(song)
                }).done(function (data) {
                    toastr.success('song updated!');
                });

                return true;
            },

            destroy = function (song) {
                $.ajax({
                    url: '/api/song/' + song.id,
                    type: "DELETE",
                    contentType: 'application/json',
                }).done(function (data) {
                    removeFromList(song);
                    toastr.success('release the kraken!');
                });
            },

            removeFromList = function (song) {
                _.each(_bandList(), function (band) {
                    var index = -1;
                    _.each(band.songs(), function (item, i) {
                        if (item.name === this.name && item.id === this.id) {
                            index = i;
                            return false;
                        }
                    }, this);

                    if (index >= 0) {
                        band.songs.splice(index, 1);
                        return false;
                    }
                }, song);
            },

            mapping = function (data) {
                for (var i = 0; i < data.length; i++) {
                    var item = data[i],
                        band = {
                            id: ko.observable(item.id),
                            name: ko.observable(item.name),
                            songs: ko.observableArray(item.songs)
                        };

                    _bandList.push(band);
                }
            },

            fetchData = function () {
                var getBandList = $.ajax({
                    url: '/api/band',
                    type: "get",
                    contentType: 'application/json'
                });

                var getBandOptions = $.ajax({
                    url: '/api/lookups',
                    type: "get",
                    contentType: 'application/json'
                });

                $.when(getBandList, getBandOptions).done(function (bandList, bandOptions) {
                    mapping(bandList[0]);
                    _bands(bandOptions[0]);
                    toastr.success('songs retrieved successfully');
                });
            },

        initialize = function () {
            fetchData();
        };

        initialize();

        return {
            bands: _bands,
            band: _band,
            song: _song,
            bandList: _bandList,
            newSong: newSong,
            updateListened: updateListened,
            destroy: destroy
        };
    };

    app.viewModel = new appVM();
})(jQuery);