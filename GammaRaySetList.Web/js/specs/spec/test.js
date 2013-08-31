/*global describe, it, app */
'use strict';
(function () {

    describe('App ViewModel Tests', function () {
        it('bands should be greater than 0', function () {
            expect(app.viewModel.bands()).to.have.length.above(0);
        });

        it('bandList should be equal to 1', function () {
            app.viewModel.bandList.removeAll();

            app.viewModel.band({
                name: "Helloween",
                id: 1
            });

            app.viewModel.song('Rebellion in Dreamland');

            app.viewModel.newSong();

            expect(app.viewModel.bandList()).to.have.length(1);
        });

        it('bandList should contains 2 songs', function () {
            app.viewModel.bandList.removeAll();

            function add(songName) {
                app.viewModel.band({
                    name: "Helloween",
                    id: 1
                });

                app.viewModel.song(songName);

                app.viewModel.newSong();
            }

            add('Rebellion in Dreamland');
            add('Anywhere in the galaxy');

            expect(app.viewModel.bandList()[0].songs()).to.have.length(2);
        });

        it('newSong should return false if song is null', function () {
            app.viewModel.song(undefined);

            expect(app.viewModel.newSong()).to.not.be.ok;
        });

    });
})();
