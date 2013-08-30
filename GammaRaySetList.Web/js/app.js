/// <reference path="../libs/underscore/underscore.js" />
/// <reference path="viewmodel/app.view.js" />
/// <reference path="../libs/knockoutjs/knockout-2.3.0.js" />
/*global ko, jQuery, _, ENTER_KEY */

var app = app || {};

(function () {
    'use strict';

    ko.applyBindings(app.viewModel || {}, $('#app')[0]);
})();