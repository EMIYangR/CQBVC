function IsNull(Data) {
    if (Data == null || Data == undefined || Data == "null" || Data == "undefined" || Data == "" || Data.length == 0) {
        return true;
    } else {
        return false;
    }
}

function TimeDate(Time) {
    if (Time == null) {
        return "";
    } else {
        if (Time.length > 10) {
            Time = Time.substring(0, 10);
        }

        var Data = new Date(Time * 1000);
        var Y = Data.getFullYear();
        var M = Data.getMonth() + 1 < 10 ? "0" + (Data.getMonth() + 1) : Data.getMonth() + 1;
        var D = Data.getDate();
        var h = Data.getHours();
        var m = Data.getMinutes();
        var s = Data.getSeconds();
        return Y + "-" + M + "-" + D + " " + h + ":" + m + ":" + s;
    }
}

function GetCookie(Name) {
    var Split = document.cookie.split(";");
    for (var Index = 0; Index < Split.length; Index++) {
        var Cookie = Split[Index];
        if (Cookie.indexOf(Name) > 0) {
            var Value = Cookie.substring(Name.length + 2, Cookie.length);
            if (Value.length > 0) {
                return Value;
            }
        }
    }

    return "";
}

function DocumentCopyText(Data) {
    var Input = document.createElement("textarea");
    Input.value = Data;
    document.body.appendChild(Input);
    Input.select();
    document.execCommand("Copy");
    document.body.removeChild(Input);
}

function SizeFormat(Bytes) {
    if (Bytes == 0) {
        return "0 Bytes";
    } else {
        var KB = 1024;
        var SizeArray = ["Bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB"];
        var Index = Math.floor(Math.log(Bytes) / Math.log(KB));
        var Number = parseFloat((Bytes / Math.pow(KB, Index)).toFixed(2));
        var ConvertSize = Number + SizeArray[Index];
        return ConvertSize;
    }
}

function CacheImage(Link) {
    return new Promise(function (TerminateReturn) {
        var DocumentData = document.createElement("img");
        DocumentData.src = "https://cloudcache.tencent-cloud.com/open_proj/proj_qcloud_v2/gateway/routine/compliance/css/img/logo-cloud.png";
        DocumentData.src = Link;
        DocumentData.onload = function () {
            TerminateReturn();
        };
    });
}
