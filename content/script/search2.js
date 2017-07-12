//$(document).ready(function () {
//    $("#search").click(function () {
//        var name1 = $("#txtsearch").val();
        
//        $.ajax({
            
//            type: 'GET',
//            datatype: 'Json',
//            url: 'Home/getfriend',
//            data: {name:name1},
//            success: function (result) {
//                console.log(result[0]);
//                for (var i = 0; i < result.length; i++) {
//                    var html = '<img src="' + result[i].profilepic + '"/><label>' + result[i].loginid + '</label><label>' + result[i].firstname + '</label><label>' + result[i].surname + '</label>'
//                    $(".friend").append(html);
//                }


//            }
//        });
//    });
//});
$(document).ready(function () {
    $("#search").click(function () {
        var name = $("#txtsearch").val();
        console.log($("#txtsearch").val())

        $.ajax({

            type: 'GET',
            dataType: 'Json',
            url: 'Home/getfriend',
            data: { name: name },
            success: function (data) {
                //console.log(data[0]);
                for (var x = 0; x < data.length; x++) {
                   // console.log("ID: " + data[x].loginid + " name: " + data[x].firstname + " picture: " + data[x].profilepic);
                    var html = '<img src="' + data[x].profilepic + '"style="height:55px;" />' + '<label>' + data[x].firstname + '</label><label>' + data[x].surname + '</label>';
                   // html += '<a id="btnaddFrnd" href="/Home/TellMeDate?id=' + data[x].loginid + '" class="btn btn-success btn-add-frnd">Add Friend </a><input type=hidden id=' + data[x].loginid + '><br><hr>';
                    $(".friend").append(html);


                }

            }
        })
    });
    //$("#btnaddFrnd").click(function () {
    //    var i = $("#btnaddFrnd").val();
    //    alert(i);
    //});
});
