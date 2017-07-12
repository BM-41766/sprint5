$(document).ready(function () {
    $("#lnkaddphoto").click(function () {
        var status = $("#status").val();
        var loginid = $("#X_mainloginid").val();
        var id = parseInt(loginid);
        $('#filebrows').trigger('click');
        //alert("sucess");
        var img11 = $(".profpic").attr('src');
        //var imge1 = $("#img").attr('value');
        //alert(imge1);
        //alert(img11);
        $("#dialog").dialog({
            model: true,
            autoopen: false,
            title: "add photo",
            width: 350,
            height: 350,

        });
        var html = '<img src="' + img11 + '"style="height:70px;width:70px;margin-left:-210px;margin-top:-10px;"/><input type="text" id="txt1" maxlength="50" style="color:black;"/>';
        $("#dialog").show();
        $("#dialog").dialog('open');
        $(".dialogue").append(html);
    });


});