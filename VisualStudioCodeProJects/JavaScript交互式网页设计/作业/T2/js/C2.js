function operation(){
    var num1 = document.getElementById("a1").value;
    var num2 = document.getElementById("a2").value;
    var ysf = document.getElementById("a3").value;
    if(num1.trim() != ""&&num2.trim()!=""){
        if(!isNaN(num1)&&!isNaN(num2)){
            document.getElementById("result").value=eval(num1+ysf+num2);
        } else {
            alert("请输入正确的数值！");
        }
    } else {
        alert("请输入两个数！");
    }
}