/* JS Document */

/******************************

[Table of Contents]

1. Vars and Inits
2. IE Check
3. Set Header
4. Init Search
5. Init Menu


******************************/

$(document).ready(function () {
    "use strict";

    /* 

    1. Vars and Inits

    */

    var menu = $('.menu');
    var menuActive = false;
    var header = $('.header');

    // setHeader();

    $(window).on('resize', function () {
        // setHeader();
    });

    $(document).on('scroll', function () {
        // setHeader();
    });

    // setHeader();
    initSearch();
    initMenu();

    /* 

    2. IE Check

    */


    /* 

    3. Set Header

    */

    // function setHeader() {
    //     if ($(window).scrollTop() > 0) {
    //         header.addClass('scrolled');
    //     } else {
    //         header.removeClass('scrolled');
    //     }
    // }

    /* 

    3. Init Search

    */

    function initSearch() {
        if ($('.header_search').length) {
            var search = $('.header_search');
            var panel = $('.search_container');
            search.on('click', function () {
                panel.toggleClass('active');
            });
        }
    }

    /* 

    4. Init Menu

    */

    function initMenu() {
        if ($('.hamburger').length && $('.menu').length) {
            var hamb = $('.hamburger');
            var close = $('.menu_close_container');

            hamb.on('click', function () {
                if (!menuActive) {
                    openMenu();
                } else {
                    closeMenu();
                }
            });

            close.on('click', function () {
                if (!menuActive) {
                    openMenu();
                } else {
                    closeMenu();
                }
            });


        }
    }

    function openMenu() {
        menu.addClass('active');
        menuActive = true;
    }

    function closeMenu() {
        menu.removeClass('active');
        menuActive = false;
    }

    var k = 0;

    $('.modalForgot').click(function () {
        var id = k % 2;
        if (id == 0) {
            modalLoginSlide(resources[20], 'modal-forgot-password', 'modalBackLogin', 'modalForgot', resources[17]);
        } else if (id == 1) {
            modalLoginSlide(resources[17], 'modal-sign-in', 'modalForgot', 'modalBackLogin', '<a href="javascript:void(0)" class="modal_log_button">' + resources[18] + ' | </a><a href="/Registration" class="modal_reg_button">' + resources[19] + '</a>');
        }
        k++;
    });

    $('#loginModal').on('hidden.bs.modal', function () {
        $('#loginModal .modal-body input').val("");
        $('#loginModal .invalid-feedback').remove();
        $('#loginModal .text-danger').remove();
        $('body').removeAttr('style');


        if (k % 2 == 1) {
            $('.modalForgot').click();
        }


    })



    function modalLoginSlide(buttonText, showedClass, addedClass, removedClass, modal_header_text) {
        $('.modalSlider').animate({
            opacity: 0
        }, {
            duration: 500,
            complete: function () {
                $('.modalSlider').hide();
                $('.' + showedClass).show(); //
                $('.modalForgotButton').html(buttonText); //
                $('#loginModal .modal-header span').html(modal_header_text);

                $('.modal-footer>div').addClass(addedClass); //

                $('.' + showedClass).animate({ //
                    opacity: 1
                }, {
                    duration: 500,
                    complete: function () {
                        $(this).removeClass(removedClass); //
                    }
                })

            }
        })
    }

});


$('#formModal').on('hidden.bs.modal', function (e) {
    $('#formModal .formModalBody>span').html(resources[16]);
})




$('#loginModal .modal-sign-in .form-submit a').bind('click', function (e) {

    var isValid = check_login('.modal-sign-in', resources[0], resources[1], '#loginEmail', '#loginPassword');

    if (isValid) {
        var data = {
            email: $('#loginEmail').val(),
            password: $('#loginPassword').val()
        };

        $('#formModal').modal('show');

        $('#loginModal').hide();

        setTimeout(function () {
            $.ajax({
                url: '/Login/Index',
                method: 'post',
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify(data),
                async: false,
                success: function (result) {

                    $('#formModal').modal('hide');
                    $('body').addClass('modal-open');
                    $('body').css('padding-right', '17px');


                    if (result.res == "0") {
                        $('#loginModal').show();
                        $('#loginModal #loginEmail').val(data.email);
                        $('#loginModal #loginPassword').val(data.password);
                        $("<div class='text-danger'>" + resources[2] + "</div>").insertBefore('#loginModal .modal-sign-in>form .form-submit');
                    } else {
                        window.location.reload();
                    }

                }
            })
        }, 500)
    }


    e.preventDefault();
    e.stopImmediatePropagation();
    return false;

});


function check_login(mainClass, text1, text2, ch1, ch2) {
    var isValid = true;

    $(mainClass + '>form .invalid-feedback').remove();
    $(mainClass + '>form .text-danger').remove();

    if ($(ch1).val() == "" || !validateEmail($(ch1).val())) {
        $($(ch1).parent().parent()).append('<div class="invalid-feedback">' + text1 + '</div>');
        isValid = false;
    }

    if (ch2 == '#forgot_number') {
        if ($(ch2).val() == "" || !checkNumber($(ch2))) {
            $($(ch2).parent().parent()).append('<div class="invalid-feedback">' + text2 + '</div>');
            isValid = false;
        }
    } else {
        if ($(ch2).val() == "") {
            $($(ch2).parent().parent()).append('<div class="invalid-feedback">' + text2 + '</div>');
            isValid = false;
        }

    }

    return isValid;
}


$('#loginModal .modal-forgot-password .form-submit a').bind('click', function (e) {
    var isValid = check_login('.modal-forgot-password', resources[0], resources[14], '#forgot_email', '#forgot_number');

    if (isValid) {
        var data = {
            email: $('#forgot_email').val(),
            phone: $('#forgot_number').val()
        };

        $('#formModal').modal('show');

        $('#loginModal').hide();

        setTimeout(function () {
            $.ajax({
                url: '/Login/Forgot',
                method: 'post',
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify(data),
                async: false,
                success: function (result) {

                    if (result.res == "1") {
                        $('#formModal .formModalBody>span').html(resources[15]);
                        setTimeout(function () {
                            $('#formModal').modal('hide');
                            $('#loginModal').modal('hide');
                        }, 1500);
                    } else {
                        $('#formModal').modal('hide');
                        $('body').addClass('modal-open');
                        $('body').css('padding-right', '17px');

                        $('#loginModal').show();
                        $('#loginModal #loginEmail').val(data.email);
                        $('#loginModal #loginPassword').val(data.password);

                        if (result.res == "0") {
                            $("<div class='text-danger'>" + resources[2] + "</div>").insertBefore('#loginModal .modal-forgot-password>form .form-submit')
                        }
                    }



                }
            })
        }, 500);
    }


    e.preventDefault();
    e.stopImmediatePropagation();
    return false;

})


$('#loginEmail').keyup(function (event) {
    if (event.keyCode === 13) {
        $("#loginModal .modal-sign-in .form-submit a").click();
    }
});

$('#loginPassword').keyup(function (event) {
    if (event.keyCode === 13) {
        $("#loginModal .modal-sign-in .form-submit a").click();
    }
});

$('#forgot_email').keyup(function (event) {
    if (event.keyCode === 13) {
        $("#loginModal .modal-forgot-password .form-submit a").click();
    }
});

$('#forgot_number').keyup(function (event) {
    if (event.keyCode === 13) {
        $("#loginModal .modal-forgot-password .form-submit a").click();
    }
});

function numberFunction(k) {
    var a = k.val();
    if (a.length > 0)
        var b = a[a.length - 1].charCodeAt();

    if (a.length == 1 && !(b == 43 || b == 48)) {
        k.val(k.val().split(k.val()[a.length - 1])[0]);
    } else if (a.length > 1 && !(b >= 48 && b <= 57)) {
        k.val(k.val().split(k.val()[a.length - 1])[0]);
    }
}

function checkNumber(k) {
    var a = k.val();
    if (a.length > 1) {
        var b;
        for (var i = 0; i < a.length; i++) {
            b = a[i].charCodeAt();
            if (i == 0 && !(b == 43 || b == 48)) {
                return false;
            } else if (i > 0 && !(b >= 48 && b <= 57)) {
                return false;
            }
        }

        return true;
    }
    return false;
}

function validateEmail(email) {
    var re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(String(email).toLowerCase());
}
$(document).on("input", "input[type='tel']", function (e) {
    numberFunction($(this));
});
//$('#profile_papers .profile_paper_delete').bind("click", function (e) {
//    var id = $(this).data('id');
//    $('#deleteModal .delete_button>a').attr('href', '/Paper/Delete/' + id);
//    $('#deleteModal').modal('show');

//    e.preventDefault();
//    e.stopImmediatePropagation();
//    return false;
//});

//$('#deleteModal .cancel_delete_modal').bind("click", function (e) {

//    $('#deleteModal').modal('hide');

//    e.preventDefault();
//    e.stopImmediatePropagation();
//    return false;
//})