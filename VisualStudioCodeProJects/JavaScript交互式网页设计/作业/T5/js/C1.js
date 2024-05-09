var yearSelect = document.getElementById("year");
var monthSelect = document.getElementById("month");
var dateul = document.getElementById("dateul");

function init() {
    for (var year = 1990; year < 3000; year++) {
        createOption(year, year, yearSelect);
    }
    for (var month = 1; month < 13; month++) {
        createOption(month, month - 1, monthSelect);
    }
    var now = new Date();
    showSelect(now.getFullYear(), now.getMonth());
    showDates();
    yearSelect.onchange = function () {
        showDates();
    }
    monthSelect.onchange = function () {
        showDates();
    }
}

function createOption(text, value, parent) {
    var option = document.createElement("option");
    option.innerHTML = text;
    option.value = value;
    parent.appendChild(option);
}

function showSelect(year, month) {
    yearSelect.value = year;
    monthSelect.value = month;
}

function showDates() {
    dateul.innerHTML = "";
    var year = yearSelect.value;
    var month = monthSelect.value;

    for (var i = 0; i < getDays(year, month); i++) {
        createLi("", dateul);
    }
    for (var j = 1; j <= getDatesOfMonth(year, month); j++) {
        createLi(j, dateul);
    }
}

function getDays(year, month) {
    var d = new Date(year, month, 1);
    return d.getDay();
}

function createLi(text, parent) {
    var li = document.createElement("li");
    li.innerHTML = text;
    parent.appendChild(li);
}

function getDatesOfMonth(year, month) {
    var d = new Date(year, month + 1, 0);
    return d.getDate();
}

init();