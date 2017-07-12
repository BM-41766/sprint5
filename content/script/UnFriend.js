$(document).on('click', '#Unfriendbtn', function () {
    //$(".frnd").empty();
    var reciverid1 = $("#X_mainloginid").val();
    var senderid1 = $(this).data("id");
    alert(senderid1);
    $.ajax({
        type: 'GET',
        dataType: 'Json',
        url: 'Home/unfriend',
        data: { reciverid: reciverid1, senderid: senderid1 },
        success: function (data) {
        }
    })
});