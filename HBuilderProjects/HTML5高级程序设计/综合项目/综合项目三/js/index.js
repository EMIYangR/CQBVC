const width = 1000;
const height = 650;
const snack_width = 20;
const snack_height = 20;
//移动时间间隔
const time_move = 300;
//食物刷新时间
const time_food = 5000;
//食物总量
const total_food = 500;
//石头刷新时间
const time_stone = 8000;
//石头总量
const total_stone = 300;

let switchStatus = 0;
let changeMove = "right";
let currentMove = "right";
//全部被用的位置
let points = new Array();
let snacks = new Array();
let foods = new Array();
let stones = new Array();
let moveing = false;
let timeMoveId, timefoodId, timestoneId;
window.onload = function() {
	createGround();
};
//捕获按的哪个键
function keyDown(event) {
	if (event.keyCode == "87") {
		//W
		changeMove = "up";
	} else if (event.keyCode == "68") {
		//D
		changeMove = "right";
	} else if (event.keyCode == "83") {
		//S
		changeMove = "down";
	} else if (event.keyCode == "65") {
		//A
		changeMove = "left";
	}
}

function handlePoints(x, y, type) {
	if (0 == type) {
		points.push(x + y * width);
	} else {
		let index = points.indexOf(x + y * width);
		if (index != -1) {
			points.splice(index, 1);
		}
	}
}
//贪吃蛇
function snack(x, y) {
	this.x = x;
	this.y = y;
}
//食物
function food(x, y) {
	this.x = x;
	this.y = y;
}
//石头
function stone(x, y) {
	this.x = x;
	this.y = y;
}
//开关
function clickSwitch() {
	if (switchStatus == 0 || switchStatus == 2) {
		document.getElementById("switch").value = "暂停";
		if (switchStatus == 0) {
			//开始
			play();
		}
		switchStatus = 1;
	} else if (switchStatus == 1) {
		document.getElementById("switch").value = "继续";
		switchStatus = 2;
	}
}
//碰撞判定并操作
function judge(x, y) {
	//撞上边界？
	if (x < 0 || x >= width || y < 0 || y >= height) {
		end();
		return;
	}
	let i;
	//撞上自己？
	for (i = 1; i < snacks.length; i++) {
		if (snacks[0].x == snacks[i].x && snacks[0].y == snacks[i].y) {
			end();
			return;
		}
	}
	//撞上石头？
	for (i = 0; i < stones.length; i++) {
		if (snacks[0].x == stones[i].x && snacks[0].y == stones[i].y) {
			end();
			return;
		}
	}
	//撞上食物？
	let flag = false;
	for (i = 0; i < foods.length; i++) {
		if (x == foods[i].x && y == foods[i].y) {
			flag = true;
			foods.splice(i, 1);
		}
	}
	let newsnack = new snack(x, y);
	snacks.unshift(newsnack);
	if (!flag) {
		let p = snacks.pop();
		handlePoints(p.x, p.y, 1);
	}
	document.getElementById("content").value = "x:" + snacks[0].x + " y:" + snacks[0].y + " length:" + snacks.length;
	refresh();
}
//移动贪吃蛇
function move() {
	if (moveing == false && switchStatus == 1) {
		moveing = true;
		if ((currentMove != "right" && changeMove == "left") || (currentMove == "left" && changeMove == "right")) {
			currentMove = "left";
			judge(snacks[0].x - snack_width, snacks[0].y);
		} else if ((currentMove != "down" && changeMove == "up") || (currentMove == "up" && changeMove == "down")) {
			currentMove = "up";
			judge(snacks[0].x, snacks[0].y - snack_height);
		} else if ((currentMove != "left" && changeMove == "right") || (currentMove == "right" && changeMove ==
				"left")) {
			currentMove = "right";
			judge(snacks[0].x + snack_width, snacks[0].y);
		} else if ((currentMove != "up" && changeMove == "down") || (currentMove == "down" && changeMove == "up")) {
			currentMove = "down";
			judge(snacks[0].x, snacks[0].y + snack_height);
		}
		changMove = currentMove;
	}
	moveing = false;
}
//创建地图
function createGround() {
	let canvas = document.getElementById("canvas");
	let draw = canvas.getContext('2d');
	//清除原图形
	draw.clearRect(0, 0, width, height);
	draw.strokeStyle = "red";
	draw.strokeRect(0, 0, width, height);
}
//创建食物 
function createfood() {
	if (foods.length < total_food) {
		let x = Math.round(Math.random() * (width / snack_width - 1)) * snack_width;
		let y = Math.round(Math.random() * (height / snack_height - 1)) * snack_height;
		if (points.indexOf(x + y * width) == -1) {
			let newfood = new food(x, y);
			//alert(newfood.x + "****" + newfood.y);
			let canvas = document.getElementById("canvas");
			let draw = canvas.getContext('2d');
			draw.fillStyle = "green";
			draw.fillRect(x, y, snack_width, snack_height);
			foods.push(newfood);
			handlePoints(x, y, 0);
		}
	}
}
//创建石头
function createstone() {
	if (stones.length < total_stone) {
		let x = Math.round(Math.random() * (width / snack_width - 1)) * snack_width;
		let y = Math.round(Math.random() * (height / snack_height - 1)) * snack_height;
		if (points.indexOf(x + y * width) == -1) {
			let newstone = new stone(x, y);
			let canvas = document.getElementById("canvas");
			let draw = canvas.getContext('2d');
			draw.fillStyle = "#663300";
			draw.beginPath();
			draw.arc(x + snack_width * 0.5, y + snack_height * 0.5, snack_width * 0.5 + 1, 0, Math.PI * 2, true);
			draw.closePath();
			draw.fill();
			stones.push(newstone);
			handlePoints(x, y, 0);
		}
	}
}
//刷新场景
function refresh() {
	let canvas = document.getElementById("canvas");
	let draw = canvas.getContext('2d');
	//清除原图形
	draw.clearRect(1, 1, width - 2, height - 2);
	//边界
	draw.strokeStyle = "red";
	draw.strokeRect(0, 0, width, height);
	let i;
	//食物
	draw.fillStyle = "green";
	for (i = 0; i < foods.length; i++) {
		draw.fillRect(foods[i].x, foods[i].y, snack_width, snack_height);
	}
	//石头
	draw.fillStyle = "#663300";
	for (i = 0; i < stones.length; i++) {
		draw.beginPath();
		draw.arc(stones[i].x + snack_width * 0.5, stones[i].y + snack_height * 0.5, snack_width * 0.5 + 1, 0, Math
			.PI * 2, true);
		draw.closePath();
		draw.fill();
	}
	//贪吃蛇  
	draw.fillStyle = "blue";
	draw.beginPath();
	//圆心x坐标|圆心y坐标|半径|始|PI为圆周率。Math.PI*2为画圆|true为时针方向：逆时针，0为顺时针
	draw.arc(snacks[0].x + snack_width * 0.5, snacks[0].y + snack_height * 0.5, snack_width * 0.5 + 1, 0, Math.PI * 2,
		true);
	draw.closePath();
	draw.fill();
	for (i = 1; i < snacks.length; i++) {
		draw.fillRect(snacks[i].x, snacks[i].y, snack_width, snack_height);
	}
}
//游戏开始
function play() {
	createGround();
	for (let i = 2; i > 0; i--) {
		let newsnack = new snack(snack_width * i, snack_height);
		snacks.push(newsnack);
		handlePoints(newsnack.x, newsnack.y, 0);
	}
	refresh();
	document.onkeydown = keyDown;
	timeMoveId = setInterval(move, time_move);
	timefoodId = setInterval(createfood, time_food);
	timestoneId = setInterval(createstone, time_stone);
}
//游戏结束
function end() {
	clearInterval(timeMoveId);
	clearInterval(timefoodId);
	clearInterval(timestoneId);
	switchStatus = 0;
	changeMove = "right";
	currentMove = "right";
	points.length = 0;
	snacks.length = 0;
	foods.length = 0;
	stones.length = 0;
	moveing = false;
	document.getElementById("switch").value = "开始";
	document.getElementById("content").value = "游戏结束";
	alert("游戏结束");
}