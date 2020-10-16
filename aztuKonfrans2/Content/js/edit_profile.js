var form_submit = function (e) {

    var last_data = requiredJSON(false);
    var isValid = res_Valid;

    console.log(last_data);

    $('#formModal').modal('show');

    setTimeout(function () {
        $.ajax({
            url: '/User/EditProfile/',
            method: 'post',
            contentType: "application/json; charset=utf-8",
            cache: false,
            data: JSON.stringify(last_data),
            async: false,
            success: function (result) {
                if (result.res == "0") {
                    setTimeout(function () {
                        window.location.href = "/User/MyProfile";
                    }, 2000);

                    $('#formModal .formModalBody span').html(resources[22]);

                }
            }
        })
    }, 500);

    e.preventDefault();
    e.stopImmediatePropagation();

    return false;

};

$('.form-submit a').bind("click", form_submit);