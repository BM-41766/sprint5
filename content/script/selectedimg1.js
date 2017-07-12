$(document).ready(function () {
    $("#filebrows").change(function () {

        var formData = new FormData();
        // var file = document.getElementById('file').file;
        // for (var i = 0; i < totalFiles; i++) {
        // var file = document.getElementById("file").files[i];
        var files1 = $("#filebrows").get(0).files;
       // alert("dfghj123");
        //alert(totalFiles);
        if (files1.length > 0) {
            formData.append("fileImg", files1[0]);

        }
        $.ajax({
            type: "POST",
            url: 'Home/postimage',
            data: formData,
            dataType: 'json',
            contentType: false,
            processData: false,
            success: function (data1) {
                console.log("result:" + data1);
               // alert(data1);
                var html = '<img src="' + data1 + '" id="postimg" class="postimge" style="height:70px;width:70px;margin-top:30px;border:dotted; color:black;"/><br/><br/><input type="button" value="post" id="btnpost1" style="color:blue;margin-left:170px;"/>';
                // alert('succes!!');
                $("#dialog").append(html);
            }
        });

    });
});
