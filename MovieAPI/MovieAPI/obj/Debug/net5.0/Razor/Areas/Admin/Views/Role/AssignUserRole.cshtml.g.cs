#pragma checksum "G:\Prcatices\MovieAPI\MovieAPI\Areas\Admin\Views\Role\AssignUserRole.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cc4c146cbe3af014099084d56f9c1fe13571d439"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Role_AssignUserRole), @"mvc.1.0.view", @"/Areas/Admin/Views/Role/AssignUserRole.cshtml")]
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
#line 1 "G:\Prcatices\MovieAPI\MovieAPI\Areas\Admin\Views\_ViewImports.cshtml"
using MovieAPI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "G:\Prcatices\MovieAPI\MovieAPI\Areas\Admin\Views\_ViewImports.cshtml"
using MovieAPI.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cc4c146cbe3af014099084d56f9c1fe13571d439", @"/Areas/Admin/Views/Role/AssignUserRole.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9be74a2e6d59c40b42815892e2ddea63ef751f1e", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Role_AssignUserRole : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "G:\Prcatices\MovieAPI\MovieAPI\Areas\Admin\Views\Role\AssignUserRole.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<br />
<br />
<div class=""row"">
    <div class=""col-6"">
        <h2 class=""text-info"">Assign User Role</h2>
    </div>
</div>
<br />
<div>
    <table class=""table table-striped border"">
        <tr class=""table-info"">
            <th>
                User Name
            </th>

            <th>Role Name</th>
        </tr>
");
#nullable restore
#line 22 "G:\Prcatices\MovieAPI\MovieAPI\Areas\Admin\Views\Role\AssignUserRole.cshtml"
         foreach (var item in ViewBag.UserRoles)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 25 "G:\Prcatices\MovieAPI\MovieAPI\Areas\Admin\Views\Role\AssignUserRole.cshtml"
               Write(item.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 26 "G:\Prcatices\MovieAPI\MovieAPI\Areas\Admin\Views\Role\AssignUserRole.cshtml"
               Write(item.RoleName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n");
#nullable restore
#line 28 "G:\Prcatices\MovieAPI\MovieAPI\Areas\Admin\Views\Role\AssignUserRole.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </table>\r\n</div>\r\n\r\n");
            DefineSection("scripts", async() => {
                WriteLiteral("\r\n    <script src=\"//cdn.jsdelivr.net/npm/alertifyjs@1.11.2/build/alertify.min.js\"></script>\r\n    <script type=\"text/javascript\">\r\n        $(function(){\r\n            var save = \'");
#nullable restore
#line 36 "G:\Prcatices\MovieAPI\MovieAPI\Areas\Admin\Views\Role\AssignUserRole.cshtml"
                   Write(TempData["save"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("\'\r\n            if(save!=\'\') {\r\n                alertify.success(save);\r\n            }\r\n            var edit = \'");
#nullable restore
#line 40 "G:\Prcatices\MovieAPI\MovieAPI\Areas\Admin\Views\Role\AssignUserRole.cshtml"
                   Write(TempData["edit"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("\'\r\n            if(edit!=\'\') {\r\n                alertify.success(edit);\r\n            }\r\n            var del = \'");
#nullable restore
#line 44 "G:\Prcatices\MovieAPI\MovieAPI\Areas\Admin\Views\Role\AssignUserRole.cshtml"
                  Write(TempData["delete"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("\'\r\n            if (del!=\'\') {\r\n                alertify.error(del);\r\n            }\r\n        })\r\n    </script>\r\n");
            }
            );
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
