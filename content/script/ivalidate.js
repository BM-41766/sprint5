/// <reference path="ivalidate.js" />
function datavalidate() {
    var fn = document.getElementById("fname").value;
    if (fn == "") {
            document.getElementById("fname").placeholder = "Enter firstname";
            document.getElementById("fname").style.backgroundcolor = "#f41122";
            
    }

}
function dvalidate() {
    var fn1 = document.getElementById("fname").placeholder;
    if (fn1 == "Enter firstname") {
        document.getElementById("fname").placeholder = "First name";
    }
}

function lnamevalidate() {
    var ln = document.getElementById("lname").value;
    if (ln == "") {
        document.getElementById("lname").placeholder = "Enter surname";
    }
}
function lastvalidate() {
    var lnm = document.getElementById("lname").placeholder;
    if (lnm == "Enter surname") {
        document.getElementById("lname").placeholder = "surname";
    }
}

function emlvalidate() {
    var em = document.getElementById("emal").value;
    if (em == "") {
        document.getElementById("emal").placeholder = "Enter email address";
    }
}

function emvalidate() {
    var emv = document.getElementById("emal").placeholder;
    if (evm == "Enter email address") {
        document.getElementById("emal").placeholder = "Email address or mobile number";
    }
}
function evalidate() {
    var ei = document.getElementById("emid").value;
    if (ei == "") {
        document.getElementById("emid").placeholder = "Re-enter email address";
    }
}
function revalidate() {
    var rev = document.getElementById("emid").placeholder;
    if (rev == "Re-enter email address") {
        document.getElementById("emid").placeholder = "Re-enter email address or mobile number";
    }
}
function paswrdvalidate() {
    var pas = document.getElementById("paswrd").value;
    if (pas == "") {
        document.getElementById("paswrd").placeholder = "Enter password";
    }
}
function pswrd() {
    var pswd = document.getElementById("paswrd").placeholder;
    if (pswd == "Enter password") {
        document.getElementById("paswrd").placeholder = "New password";
    }
}
