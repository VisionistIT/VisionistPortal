// Agency Theme JavaScript

(function($) {
    "use strict"; // Start of use strict

    // jQuery for page scrolling feature - requires jQuery Easing plugin
    $('a.page-scroll').bind('click', function(event) {
        var $anchor = $(this);
        $('html, body').stop().animate({
            scrollTop: ($($anchor.attr('href')).offset().top - 50)
        }, 1250, 'easeInOutExpo');
        event.preventDefault();
    });

    // Highlight the top nav as scrolling occurs
    $('body').scrollspy({
        target: '.navbar-fixed-top',
        offset: 51
    });

    // Closes the Responsive Menu on Menu Item Click
    $('.navbar-collapse ul li a').click(function(){ 
            $('.navbar-toggle:visible').click();
    });

    // Offset for Main Navigation
    $('#mainNav').affix({
        offset: {
            top: 100
        }
    })

    $(".img-responsive").hover(
    function () {
        var src = $(this).attr("src");
        $(this).attr("src", src.replace(/\.png$/i, ".gif"));
    },
    function () {
        var src = $(this).attr("src");
        $(this).attr("src", src.replace(/\.gif$/i, ".png"));
    });
    var canvasHeight = $(window).height();
    var floatingBanners = $("#floating-banner");
    var imageHeight = floatingBanners.height();
    
    var imageY = floatingBanners.offset().top;
    var lowerBound = imageY + 3;//canvasHeight - imageHeight;
    var higherBound = imageY - 3//canvasHeight - imageHeight;
    var duration = 1500;

    function bannerMoveDown() {
        $("#floating-banner").animate({ top: lowerBound }, duration, 'linear', bannerMoveUp);
    }
    function bannerMoveUp() {
        $("#floating-banner").animate({ top: higherBound }, duration, 'linear', bannerMoveDown);
    }
    bannerMoveDown();
})(jQuery); // End of use strict
