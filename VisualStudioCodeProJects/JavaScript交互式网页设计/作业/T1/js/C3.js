var a = 340;
var b = true;

if(b){
    document.write("会员消费："+a)
    if(a>200){
        document.write("，实际消费："+a*0.75)
    } else{
        document.write("，实际消费："+a*0.9)
    } 
} else {
    document.write("非会员消费："+a)
    if(a>100){
        document.write("，实际消费："+a*0.9)
    } else{
        document.write("，实际消费："+a)
    }
}
