var form_submit = function (e) {

    var last_data = requiredJSON(true);
    var isValid = res_Valid;

    if (isValid && $('#password').val().length > 0 && $('#repassword').val().length > 0) {
        $('#formModal').modal('show');

        setTimeout(function () {
            $.ajax({
                url: '/Registration/Index/',
                method: 'post',
                contentType: "application/json; charset=utf-8",
                cache: false,
                data: JSON.stringify(last_data),
                async: false,
                success: function (result) {
                    if (result.res == "0") {
                        if ($($($('#email').parent().parent()).find('.invalid-feedback')).length > 0)
                            $($($('#email').parent().parent()).find('.invalid-feedback')).html(resources[8]);
                        else
                            $($($('#email').parent().parent())).append('<div class="invalid-feedback col-sm-12">' + resources[8] + '</div>')
                    }
                    else if (result.res == "1") {
                        if ($($($('#password').parent().parent()).find('.invalid-feedback')).length > 0)
                            $($($('#password').parent().parent()).find('.invalid-feedback')).html(resources[9]);
                        else
                            $($($('#password').parent().parent())).append('<div class="invalid-feedback col-sm-12">' + resources[9] + '</div>')
                    }
                    else {
                        setTimeout(function () {
                            window.location.href = "/";
                        }, 3000);

                        $('#formModal .formModalBody span').html(resources[12]);

                    }
                }
            })
        }, 500);
    }

    e.preventDefault();
    e.stopImmediatePropagation();

    return false;

};

$('.form-submit a').bind("click", form_submit);