<?php

function SetCurl($Curl, $Header) {
    curl_setopt($Curl, CURLOPT_HTTPHEADER, $Header);
    curl_setopt($Curl, CURLOPT_RETURNTRANSFER, true);
    curl_setopt($Curl, CURLOPT_FOLLOWLOCATION, false);
    curl_setopt($Curl, CURLOPT_SSL_VERIFYPEER, false);
    curl_setopt($Curl, CURLOPT_SSL_VERIFYHOST, false);
    curl_setopt($Curl, CURLOPT_TIMEOUT, 30);
}

function CurlGet($Url, $Header) {
    $Curl = curl_init($Url);
    SetCurl($Curl, $Header);
    $Result = curl_exec($Curl);
    curl_close($Curl);
    return $Result;
}

function CurlPost($Url, $Data, $Header) {
    $Curl = curl_init($Url);
    SetCurl($Curl, $Header);
    curl_setopt($Curl, CURLOPT_POST, true);
    curl_setopt($Curl, CURLOPT_POSTFIELDS, $Data);
    $Result = curl_exec($Curl);
    curl_close($Curl);
    return $Result;
}

function CurlHeadGet($Url, $Header) {
    $Curl = curl_init($Url);
    SetCurl($Curl, $Header);
    curl_setopt($Curl, CURLOPT_HEADER, true);
    $Response = curl_exec($Curl);
    $HeaderSize = curl_getinfo($Curl, CURLINFO_HEADER_SIZE);
    $Result = substr($Response, 0, $HeaderSize);
    curl_close($Curl);
    return $Result;
}

function CurlHeadPost($Url, $Data, $Header) {
    $Curl = curl_init($Url);
    SetCurl($Curl, $Header);
    curl_setopt($Curl, CURLOPT_HEADER, true);
    curl_setopt($Curl, CURLOPT_POST, true);
    curl_setopt($Curl, CURLOPT_POSTFIELDS, $Data);
    $Response = curl_exec($Curl);
    $HeaderSize = curl_getinfo($Curl, CURLINFO_HEADER_SIZE);
    $Result = substr($Response, 0, $HeaderSize);
    curl_close($Curl);
    return $Result;
}

function GetSubStr($String, $StringLeft, $StringRight) {
    $LengthLeft = strlen($StringLeft);
    $RightLength = strlen($String);

    if ($RightLength == 0 || $LengthLeft == 0) {
        return "";
    }

    $Left = strpos($String, $StringLeft);
    if ($Left == "") {
        return "";
    }

    $LeftForRight = substr($String, $Left, $RightLength);
    $Right = strpos($LeftForRight, $StringRight);

    $String = substr($String, $Left, $Right);
    $Data = substr($String, $LengthLeft, strlen($String));

    return $Data;
}

function StatisticsTraffic($Type, $Size) {
    $Url = "https://127.0.0.1:9843/FlowRecord/Parse.php?Type=" . $Type . "&Size=" . $Size;

    $Header = array(
        "Host: api.kinh.cc",
        "User-Agent: Server;API;Expand"
    );

    $Curl = curl_init();
    curl_setopt($Curl, CURLOPT_URL, $Url);
    curl_setopt($Curl, CURLOPT_HTTPHEADER, $Header);
    curl_setopt($Curl, CURLOPT_RETURNTRANSFER, true);
    curl_setopt($Curl, CURLOPT_SSL_VERIFYPEER, false);
    curl_setopt($Curl, CURLOPT_SSL_VERIFYHOST, false);
    curl_setopt($Curl, CURLOPT_TIMEOUT, 1);
    curl_exec($Curl);
    curl_close($Curl);
}

function StorageBaiDuCloudLink($Type, $DownLoadLink, $UserAgent) {
    $Url = "https://127.0.0.1:9843/BaiDu/Parse/DataBase.php";

    $ServerMD5 = GetSubStr($DownLoadLink, "baidupcs.com/file/", "?bkt");

    $Data = json_encode(
        array(
            "Type" => 0,
            "ServerMD5" => $ServerMD5,
            "ParseType" => $Type,
            "Link" => $DownLoadLink,
            "UserAgent" => $UserAgent,
        )
    );

    $Header = array(
        "Host: api.kinh.cc",
        "User-Agent: Server;API;Expand"
    );

    $Curl = curl_init();
    curl_setopt($Curl, CURLOPT_URL, $Url);
    curl_setopt($Curl, CURLOPT_POST, true);
    curl_setopt($Curl, CURLOPT_POSTFIELDS, $Data);
    curl_setopt($Curl, CURLOPT_HTTPHEADER, $Header);
    curl_setopt($Curl, CURLOPT_RETURNTRANSFER, true);
    curl_setopt($Curl, CURLOPT_SSL_VERIFYPEER, false);
    curl_setopt($Curl, CURLOPT_SSL_VERIFYHOST, false);
    curl_setopt($Curl, CURLOPT_TIMEOUT, 1);
    curl_exec($Curl);
    curl_close($Curl);
}
