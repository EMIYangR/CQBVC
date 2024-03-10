<?php
header("Access-Control-Allow-Origin: *");
header("Access-Control-Allow-Methods: POST");

require("../Expand.php");

$JsonData = json_decode(file_get_contents("php://input"), true);

$Link = $JsonData["Link"];
$Randsk = $JsonData["Randsk"];
$Base64Dir = $JsonData["Base64Dir"];
$Page = $JsonData["Page"];

if (strlen($Link) == 0) {
    echo json_encode(
        array(
            "Status" => 18
        )
    ); #参数不全
} else {
    $Dir = base64_decode($Base64Dir);
    $Url = "https://pan.baidu.com/share/wxlist";
    $Data = "clienttype=25&num=100&shorturl=" . $Link . "&dir=" . urlencode($Dir) . "&page=" . $Page;

    if ($Dir == "") {
        $Data .= "&root=1";
    }

    $Header = array(
        "User-Agent: netdisk",
        "Cookie: BDCLND=" . urlencode($Randsk)
    );

    $Result = CurlPost($Url, $Data, $Header);
    $JsonData = json_decode($Result, true);

    $Sha256Data = "";

    $Errno = $JsonData["errno"];
    $ErrType = $JsonData["errtype"];
    if ($Errno == "0") {
        $Array = [];

        $UserName = $JsonData["data"]["uname"];
        $ShareTime = $JsonData["data"]["link_ctime"];
        $ShareExpiredType = $JsonData["data"]["expiredType"];

        $ListLength = count($JsonData["data"]["list"]);
        $ShareID = $JsonData["data"]["shareid"];
        $UserUK = $JsonData["data"]["uk"];

        for ($i = 0; $i <= $ListLength; $i++) {
            $Name = $JsonData["data"]["list"][$i]["server_filename"];
            if ($Name != "") {
                $Size = $JsonData["data"]["list"][$i]["size"];
                $Time = $JsonData["data"]["list"][$i]["local_ctime"];
                $Path = $JsonData["data"]["list"][$i]["path"];
                $Type = $JsonData["data"]["list"][$i]["isdir"];
                $PCS = $JsonData["data"]["list"][$i]["dlink"];
                $MD5 = $JsonData["data"]["list"][$i]["md5"];
                $ID = $JsonData["data"]["list"][$i]["fs_id"];
                $Thumbs = $JsonData["data"]["list"][$i]["thumbs"]["url3"];

                $Category_Arrar = explode(".", $Name);
                $Category = $Category_Arrar[count($Category_Arrar) - 1];

                $Thumbs = str_ireplace("http://", "https://", $Thumbs);
                $PCS = str_ireplace("http://", "https://", $PCS);
                $PCSPath = str_ireplace("?fid=", "&fid=", $PCS);
                $PCSPath = substr($PCSPath, 29);

                $Sha1 = sha1($MD5 . "5a9741eb4cdbe321" . $ID);

                $Data = array(
                    "Name" => $Name,
                    "Size" => $Size,
                    "Time" => $Time,
                    "Path" => $Path,
                    "Type" => $Type,
                    "PCS" => $PCS,
                    "PCSPath" => $PCSPath,
                    "MD5" => $MD5,
                    "ID" => $ID,
                    "Sha1" => $Sha1,
                    "Category" => $Category,
                    "Thumbs" => $Thumbs
                );

                $Array = array_merge(
                    $Array,
                    array(
                        $Data
                    )
                );
            }

            $Sha256Data .= $Sha1;
        }

        if ($Dir == "") {
            $Path = $JsonData["data"]["list"][0]["path"];
            $Name = $JsonData["data"]["list"][0]["server_filename"];
            $Dir = str_ireplace($Name, "", $Path);
            $Dir = substr($Dir, 0, strlen($Dir) - 1);

            if (count($JsonData["data"]["list"]) == 1 && strlen($JsonData["data"]["list"][0]["dlink"]) > 0) {
                $OneFile = true;
            } else {
                $OneFile = false;
            }
        } else {
            $OneFile = false;
        }

        $Sha256 = hash("sha256", $Sha256Data);

        echo json_encode(
            array(
                "Status" => 0,
                "UserName" => $UserName,
                "ShareTime" => $ShareTime,
                "ShareExpiredType" => $ShareExpiredType,
                "Sha256" => $Sha256,
                "Count" => $ListLength,
                "Page" => $Page,
                "ShieldDir" => $Dir,
                "OneFile" => $OneFile,
                "ShareID" => $ShareID,
                "UserUK" => $UserUK,
                "List" => $Array
            )
        );
    } else {
        if ($ErrType == "mis_105") {
            echo json_encode(
                array(
                    "Status" => 30
                )
            ); #资源不存在
        } else if ($ErrType == "mis_2") {
            echo json_encode(
                array(
                    "Status" => 233
                )
            ); #目录不存在
        } else if ($ErrType == 3) {
            echo json_encode(
                array(
                    "Status" => 235
                )
            ); #非法文件资源禁止访问
        } else if ($ErrType == "mis_105") {
            echo json_encode(
                array(
                    "Status" => 29
                )
            ); #资源已被删除
        } else if ($ErrType == "mis_105") {
            echo json_encode(
                array(
                    "Status" => 234
                )
            ); #资源已过期
        } else {
            echo json_encode(
                array(
                    "Status" => 6,
                    "Errno" => $Errno,
                    "Type" => $ErrType
                )
            ); #未知错误
        }
    }
}
