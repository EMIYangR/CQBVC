window.onresize = function () {
    if (document.location.toString().indexOf("Type=FileList") != -1) {
        if (window.innerHeight > window.innerWidth) {
            document.getElementById("ShareData").setAttribute("class", "");
            document.getElementById("ListCol").setAttribute("class", "mdui-p-t-3");
        } else {
            document.getElementById("ShareData").setAttribute("class", "mdui-col mdui-col-xs-3");
            document.getElementById("ListCol").setAttribute("class", "mdui-col mdui-col-xs-9");
        }
    }
};

function GetCode() {
    var Link = document.getElementById("Link").value;
    var Code = Link.match(/提取码.? *(\w{4})/);
    if (Code == null && Link.indexOf("?pwd=") != -1) {
        Code = Link.substring(Link.indexOf("?pwd=") + 5, Link.indexOf("?pwd=") + 9);
        document.getElementById("Code").value = Code;
    } else if (Code != null) {
        document.getElementById("Code").value = Code[1];
    }
}

function LinkParse() {
    var Link = document.getElementById("Link").value;
    var Code = document.getElementById("Code").value;

    if (Code.length > 4) {
        document.getElementById("Code").focus();

        mdui.snackbar({
            position: "top",
            message: "密码错误",
        });
    } else {
        if (Link == null || Link == "") {
            document.getElementById("Link").focus();

            mdui.snackbar({
                position: "top",
                message: "请填写地址",
            });
        } else {
            if (Link.indexOf("baidu.com") == -1 && Link.substring(0, 1) != "1") {
                Link = "1" + Link;
            }

            if (Link.indexOf("/init?surl=") == -1) {
                Link = Link.match(/1[A-Za-z0-9-_]+/)[0];
            } else {
                Link = Link.match(/surl=([A-Za-z0-9-_]+)/)[0];
                Link = "1" + Link.replace("surl=", "");
            }

            if (Link == null || Link == "") {
                document.getElementById("Link").focus();

                mdui.snackbar({
                    position: "top",
                    message: "地址错误",
                });
            } else {
                LoadIng(true, "正在解析", 220);

                var Randsk = localStorage.getItem("LinkRecord_Randsk_" + Link);
                if (Randsk == null || Randsk == "") {
                    LoadIng(true, "正在获取Randsk", 220);

                    var Url = "https://api.kinh.cc/TMP/GetRandsk.php";

                    var Data = JSON.stringify({
                        Link: Link,
                        Code: Code,
                    });

                    $.ajax({
                        type: "post",
                        dataType: "json",
                        url: Url,
                        data: Data,
                        error: function () {
                            LoadIng(false);

                            Swal.fire({
                                icon: "error",
                                title: "网络异常",
                                confirmButtonText: "刷新",
                            }).then(function () {
                                window.location.reload();
                            });
                        },
                        success: function (Result) {
                            var Status = Result.Status;
                            if (Status == 0 || Status == 143) {
                                Title = Result.Title;

                                localStorage.setItem("LinkRecord_Link_" + Link, Link);
                                localStorage.setItem("LinkRecord_Title_" + Link, Title);

                                if (Status == 0) {
                                    Randsk = Result.Randsk;
                                    localStorage.setItem("Randsk_" + Link, Randsk);
                                    localStorage.setItem("LinkRecord_Randsk_" + Link, Randsk);
                                    if (Code != "" && Code != null) {
                                        localStorage.setItem("LinkRecord_Code_" + Link, Code);
                                    }
                                }

                                LoadIng(true, "正在重定向到文件列表", 220);
                                Post_FileList(Link);
                            } else if (Status == 33) {
                                LoadIng(false);

                                Swal.fire({
                                    icon: "error",
                                    title: "密码错误",
                                    confirmButtonText: "关闭",
                                });
                            } else if (Status == 338) {
                                LoadIng(false);

                                Swal.fire({
                                    icon: "warning",
                                    title: "请输入提取码",
                                    confirmButtonText: "关闭",
                                });
                            } else if (Status == 315) {
                                LoadIng(false);

                                Swal.fire({
                                    icon: "error",
                                    title: "标题获取失败",
                                    confirmButtonText: "关闭",
                                });
                            } else if (Status == 6) {
                                LoadIng(false);

                                Swal.fire({
                                    icon: "error",
                                    title: "未知错误",
                                    confirmButtonText: "关闭",
                                });
                            }
                        },
                    });
                } else {
                    LoadIng(true, "正在重定向到文件列表", 220);
                    Post_FileList(Link);
                }
            }
        }
    }
}

function Post_FileList(Link) {
    var TermsOfServiceInput = document.getElementById("TermsOfServiceInput").checked;
    if (TermsOfServiceInput == false) {
        LoadIng(false);

        Swal.fire({
            icon: "warning",
            title: "请阅读服务条款",
            text: "必须阅读完全部服务条款才可以同意服务条款",
            confirmButtonText: "阅读服务条款",
            denyButtonText: "关闭",
            showDenyButton: true,
        }).then(function (Result) {
            if (Result.isConfirmed) {
                window.open("https://kinhdown.com/?Type=TOS");
            }
        });
    } else {
        var form = $('<form method="post" action="./?Type=FileList"></form>');
        form.append(`<input type="hidden" name="Link" value="${Link}">`);
        $(document.body).append(form);
        form.submit();
    }
}

function ListRecord() {
    var TrueLength = 0;

    var HTMLCode = "<div class='mdui-col'><div class='mdui-card'><div class='mdui-card-content'><div class='mdui-card-primary-title'>历史记录</div><div class='mdui-card-primary-subtitle'>解析分享地址历史记录</div><div class='mdui-card-menu'><button class='mdui-btn mdui-color-red-400 mdui-ripple'mdui-tooltip='{content:&quot;清空历史记录列表&quot;}'onclick='AllDelRecord()'><i class='mdui-icon material-icons'>delete</i>清空历史记录</button><button class='mdui-btn mdui-color-indigo mdui-ripple'mdui-tooltip='{content:&quot;刷新历史记录列表&quot;}'onclick='window.location.reload()'><i class='mdui-icon mdui-icon-left material-icons'>refresh</i>刷新</button></div></div><div class='mdui-card-primary'><div class='mdui-table-fluid'><table class='mdui-table'><th>标题</th><th>分享地址</th><th>操作</th>";

    for (var i = 0; i < localStorage.length; i++) {
        var Data = localStorage.key(i);
        if (Data != null && Data.indexOf("LinkRecord_Link_") != -1) {
            TrueLength++;

            Link = Data.substring(16, Data.length);
            var Code = localStorage.getItem("LinkRecord_Code_" + Link);
            if (IsNull(Code) == true) {
                Code = "";
            }

            var Title = localStorage.getItem("LinkRecord_Title_" + Link);

            HTMLCode = HTMLCode + "<tr><td>" + Title + "</td><td>" + Link + '</td><td><button class="mdui-btn mdui-btn-icon" mdui-tooltip="{content:&quot;删除记录&quot;}" onclick="DelRecord(' + "'" + Link + "'" + ')"><i class="mdui-icon material-icons">delete</i></button><button class="mdui-btn mdui-btn-icon" mdui-tooltip="{content:&quot;填充地址&quot;}" onclick="Filling(' + "'" + Link + "','" + Code + "'" + ')"><i class="mdui-icon material-icons">content_paste</i></button></td></tr>';
        }
    }

    if (TrueLength != 0) {
        document.getElementById("RecordClass").setAttribute("class", "mdui-row-sm-2 mdui-row-lg-2");
        HTMLCode = HTMLCode + "</table></div></div></div></div>";
        document.getElementById("RecordDiv").innerHTML = HTMLCode;
    }
}

function AllDelRecord() {
    LoadIng(true, "正在清空历史记录", 220);

    for (var i = 0; i < localStorage.length; i++) {
        if (i == 0) {
            var Data = localStorage.key(0);
        } else {
            var Data = localStorage.key(localStorage.length - i);
        }

        if (Data != null && Data.indexOf("LinkRecord_Link_") != -1) {
            Link = Data.substring(16, Data.length);
            localStorage.removeItem("LinkRecord_Link_" + Link);
            localStorage.removeItem("LinkRecord_Code_" + Link);
            localStorage.removeItem("LinkRecord_Randsk_" + Link);
            localStorage.removeItem("LinkRecord_Title_" + Link);
        }
    }

    window.location.reload();
}

function DelRecord(Link) {
    localStorage.removeItem("LinkRecord_Link_" + Link);
    localStorage.removeItem("LinkRecord_Code_" + Link);
    localStorage.removeItem("LinkRecord_Randsk_" + Link);
    localStorage.removeItem("LinkRecord_Title_" + Link);

    LoadIng(true, "正在删除历史记录", 220);
    window.location.reload();
}

function Filling(Link, Code) {
    document.getElementById("Link").value = Link;
    document.getElementById("Code").value = Code;
}

function GetTokenTime() {
    var date = new Date();
    var Y = date.getFullYear();
    var M = ZeroFill(date.getMonth() + 1);
    var D = ZeroFill(date.getDate());
    return Y + "-" + M + "-" + D;
}

function ZeroFill(i) {
    if (i >= 0 && i <= 9) {
        return "0" + i;
    } else {
        return i;
    }
}

function GetRequestToken(Link) {
    var TokenName = "Token_" + GetTokenTime() + "_" + Link;
    var Token = localStorage.getItem(TokenName);
    return Token;
}

function LinkList(Link, Dir, Randsk, Page) {
    LoadIng(true, "正在解析文件列表", 220);

    var Token = GetRequestToken(Link);

    var Url = "https://api.kinh.cc/TMP/List.php";

    var Data = JSON.stringify({
        Link: Link,
        Token: Token,
        Randsk: Randsk,
        Base64Dir: new Base64().encode(Dir),
        Page: Page,
    });

    $.ajax({
        type: "post",
        dataType: "json",
        url: Url,
        data: Data,
        error: function () {
            LoadIng(false);

            Swal.fire({
                icon: "error",
                title: "网络异常",
                confirmButtonText: "刷新",
            }).then(function () {
                window.location.reload();
            });
        },
        success: function (Result) {
            var Status = Result.Status;
            if (Status == 0) {
                localStorage.setItem("Dir_" + Link, Dir);
                var FileLength = Result.List.length;

                if (FileLength == 0) {
                    LoadIng(false);
                } else {
                    var ListPath = "<button class='mdui-btn btn mdui-btn-dense mdui-color-blue-accent' mdui-tooltip='{content:&quot;全部文件&quot;}' onclick='LinkList(" + '"' + Link + '","' + "" + '","' + Randsk + '",1' + ")'><i class='mdui-list-item-icon mdui-icon material-icons' style='margin-top:-4px'>home</i> 全部文件</button>";

                    var DirArray = Dir.split("/");
                    var DirArray_Length = DirArray.length;

                    if (Dir == "") {
                        var ShieldDir = Result.ShieldDir;
                        localStorage.setItem("ShieldDir_" + Link, ShieldDir);
                    } else {
                        var ShieldDir = localStorage.getItem("ShieldDir_" + Link);
                    }

                    for (var i = 1; i < DirArray_Length; i++) {
                        if (i == DirArray_Length - 1) {
                            var Color = "mdui-color-green-600";
                        } else {
                            var Color = "mdui-color-indigo-accent";
                        }

                        var Name = DirArray[i];
                        Path = Dir.substring(0, Dir.indexOf(Name)) + Name;
                        if (Path != ShieldDir) {
                            ListPath = ListPath + "<i class='mdui-icon material-icons'>keyboard_arrow_right</i><button class='mdui-btn btn mdui-btn-dense " + Color + "' mdui-tooltip='{content:&quot;打开=>" + Path + "&quot;}' onclick='LinkList(" + '"' + Link + '","' + Path + '","' + Randsk + '",1' + ")'>" + Name + "</button>";
                        }
                    }

                    if (document.getElementById("ListData") == null || Page == 1) {
                        var List = "";
                    } else {
                        var List = document.getElementById("ListData").innerHTML;
                    }

                    var File_Count = 0;
                    var Folder_Count = 0;

                    var Code = localStorage.getItem("LinkRecord_Code_" + Link);

                    var ShareID = Result.ShareID;
                    var UserUK = Result.UserUK;
                    var OneFile = Result.OneFile;

                    for (var i = 0; i < FileLength; i++) {
                        var File_Name = Result.List[i].Name;
                        var File_Size = Result.List[i].Size;
                        var File_Time = Result.List[i].Time;
                        var File_Path = Result.List[i].Path;
                        var File_PCS = Result.List[i].PCS;
                        var File_PCSPath = Result.List[i].PCSPath;
                        var File_MD5 = Result.List[i].MD5;
                        var File_ID = Result.List[i].ID;
                        var File_Category = Result.List[i].Category;
                        var File_Thumbs = Result.List[i].Thumbs;

                        if (File_PCS == null) {
                            File_PCS = "";
                        } else if (File_PCS.indexOf("d.pcs.baidu.com") != -1) {
                            var DownLoad_Data_Array = {};
                            DownLoad_Data_Array["Link"] = Link;
                            DownLoad_Data_Array["Code"] = Code;
                            DownLoad_Data_Array["Randsk"] = Randsk;
                            DownLoad_Data_Array["ShareID"] = ShareID;
                            DownLoad_Data_Array["UserUK"] = UserUK;
                            DownLoad_Data_Array["Base64Name"] = new Base64().encode(File_Name);
                            DownLoad_Data_Array["Size"] = File_Size;
                            DownLoad_Data_Array["ID"] = File_ID;
                            DownLoad_Data_Array["Base64Path"] = new Base64().encode(File_Path);
                            DownLoad_Data_Array["PCS"] = File_PCS;
                            DownLoad_Data_Array["PCSPath"] = File_PCSPath;
                            DownLoad_Data_Array["MD5"] = File_MD5;
                            DownLoad_Data_Array["OneFile"] = OneFile;

                            DownLoad_Data_Json = JSON.stringify(DownLoad_Data_Array);
                            DownLoad_Data_Base64 = new Base64().encode(DownLoad_Data_Json);
                        }

                        if (Result.List[i].Type == 0) {
                            File_Count++;

                            var IConSVG = GetICon(File_Name.split(".").pop(), false);

                            var Button = '<button class="mdui-btn mdui-btn-icon" mdui-tooltip="{content:&quot;下载文件&quot;}" onclick="DownLoad(' + "'" + File_MD5 + "','" + DownLoad_Data_Base64 + "',true" + ')"><i class="mdui-icon material-icons">file_download</i></button>';

                            var File_Size = SizeFormat(File_Size);
                            var CheckboxData = "File|MD5=" + File_MD5 + "|Data=" + DownLoad_Data_Base64;
                        } else {
                            var Folder_Data_Array = {};
                            Folder_Data_Array["Link"] = Link;
                            Folder_Data_Array["Code"] = Code;
                            Folder_Data_Array["Randsk"] = Randsk;
                            Folder_Data_Array["Path"] = File_Path;

                            Folder_Data_Json = JSON.stringify(Folder_Data_Array);
                            Folder_Data_Base64 = new Base64().encode(Folder_Data_Json);

                            Folder_Count++;

                            var IConSVG = GetICon(File_Name, true);

                            var Button = '<button class="mdui-btn mdui-btn-icon" mdui-tooltip="{content:&quot;打开[' + File_Name + ']文件夹&quot;}" onclick="LinkList(' + "'" + Link + "','" + File_Path + "','" + Randsk + "',1" + ')"><i class="mdui-icon material-icons">launch</i></button><button class="mdui-btn mdui-btn-icon" mdui-tooltip="{content:&quot;下载文件夹&quot;}" onclick="LoadIng(true,&quot;正在扫描文件夹&quot;,220);ScanningFolder(' + "'" + Link + "','" + Code + "','" + File_Path + "','" + Randsk + "'" + ',1).then(function() {LoadIng(false);mdui.snackbar({position:&quot;top&quot;,message:&quot;已加入解析列表&quot;,buttonText:&quot;查看解析列表&quot;,onButtonClick: function() {window.location.replace(&quot;./?Type=ParseList&quot;)}});})"><i class="mdui-icon material-icons">file_download</i></button>';
                            var File_Size = "---:---:---";
                            var CheckboxData = "Folder|Path=" + File_Path + "|Data=" + Folder_Data_Base64;
                        }

                        List += '<tr value="' + CheckboxData + '" id="checkbox_' + i + '" ><td style="padding-bottom: 0px;padding-top: 8px">' + IConSVG + "</td><td>" + File_Name + "</td><td>" + File_Size + "</td><td>" + TimeDate(File_Time) + "</td><td>" + Button + "</td></tr>";
                    }

                    var OpenListButton = "<button class='mdui-btn mdui-color-indigo mdui-btn-block mdui-ripple' mdui-tooltip='{content:&quot;多选文件下载&quot;}' onclick='DownLoad_MultipleChoice()'><i class='mdui-list-item-icon mdui-icon material-icons'>file_download</i> 多选文件下载</button>";

                    if (FileLength == 100) {
                        var SetPage = Number(Result.Page) + 1;

                        OpenListButton += "<br><button class='mdui-btn mdui-color-deep-purple-accent mdui-btn-block mdui-ripple' mdui-tooltip='{content:&quot;加载更多文件&quot;}' onclick='LinkList(" + '"' + Link + '","' + Dir + '","' + Randsk + '",' + SetPage + ")'><i class='mdui-list-item-icon mdui-icon material-icons'>all_inclusive</i> 加载更多文件</button>";
                    }

                    var FileCountInfo = FileLength + "个文件类型 | " + Folder_Count + "个文件夹 | " + File_Count + "个文件";

                    if (Result.ShareExpiredType == 0) {
                        var ShareExpiredTime = "永久有效";
                    } else {
                        var ShareExpiredTime = Result.ShareExpiredType + "天";
                    }

                    document.getElementById("UserName").innerText = Result.UserName;
                    document.getElementById("ShareTime").innerText = TimeDate(Result.ShareTime);
                    document.getElementById("ShareExpiredTime").innerText = ShareExpiredTime;

                    document.getElementById("ListPath").innerHTML = ListPath;
                    document.getElementById("FileCountInfo").innerHTML = FileCountInfo;
                    document.getElementById("List").innerHTML = List;
                    document.getElementById("OpenListButton").innerHTML = OpenListButton;

                    document.getElementById("FileLength").value = FileLength;

                    if (FileLength == 200) {
                        var Length = document.getElementsByClassName("mdui-table-cell-checkbox").length;
                        document.getElementsByClassName("mdui-table-cell-checkbox")[Length - 1].innerHTML = "";
                    }

                    document.getElementById("ListDiv").innerHTML += "";

                    try {
                        mdui.mutation();
                    } catch (Error) {
                        console.log("mdui.mutation()", Error);
                    }

                    LoadIng(false);
                }
            } else if (Status == 18) {
                LoadIng(false);

                Swal.fire({
                    icon: "error",
                    title: "数据缺失",
                    confirmButtonText: "返回首页",
                }).then(function () {
                    window.location.replace("./?Type=LinkParse");
                });
            } else if (Status == 2) {
                LoadIng(false);

                Swal.fire({
                    icon: "error",
                    title: "验证错误",
                    text: "人机身份验证过期",
                    confirmButtonText: "返回首页",
                }).then(function () {
                    localStorage.removeItem((TokenName = "Token_" + GetTokenTime() + "_" + Link));
                    window.location.replace("./?Type=LinkParse");
                });
            } else if (Status == 149) {
                LoadIng(false);

                Swal.fire({
                    icon: "error",
                    title: "IP校验错误",
                    confirmButtonText: "刷新",
                }).then(function () {
                    window.location.reload();
                });
            } else if (Status == 30) {
                LoadIng(false);

                Swal.fire({
                    icon: "error",
                    title: "资源不存在",
                    text: "地址错误",
                    confirmButtonText: "返回首页",
                }).then(function () {
                    window.location.replace("./?Type=LinkParse");
                });
            } else if (Status == 233) {
                LoadIng(false);

                Swal.fire({
                    icon: "error",
                    title: "目录不存在",
                    confirmButtonText: "返回全部文件",
                }).then(function () {
                    LinkList(Link, "", Randsk, 1);
                });
            } else if (Status == 235) {
                LoadIng(false);

                Swal.fire({
                    icon: "error",
                    title: "非法文件资源禁止访问",
                    confirmButtonText: "返回首页",
                }).then(function () {
                    window.location.replace("./?Type=LinkParse");
                });
            } else if (Status == 29) {
                LoadIng(false);

                Swal.fire({
                    icon: "error",
                    title: "资源已被删除",
                    confirmButtonText: "返回首页",
                }).then(function () {
                    window.location.replace("./?Type=LinkParse");
                });
            } else if (Status == 234) {
                LoadIng(false);

                Swal.fire({
                    icon: "error",
                    title: "资源已过期",
                    confirmButtonText: "返回首页",
                }).then(function () {
                    window.location.replace("./?Type=LinkParse");
                });
            } else if (Status == 6) {
                LoadIng(false);

                Swal.fire({
                    icon: "error",
                    title: "无法解析地址",
                    text: "可能是服务器问题有可能是地址不可用",
                    confirmButtonText: "刷新",
                    denyButtonText: "返回首页",
                    showDenyButton: true,
                }).then(function (Result) {
                    if (Result.isConfirmed) {
                        window.location.reload();
                    } else {
                        window.location.replace("./?Type=LinkParse");
                    }
                });
            }
        },
    });
}

function DownLoad(MD5, Data, Snackbar) {
    var localStorage_Data = localStorage.getItem("LinkData_MD5_" + MD5);

    if (localStorage_Data == null) {
        localStorage.setItem("LinkData_MD5_" + MD5, new Base64().decode(Data));
    }

    if (Snackbar == true) {
        mdui.snackbar({
            position: "top",
            message: "已加入解析列表",
            buttonText: "查看解析列表",
            onButtonClick: function () {
                window.location.replace("./?Type=ParseList");
            },
        });
    }
}

function DownLoad_MultipleChoice() {
    var FileLengthData = document.getElementById("FileLength").value;

    var State = 0;

    for (var i = 0; i < FileLengthData; i++) {
        if (State == 0) {
            var Data = document.getElementById("checkbox_" + i).outerHTML;
            if (Data.indexOf('class="mdui-table-row-selected"') != -1) {
                Data = Data.substring(11, Data.indexOf('" id="checkbox_'));
                if (Data.indexOf("Folder|Path=") == -1) {
                    var MD5 = Data.substring(9, Data.indexOf("|Data="));
                    if (MD5.length == 32) {
                        var Data = Data.substring(47, Data.length);
                        DownLoad(MD5, Data, false);
                    } else {
                        State = 1;
                        Swal.fire({
                            icon: "error",
                            title: "数据异常 - 添加终止(请清理缓存)",
                            text: Data,
                            confirmButtonText: "终止",
                        });

                        return false;
                    }
                } else {
                    LoadIng(true, "正在扫描文件夹", 220);

                    var JsonData = JSON.parse(new Base64().decode(Data.substring(Data.indexOf("|Data=") + 6, Data.length)));
                    var Link = JsonData["Link"];
                    var Code = JsonData["Code"];
                    var Dir = JsonData["Path"];
                    var Randsk = JsonData["Randsk"];

                    ScanningFolder(Link, Code, Dir, Randsk, 1).then(function () {
                        LoadIng(false);
                    });

                    return false;
                }
            }
        }
    }

    mdui.snackbar({
        position: "top",
        message: "已加入解析列表",
        buttonText: "查看解析列表",
        onButtonClick: function () {
            window.location.replace("./?Type=ParseList");
        },
    });
}

function ScanningFolder(Link, Code, Dir, Randsk, Page) {
    return new Promise(function (TerminateReturn) {
        var Url = "https://api-pan-baidu.kinh.cc/share/wxlist";
        var Data = "clienttype=25&num=100&shorturl=" + Link + "&dir=" + encodeURIComponent(Dir) + "&sekey=" + encodeURIComponent(Randsk) + "&page=" + Page;

        $.ajax({
            type: "post",
            dataType: "json",
            url: Url,
            data: Data,
            error: function (Error) {
                console.log("ScanningFolder", Link, Dir, Randsk, Page, Error);
                TerminateReturn();
            },
            success: async function (Result) {
                var Count = Result["data"]["list"].length;
                var ShareID = Result["data"]["shareid"];
                var UserUK = Result["data"]["uk"];

                for (var Index = 0; Index < Count; Index++) {
                    var File_Path = Result["data"]["list"][Index]["path"];
                    if (Result["data"]["list"][Index]["isdir"] == "0") {
                        var File_Name = Result["data"]["list"][Index]["server_filename"];
                        var File_Size = Result["data"]["list"][Index]["size"];
                        var File_ID = Result["data"]["list"][Index]["fs_id"];
                        var File_PCS = Result["data"]["list"][Index]["dlink"];
                        File_PCS = File_PCS.replace("http://", "https://");
                        var File_PCSPath = Result["data"]["list"][Index]["dlink"];
                        File_PCSPath = File_PCSPath.replace("?fid=", "&fid=");
                        File_PCSPath = File_PCSPath.substring(28, File_PCSPath.length);
                        var File_MD5 = Result["data"]["list"][Index]["md5"];

                        var DownLoad_Data_Array = {};
                        DownLoad_Data_Array["Link"] = Link;
                        DownLoad_Data_Array["Code"] = Code;
                        DownLoad_Data_Array["Randsk"] = Randsk;
                        DownLoad_Data_Array["ShareID"] = ShareID;
                        DownLoad_Data_Array["UserUK"] = UserUK;
                        DownLoad_Data_Array["Base64Name"] = new Base64().encode(File_Name);
                        DownLoad_Data_Array["Size"] = File_Size;
                        DownLoad_Data_Array["ID"] = File_ID;
                        DownLoad_Data_Array["Base64Path"] = new Base64().encode(File_Path);
                        DownLoad_Data_Array["PCS"] = File_PCS;
                        DownLoad_Data_Array["PCSPath"] = File_PCSPath;
                        DownLoad_Data_Array["MD5"] = File_MD5;
                        DownLoad_Data_Array["OneFile"] = false;

                        DownLoad_Data_Json = JSON.stringify(DownLoad_Data_Array);
                        DownLoad_Data_Base64 = new Base64().encode(DownLoad_Data_Json);
                        DownLoad(File_MD5, DownLoad_Data_Base64, false);
                    } else {
                        await ScanningFolder(Link, Code, File_Path, Randsk, 1);
                    }
                }

                if (Count == 99) {
                    await ScanningFolder(Link, Code, Dir, Randsk, 2);
                }

                TerminateReturn();
            },
        });
    });
}

function ParseList() {
    var TaskCount = 0;
    var List = "";

    for (var i = 0; i < localStorage.length; i++) {
        var Data = localStorage.key(i);
        if (Data != null && Data.indexOf("LinkData_MD5_") != -1) {
            TaskCount++;

            var MD5 = Data.substring(13, Data.length);

            var Data = localStorage.getItem("LinkData_MD5_" + MD5);
            var JsonData = JSON.parse(Data);

            var Name = new Base64().decode(JsonData["Base64Name"]);
            var Size = JsonData["Size"];

            var DelButton = '<button class="mdui-btn mdui-btn-icon" mdui-tooltip="{content:&quot;删除任务&quot;}" onclick="EmptyDownLoadData(' + "'" + MD5 + "'" + ',true)"><i class="mdui-icon material-icons">delete</i></button>';
            var ButtonDiv = '<div id="Button_' + MD5 + '">' + DelButton + "</div>";

            if (MD5.length == 32) {
                Info = "等待查询";
            } else {
                Info = "数据异常 - 拒绝解析(请清理缓存)";
            }

            var Extension = Name.split(".").pop();
            var IConSVG = GetICon(Extension);

            List = List + '<tr><td style="padding-bottom: 0px;padding-top: 8px">' + IConSVG + '</td><td id="Name_' + MD5 + '">' + Name + "</td><td>" + SizeFormat(Size) + '</td><td id="Status_' + MD5 + '">' + Info + '<td id="Time_' + MD5 + '">未完成</td><td>' + ButtonDiv + "</td></td>";
        }
    }

    document.getElementById("TaskCount").innerText = TaskCount + "个任务";
    document.getElementById("List").innerHTML = List;

    document.getElementById("ListDiv").innerHTML += "";

    try {
        mdui.mutation();
    } catch (Error) {
        console.log("mdui.mutation()", Error);
    }

    LoadIng(false);
}

function AllDelParse() {
    LoadIng(true, "正在获取解析列表", 220);

    var Count = localStorage.length;
    for (var i = 0; i < Count; i++) {
        if (i == 0) {
            var Data = localStorage.key(0);
        } else {
            var Data = localStorage.key(Count - i);
        }

        if (Data != null) {
            if (Data.indexOf("LinkData_MD5_") != -1 || Data.indexOf("DownLoadData_MD5_") != -1 || Data.indexOf("FileMD5Data_") != -1) {
                localStorage.removeItem(Data);
                AllDelParse();
                return;
            }
        }

        if (i == Count - 1) {
            window.location.reload();
        }
    }
}

async function CycleTask_LinkScanning() {
    if (document.getElementById("CycleTask_LinkScanning").innerText == 0) {
        var Result = await LinkScanning();
        if (Result == 0) {
            document.getElementById("CycleTask_LinkScanning").innerText = 1;
        } else if (Result == 1) {
            document.getElementById("CycleTask_LinkScanning").innerText = 0;
        }

        CycleTask_LinkScanning();
    } else {
        setTimeout(async function () {
            await LinkScanning();
            CycleTask_LinkScanning();
        }, 30000);
    }
}

function LinkScanning() {
    return new Promise(async function (TerminateReturn) {
        var BaiDuToken = localStorage.getItem("BaiDuToken");
        if (BaiDuToken == null) {
            BaiDuToken = "";
        }

        for (var i = 0; i < localStorage.length; i++) {
            var Data = localStorage.key(i);
            if (Data != null && Data.indexOf("LinkData_MD5_") != -1) {
                var MD5 = Data.substring(13, Data.length);
                if (MD5.length == 32 && document.getElementById("Status_" + MD5) != null) {
                    var DownLoadData = localStorage.getItem("DownLoadData_MD5_" + MD5);
                    var Key = localStorage.getItem("Key");
                    var AFDianToken = GetCookie("AFDianToken");
                    if ((Key == null || Key == "") && (AFDianToken == null || AFDianToken == "")) {
                        await TriggerInputPassWord();
                        TerminateReturn(1);
                    } else {
                        if (DownLoadData == null) {
                            var Data = localStorage.getItem("LinkData_MD5_" + MD5);
                            var JsonData = JSON.parse(Data);

                            var FileMD5Data = localStorage.getItem("FileMD5Data_" + MD5);
                            if (FileMD5Data == "" || FileMD5Data == null) {
                                localStorage.setItem("FileMD5Data_" + MD5, '{"Status":0,"Name":"0","Size":"0","ServerMD5":"0","MD5":"0","MD5256K":"0","Time":0}');
                                TerminateReturn(1);

                                break;
                            } else {
                                var FileMD5JsonData = JSON.parse(FileMD5Data);
                                var FileMD5 = FileMD5JsonData["MD5"];
                                var FileMD5256K = FileMD5JsonData["MD5256K"];
                                var FileSize = FileMD5JsonData["Size"];
                                var Token = GetRequestToken(JsonData["Link"]);

                                var Url = "https://api.kinh.cc/BaiDu/Parse/Web.php";

                                var JsonData = JSON.parse(Data);
                                JsonData["Key"] = Key;
                                JsonData["FileMD5"] = FileMD5;
                                JsonData["FileMD5256K"] = FileMD5256K;
                                JsonData["FileSize"] = FileSize;
                                JsonData["BaiDuToken"] = BaiDuToken;
                                JsonData["Token"] = Token;
                                JsonData["AFDianToken"] = AFDianToken;
                                var Data = JSON.stringify(JsonData);

                                document.getElementById("Status_" + MD5).innerHTML = "正在获取下载地址";

                                $.ajax({
                                    type: "post",
                                    dataType: "json",
                                    url: Url,
                                    data: Data,
                                    error: function () {
                                        document.getElementById("Status_" + MD5).innerHTML = "请求错误";
                                        TerminateReturn(0);
                                    },
                                    success: async function (Result) {
                                        var Status = Result.Status;

                                        if (Status == 0) {
                                            localStorage.setItem("DownLoadData_MD5_" + MD5, JSON.stringify(Result));
                                            document.getElementById("Status_" + MD5).innerHTML = "生成下载链接成功 - 等等刷新任务列表";
                                            TerminateReturn(1);
                                        } else if (Status == 2) {
                                            document.getElementById("Status_" + MD5).innerHTML = "身份验证失败或过期";
                                            TerminateReturn(0);
                                        } else if (Status == 149) {
                                            document.getElementById("Status_" + MD5).innerHTML = "IP校验错误";
                                            TerminateReturn(0);
                                        } else if (Status == 135) {
                                            document.getElementById("Status_" + MD5).innerHTML = "无法获取IP地址";
                                            TerminateReturn(0);
                                        } else if (Status == 139) {
                                            Swal.fire({
                                                icon: "warning",
                                                title: "地区发生变化",
                                                text: "一人一个(口令/密钥/激活码) | 不可分享给他人使用 | 不可更换(口令/密钥/激活码)首次使用地",
                                                confirmButtonText: "重新输入(口令/密钥/激活码)",
                                            }).then(async function () {
                                                await TriggerInputPassWord();
                                                TerminateReturn(1);
                                            });
                                        } else if (Status == 15 || Status == 341) {
                                            await TriggerInputPassWord();
                                            TerminateReturn(1);
                                        } else {
                                            document.getElementById("Status_" + MD5).innerHTML = "获取下载地址失败";
                                            TerminateReturn(0);
                                        }
                                    },
                                });

                                break;
                            }
                        } else {
                            var JsonData = JSON.parse(DownLoadData);
                            var DownLoadLink = JsonData["DownLoadLink"];
                            var UserAgent = JsonData["UserAgent"];
                            var Time = JsonData["Time"];
                            var Direct = JsonData["Direct"];
                            var Name = document.getElementById("Name_" + MD5).innerHTML;

                            document.getElementById("Time_" + MD5).innerHTML = TimeDate(Time);

                            var DelButton = '<button class="mdui-btn mdui-btn-icon" mdui-tooltip="{content:&quot;删除任务&quot;}" onclick="EmptyDownLoadData(' + "'" + MD5 + "'" + ',true)"><i class="mdui-icon material-icons">delete</i></button>';

                            if (Date.now() / 1000 - 28800 > Time) {
                                document.getElementById("Status_" + MD5).innerHTML = "地址过期";
                                var Button = "";
                            } else {
                                document.getElementById("Status_" + MD5).innerHTML = "获取下载地址成功";

                                var Button = GetHTMLCodeParseListButton(Name, DownLoadLink, UserAgent, MD5, Direct);
                            }

                            document.getElementById("Button_" + MD5).innerHTML = DelButton + Button;
                        }
                    }
                }
            }
        }
    });
}

function TriggerInputPassWord() {
    return new Promise(function (TerminateReturn) {
        Swal.fire({
            icon: "error",
            title: "口令",
            text: "不存在或已过期",
            confirmButtonText: "输入口令",
        }).then(function () {
            Swal.fire({
                title: "请输入下载口令",
                text: "免费领取口令 https://kinhdown.com/?Type=Help",
                imageUrl: "https://ae05.alicdn.com/kf/U1bb58c2805af44278142e25f6eebe95ey.gif",
                input: "password",
                confirmButtonText: "提交",
                denyButtonText: "关闭",
                showDenyButton: true,
            }).then(function (password) {
                if (password.isConfirmed) {
                    localStorage.setItem("Key", password.value);
                    TerminateReturn();
                } else {
                    TerminateReturn();
                }
            });
        });
    });
}

function GetHTMLCodeParseListButton(Name, DownLoadLink, UserAgent, MD5, Direct) {
    var Button = '<button class="mdui-btn mdui-btn-icon" mdui-tooltip="{content:' + "'复制下载地址'" + '}" onclick="DocumentCopyText(' + "'" + DownLoadLink + "'" + ");mdui.snackbar({position:" + "'top'" + ",message:" + "'复制成功'" + '})"><i class="mdui-icon material-icons">link</i></button><button class="mdui-btn mdui-btn-icon" mdui-tooltip="{content:' + "'复制User-Agent'" + '}" onclick="DocumentCopyText(' + "'" + UserAgent + "'" + ");mdui.snackbar({position:" + "'top'" + ",message:" + "'复制成功'" + '})"><i class="mdui-icon material-icons">vpn_key</i></button><button class="mdui-btn mdui-btn-icon" mdui-tooltip="{content:' + "'发送到Aria2'" + '}" onclick="LoadIng(true,' + "'正在发送的Aria2下载引擎'" + ",240);PassAria2DownloadData(" + "'" + MD5 + "','" + Name + "','" + DownLoadLink + "','" + UserAgent + "'" + ').then(function () {LoadIng(false)})"><i class="mdui-icon material-icons">cloud_download</i></button><button class="mdui-btn mdui-btn-icon" mdui-tooltip="{content:&quot;复制文件MD5&quot;}" onclick="DocumentCopyText(JSON.parse(localStorage.getItem(' + "'FileMD5Data_" + MD5 + "'" + "))[" + "'MD5'" + "]);mdui.snackbar({position:" + "'top'" + ",message:" + "'复制成功'" + '})"><i class="mdui-icon material-icons">https</i></button><button class="mdui-btn mdui-btn-icon" mdui-tooltip="{content:' + "'复制文件特征码'" + '}" onclick="CopyFileSignature(' + "'" + MD5 + "'" + ')"><i class="mdui-icon material-icons">all_inclusive</i></button><button class="mdui-btn mdui-btn-icon" mdui-tooltip="{content:&quot;重新解析下载地址&quot;}" onclick="EmptyDownLoadData(' + "'" + MD5 + "'" + ',false)"><i class="mdui-icon material-icons">refresh</i></button>';

    if (Direct == true) {
        Button = '<button class="mdui-btn mdui-btn-icon" mdui-tooltip="{content:&quot;打开下载地址&quot;}" onclick="window.open(&quot;' + DownLoadLink + '&quot;)"><i class="mdui-icon material-icons">launch</i></button>' + Button;
    }

    return Button;
}

function CopyFileMD5(MD5) {
    var FileMD5Data = localStorage.getItem("FileMD5Data_" + MD5);
    var JsonData = JSON.parse(FileMD5Data);
    var FileMD5 = JsonData["MD5"];

    DocumentCopyText(FileMD5);

    mdui.snackbar({
        position: "top",
        message: "复制成功",
    });
}

function CopyFileSignature(ServerMD5) {
    var FileMD5Data = localStorage.getItem("FileMD5Data_" + ServerMD5);
    var JsonData = JSON.parse(FileMD5Data);
    var MD5 = JsonData["MD5"];
    var MD5256K = JsonData["MD5256K"];
    var Size = JsonData["Size"];
    var Name = JsonData["Name"];
    var Signature = MD5 + "#" + MD5256K + "#" + Size + "#" + Name;

    DocumentCopyText(Signature);

    mdui.snackbar({
        position: "top",
        message: "复制成功",
    });
}

function EmptyDownLoadData(MD5, Tyle) {
    LoadIng(true, "正在获取解析列表", 220);

    if (Tyle == true) {
        localStorage.removeItem("LinkData_MD5_" + MD5);
        localStorage.removeItem("FileMD5Data_" + MD5);
    }

    localStorage.removeItem("DownLoadData_MD5_" + MD5);

    window.location.reload();
}

function ClearCache() {
    Swal.fire({
        icon: "warning",
        title: "是否确定清除缓存？",
        confirmButtonText: "确定",
        denyButtonText: "取消",
        showDenyButton: true,
    }).then(function (Result) {
        if (Result.isConfirmed) {
            LoadIng(true, "正在清除缓存", 240);
            localStorage.clear();
            window.location.replace("./?Type=LinkParse");
        }
    });
}

function SetAria2() {
    var Aria2_Link = localStorage.getItem("Aria2_Link");
    var Aria2_Token = localStorage.getItem("Aria2_Token");

    if (Aria2_Link == "" || Aria2_Link == null) {
        Aria2_Link = "ws://127.0.0.1:6800/jsonrpc";
    }

    if (Aria2_Token == null) {
        Aria2_Token = "";
    }

    Swal.fire({
        title: "配置Aria2",
        confirmButtonText: "确定",
        denyButtonText: "取消",
        showDenyButton: true,
        html: '<a>Aria2 WebSocket地址</a><br><a>AriaNgGUI地址:ws://127.0.0.1:6800/jsonrpc</a><br><a>Motrix地址:ws://127.0.0.1:16800/jsonrpc</a><br><a>Aria2 HTTP地址</a><br></br><input class="mdui-textfield-input" id="Link" type="text" value="' + Aria2_Link + '"><br><a>Token(没有不要填)</a><input id="Token" class="mdui-textfield-input" type="text" value="' + Aria2_Token + '">',
        preConfirm: function () {
            Aria2_Link = document.getElementById("Link").value;
            Aria2_Token = document.getElementById("Token").value;

            localStorage.setItem("Aria2_Link", Aria2_Link);
            localStorage.setItem("Aria2_Token", Aria2_Token);
        },
    });
}

function PassAria2DownloadData(MD5, Name, DownLoadLink, UserAgent) {
    return new Promise(async function (TerminateReturn) {
        var Aria2_Link = localStorage.getItem("Aria2_Link");
        var Aria2_Token = localStorage.getItem("Aria2_Token");

        if (Aria2_Link == "" || Aria2_Link == null) {
            Aria2_Link = "ws://127.0.0.1:6800/jsonrpc";
        }

        if (Aria2_Token == null) {
            Aria2_Token = "";
        }

        var Split = 1024;

        // if ((await IsIPV6()) == true) {
        // } else {
        //     var DownLoadArray = '"' + DownLoadLink + '"';
        // }

        var DownLoadArray = '"' + DownLoadLink + '"';

        var Aria2_Data = '{"jsonrpc":2,"id":"KinhDown","method":"system.multicall","params":[[{"methodName":"aria2.addUri","params":["token:' + Aria2_Token + '",[' + DownLoadArray + '],{"max-connection-per-server":"' + Split + '","split":"' + Split + '","out":"' + Name + '","user-agent":"' + UserAgent + '"}]}]]}';

        var Variable_WebSocket = new WebSocket(Aria2_Link);
        Variable_WebSocket.onopen = function () {
            Variable_WebSocket.send(Aria2_Data);
        };

        Variable_WebSocket.onclose = function () {
            mdui.snackbar({
                position: "top",
                message: "发送失败",
            });

            TerminateReturn(false);
        };

        Variable_WebSocket.onerror = function () {
            mdui.snackbar({
                position: "top",
                message: "发送失败",
            });

            TerminateReturn(false);
        };

        Variable_WebSocket.onmessage = async function (Data) {
            TerminateReturn(await Check_Whether_Aria2TaskCreatedSuccessfully(Data.data));
        };
    });
}

function Check_Whether_Aria2TaskCreatedSuccessfully(Data) {
    return new Promise(function (TerminateReturn) {
        if (Data.indexOf("KinhDown") != -1 && Data.indexOf("result") == -1) {
            mdui.snackbar({
                position: "top",
                message: "创建下的任务失败",
            });

            TerminateReturn(false);
        } else if (Data.indexOf("KinhDown") != -1 && Data.indexOf("result") != -1) {
            mdui.snackbar({
                position: "top",
                message: "发送成功",
            });

            TerminateReturn(true);
        }
    });
}

async function PassAria2DownloadData_MultipleChoice() {
    var JsonErrorMD5 = {};

    var Count = document.getElementsByClassName("mdui-table-row-selected").length;

    for (var i = 0; i < Count; i++) {
        var HTMLCode = document.getElementsByClassName("mdui-table-row-selected")[i].innerHTML;
        var MD5_IndexOf = HTMLCode.indexOf('<div id="Button_') + 16;
        var MD5 = HTMLCode.substring(MD5_IndexOf, MD5_IndexOf + 32);

        var Data = localStorage.getItem("DownLoadData_MD5_" + MD5);
        if (Data == "" || Data == null) {
            mdui.snackbar({
                position: "top",
                message: "[" + MD5 + "]数据缺失",
            });
        } else {
            var JsonData = JSON.parse(Data);
            var DownLoadLink = JsonData["DownLoadLink"];
            var UserAgent = JsonData["UserAgent"];
            var Name = document.getElementById("Name_" + MD5).innerHTML;

            LoadIng(true, "[" + (i + 1) + "/" + Count + "]正在发送的Aria2下载引擎", 280);

            var Status = await PassAria2DownloadData(MD5, Name, DownLoadLink, UserAgent);
            if (Status == false) {
                JsonErrorMD5[i] = MD5;
            }
        }
    }

    LoadIng(false);

    JsonErrorMD5Str = JSON.stringify(JsonErrorMD5);
    if (JsonErrorMD5Str != "{}") {
        Swal.fire({
            icon: "error",
            title: "发送失败",
            text: JsonErrorMD5Str,
            confirmButtonText: "确定",
        });
    }
}

function GetIConJson() {
    $.ajax({
        type: "get",
        url: "https://vkceyugu.cdn.bspapp.com/VKCEYUGU-ab498c51-8871-421b-8e23-a43eaa306dff/c9dc1707-5f9d-4f4c-a54c-7f51fd29a6eb.json",
        success: function (Result) {
            localStorage.setItem("IconJson", JSON.stringify(Result));
        },
    });
}

function GetICon(Name, Folder) {
    JsonData = JSON.parse(localStorage.getItem("IconJson"));
    var SVG = JsonData[Name];
    if (SVG == "" || SVG == null) {
        if (Folder == true) {
            SVG = JsonData["folder"];
        } else {
            SVG = JsonData["unknow"];
        }
    }

    if (SVG != "" && SVG != null) {
        SVG = SVG.replace("<svg", '<svg width="64" height="64"');
    }

    return SVG;
}
