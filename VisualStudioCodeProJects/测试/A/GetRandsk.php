<?php
header("Access-Control-Allow-Origin: *");
header("Access-Control-Allow-Methods: POST");

require("../Expand.php");

$JsonData = json_decode(file_get_contents("php://input"), true);

$Link = $JsonData["Link"];
$Code = $JsonData["Code"];

if (strlen($Link) == 0) {
    echo json_encode(
        array(
            "Status" => 18
        )
    ); #参数不全
} else {
    $GetListUrl = "https://pan.baidu.com/share/wxlist";
    $GetListData = "clienttype=25&root=1&shorturl=" . $Link . "&pwd=" . $Code;
    $Header = array("User-Agent: netdisk");

    $CUrl = curl_init($GetListUrl);
    curl_setopt($CUrl, CURLOPT_POST, true);
    curl_setopt($CUrl, CURLOPT_POSTFIELDS, $GetListData);
    curl_setopt($CUrl, CURLOPT_HTTPHEADER, $Header);
    curl_setopt($CUrl, CURLOPT_HEADER, true);
    curl_setopt($CUrl, CURLOPT_RETURNTRANSFER, true);
    curl_setopt($CUrl, CURLOPT_SSL_VERIFYPEER, false);
    curl_setopt($CUrl, CURLOPT_SSL_VERIFYHOST, false);
    curl_setopt($CUrl, CURLOPT_TIMEOUT, 30);
    $Response = curl_exec($CUrl);
    $HeaderSize = curl_getinfo($CUrl, CURLINFO_HEADER_SIZE);
    $ResultHeader = substr($Response, 0, $HeaderSize);
    $Result = substr($Response, $HeaderSize, strlen($Response));
    curl_close($CUrl);

    if (strpos($ResultHeader, "BDCLND") == true) {
        $JsonData = json_decode($Result, true);
        $Title = $JsonData["data"]["title"];
        if (strlen($Title) > 0) {
            $Title_Array = explode("/", $Title);
            $Title = $Title_Array[count($Title_Array) - 1];

            echo json_encode(
                array_merge(
                    array(
                        "Status" => 0,
                        "Code" => 0,
                        "Randsk" => urldecode(GetSubstr($ResultHeader, "Set-Cookie: BDCLND=", ";")),
                        "Title" => $Title
                    ),
                    $JsonData
                )
            );
        } else {
            echo json_encode(
                array(
                    "Status" => 315,
                    "Code" => 0
                )
            ); #标题获取失败
        }
    } else {
        $JsonData = json_decode($Result, true);
        $ErrorType = $JsonData["errtype"];
        if ($ErrorType == "0") {
            $Title = $JsonData["data"]["title"];
            if (strlen($Title) > 0) {
                $Title_Array = explode("/", $Title);
                $Title = $Title_Array[count($Title_Array) - 1];

                echo json_encode(
                    array(
                        "Status" => 143,
                        "Code" => 1,
                        "Title" => $Title
                    ) #无Randsk
                );
            } else {
                echo json_encode(
                    array(
                        "Status" => 315,
                        "Code" => 1
                    )
                ); #标题获取失败
            }
        } else if ($ErrorType == "mispwd-9") {
            if (strlen($Code) == 0) {
                echo json_encode(
                    array(
                        "Status" => 338
                    )
                ); #请输入提取码
            } else {
                echo json_encode(
                    array(
                        "Status" => 33
                    )
                ); #密码错误
            }
        } else {
            echo json_encode(
                array(
                    "Status" => 6
                )
            ); #未知错误
        }
    }
}
