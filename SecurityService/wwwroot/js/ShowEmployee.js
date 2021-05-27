//declear global variable for load load
var currentLocation = 0;
var skip = 0;

// lazy load employee
$(document).ready(function () {
    //load swiper 
    const swiper = document.querySelector('.swiper-container3').swiper;
  
    var imagePath = "";
   //load first data   
    $.ajax({
        type: "GET",
        url: "http://localhost:8085/api/employees/" + skip,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {          
            $.each(data, function (y, item) {
                $.ajax({
                    type: "GET",
                    url: "http://localhost:8085/api/images/Search/" + item.id,
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (dataImage) {
                        $.each(dataImage, function (y, itemImage) {
                            imagePath = itemImage.path
                            
                        })
                    },
                    async: false 
                })

                data = '<div class="swiper-slide swiper-slide3">'
                    + '<div class="emp-detail">'
                    + '<div class="img-emp">'
                    + '<img src="' + imagePath + '"/>'
                    + '</div>'
                    + '<div class="emp-content">'
                    + '<h3>' + item.name + '</h3>'
                    + '<h5>' + item.role + ' </h5>'
                    + '<a href="../Contact/Index" class="myBtn"> Contact Us</a>'
                    + '</div>'
                    + '</div>'
                    + '</div>'
                swiper.appendSlide(data)
                swiper.update();
                swiper.updateSlides()	


            })
            skip++;
        }
    });
    //load if auto swipe
    swiper.on('slideNextTransitionStart', function () {
        currentLocation++;
        if (currentLocation % 2 == 0) {
            skip++;

            $.ajax({
                type: "GET",
                url: "http://localhost:8085/api/employees/" + skip,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    $.each(data, function (y, item) {
                        $.ajax({
                            type: "GET",
                            url: "http://localhost:8085/api/images/Search/" + item.id,
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            success: function (dataImage) {
                                $.each(dataImage, function (y, itemImage) {
                                    imagePath = itemImage.path

                                })
                            },
                            async: false
                        })
                        console.log(imagePath)

                        data = '<div class="swiper-slide swiper-slide3">'
                            + '<div class="emp-detail">'
                            + '<div class="img-emp">'
                            + '<img src="' + imagePath + '"/>'
                            + '</div>'
                            + '<div class="emp-content">'
                            + '<h3>' + item.name + '</h3>'
                            + '<h5>' + item.role + ' </h5>'
                            + '<a href="../Contact/Index" class="myBtn"> Contact Us</a>'
                            + '</div>'
                            + '</div>'
                            + '</div>'
                        swiper.appendSlide(data)
                        swiper.updateSlides()


                    })
                    skip++;
                }
            });

        }
    });
    //load if click next button
    $(".swiper-button-next").click(function () {
        currentLocation++;
        if (currentLocation % 2 == 0) {
            skip++;

            $.ajax({
                type: "GET",
                url: "http://localhost:8085/api/employees/" + skip,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    $.each(data, function (y, item) {
                        $.ajax({
                            type: "GET",
                            url: "http://localhost:8085/api/images/Search/" + item.id,
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            success: function (dataImage) {
                                $.each(dataImage, function (y, itemImage) {
                                    imagePath = itemImage.path

                                })
                            },
                            async: false
                        })
                        console.log(imagePath)

                        data = '<div class="swiper-slide swiper-slide3">'
                            + '<div class="emp-detail">'
                            + '<div class="img-emp">'
                            + '<img src="' + imagePath + '"/>'
                            + '</div>'
                            + '<div class="emp-content">'
                            + '<h3>' + item.name + '</h3>'
                            + '<h5>' + item.role + ' </h5>'
                            + '<a href="../Contact/Index" class="myBtn"> Contact Us</a>'
                            + '</div>'
                            + '</div>'
                            + '</div>'
                        swiper.appendSlide(data)
                        swiper.updateSlides()


                    })
                    skip++;
                }
            });
            
        }
    })

   
})

