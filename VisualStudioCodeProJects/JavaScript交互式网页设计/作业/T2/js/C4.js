function checkLogin() {
    var userEmail = document.getElementById("txtEmail").value;
    var UserPwd = document.getElementById("txtPwd").value;
    if (userEmail == "10000@qq.com" && UserPwd == "123456") {
        alert("登录成功！")
    } else {
        alert("登录失败！")
    }
}

function keyFun() {
    var key = Event.keyCode;
    if (key == 13) {
        checkLogin();
    }
}