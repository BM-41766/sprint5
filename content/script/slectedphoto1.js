$(document).ready(function () {
    $("#filebrows").change(function () {
        var formData = new FormData();
       // var file = document.getElementById('file').file;
        // for (var i = 0; i < totalFiles; i++) {
        // var file = document.getElementById("file").files[i];
        var files = $("#filebrows").get(0).files;
        alert("dfghj123");
        //alert(totalFiles);
        if (files.length > 0) {
            formData.append("fileImg", files[0]);

        }
        $.ajax({
            type: 'GET',
            url: 'Home/postimage',
            data: formData,
            dataType: 'Json',
            contentType: false,
            processData: false,
            success: function (response) {
                console.log("result:" + response);
                //var html='<div style="background-color:'+i></div>'
                alert('succes!!');
            }
        });

    });
});
