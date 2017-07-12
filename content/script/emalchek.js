function malchek() {
    //alert("sdfghjk");
    var fnm = document.getElementById("fname").value;
    var len = fnm.value.length;
    if (fnm >= 3) {
        alert("sucess");
      fnm.innerHTML = n
    }
   /* else {
        alert("fail");
    }*/
    var x = document.getElementById("emal").value;
    var at = x.indexOf("@");
    var dot = x.lastIndexOf(".");
    if (at < 1 || dot < at + 2 || dot + 2 >= x.length) {
        alert("Not a valid e-mail address");
        return false;
    }
    /*alert("sdfghjkhgfd")
    var x = document.getElementById("emal").value;
    var y = document.getElementById("emid").value;
    if (emal == emid) {
        alert("sucess")
    }*/
    var pas = [(a - z)(A - Z)(0 - 9)];
    if (paswrd.value == pas) {
        alert("Correct....")
        return true;
    }
}
