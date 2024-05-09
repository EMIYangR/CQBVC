document.getElementById('i3').onclick=function(){
    var a=document.getElementById('i1').value;
    var b=document.getElementById('i2').value;
    
    
    var td1=document.createElement('td');
    td1.innerHTML="<input type='checkbox'>";

    var td2=document.createElement('td');
    td2.innerHTML=a;
    
    var td3=document.createElement('td');
    td3.innerHTML=b;

    var td4=document.createElement('td');
    td4.innerHTML="<button onclick='del(this)'>删除</button>";
    var c=document.createElement('tr');
    c.appendChild(td1);
    c.appendChild(td2);
    c.appendChild(td3);
    c.appendChild(td4);
    document.getElementById('tab').appendChild(c);
}

function del(obj) {
    var tr = obj.parentNode.parentNode;
    if (tr != null) {
        tr.parentNode.removeChild(tr);
    }
}