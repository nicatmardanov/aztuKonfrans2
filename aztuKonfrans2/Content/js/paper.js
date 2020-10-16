$(document).on("click", ".paper_approve>a", function (e) {
    var k = $(this).parent();
    var id = $(this).data('id');
    $.ajax({
        url: '/Paper/Paper_Approve/' + id,
        method: 'get',
        contentType: "application/json; charset=utf-8",
        async: false,
        success: function (result) {
            k.html('<a href="javascript:void(0)" data-id=' + id + '>' + resources[4] + '</a>');
            k.addClass('paper_disapprove');
            k.removeClass('paper_approve');
        }
    });

    e.preventDefault();
    e.stopImmediatePropagation();

    return false;
});



$(document).on("click", ".paper_disapprove>a", function (e) {
    var k = $(this).parent();
    var id = $(this).data('id');
    $.ajax({
        url: '/Paper/Paper_DApprove/' + id,
        method: 'get',
        contentType: "application/json; charset=utf-8",
        async: false,
        success: function (result) {
            k.html('<a href="javascript:void(0)" data-id=' + id + '>' + resources[5] + '</a>');
            k.addClass('paper_approve');
            k.removeClass('paper_disapprove');
        }
    });

    e.preventDefault();
    e.stopImmediatePropagation();

    return false;
});





