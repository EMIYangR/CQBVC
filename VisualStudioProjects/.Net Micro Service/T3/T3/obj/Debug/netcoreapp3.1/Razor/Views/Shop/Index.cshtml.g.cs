#pragma checksum "D:\Users\EMI\VisualStudioProjects\.Net Micro Service\T3\T3\Views\Shop\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0332d23c8bc484320d9330491af4c3fae886fc0b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shop_Index), @"mvc.1.0.view", @"/Views/Shop/Index.cshtml")]
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
#line 1 "D:\Users\EMI\VisualStudioProjects\.Net Micro Service\T3\T3\Views\_ViewImports.cshtml"
using T3;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Users\EMI\VisualStudioProjects\.Net Micro Service\T3\T3\Views\_ViewImports.cshtml"
using T3.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\Users\EMI\VisualStudioProjects\.Net Micro Service\T3\T3\Views\Shop\Index.cshtml"
using T3.Controllers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\Users\EMI\VisualStudioProjects\.Net Micro Service\T3\T3\Views\Shop\Index.cshtml"
using Microsoft.Extensions.Logging;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0332d23c8bc484320d9330491af4c3fae886fc0b", @"/Views/Shop/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d56a30a2cc32569690dfdf94afaa7c1c5e953f17", @"/Views/_ViewImports.cshtml")]
    public class Views_Shop_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "D:\Users\EMI\VisualStudioProjects\.Net Micro Service\T3\T3\Views\Shop\Index.cshtml"
  
    ViewData["Title"] = "商品详情";

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\Users\EMI\VisualStudioProjects\.Net Micro Service\T3\T3\Views\Shop\Index.cshtml"
   
    logger.LogInformation("显示Index.cshtml视图");

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n<h1>商品详情</h1>\r\n\r\n<ul class=\"list-group\">\r\n    <li class=\"list-group-item\">商品名称：");
#nullable restore
#line 17 "D:\Users\EMI\VisualStudioProjects\.Net Micro Service\T3\T3\Views\Shop\Index.cshtml"
                                Write(Model.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n    <li class=\"list-group-item\">商品价格：");
#nullable restore
#line 18 "D:\Users\EMI\VisualStudioProjects\.Net Micro Service\T3\T3\Views\Shop\Index.cshtml"
                                Write(string.Format("{0:C}",Model.Price));

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n    <li class=\"list-group-item\">商品详情：");
#nullable restore
#line 19 "D:\Users\EMI\VisualStudioProjects\.Net Micro Service\T3\T3\Views\Shop\Index.cshtml"
                                Write(Model.Desc);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n</ul>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public ILogger<ShopController> logger { get; private set; }
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
