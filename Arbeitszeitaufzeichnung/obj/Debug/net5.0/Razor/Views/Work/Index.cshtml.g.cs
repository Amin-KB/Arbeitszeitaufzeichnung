#pragma checksum "D:\VisualStudio2019\Arbeitszeitaufzeichnung\Arbeitszeitaufzeichnung\Views\Work\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "270cb4052d10c16c4f4c45ba1fc2c4e9e72826b1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Work_Index), @"mvc.1.0.view", @"/Views/Work/Index.cshtml")]
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
#line 1 "D:\VisualStudio2019\Arbeitszeitaufzeichnung\Arbeitszeitaufzeichnung\Views\_ViewImports.cshtml"
using Arbeitszeitaufzeichnung;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\VisualStudio2019\Arbeitszeitaufzeichnung\Arbeitszeitaufzeichnung\Views\_ViewImports.cshtml"
using Arbeitszeitaufzeichnung.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"270cb4052d10c16c4f4c45ba1fc2c4e9e72826b1", @"/Views/Work/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5d4f7ffccb854a1bbac7e9b8f18bbb0c93b00a78", @"/Views/_ViewImports.cshtml")]
    public class Views_Work_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Arbeitszeitaufzeichnung.Models.ViewModels.WorktimeVM>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\VisualStudio2019\Arbeitszeitaufzeichnung\Arbeitszeitaufzeichnung\Views\Work\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 11 "D:\VisualStudio2019\Arbeitszeitaufzeichnung\Arbeitszeitaufzeichnung\Views\Work\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Employee));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 14 "D:\VisualStudio2019\Arbeitszeitaufzeichnung\Arbeitszeitaufzeichnung\Views\Work\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Come));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 17 "D:\VisualStudio2019\Arbeitszeitaufzeichnung\Arbeitszeitaufzeichnung\Views\Work\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Go));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 20 "D:\VisualStudio2019\Arbeitszeitaufzeichnung\Arbeitszeitaufzeichnung\Views\Work\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.MinimumBreak));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 23 "D:\VisualStudio2019\Arbeitszeitaufzeichnung\Arbeitszeitaufzeichnung\Views\Work\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.LongestBreak));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 26 "D:\VisualStudio2019\Arbeitszeitaufzeichnung\Arbeitszeitaufzeichnung\Views\Work\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.WorkTime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 29 "D:\VisualStudio2019\Arbeitszeitaufzeichnung\Arbeitszeitaufzeichnung\Views\Work\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.TotalBreakTime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 34 "D:\VisualStudio2019\Arbeitszeitaufzeichnung\Arbeitszeitaufzeichnung\Views\Work\Index.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 37 "D:\VisualStudio2019\Arbeitszeitaufzeichnung\Arbeitszeitaufzeichnung\Views\Work\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.EmployeeName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 40 "D:\VisualStudio2019\Arbeitszeitaufzeichnung\Arbeitszeitaufzeichnung\Views\Work\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Come));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 43 "D:\VisualStudio2019\Arbeitszeitaufzeichnung\Arbeitszeitaufzeichnung\Views\Work\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Go));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 46 "D:\VisualStudio2019\Arbeitszeitaufzeichnung\Arbeitszeitaufzeichnung\Views\Work\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.MinimumBreak));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 49 "D:\VisualStudio2019\Arbeitszeitaufzeichnung\Arbeitszeitaufzeichnung\Views\Work\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.LongestBreak));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 52 "D:\VisualStudio2019\Arbeitszeitaufzeichnung\Arbeitszeitaufzeichnung\Views\Work\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.WorkTime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 55 "D:\VisualStudio2019\Arbeitszeitaufzeichnung\Arbeitszeitaufzeichnung\Views\Work\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.TotalBreakTime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 58 "D:\VisualStudio2019\Arbeitszeitaufzeichnung\Arbeitszeitaufzeichnung\Views\Work\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Arbeitszeitaufzeichnung.Models.ViewModels.WorktimeVM>> Html { get; private set; }
    }
}
#pragma warning restore 1591
