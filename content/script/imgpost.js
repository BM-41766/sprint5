$(document).on('click', '#btnpost1', function () {
    var status = $("#txt1").val();
   // alert(status);
    var loginid = $("#X_mainloginid").val();
   // alert(loginid);
    var id = parseInt(loginid);
    var img = $(".postimge").attr('src');
    //alert(img);
    // alert("dfghj");
    console.log($("#txt1").val())
    $.ajax({
        type: 'GET',
        dataType: 'Json',
        url: 'Home/postingimage',
        data: { postheder: status, postimg: img, logginid: loginid },
        success: function (data) {
            var x = 0;
           // for (var x = 0; x < data[x].length; x++) {
                console.log("ID: " + data[x].loginid + " name: " + data[x].firstname + " picture: " + data[x].profilepic + "postimg:" + data[x].postingimage + "postheader:" + data[x].postingheader);
                var html = '<img src="' + data[x].profilepic + '"style="height:55px;width:30px;"/>' + '<label style="margin-top:-35px; margin-left:50px;">' + data[x].firstname + data[x].surname + '<br/><br/><label>' + data[x].postingheader + '</label><img src="' + data[x].postingimage + '"style="height:75px;width:75px;"/><br/><hr>';
                $(".posting").append(html);
                $(".posting").show();
           // }
        }
    })
});
