// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {

   
$(window).on('load', function () {
    $('.preloader').delay(4000).fadeOut('slow');
    $('.center').delay(5000).fadeOut('slow');
}); 

$("#btnFullPro").click(function () {

    $('html, body').animate({
        scrollTop: $("#Divpro").offset().top -70
    }, 2000);
    //$("#backtotop").show();
});

$("#backtotop").click(function () {
    $('html, body').animate({
        scrollTop: $("#btnFullPro").offset().top - 70
    }, 2000);
    //$("#backtotop").hide();
    });

});