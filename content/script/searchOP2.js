$(document).ready(function () {
    $("#search").click(function () {
        var name = $("#txtsearch").val();
        var name1 = $("#X_mainloginid").val();
        var x1 = parseInt(name1);
        console.log($("#txtsearch").val())

        $.ajax({

            type: 'GET',
            dataType: 'Json',
            url: 'Home/getfriend',
            data: { name: name },
            success: function (data) {
                $(".friend").empty();
                //console.log(data[0]);
                for (var x = 0; x < data.length; x++) {
                    if (data[x].relation == 1 && x1 == data[x].senderid) {
                        console.log("ID: " + data[x].loginid + " name: " + data[x].firstname + " picture: " + data[x].profilepic);
                        var html = '<img src="' + data[x].profilepic + '"style="height:55px;width:30px;"/>' + '<label style="margin-top:-35px; margin-left:50px;">' + data[x].firstname + data[x].surname + '</label> <input type="button" value="Request send" id="frndbtn" style="margin-left:135px;margin-top:-35px;" data-id="' + data[x].loginid + '"/><input type=hidden style="margin-left:210px;margin-top:-35px; height:25px;" value="' + name1 + '"/><br><hr>';
                        // html += '<a id="btnaddFrnd" href="/Home/TellMeDate?id=' + data[x].loginid + '" class="btn btn-success btn-add-frnd">Add Friend </a><input type=hidden id=' + data[x].loginid + '><br><hr>';
                        // $(".friend").append(html);

                    }
                    else {
                        console.log("ID: " + data[x].loginid + " name: " + data[x].firstname + " picture: " + data[x].profilepic);
                        var html = '<img src="' + data[x].profilepic + '"style="height:55px;width:30px;"/>' + '<label style="margin-top:-35px; margin-left:50px;">' + data[x].firstname + data[x].surname + '</label> <input type="button" value="Addfriend" id="frndbtn" style="margin-left:135px;margin-top:-35px;" data-id="' + data[x].loginid + '"/><input type=hidden style="margin-left:210px;margin-top:-35px; height:25px;" value="' + name1 + '"/><br><hr>';
                        // html += '<a id="btnaddFrnd" href="/Home/TellMeDate?id=' + data[x].loginid + '" class="btn btn-success btn-add-frnd">Add Friend </a><input type=hidden id=' + data[x].loginid + '><br><hr>';

                    }

                    $("#hide").hide();
                    $(".friend").append(html);
                    //$(".friend").show();

                }
            }
        })
    });
    $(document).on('click', '#frndbtn', function () {
        var reciverid1 = $(this).data("id");
        var senderid1 = $("#X_mainloginid").val();
        $(this).prop('value', 'Request Send');
        $.ajax({

            type: 'GET',
            dataType: 'Json',
            url: 'Home/addfrnd',
            data: { receiverid: reciverid1, senderid: senderid1 },
            success: function (data) {
                //    //console.log(data[0]);
                //    for (var x = 0; x < data.length; x++) {
                //        console.log("ID: " + data[x].loginid + " name: " + data[x].firstname + " picture: " + data[x].profilepic);
                //        var html = '<img src="' + data[x].profilepic + '"style="height:55px;width:30px;"/>' + '<label style="margin-top:-35px; margin-left:50px;">' + data[x].firstname + data[x].surname + '</label> <input type="button" value="Addfriend" id="frndbtn" style="margin-left:135px;margin-top:-35px;" data-id="'+data[x].loginid+'"/><input type=hidden style="margin-left:210px;margin-top:-35px; height:25px;" value="'+name1+'"/><br><hr>';
                //        // html += '<a id="btnaddFrnd" href="/Home/TellMeDate?id=' + data[x].loginid + '" class="btn btn-success btn-add-frnd">Add Friend </a><input type=hidden id=' + data[x].loginid + '><br><hr>';
                //        $(".friend").append(html);

                //    }
                //    $("#hide").hide();
            }
        })

    });
    $(document).ready(function () {
        $("#aprvfrnd").click(function () {
            var name1 = $("#X_mainloginid").val();
            var x = parseInt(name1);
            console.log($("#txtsearch").val())
            $(".friend").empty();
            $.ajax({
                type: 'GET',
                dataType: 'Json',
                url: 'Home/frndaprove',
                data: { reciverid1: name1 },
                success: function (data) {

                    // $(".friend").empty();
                    //console.log(data[0]);
                    for (var x = 0; x < data.length; x++) {
                        if (data[x].relation == 0) {
                            console.log("ID: " + data[x].loginid + " name: " + data[x].firstname + " picture: " + data[x].profilepic);
                            var html = '<img src="' + data[x].profilepic + '"style="height:55px;width:30px;"/>' + '<label style="margin-top:-35px; margin-left:50px;">' + data[x].firstname + data[x].surname + '</label> <input type="button" value="Confirm" id="confrmbtn" style="margin-left:150px;margin-top:-25px;" data-id="' + data[x].loginid + '"/><input type="button" value="Delete Request" id="deltebtn" style="margin-top:-25px;" data-id="' + data[x].loginid + '"/><input type=hidden style="margin-left:210px;margin-top:-35px; height:25px;" value="' + name1 + '"/><br><hr>';
                            // html += '<a id="btnaddFrnd" href="/Home/TellMeDate?id=' + data[x].loginid + '" class="btn btn-success btn-add-frnd">Add Friend </a><input type=hidden id=' + data[x].loginid + '><br><hr>';
                            $(".friend").append(html);

                        }

                    }
                }
            })
        });
        $(document).on('click', '#confrmbtn', function () {
            //$(".frnd").empty();
            var reciverid1 = $("#X_mainloginid").val();
            var senderid1 = $(this).data("id");
            $("#deltebtn").hide();
            $(this).prop('value', 'Friend');
            $.ajax({
                type: 'GET',
                dataType: 'Json',
                url: 'Home/confirm',
                data: { reciverid: reciverid1, senderid: senderid1 },
                success: function (data) {
                }
            })
        });
        $(document).on('click', '#deltebtn', function () {
            //$(".frnd").empty();
            var reciverid1 = $("#X_mainloginid").val();
            var senderid1 = $(this).data("id");
            alert(senderid1);
            $.ajax({
                type: 'GET',
                dataType: 'Json',
                url: 'Home/delete',
                data: { reciverid: reciverid1, senderid: senderid1 },
                success: function (data) {
                }
            })
        });
        $(document).ready(function () {
            $("#frndsrch").click(function () {
                var name1 = $("#X_mainloginid").val();
                var x = parseInt(name1);
                alert(x);

                $.ajax({

                    type: 'GET',
                    dataType: 'Json',
                    url: 'Home/frndsearch',
                    data: { loginid: name1 },
                    success: function (data) {
                        console.log(data[0]);
                        for (var x = 0; x < data.length; x++) {
                            console.log("ID: " + data[x].loginid + " name: " + data[x].firstname + " picture: " + data[x].profilepic);
                            if (data[x].relation == 1) {

                                var html = '<img src="' + data[x].profilepic + '"style="height:55px;width:30px;"/>' + '<label style="margin-top:-35px; margin-left:50px;">' + data[x].firstname + data[x].surname + '</label> <input type="button" value="UnFriend" id="Unfriendbtn" style="margin-left:135px;margin-top:-35px;" data-id="' + data[x].senderid + '"/><input type=hidden style="margin-left:210px;margin-top:-35px; height:25px;" value="' + name1 + '"/><br><hr>';
                                $(".friend").append(html);
                            }
                        }
                    }
                })
            });
        });
    });
});