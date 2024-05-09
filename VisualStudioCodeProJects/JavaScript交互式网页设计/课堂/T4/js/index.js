function insert() {
    var sel = document.getElementsByTagName("select")[0];
    
    var name = document.getElementById("name").value;
    var singer = document.getElementById("singer").value;

    var array = new Array(name, singer);
    var tb = document.getElementById("tb");
    var cols = tb.getElementsByTagName("th");
    var newtr = document.createEvent("tr");
    
    for (var i; i < cols.length; i++) {
        if (i == cols.length - 1) {
            var td = document.createElement("td");
            var a = document.createElement("a");
            a.innerHTML = "删除";
            a.onclick = function () {
                a.parentNode.parentNode.parentNode.removeChild(a.parentNode.parentNode);
            }
            a.setAttribute("herf", "#");
            td.appendChild(a);
            newtr.appendChild(td);
        } else {
            var td = document.createElement("td");
            td.innerHTML = array[i];
            newtr.appendChild(td);
        }
    }
    tb.appendChild(newtr);
}
function del(obj) {
    var tr = obj.parentNode.parentNode;
    if (tr != null) {
        tr.parentNode.removeChild(tr);
    }
}