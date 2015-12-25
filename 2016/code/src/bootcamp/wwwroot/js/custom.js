// jQuery to collapse the navbar on scroll
$(window).scroll(function () {
    if ($(".navbar").offset().top > 50) {
        $(".navbar-fixed-top").addClass("top-nav-collapse");
    } else {
        $(".navbar-fixed-top").removeClass("top-nav-collapse");
    }
});

// jQuery for page scrolling feature - requires jQuery Easing plugin
$(function () {
    $('a.page-scroll').bind('click', function (event) {
        var $anchor = $(this);
        $('html, body').stop().animate({
            scrollTop: $($anchor.attr('href')).offset().top
        }, 1500, 'easeInOutExpo');
        event.preventDefault();
    });
});

// Closes the Responsive Menu on Menu Item Click
$('.navbar-collapse ul li a').click(function () {
    $('.navbar-toggle:visible').click();
});

$(function () {
 
    var timerColor = $("#CountDownTimer").data('bgcolor'); 
    $("#CountDownTimer").TimeCircles({
        "bg_width": 0.5,
        "fg_width": 0.03666666666666667,
        "circle_bg_color": timerColor,
        count_past_zero: false
    })
     .addListener(function (unit, value, total) {
         total = Math.abs(total);
         if (total == 0) {
             $("#CountDownTimer").stop();
             $('#divTimer').text("");
         }
     }, "all");

    $('#CountDownTimer .time_circles .textDiv_Hours').css('color', timerColor);
    $('#CountDownTimer .time_circles .textDiv_Days').css('color', timerColor);
    $('#CountDownTimer .time_circles .textDiv_Minutes').css('color', timerColor);
    $('#CountDownTimer .time_circles .textDiv_Seconds').css('color', timerColor);

    $('.time_circles h4').css('color', timerColor);
});