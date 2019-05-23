/* Adapted from https://css-tricks.com/snippets/jquery/smooth-scrolling/
Since scroll-behaviour: smooth does not work on mobile, fun jquery solution. */
var headerHeight = $("div#header").height();
        // Select all links with hashes
        $('a[href*="#"]')
            // Remove links that don't actually link to anything
            .not('[href="#"]')
            .not('[href="#0"]')
            // .not('[href="/about.html]')
            .click(function(event) {
                // On-page links
                if (
                    location.pathname.replace(/^\//, '') == this.pathname.replace(/^\//, '') &&
                    location.hostname == this.hostname
                ) {
                    // Figure out element to scroll to
                    var target = $(this.hash);
                    target = target.length ? target : $('[name=' + this.hash.slice(1) + ']');
                    // Does a scroll target exist?
                    if (target.length) {
                        // Only prevent default if animation is actually gonna happen
                        event.preventDefault();
                        console.log($(window).scrollTop());
                        console.log(target.offset().top);
                        console.log(target.offset().bottom);
                        if ($(window).width() < 768) {
                            console.log($(window).width());
                            
                            if (target.offset().top != $(window).scrollTop()) {
                                $('html, body').animate({
                                    scrollTop: target.offset().top - 160
                                }, 1000, function() {
                                    // Callback after animation
                                    // Must change focus!
                                    var $target = $(target);
                                    $target.focus();
                                    if ($target.is(":focus")) { // Checking if the target was focused
                                        return false;
                                    } else {
                                        console.log("Got here");
                                        $target.attr('tabindex', '-1'); // Adding tabindex for elements not focusable
                                        $target.focus(); // Set focus again
                                    };
                                });
                            }
                            else {
                                $('html, body').animate({
                                    scrollTop: target.offset().top
                                }, 1000, function() {
                                    // Callback after animation
                                    // Must change focus!
                                    var $target = $(target);
                                    $target.focus();
                                    if ($target.is(":focus")) { // Checking if the target was focused
                                        return false;
                                    } else {
                                        console.log("Got here");
                                        $target.attr('tabindex', '-1'); // Adding tabindex for elements not focusable
                                        $target.focus(); // Set focus again
                                    };
                                });

                            }
                        } else {
                            console.log($(window).width());
                            $('html, body').animate({
                                scrollTop: target.offset().top
                            }, 1000, function() {
                                // Callback after animation
                                // Must change focus!
                                var $target = $(target);
                                $target.focus();
                                if ($target.is(":focus")) { // Checking if the target was focused
                                    return false;
                                } else {
                                    console.log("Got here");
                                    $target.attr('tabindex', '-1'); // Adding tabindex for elements not focusable
                                    $target.focus(); // Set focus again
                                };
                            });
                        }
                    }
                }
            });