var ENTER_KEY = 13;

ko.bindingHandlers.enterKey = {
    init: function (element, valueAccessor, allBindingsAccessor, data) {
        var wrappedHandler, newValueAccessor;

        wrappedHandler = function (data, event) {
            if (event.keyCode === ENTER_KEY) {
                valueAccessor().call(this, data, event);
            }
        };

        newValueAccessor = function () {
            return {
                keyup: wrappedHandler
            };
        };

        ko.bindingHandlers.event.init(element, newValueAccessor, allBindingsAccessor, data);
    }
};