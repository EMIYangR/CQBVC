#pragma checksum "D:\Users\EMI\VisualStudioProjects\.Net Micro Service\T1Class\SessionA\Views\User\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4582a8bb05127268ead04aba9a0368cdc56a4c4d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_Index), @"mvc.1.0.view", @"/Views/User/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\Users\EMI\VisualStudioProjects\.Net Micro Service\T1Class\SessionA\Views\_ViewImports.cshtml"
using SessionA;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Users\EMI\VisualStudioProjects\.Net Micro Service\T1Class\SessionA\Views\_ViewImports.cshtml"
using SessionA.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4582a8bb05127268ead04aba9a0368cdc56a4c4d", @"/Views/User/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b462d176f46a4e407880afdbf97ee10c6a9897b9", @"/Views/_ViewImports.cshtml")]
    public class Views_User_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<h1>SessionA</h1>\r\n<h2>用户名：");
#nullable restore
#line 2 "D:\Users\EMI\VisualStudioProjects\.Net Micro Service\T1Class\SessionA\Views\User\Index.cshtml"
   Write(ViewBag.User);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n<h2>登录时间：");
#nullable restore
#line 3 "D:\Users\EMI\VisualStudioProjects\.Net Micro Service\T1Class\SessionA\Views\User\Index.cshtml"
    Write(ViewBag.LoginTime);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n<h2>SessionID：");
#nullable restore
#line 4 "D:\Users\EMI\VisualStudioProjects\.Net Micro Service\T1Class\SessionA\Views\User\Index.cshtml"
         Write(ViewBag.SID);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591