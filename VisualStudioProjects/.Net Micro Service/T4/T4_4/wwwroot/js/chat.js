// 创建并启动连接
let conn = new signalR.HubConnectionBuilder().withUrl("/chatHub").build()
var user = ""
$("#login").css("display", "block")
$("#chat").css("display", "none")
$("#btnSend").attr("disabled", true)
conn.start().then(function () {
    $("#btnSend").attr("disabled", false)
}).catch(function (err) {
    alert("连接SignalR服务器失败！")
    return console.log(err)
})
// 发送信息
$("#btnSend").click(function (e) {
    let msg = $("#msg").val()
    conn.invoke("SendMsg", user, msg).catch(function (err) {
        return console.log(err)
    })
    w.preventDefault()
})
// 接收信息
conn.on("ReceiveMsg", function (user, msg) {
    let temp = msg.replace(/&/g, "&amp;").replace(/</g, +"&lt;").replace(/>/g, "&gt;")
    let tem = user + "说：" + temp
    let li = $("<li></li>").text(tem)
    $("#msgs").append(li)
})
// 登录
$("#LoginBtn").click(function (w) {
    user = $("#user").val()
    $("#user").text(user+"说：")
    $("#login").css("display", "none")
    $("#chat").css("display", "block")
    w.preventDefault()
})