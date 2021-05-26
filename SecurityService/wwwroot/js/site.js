// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.


// Write your JavaScript code.

var swiper = new Swiper('.swiper-container1', {
    observer: true,
    observeParents: true,
    direction: 'vertical',
    spaceBetween: 5,
    effect: 'fade',
    centeredSlides: true,

    autoplay: {
        delay: 3000,
        disableOnInteraction: false,
    },
    pagination: {
        el: '.swiper-pagination1',
        clickable: true,
    },

});

function dmm() {
    var mySwiper = new Swiper(".swiper-container2", {
        observer: true,
        observeParents: true,
        effect: "coverflow",
        grabCursor: true,
        centeredSlides: true,
        slidesPerView: "auto",
        coverflowEffect: {
            rotate: 50,
            stretch: 0,
            depth: 100,
            modifier: 1,
            slideShadows: true,
        },
        autoplay: {
            delay: 4000,
            disableOnInteraction: false,
        },
        pagination: {
            el: '.swiper-pagination2',
            clickable: true,
        },
        navigation: {
            nextEl: '.swiper-button-next',
            prevEl: '.swiper-button-prev',
        },

    });
}

var swiper3 = new Swiper('.swiper-container3', {
    observer: true,
    observeParents: true,
    slidesPerView: 3,
    autoplay: {
        delay: 3000,
        disableOnInteraction: false,
    },
    navigation: {
        nextEl: '.swiper-button-next',
        prevEl: '.swiper-button-prev',
    },
    // Responsive breakpoints
    breakpoints: {
        // when window width is <= 480px
        480: {
            slidesPerView: 1,
        },
        // when window width is <= 640px
        768: {
            slidesPerView: 2,

        },

        1024: {
            slidesPerView: 3,
        },
    }

});


// search function

$(document).ready(function () {
    var myNav = document.getElementById("myNav");
    var searchAround = document.getElementById("searchAround");

    $('#search').click(function () {
        $('.myNav-item').addClass('hide-item');
        $('.search-form').addClass('active');
        $('.close').addClass('active');
        $('#search').hide();
        $('.search-dropdown').addClass('active');
        myNav.style.backgroundColor = "rgba(0,0,0,1)";
        searchAround.style.display = "block";
        document.body.style.overflow = "hidden";



    })
    $('.close').click(function () {
        $('.myNav-item').removeClass('hide-item');
        $('.search-form').removeClass('active');
        $('.close').removeClass('active');
        $('.search-dropdown').removeClass('active');
        $('#search').show();
        myNav.style.removeProperty("background-color");
        searchAround.style.display = "none";
        document.body.style.removeProperty("overflow");

    })
})


// navigation sticky

window.onscroll = function () { myFunction() };

var header = document.getElementById("myNav");

var sticky = header.offsetTop;

function myFunction() {
    if (window.pageYOffset > sticky) {
        header.classList.add("sticky");
    } else {
        header.classList.remove("sticky");

    }
};


//hamberger menu

$(document).ready(function () {
    var myNav_list = document.getElementById('myNav-list');
    var myNav = document.getElementById('myNav');
    var navIcon = document.getElementById('nav-icon');
    $('#menu-btn').click(function () {
        if ($(this).prop("checked") == true) {
            myNav_list.classList.add("active");
            myNav.classList.add("active");
            document.body.style.overflow = "hidden";
            navIcon.classList.add("active");
        } else {
            myNav_list.classList.remove("active");
            myNav.classList.remove("active");
            document.body.style.removeProperty("overflow");
            navIcon.classList.remove("active");

        }
    })
})

// fade in when sroll down

$(window).on("load", function () {
    $(window).scroll(function () {
        var windowBottom = $(this).scrollTop() + $(this).innerHeight();
        $(".fade").each(function () {
            /* Check the location of each desired element */
            var objectBottom = $(this).offset().top + $(this).outerHeight();

            /* If the element is completely within bounds of the window, fade it in */
            if (objectBottom < windowBottom) { //object comes into view (scrolling down)

                if ($(this).css("opacity") == 0) { $(this).fadeTo(100, 1, "linear"); }
            }
        });
    }).scroll(); //invoke scroll-handler on page-load
});

