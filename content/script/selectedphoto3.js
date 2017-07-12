$(document).ready(function () {
    $("#filebrows").change(function () {
        var formData = new FormData();
        // var file = document.getElementById('file').file;
        // for (var i = 0; i < totalFiles; i++) {
        // var file = document.getElementById("file").files[i];
        var files1 = $("#filebrows").get(0).files;
        alert("dfghj123");
        //alert(totalFiles);
        if (files1.length > 0) {
            formData.append("fileImg", files1[0]);

        }
        $.ajax({
            type: 'POST',
            url: 'Home/postimage',
            data: formData,
            dataType: 'Json',
            contentType: false,
            processData: false,
            success: function (response) {
                console.log("result:" + response);
                var html = '<img src=' +response + '/>';
                alert('succes!!');
                $(".dialogue").append(html);
            }
        });

    });
});
