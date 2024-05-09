function go() {
    var url = document.getElementById("txt").value;
    window.location.assign(url);
}

function seturl(url) {
    document.getElementById("txt").value = url;
}