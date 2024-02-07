// var names = ["李华","小明","小红","小张","HXD","LPL","LOL"];
var names = ["刘小萍","樊晋君","黄俊","李瑞","陈青婷","江洪苇","邬欢欢",
		"张梓靖","刘莲花","张世程","王励","郭红梅","杨莹","金伍燕","向洋",
		"唐敏嘉","唐忠意","王运弛","印前程","林福轩","刘宇","杨钰婷","罗毅凤",
		"李行","钱昱洁","袁玉","王灿","王锦臣","董百英","蒲皓","陈世豪","查美丽",
		"邵怡欣","王燕方","王家伟","黄毓茹","马景涛","林仕鸿","王欢"]
var length = names.length;

var displayBoard = document.getElementById("nameDisplay");

mytime = null

function clickButton(btn) {
    var text = btn.innerHTML;
    console.log(text);

    if (text == "Start") {
        btn.innerHTML = "End";

        if (mytime == null) {
            mytime = setInterval(function () {
                var name = randomName();
                console.log(name);
                displayBoard.innerHTML = name;
            }, 100);
        }

    } else if (text == "End") {
        btn.innerHTML = "Start";

        if (mytime != null) {
            clearInterval(mytime);
            mytime = null;
        }
    }


}

function randomName() {
    var randomNum = Math.ceil(Math.random() * 4000) % length + 1;
    return names[randomNum - 1];
}