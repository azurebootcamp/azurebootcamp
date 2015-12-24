/*!
 * Start Bootstrap - Grayscale Bootstrap Theme (http://startbootstrap.com)
 * Code licensed under the Apache License v2.0.
 * For details, see http://www.apache.org/licenses/LICENSE-2.0.
 */

$(function () {

    $("#CountDownTimer").TimeCircles({
        "bg_width": 0.5,
        "fg_width": 0.03666666666666667,
        "circle_bg_color": "#90989F",
        count_past_zero: false
    })
     .addListener(function (unit, value, total) {
         total = Math.abs(total);
         if (total == 0) {
             $("#CountDownTimer").hide();
             $('#divTimer').hide();
             $('.intro-body').addClass('azurelogo');
         }
     }, "all");
});