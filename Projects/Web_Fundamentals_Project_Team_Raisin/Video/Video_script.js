
$(document).ready(function () {
    var show; // current video on the screen
    var temp; // video for hidding
    var count = 1;
    var frame = '#frame'
    var temp_old = '';
    var random;
    var videos = ["https://www.youtube.com/embed/GofPvMpQ5cQ",
        "https://www.youtube.com/embed/txQEmxcjBL0",
        "https://www.youtube.com/embed/wTI4_yXEJuo",
        "https://www.youtube.com/embed/CJOU_riuZ-4",
        "https://www.youtube.com/embed/MZrdrfdAl44",
        "https://www.youtube.com/embed/Z_S2uRjLZ14",
		"https://www.youtube.com/embed/n5WSlt1yyMU"];



    function random_generator() {

        random = Math.round(Math.random() * Math.floor(6));
        return random;

    }




    // overlay allow to click on the frame without directly start the video(cheat). 
    $('.overlay').on('click', function () {
        clearInterval(refreshIntervalId);
        //$(show).css('width', '800px');
        //$(show + ' iframe').css('width', '800px');
        //$(show).css('height', '600px');
        //$(show + ' iframe').css('height', '600px');
        $('.overlay').css('display', 'none');
        //$('#video_frame').css('width', '800px');
        //$('#video_frame').css('height', '660px');
    });


    // Looping every 10sec and showing next video frame until click on some frame (overlay).
    var refreshIntervalId = setInterval(function () {
        

        $('#frame').attr('src', videos[count]);

        if (count == 7) {
            count = 1;
        }
       
        count++;
    }, 10000);



    //on click (слуяайно Видео) activate function
    $('#random_slide').on('click', function () {
        var get = random_generator();
        




        console.log(get);
        $('.overlay').css('display', 'block');
        $('#frame').attr('src', videos[get]);


        clearInterval(refreshIntervalId);
    });


    //on click (Предишно Видео) activate function to go video frames step by step by the user
    $('#left_slide').on('click', function () {
        $('.overlay').css('display', 'block');
        $('#frame').attr('src', videos[count]);
        if (count == 5) {
            count = 0;
        } else {
            count++;
        }
        clearInterval(refreshIntervalId);
    });



    //on click (Следващо Видео) activate function to go video frames step by step by the user
    $('#right_slaid').on('click', function () {


        $('.overlay').css('display', 'block'); // activate the overlay
        $('#frame').attr('src', videos[count]);
        if (count == -1) {
            count = 5;
        } else {
            count--;
        }
        if (count == -1) {
            count = 5;
        }
        clearInterval(refreshIntervalId);
    });

});