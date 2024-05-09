document.getElementById('but').onclick=function(){
    var name=document.getElementById('i1').value;
    var sex=document.getElementById('se').value;
    var age=document.getElementById('i2').value;
    var class1=document.getElementById('i3').value;
    var phone=document.getElementById('i4').value;
    
    var td1=document.createElement('td');
    td1.innerText=name;

    var td2=document.createElement('td');
    td2.innerText=sex;

    var td3=document.createElement('td');
    td3.innerText=age;

    var td4=document.createElement('td');
    td4.innerText=class1;

    var td5=document.createElement('td');
    td5.innerText=phone;

    var td6=document.createElement('td');
    td6.innerHTML='<a href="#" onclick="del(this)">删除</a>';

    var tr=document.createElement('tr');
    tr.appendChild(td1);
    tr.appendChild(td2);
    tr.appendChild(td3);
    tr.appendChild(td4);
    tr.appendChild(td5);
    tr.appendChild(td6);
    document.getElementById('tab').appendChild(tr);
}
function del(obj) {
    var tr = obj.parentNode.parentNode;
    if (tr != null) {
        tr.parentNode.removeChild(tr);
    }
}