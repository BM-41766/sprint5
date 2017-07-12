$(document).ready(function () {
    $("#login").click(function () {
        alert("gfg");
        var username = $(".username").val();
       var password = $(".password").val();
        $.ajax({

            url: "http://localhost:2647/Views/my/Service1.svc?/login()",
            data: { username: username, password: password },
            success: function (result) {
                console.log(result);
                alert(result);

            }
        });
    });
});