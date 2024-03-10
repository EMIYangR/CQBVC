<?php

require("../API/Expand.php");

$UserArray = explode(".", $_SERVER["HTTP_X_FORWARDED_FOR"]);
$UserIP = $UserArray[0] . $UserArray[1];

$Type = $_GET["Type"];
$Header_Share_Url = $_GET["Header_Share_Url"];
$Link = $_REQUEST["Link"];
$Code = $_POST["Code"];
?>
<!DOCTYPE html>
<html>

<head>
    <meta charset="utf-8">
    <title id="WebTitle">百度云盘在线解析</title>
    <meta name="viewport" content="width=device-width">
    <meta name="referrer" content="no-referrer">
    <link rel="icon" href="https://ae05.alicdn.com/kf/H45841aef355b407da2c4e66d99f13e07z.png">
    <link rel="stylesheet" href="https://cdn.staticfile.org/mdui/1.0.2/css/mdui.min.css">
    <link rel="stylesheet" href="https://cdn.staticfile.org/limonte-sweetalert2/11.4.14/sweetalert2.min.css">
    <link rel="stylesheet" href="https://api.kinh.cc/Static/CSS/MDUI.css">
    <script src="https://cdn.staticfile.org/mdui/1.0.2/js/mdui.min.js"></script>
    <script src="https://cdn.staticfile.org/limonte-sweetalert2/11.4.14/sweetalert2.min.js"></script>
    <script src="https://cdn.staticfile.org/jquery/3.6.0/jquery.min.js"></script>
    <script src="https://api.kinh.cc/Static/JavaScript/Base64.js"></script>
    <script src="https://api.kinh.cc/Static/JavaScript/Necessary.js"></script>
    <script src="https://api.kinh.cc/Static/JavaScript/LoadIng.js"></script>
    <script src="./JavaScript.js?Sha1=<? echo sha1_file("./JavaScript.js"); ?>"></script>

    <style>
        body {
            background-color: #eef1f5;
        }

        .List-Container {
            width: 96%;
            max-width: 2048px
        }
    </style>
</head>

<body class="mdui-appbar-with-toolbar mdui-theme-primary-indigo mdui-theme-accent-indigo">
    <script>
        GetIConJson()
    </script>

    <input id="FileLength" type="text" style="display:none" value="0"></input>

    <header class="mdui-appbar mdui-appbar-fixed">
        <div class="mdui-toolbar mdui-color-theme">
            <a href="./?Type=LinkParse" class="mdui-typo-headline" mdui-tooltip="{content:'百度云盘在线解析'}">百度云盘在线解析</a>
            <div class="mdui-toolbar-spacer"></div>
            <a href="./?Type=LinkParse" class="mdui-btn mdui-btn-icon"><i class="mdui-icon material-icons" mdui-tooltip="{content:'地址解析'}">link</i></a>
            <a href="./?Type=ParseList" class="mdui-btn mdui-btn-icon"><i class="mdui-icon material-icons" mdui-tooltip="{content:'解析列表'}">file_download</i></a>
            <a href="javascript:window.location.reload()" class="mdui-btn mdui-btn-icon"><i class="mdui-icon material-icons" mdui-tooltip="{content:'刷新'}">refresh</i></a>
        </div>
    </header>

    <?php
    if ($Type == "LinkParse") {
    ?>
        <div class="mdui-container mdui-p-t-3">
            <div class="mdui-card">
                <div class="mdui-card-content mdui-typo">
                    <div class="mdui-row-sm-1 mdui-row-lg-1" id="RecordClass">
                        <div style="margin-top:16px"></div>
                        <div id="RecordDiv"></div>

                        <div style="margin-top:16px"></div>
                        <div class="mdui-col">
                            <div class="mdui-card">
                                <div class="mdui-card-content">
                                    <div class="mdui-card-primary-title">解析</div>
                                    <div class="mdui-card-primary-subtitle">解析百度云盘分享地址</div>

                                    <div class="mdui-card-menu">
                                        <button class="mdui-btn mdui-color-red-400 mdui-ripple" mdui-tooltip="{content:'清理本地缓存'}" onclick="ClearCache()"><i class="mdui-icon mdui-icon-left material-icons">delete_forever</i>清理缓存</button>
                                    </div>
                                </div>

                                <div class="mdui-card-primary" style="padding-top: 8px;">
                                    <div class="mdui-textfield">
                                        <label class="mdui-textfield-label">分享地址</label>
                                        <input class="mdui-textfield-input" id="Link" type="text" value="<?php echo $Link; ?>" oninput="GetCode()"></input>
                                    </div>

                                    <div class="mdui-textfield" style="padding-top: 8px;">
                                        <label class="mdui-textfield-label">提取码</label>
                                        <input class="mdui-textfield-input" id="Code" type="text" value="<?php echo $Code; ?>"></input>
                                    </div>

                                    <div class="mdui-col" style="padding-top: 8px;padding-bottom: 8px;" mdui-tooltip="{content:'同意服务条款'}">
                                        <label class="mdui-checkbox"><input type="checkbox" id="TermsOfServiceInput"><i class="mdui-checkbox-icon"></i><a href="https://kinhdown.com/?Type=TOS">服务条款</a></label>
                                    </div>

                                    <button class="mdui-btn mdui-color-green-600 mdui-btn-block mdui-ripple" mdui-tooltip="{content:'解析百度云盘分享地址'}" onclick="LinkParse()"><i class="mdui-list-item-icon mdui-icon material-icons" style="margin-top:-2px">arrow_forward</i> 解析分享地址</button>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div style="height:16px"></div>
                </div>
            </div>
        </div>

        <script>
            document.getElementById("WebTitle").innerText = "百度云盘在线解析 | 地址解析"

            document.addEventListener("DOMContentLoaded", function() {
                ListRecord()
                LoadIng(false)
            })
        </script>
    <?php
    } else if ($Type == "FileList") {
    ?>
        <script>
            document.getElementById("WebTitle").innerText = "百度云盘在线解析 | 文件列表"
        </script>
        <?php

        if ($Link == "") {
        ?>
            <script>
                document.addEventListener(
                    "DOMContentLoaded",
                    function() {
                        LoadIng(false)

                        Swal.fire({
                            icon: "error",
                            title: "数据异常",
                            text: "请勿直接访问网页",
                            confirmButtonText: "返回首页",
                        }).then(
                            function() {
                                window.location.replace("./?Type=LinkParse")
                            }
                        )
                    }
                )
            </script>
        <?php
        } else {
        ?>
            <div class="mdui-container mdui-p-t-3 List-Container">
                <div class="mdui-row">
                    <div class="mdui-col mdui-col-xs-3" id="ShareData">
                        <div class="mdui-card">
                            <div class="mdui-card-primary">
                                <i class="mdui-list-item-icon mdui-icon material-icons" style="margin-top:-4px">account_circle</i><a style="margin-left:6px;font-weight:600">分享用户:<lua id="UserName"></lua></a>

                                <div style="margin:8px"></div>

                                <i class="mdui-list-item-icon mdui-icon material-icons" style="margin-top:-4px">date_range</i><a style="margin-left:6px;font-weight:600">分享时间:<lua id="ShareTime"></lua></a>

                                <div style="margin:8px"></div>

                                <i class="mdui-list-item-icon mdui-icon material-icons" style="margin-top:-4px">data_usage</i><a style="margin-left:6px;font-weight:600">有效期:<lua id="ShareExpiredTime"></lua></a>

                                <div style="height:4px"></div>
                            </div>
                        </div>
                    </div>

                    <div class="mdui-col mdui-col-xs-9" id="ListCol">
                        <div class="mdui-card">
                            <div class="mdui-card-content" id="ListPath"></div>
                        </div>

                        <div class="mdui-p-t-3">
                            <div class="mdui-card">
                                <div class="mdui-card-content">
                                    <div class="mdui-card-primary-title">文件列表</div>
                                    <div class="mdui-card-primary-subtitle" id="FileCountInfo"></div>
                                </div>

                                <div class="mdui-card-content" id="ListDiv">
                                    <div class="mdui-table-fluid">
                                        <table class="mdui-table mdui-table-selectable">
                                            <thead>
                                                <tr>
                                                    <th>图标</th>
                                                    <th>文件名</th>
                                                    <th>文件大小</th>
                                                    <th>创建时间</th>
                                                    <th>操作</th>
                                                </tr>
                                            </thead>

                                            <tbody id="List"></tbody>
                                        </table>
                                    </div>

                                    <br>

                                    <div id="OpenListButton"></div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <script>
                document.addEventListener(
                    "DOMContentLoaded",
                    function() {
                        var Link = "<?php echo $Link; ?>"
                        var Dir = localStorage.getItem("Dir_" + Link)
                        var Randsk = localStorage.getItem("Randsk_" + Link)

                        if (Dir == null) {
                            Dir = ""
                        }

                        if (Randsk == null) {
                            Randsk = ""
                        }

                        LinkList(Link, Dir, Randsk, 1)
                    }
                )
            </script>
        <?php
        }
    } else if ($Type == "ParseList") {
        ?>
        <div class="mdui-container mdui-p-t-3">
            <div class="mdui-card">
                <div class="mdui-card-primary">
                    <div class="mdui-card-primary-title">使用必看</div>
                    <div style="font-weight:600;margin-top:4px">1.每个列表解析的User-Agent都是不1样的！请每下载1次就重新复制1次！</div>
                    <div style="font-weight:600">2.极不推荐使用Aria2/Motrix下载成功率较低！IDM下载成功率非常高！</div>
                    <div style="font-weight:600">3.请勿在(浏览器/同IP下)打开两个以上本网站！否则可能无法解析！</div>
                    <div style="font-weight:600">4.3G以下文件可能会打包下载！下载完成后请查看文件名！绝对满速下载！</div>
                    <div style="font-weight:600">5.打包下载会含有3~5次断流！因为服务器正在打包文件！5~10秒后满速下载！</div>
                    <div style="font-weight:600">6.分享地址内只有1个文件！没有还有文件夹！满速下载几率将大大提高！</div>
                    <div style="font-weight:600">7.如你使用的是共享网络！例如：“校园网”可能下载失败！每个IP只能有8线程访问百度服务器！否则将无法下载或者下载速度极慢或403拒绝访问！</div>
                    <div style="font-weight:600">8.突破宽带限制！双线下载！宽带叠加！速度翻倍！条件:1.有IPV6 | 2.Aria2关闭禁用IPV6 | 3.亿点点运气</div>
                    <div style="font-weight:600">9.只可以1次下载1个文件！不可同时下载多个文件！否则会403拒绝访问！</div>
                    <div class="mdui-typo" style="font-weight:600;margin-top:12px">下载工具:<a href="https://kinhdown.com/?Type=APPS" target="_blank">https://kinhdown.com/?Type=APPS</a></div>
                    <div class="mdui-typo" style="font-weight:600">使用教程:<a href="https://kinhdown.com/?Type=Tutorials" target="_blank">https://kinhdown.com/?Type=Tutorials</a></div>
                </div>
            </div>
        </div>

        <div class="mdui-container mdui-p-t-3">
            <div class="mdui-card">
                <div class="mdui-card-content">
                    <div class="mdui-card-primary-title">解析列表</div>
                    <div class="mdui-card-primary-subtitle" id="TaskCount"></div>

                    <div class="mdui-card-menu">
                        <button class="mdui-btn mdui-color-green-600 mdui-ripple" mdui-tooltip="{content:'配置Aria2'}" onclick="SetAria2()"><i class="mdui-icon material-icons">cloud_done</i> 配置Aria2</button>
                        <button class="mdui-btn mdui-color-red-400 mdui-ripple" mdui-tooltip="{content:'清空解析任务列表'}" onclick="AllDelParse()"><i class="mdui-icon material-icons">delete</i>清空解析任务</button>
                        <button class="mdui-btn mdui-color-indigo mdui-ripple" mdui-tooltip="{content:'刷新解析任务列表'}" onclick="window.location.reload()"><i class="mdui-icon mdui-icon-left material-icons">refresh</i>刷新</button>
                    </div>

                </div>

                <div class="mdui-card-content" id="ListDiv">
                    <div class="mdui-table-fluid">
                        <table class="mdui-table mdui-table-selectable">
                            <thead>
                                <tr>
                                    <th>图标</th>
                                    <th>文件名</th>
                                    <th>文件大小</th>
                                    <th>状态</th>
                                    <th>完成时间</th>
                                    <th>操作</th>
                                </tr>
                            </thead>

                            <tbody id="List"></tbody>
                        </table>
                    </div>

                    <br>

                    <button class="mdui-btn mdui-color-indigo mdui-btn-block mdui-ripple" mdui-tooltip="{content:'多选文件发送到Aria2'}" onclick="PassAria2DownloadData_MultipleChoice()"><i class="mdui-list-item-icon mdui-icon material-icons">file_download</i> 多选文件发送到Aria2</button>
                </div>
            </div>
        </div>

        <div id="CycleTask_LinkScanning" style="display:none">0</div>

        <script>
            document.getElementById("WebTitle").innerText = "百度云盘在线解析 | 解析列表"

            document.addEventListener(
                "DOMContentLoaded",
                function() {
                    ParseList(true)
                    CycleTask_LinkScanning()
                }
            )
        </script>
    <?php
    } else {
        header("Location: ./?Type=LinkParse");
    }
    ?>

    <script>
        LoadIng(true, "正在加载数据", 220)

        document.addEventListener("DOMContentLoaded", function() {
            mdui.snackbar({
                position: "top",
                message: "如果遇到任何问题 | 清理缓存即可解决",
                buttonText: "清理缓存",
                onButtonClick: function() {
                    ClearCache()
                }
            })
        })
    </script>

    <div style="height:70px"></div>
    <footer class="mdui-typo">
        <!-- 2022-1-6 -->
        <p>Copyright © 2019 - 2022 <a style="font-weight:600" href="https://kinh.cc/" target="_blank">Kinh</a></p>
        <!-- 2022-1-6 -->
    </footer>

    <script>
        window.$crisp = [];
        window.CRISP_WEBSITE_ID = "2aa4b464-9d09-48be-bf41-762cae2ef51e";

        var DocumentVar = document;
        var JavaScript = DocumentVar.createElement("script");
        JavaScript.src = "https://client.crisp.chat/l.js";
        JavaScript.async = 1;

        DocumentVar.getElementsByTagName("head")[0].appendChild(JavaScript);
    </script>
</body>

</html>