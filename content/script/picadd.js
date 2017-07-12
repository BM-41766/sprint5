$(document).ready(function () {
    $("#file").change(function () {
        var formData = new FormData();
        var file = document.getElementById('file').file;
        // for (var i = 0; i < totalFiles; i++) {
        // var file = document.getElementById("file").files[i];
        var files = $("file").get(0).files;
        
        //alert(totalFiles);
        if (file.length > 0) {
            formData.append("file", files[0]);
            alert("dfghj");
        }
        $.ajax({
            type: "GET",
            url: 'Home/postimage',
            data: formData,
            dataType: 'json',
            contentType: false,
            processData: false,
            success: function (response) {
                console.log("result:" + response);
                //var html='<div style="background-color:'+i></div>'
                alert('succes!!');
            },
            error: function (error) {
                alert("errror");
            }
        })

    });
});
