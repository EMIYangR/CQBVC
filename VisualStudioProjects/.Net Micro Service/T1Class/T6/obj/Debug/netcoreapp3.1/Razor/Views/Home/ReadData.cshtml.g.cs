#pragma checksum "D:\Users\EMI\VisualStudioProjects\.Net Micro Service\T1Class\T6\Views\Home\ReadData.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e67d34652e654c99118f41cef21dbe3b6eecb5ec"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_ReadData), @"mvc.1.0.view", @"/Views/Home/ReadData.cshtml")]
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
#line 1 "D:\Users\EMI\VisualStudioProjects\.Net Micro Service\T1Class\T6\Views\_ViewImports.cshtml"
using T6;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Users\EMI\VisualStudioProjects\.Net Micro Service\T1Class\T6\Views\_ViewImports.cshtml"
using T6.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e67d34652e654c99118f41cef21dbe3b6eecb5ec", @"/Views/Home/ReadData.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2c7c4f6c747a9a5f7b2b4be4673e700d2d8619a5", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_ReadData : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<h1>Redis中获取的数据为：");
#nullable restore
#line 1 "D:\Users\EMI\VisualStudioProjects\.Net Micro Service\T1Class\T6\Views\Home\ReadData.cshtml"
            Write(ViewBag.TimeNow);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n<h1>");
#nullable restore
#line 2 "D:\Users\EMI\VisualStudioProjects\.Net Micro Service\T1Class\T6\Views\Home\ReadData.cshtml"
Write(ViewBag.P.ProductID);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 2 "D:\Users\EMI\VisualStudioProjects\.Net Micro Service\T1Class\T6\Views\Home\ReadData.cshtml"
                    Write(ViewBag.P.ProductName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 2 "D:\Users\EMI\VisualStudioProjects\.Net Micro Service\T1Class\T6\Views\Home\ReadData.cshtml"
                                           Write(ViewBag.P.ProductPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>");
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
