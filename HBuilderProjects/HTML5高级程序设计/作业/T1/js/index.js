console.log("开始设置导航按钮样式");

//选择多个元素 & 选择一个元素
var buttonList = document.querySelectorAll(".nav__btn");
var firstButton = document.querySelector(".nav__btn");
for (var i = 0; i < buttonList.length; i++) {
	var btn = buttonList[i];
	btn.className += "nav__btn--bg-c" + (i + 1);
}
firstButton.className += "nav__btn--selected";
console.log("结束设置导航按钮事件");

console.log("监听Window的加载事件");


//监听窗体加载事件处理方法
window.addEventListener("load", winLoad, false);
//窗体加载事件处理方法
function winLoad() {
	console.info("监听导航按钮的鼠标移入事件");
	var ButtonList = document.querySelectorAll(".nav__btn");
	for (var i = 0; i < buttonList.length; i++) {
		var btn = buttonList[i];
		console.info("监听导航按钮"+i+"的鼠标移入事件");
		btn.addEventListener("mouseover", btnMouseOver, false);
		console.info("监听导航按钮"+i+"的鼠标移出事件");
		btn.addEventListener("mouseout", btnMouseOut, false);
	}
}
//鼠标移入事件处理方法
function btnMouseOver() {
	var elm = event.target;
	console.assert(event.srcElement.tagName == "A", "当前元素不是A标签");
	if (event.srcElement.tagName == "A") {
		console.info("按钮当前样式：" + elm.className)
		elm.className += "nav__btn--active";
	}
}

function btnMouseOut() {
	var elm = event.target;
	console.assert(event.srcElement.tagName == "A", "当前元素不是A标签");
	if (event.srcElement.tagName == "A") {
		var index = elm.className.indexOf("nav_btn--active");
		if (index != -1) {
			var classText = elm.className;
			console.info("按钮当前样式：" + elm.classText)
			elm.className = elm.className.replace("nav__btn--active","");
		}
	}
}