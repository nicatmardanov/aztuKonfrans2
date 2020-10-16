$(document).ready(function (e) {


    $(document).on("click", ".paper_delete>a", function (e) {
        var k = $(this).parent();
        var id = $(this).data('id');

        $.ajax({
            url: '/Paper/RemovePaper/' + id,
            method: 'get',
            contentType: "application/json; charset=utf-8",
            success: function (result) {
                k.html('<a href="javascript:void(0)" data-id=' + id + '>' + resources[24] + '</a>');
                k.addClass('paper_undo');
                k.removeClass('paper_delete');
            }
        });

        e.preventDefault();
        e.stopImmediatePropagation();

        return false;
    });


    $(document).on("click", ".paper_undo>a", function (e) {
        var k = $(this).parent();
        var id = $(this).data('id');

        $.ajax({
            url: '/Paper/UndoPaper/' + id,
            method: 'get',
            contentType: "application/json; charset=utf-8",
            success: function (result) {
                k.html('<a href="javascript:void(0)" data-id=' + id + '>' + resources[23] + '</a>');
                k.addClass('paper_delete');
                k.removeClass('paper_undo');
            }
        });

        e.preventDefault();
        e.stopImmediatePropagation();

        return false;
    });
});