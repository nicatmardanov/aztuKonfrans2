
$(document).ready(function () {

    $(document).on("click", ".all_users_list li a", function (e) {
        var id = parseInt($(this).data('id'))
        var info_id = parseInt($('.approve_user a').data('id'))
        if (id != info_id) {
            $.ajax({
                url: '/User/UserInfo/' + id,
                method: 'get',
                contentType: "application/json; charset=utf-8",
                async: false,
                success: function (result) {
                    $('#user_info_apr').html('');
                    $('#user_info_apr').append(result);
                }
            });
        }

        e.preventDefault();
        e.stopImmediatePropagation();

        return false;
    });
    $(document).on("click", ".approve_user a", function (e) {
        var k = $(this);
        var id = parseInt($(k).data('id'));

        $.ajax({
            url: '/User/ApproveUser/' + id,
            method: 'get',
            contentType: "application/json; charset=utf-8",
            async: false,
            success: function (result) {
                $('.dactivate_user').html('');
                $('.dactivate_user').append(result);
            }
        });

        e.preventDefault();
        e.stopImmediatePropagation();

        return false;
    });

    $(document).on("click", ".disable_user_section a", function (e) {
        var k = $(this);
        var id = parseInt($(k).data('id'));

        $.ajax({
            url: '/User/DeactiveUser/' + id,
            method: 'get',
            contentType: "application/json; charset=utf-8",
            async: false,
            success: function (result) {
                $('.dactivate_user').html('');
                $('.dactivate_user').append(result);
            }
        });

        e.preventDefault();
        e.stopImmediatePropagation();

        return false;
    })



    $(document).on("click", ".make_admin_user a", function (e) {
        var id = $(this).data('id');
        var k = $(this).parent();
        var z = $(this);
        var h = resources[10];
        $.ajax({
            url: '/User/ChangeRole?id=' + id + '&type=1',
            method: 'get',
            contentType: "application/json; charset=utf-8",
            async: false,
            cache: false,
            success: function (result) {
                $(k).addClass('remove_admin_user');
                $(k).removeClass('make_admin_user');
                z.html(h);
            }
        });

        e.preventDefault();
        e.stopImmediatePropagation();
        return false;
    });

    $(document).on("click", ".remove_admin_user a", function (e) {
        var id = $(this).data('id');
        var k = $(this).parent();
        var z = $(this);
        var h = resources[11];
        $.ajax({
            url: '/User/ChangeRole?id=' + id + '&type=0',
            method: 'get',
            contentType: "application/json; charset=utf-8",
            async: false,
            cache: false,
            processData:false,
            success: function (result) {
                $(k).addClass('make_admin_user');
                $(k).removeClass('remove_admin_user');
                z.html(h);
            }
        });

        e.preventDefault();
        e.stopImmediatePropagation();
        return false;
    });

});



