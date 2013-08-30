var app = app || {};

app.Band = new Backbone.Model.extend({
    defaults: {
        name: ''
    },

    setName: function (name) {
        this.set('name', name);
    }
});