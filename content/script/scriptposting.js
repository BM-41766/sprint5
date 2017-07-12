$(document).ready(function () {
    $("#btnpost").click(function () {
        var status = $("#status").val();
        var loginid = $("#X_mainloginid").val();
        var id = parseInt(loginid);
        console.log($("#status").val())
        $.ajax({
            type: 'GET',
            dataType: 'Json',
            url: 'Home/postingstatus',
            data: { posting: status, loginid: loginid },
            success: function (data) {
                // var x = 0;
                //for (var x = 0; x < data[x].length; x++) {

                console.log("ID: " + data[0].loginid + " name: " + data[0].firstname + " picture: " + data[0].profilepic + "post" + data[0].postingstatus);
                var html = '<img src="' + data[0].profilepic + '"style="height:55px;width:30px;"/>' + '<label style="margin-top:-35px; margin-left:50px;">' + data[0].firstname + data[0].surname + '<br/><label>' + data[0].postingstatus + '</label><br/><hr>'
                $(".posting").append(html);
                $(".posting").show();

                //}
            }
        })
    })
});


