let expect = require('chai').expect;
let SoftUniFy = require('./SoftUniFy')

let sofunify = new SoftUniFy();

//sofunify.downloadSong('Eminem', 'Venom', 'Knock, Knock let the devil in...');
// sofunify.downloadSong('Eminem', 'Phenomenal', 'IM PHENOMENAL...');
// sofunify.downloadSong('Dub Fx', 'Light Me On Fire', 'You can call me a liar.. ');
sofunify.playSong('Kate')
console.log(sofunify.allSongs);




describe("All tests", function() {
    let softUniFy;
    beforeEach(function () {
        softUniFy = new SoftUniFy()
    });

    describe("", function() {
       it("allSongs property that is initialized as an empty object", function() {
         let result = softUniFy.allSongs;
         expect(result).to.be.eql({});
       });
       
 });
 it("All songs with no song", function() {
     let result = softUniFy.allSongs
     expect(result).to.be.eql({});
    });

    it("download song", function() {
      softUniFy.downloadSong('Eminem', 'Venom', 'Knock, Knock let the devil in...')
      softUniFy.downloadSong('Eminem', 'Phenomenal', 'IM PHENOMENAL...')
      softUniFy.downloadSong('Dub Fx', 'Light Me On Fire', 'You can call me a liar.. ')
        let result = softUniFy.allSongs
        expect(result).to.be.eql(softUniFy.allSongs);
       });
 
       it("Rate artist who is not included", function() {
       // softUniFy.rateArtist('Eminem')
       softUniFy.downloadSong('Eminem', 'Kate', 'Kate')
        let result = softUniFy.rateArtist('Eminen',50)
        expect(result).to.be.eql('The Eminen is not on your artist list.');
       });

       it("play song", function() {
        softUniFy.downloadSong('Eminem', 'Kate', 'Kate')
        softUniFy.downloadSong('Eminem', 'Kate', 'Kate')
        // softUniFy.downloadSong('Eminem', 'Phenomenal', 'IM PHENOMENAL...')
        // softUniFy.downloadSong('Dub Fx', 'Light Me On Fire', 'You can call me a liar.. ')
        sofunify.playSong('Kate')
        sofunify.playSong('Kate')
        
          let result = sofunify.allSongs
          expect(result).to.be.eql({});
         });

         it("Rate artist who is not included", function() {
            // softUniFy.rateArtist('Eminem')
            softUniFy.downloadSong('Eminem', 'Kate', 'KateLyrics')
             let result = softUniFy.songsList
             expect(result).to.be.eql('Kate - KateLyrics');
            });

            it("Rate artist who is not included", function() {
                // softUniFy.rateArtist('Eminem')
                softUniFy.downloadSong('Eminem', 'Kate', 'Kate')
                softUniFy.downloadSong('Eminem', 'Kate', 'Kate')
                softUniFy.downloadSong('Eminem', 'Kate', 'Kate')
                 let result = softUniFy.rateArtist('Eminem',50)
                 expect(result).to.be.eql(50);
                });

                it("Rate artist who is not included", function() {
                    // softUniFy.rateArtist('Eminem')
                   //softUniFy.downloadSong('Eminem', 'Kate', 'Kate')
                     let result = softUniFy.songsList
                     expect(result).to.be.eql('Your song list is empty');
                    }); 
                    it("Rate artist who is not included", function() {
                        softUniFy.downloadSong('Eminem', 'Kate', 'Kate')
                        let result =sofunify.playSong('Kate')
                        expect(result).to.be.eql('You have not downloaded a Kate song yet. Use SoftUniFy\'s function downloadSong() to change that!');
                        });
                        it("Rate artist who is not included", function() {
                            // softUniFy.rateArtist('Eminem')
                            softUniFy.downloadSong('Eminem', '1', '1ly')
                            softUniFy.downloadSong('Eminem', '2', '2ly')
                             let result = softUniFy.playSong('2')
                             expect(result).to.be.eql('Eminem:\n2 - 2ly\n');
                            });
                
 });