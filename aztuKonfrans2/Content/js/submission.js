$(document).ready(function () {
    aj = null;
    auth_counter = 0;
    edit_arr = [];

    //anotherAuthor = $('#another_author').html();
    //$('#another_author').remove();

    //alert(page_type);

    //if (page_type == 0) {

    //    for (var i = 0; i < $('.another_author_information').length; i++) {
    //        edit_arr[i] = $($($('.another_author_information')[i]).find('.hidden_inp')).val();
    //    }
    //}


    $('.add_author').bind("click", function (e) {
        var add_att_val = 0;
        var l_anotherAuthor;
        $.ajax({
            url: '/Paper/NewAuthor/',
            method: 'get',
            contentType: "application/json; charset=utf-8",
            async: false,
            cache: false,
            processData: false,
            success: function (result) {
                l_anotherAuthor = $(result);
                l_anotherAuthor.show();

                if (auth_counter == 0)
                    add_att_val = "";
                else
                    add_att_val = auth_counter;

                //var parentDiv = $('<div class="another_author_information sub_section"></div>');
                //$(parentDiv).insertBefore('.sub_add_author');
                //$(parentDiv).append(l_anotherAuthor);

                $(l_anotherAuthor).insertBefore('.sub_add_author');

                for (var i = 0; i < $(l_anotherAuthor).find('.form-group').length; i++) {
                    var att_val = $($(l_anotherAuthor).find('.form-group')[i]).find('label').attr('for') + add_att_val;

                    if ($($($(l_anotherAuthor).find('.form-group')[i]).find('input')).length > 0)
                        $($($(l_anotherAuthor).find('.form-group')[i]).find('input')).attr('id', att_val);
                    else
                        $($($(l_anotherAuthor).find('.form-group')[i]).find('select')).attr('id', att_val);

                    $($($(l_anotherAuthor).find('.form-group')[i]).find('label')).attr('for', att_val);
                }
                auth_counter++;
            }

        })

        e.preventDefault();
        e.stopImmediatePropagation();

        return false;

    });

    $(document).on('click', '.remove_author', function () {
        //if (page_type == 0) {
        //    var index_remove = edit_arr.indexOf($($($(this).parent().parent()).find('.hidden_inp')).val());
        //    edit_arr[index_remove] *= -1;
        //    console.log(edit_arr);
        //}

        $($(this).parent().parent()).remove();
    });

    $(document).on('change', '#paperFile', function () {
        var filename = $(this).val().replace(/C:\\fakepath\\/i, '');
        $('.full_paper_file label').html(filename);
    })

});

var form_submit = function (e) {
    var isValid = true;
    $('.invalid-feedback.col-sm-12').remove();


    for (var i = 0; i < $('.submission_form form input').length; i++) {
        if ($($('.submission_form form input')[i]).attr('required') != undefined) {
            if ($($('.submission_form form input')[i]).val() == "") {
                $($($('.submission_form form input')[i]).parent()).append('<div class="invalid-feedback col-sm-12">' + resources[6] + '</div>');
                isValid = false;
            }
            if ($($('.submission_form form input')[i]).attr('type') == 'email' && !validateEmail($($('.submission_form form input')[i]).val())) {
                $($($('.submission_form form input')[i]).parent()).append('<div class="invalid-feedback col-sm-12">' + resources[6] + '</div>');
                isValid = false;
            }

            else if ($($('.submission_form form input')[i]).attr('type') == 'tel' && !checkNumber($($('.submission_form form input')[i]))) {
                $($($('.submission_form form input')[i]).parent()).append('<div class="invalid-feedback col-sm-12">' + resources[6] + '</div>');
                isValid = false;
            }

        }

    }

    var authorsFullName = [], authorsTitle = [], authorsDegree = [], authorsCountry = [], authorsEmail = [], authorsPhone = [], authorsInstitution = [], authorsPosition = [];

    for (var i = 0; i < $('.newAuthorFullName').length; i++) {
        authorsFullName[i] = $($('.newAuthorFullName')[i]).val();
        authorsTitle[i] = $($('.newAuthorTitle')[i]).val();
        authorsDegree[i] = $($('.newAuthorDegree')[i]).val();
        authorsCountry[i] = $($('.newAuthorCountry')[i]).val();
        authorsEmail[i] = $($('.newAuthorEmail')[i]).val();
        authorsPhone[i] = $($('.newAuthorPhone')[i]).val();
        authorsInstitution[i] = $($('.newAuthorInstituion')[i]).val();
        authorsPosition[i] = $($('.newAuthorPosition')[i]).val();
    }



    if (isValid) {

        //data.title = $('#inputTitlePaper').val();
        //data.topic_id = $('#usr_sd').val();

        var form_data = new FormData();

        form_data.append("title", $('#inputTitlePaper').val());
        form_data.append("topic_id", $('#usr_sd').val());
        $.each(authorsFullName, function (index, item) {
            form_data.append('authorsFullName', item);
        });
        $.each(authorsTitle, function (index, item) {
            form_data.append('authorsTitle', item);
        });
        $.each(authorsDegree, function (index, item) {
            form_data.append('authorsDegree', item);
        });
        $.each(authorsCountry, function (index, item) {
            form_data.append('authorsCountry', item);
        });
        $.each(authorsEmail, function (index, item) {
            form_data.append('authorsEmail', item);
        });
        $.each(authorsPhone, function (index, item) {
            form_data.append('authorsPhone', item);
        });
        $.each(authorsInstitution, function (index, item) {
            form_data.append('authorsInstitution', item);
        });
        $.each(authorsPosition, function (index, item) {
            form_data.append('authorsPosition', item);
        });

        //if (page_type == 1) {
        form_data.append($("#paperFile")[0].files[0].name, $("#paperFile")[0].files[0]);
        //}
        //else {
        //    if ($('#paperFile').get(0).files.length === 1)
        //        form_data.append($("#paperFile")[0].files[0].name, $("#paperFile")[0].files[0]);
        //    else
        //        form_data.append('fileHave', 0);

        //}

        $('#formModal').modal('show');
        $('#formModal .formModalBody').append('<div class="row new_fmb_row"><div class="col-12"><span>' + resources[21] + ': <span></span></span></div></div>');

        var url = "";
        if (page_type == 0) {
            url = '/Paper/Edit/';
            form_data.append('paper_id', pl);

            $.each(edit_arr, function (index, item) {
                form_data.append('edit_arr', item);
            });
        }
        else
            url = '/Paper/AddPaper/';


        setTimeout(function () {
            aj = $.ajax({
                url: url,
                method: 'post',
                contentType: false,
                processData: false,
                data: form_data,
                cache: false,
                xhr: function () {
                    var xhr = new window.XMLHttpRequest();
                    xhr.upload.addEventListener("progress", function (evt) {
                        console.log(evt.loaded);
                        if (evt.lengthComputable) {
                            var prcComplete = evt.loaded / evt.total;
                            prcComplete = parseInt(prcComplete * 100);
                            $('#formModal .new_fmb_row>.col-12>span>span').html(prcComplete + '%');
                        }
                    }, false);
                    return xhr;
                },
                success: function (result) {
                    $('.new_fmb_row').remove();
                    setTimeout(function () {
                        window.location.href = "/User/MyProfile";
                    }, 2000);
                    //if (page_type == 1)
                    $('#formModal .formModalBody .formModalBody_after_text').html(resources[13]);
                    //else
                    //$('#formModal .formModalBody .formModalBody_after_text').html(resources[22]);

                }
            })
        }, 500)

    }




    e.preventDefault();
    e.stopImmediatePropagation();

    return false;
}

$('#submit_form_button').bind("click", form_submit);

$('#formModal').on('hidden.bs.modal', function () {
    aj.abort();
    $('.new_fmb_row').remove();
});