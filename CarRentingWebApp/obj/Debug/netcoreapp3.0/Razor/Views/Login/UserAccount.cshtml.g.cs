#pragma checksum "C:\Users\enead\source\repos\CarRentingWebApp\CarRentingWebApp\Views\Login\UserAccount.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9368d84ca181997884e3526bb43edf14356ae94c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Login_UserAccount), @"mvc.1.0.view", @"/Views/Login/UserAccount.cshtml")]
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
#line 1 "C:\Users\enead\source\repos\CarRentingWebApp\CarRentingWebApp\Views\_ViewImports.cshtml"
using CarRentingWebApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\enead\source\repos\CarRentingWebApp\CarRentingWebApp\Views\_ViewImports.cshtml"
using CarRentingWebApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9368d84ca181997884e3526bb43edf14356ae94c", @"/Views/Login/UserAccount.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8bff6b2a3ffdea8759e3d7ee522b4d2c74d7f54b", @"/Views/_ViewImports.cshtml")]
    public class Views_Login_UserAccount : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CarRentingWebApp.ViewModels.UserViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\enead\source\repos\CarRentingWebApp\CarRentingWebApp\Views\Login\UserAccount.cshtml"
  
    ViewData["Title"] = ViewBag.Username;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\enead\source\repos\CarRentingWebApp\CarRentingWebApp\Views\Login\UserAccount.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<div class=\"card\">\r\n    <div class=\"card-body\">\r\n        Hello, ");
#nullable restore
#line 10 "C:\Users\enead\source\repos\CarRentingWebApp\CarRentingWebApp\Views\Login\UserAccount.cshtml"
          Write(Model.Username);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CarRentingWebApp.ViewModels.UserViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
