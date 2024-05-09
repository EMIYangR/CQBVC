var pointer = document.getElementById("pointer");
var turntable = document.getElementById("turntable");
var gameover = true;
var cat = 51.4;
var lenCloc = 0;

function start() {
    if (gameover) {
        gameover = !gameover;
        rotate();
    }
}

function rotate() {
    lenCloc++;
    var timer = null;
    clearInterval(timer);
    timer = setInterval(function () {
        var soBuom = parseInt(Math.floor(Math.random() * 51.4) - 25.7);
        var rdm = lenCloc * 3 * 360 + soBuom;
        turntable.style.transform = "rotate(" + rdm + "deg)";
        clearInterval(timer);
        setTimeout(function () {
            gameover = !gameover;
            num = rdm % 360;
            if (num <= cat * 1) {
                alert("恭喜你获得一等奖！\n4999元免单")
            } else if (num <= cat * 2) {
                alert("恭喜你获得二等奖！\n50元免单")
            } else if (num <= cat * 3) {
                alert("恭喜你获得三等奖！\n10元免单")
            } else if (num <= cat * 4) {
                alert("恭喜你获得四等奖！\n5元免单")
            } else if (num <= cat * 5) {
                alert("恭喜你获得五等奖！\n免分期服务费")
            } else if (num <= cat * 6) {
                alert("恭喜你获得幸运奖！\n提高白条额度")
            } else if (num <= cat * 7) {
                alert("未中奖")
            }
        }, 4000);
    }, 30);
}