res_Valid = null;
function requiredJSON(isReg) {
    var isValid = true;
    $('.invalid-feedback.col-sm-12').remove();

    for (var i = 0; i < $('.reg_form>form input').length; i++) {
        if ($($('.reg_form>form input')[i]).attr('required') != undefined) {
            if ($($('.reg_form>form input')[i]).val() == "") {
                $($($('.reg_form>form input')[i]).parent().parent()).append('<div class="invalid-feedback col-sm-12">' + resources[6] + '</div>');
                isValid = false;
            }

            if ($($('.reg_form>form input')[i]).attr('type') == 'email' && !validateEmail($($('.reg_form>form input')[i]).val())) {
                $($($('.reg_form>form input')[i]).parent().parent()).append('<div class="invalid-feedback col-sm-12">' + resources[6] + '</div>');
                isValid = false;
            }

            else if ($($('.reg_form>form input')[i]).attr('type') == 'tel' && !checkNumber($($('.reg_form>form input')[i]))) {
                $($($('.reg_form>form input')[i]).parent().parent()).append('<div class="invalid-feedback col-sm-12">' + resources[6] + '</div>');
                isValid = false;
            }

        }
    }

    if (isReg && ($('#password').val() != $('#repassword').val() && $('#password').val().length > 0 && $('#repassword').val().length > 0)) {
        if (isValid)
            isValid = false;

        if ($($($('#repassword').parent().parent()).find('.invalid-feedback')).length > 0)
            $($($('#repassword').parent().parent()).find('.invalid-feedback')).html(resources[7]);
        else
            $($($('#repassword').parent().parent())).append('<div class="invalid-feedback col-sm-12">' + resources[7] + '</div>')
    }


    res_Valid = isValid;

    var last_data = {};
    last_data.first_name = $('#name').val();
    last_data.middle_name = $('#middleName').val();
    last_data.last_name = $('#lastName').val();
    last_data.phone = $('#usr_tn').val();
    last_data.country_id = $('#country').val();
    last_data.title_id = $('#usr_ap').val();
    last_data.degree_id = $('#usr_sdg').val();
    last_data.institution = $('#usr_ni').val();
    last_data.topic_id = $('#usr_sd').val();
    last_data.position = $('#usr_position').val();

    if (isReg) {
        last_data.email = $('#email').val();
        last_data.password = $('#password').val();
    }

    return last_data;
}

