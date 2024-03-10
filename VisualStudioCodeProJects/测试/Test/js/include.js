var city, isnight, rdiv, driving, myGeo, spoi, epoi;
function sotaxi(b, a, c, d) {
    showhtml("<b>\u6b63\u5728\u67e5\u8be2\uff0c\u8bf7\u7a0d\u540e\u2026\u2026</b>"); if (2 > b.length) return showhtml("<b>\u8bf7\u6b63\u786e\u8f93\u5165\u57ce\u5e02\u540d\u79f0\uff01</b>"), !1; b != city && (city = b, driving.setLocation(city), setCookie("cityname", city)); isnight = 1 == d ? 1 : 0; myGeo.getPoint(a, function (a) {
        a ? (spoi = a, myGeo.getPoint(c, function (a) { a ? driving.search(spoi, a) : showhtml("\u76ee\u7684\u5730\u65e0\u6cd5\u5339\u914d\uff0c\u53ef\u80fd\u662f\u60a8\u8f93\u5165\u7684\u5730\u70b9\u540d\u79f0\u6709\u8bef\u6216\u8fc7\u4e8e\u7b80\u7565\uff0c\u8bf7\u4fee\u6b63\u6216\u8865\u5145\u540e\u91cd\u8bd5\uff01") }, city)) :
            showhtml("\u51fa\u53d1\u5730\u5740\u65e0\u6cd5\u5339\u914d\uff0c\u53ef\u80fd\u662f\u60a8\u8f93\u5165\u7684\u5730\u70b9\u540d\u79f0\u6709\u8bef\u6216\u8fc7\u4e8e\u7b80\u7565\uff0c\u8bf7\u4fee\u6b63\u6216\u8865\u5145\u540e\u91cd\u8bd5\uff01")
    }, city)
} function showhtml(b) { document.getElementById("results").innerHTML = b; window.scrollTo(0, 0) } function setCookie(b, a) { var c = b + "=" + encodeURIComponent(a); document.cookie = c + "; expires=Mon, 31 Dec 2998 16:00:00 GMT" }
function getCookie(b) { return (new RegExp("(?:; )?" + b + "=([^;]*);?")).test(document.cookie) ? decodeURIComponent(RegExp.$1) : null }
function load() {
    var b = {
        onSearchComplete: function (a) {
            if (null != a.taxiFare) {
                var b; b = a.taxiFare.distance / 1E3; showhtml(1 == isnight ? null != a.taxiFare.night ? "<strong>\u603b\u91cc\u7a0b\u7ea6\u4e3a\uff1a" + b + "\u516c\u91cc\uff0c\u591c\u95f4\u8d39\u7528\u5408\u8ba1\uff1a" + a.taxiFare.night.totalFare + "\u5143\u3002</strong><br />\u5c0f\u63d0\u793a\uff1a" + city + "\u51fa\u79df\u8f66\u591c\u95f4\u8d77\u6b65\u4ef7\u4e3a\uff1a" + a.taxiFare.night.initialFare + "\u5143" : "<strong>\u603b\u91cc\u7a0b\u7ea6\u4e3a\uff1a" + b + "\u516c\u91cc\uff0c\u8d39\u7528\u5408\u8ba1\uff1a" +
                    a.taxiFare.day.totalFare + "\u5143\u3002</strong><br />\u5c0f\u63d0\u793a\uff1a" + city + "\u51fa\u79df\u8f66\u8d77\u6b65\u4ef7\u4e3a\uff1a" + a.taxiFare.day.initialFare + "\u5143\uff0c\u591c\u95f4\u4e0d\u52a0\u4ef7" : "<strong>\u603b\u91cc\u7a0b\u7ea6\u4e3a\uff1a" + b + "\u516c\u91cc\uff0c\u8d39\u7528\u5408\u8ba1\uff1a" + a.taxiFare.day.totalFare + "\u5143\u3002</strong><br />\u5c0f\u63d0\u793a\uff1a" + city + "\u51fa\u79df\u8f66\u8d77\u6b65\u4ef7\u4e3a\uff1a" + a.taxiFare.day.initialFare + "\u5143")
            } else showhtml("<strong>\u6682\u65f6\u65e0\u6cd5\u67e5\u8be2\u60a8\u6240\u5728\u57ce\u5e02\u7684\u6253\u8f66\u4ef7\u683c\uff0c\u6211\u4eec\u4f1a\u4e0d\u65ad\u5b8c\u5584\u67e5\u8be2\u7cfb\u7edf\uff0c\u611f\u8c22\u60a8\u7684\u652f\u6301\u548c\u7406\u89e3\u3002</strong>")
        }
    };
    city = getCookie("cityname"); null != city ? (driving = new BMap.DrivingRoute(city, b), document.taxi.city.value = city) : driving = new BMap.DrivingRoute("\u5168\u56fd", b); myGeo = new BMap.Geocoder; rdiv = document.getElementById("results")
};