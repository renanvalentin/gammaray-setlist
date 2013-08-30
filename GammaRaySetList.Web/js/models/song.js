var app = app || {};

app.Song = new Backbone.Model.extend({
    defaults: {
        name: '',
        listened: false
    },

    setName: function (name) {
        this.set('name', name);
    },

    toggle: function () {
        this.set('listened', !this.get('listened'));
    }
});