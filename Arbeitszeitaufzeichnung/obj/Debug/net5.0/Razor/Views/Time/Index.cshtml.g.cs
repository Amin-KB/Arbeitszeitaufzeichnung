#pragma checksum "D:\VisualStudio2019\Arbeitszeitaufzeichnung\Arbeitszeitaufzeichnung\Views\Time\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "95f0b7e245c9f2d12c891537535410b9974660d3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Time_Index), @"mvc.1.0.view", @"/Views/Time/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"95f0b7e245c9f2d12c891537535410b9974660d3", @"/Views/Time/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5d4f7ffccb854a1bbac7e9b8f18bbb0c93b00a78", @"/Views/_ViewImports.cshtml")]
    public class Views_Time_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 6 "D:\VisualStudio2019\Arbeitszeitaufzeichnung\Arbeitszeitaufzeichnung\Views\Time\Index.cshtml"
 if (ViewBag.Status == 1)
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\VisualStudio2019\Arbeitszeitaufzeichnung\Arbeitszeitaufzeichnung\Views\Time\Index.cshtml"
Write(Html.ActionLink("Go", "Go", "Time"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\VisualStudio2019\Arbeitszeitaufzeichnung\Arbeitszeitaufzeichnung\Views\Time\Index.cshtml"
                                        
}
else if (ViewBag.Status == 2)
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "D:\VisualStudio2019\Arbeitszeitaufzeichnung\Arbeitszeitaufzeichnung\Views\Time\Index.cshtml"
Write(Html.ActionLink("Come", "Come", "Time"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "D:\VisualStudio2019\Arbeitszeitaufzeichnung\Arbeitszeitaufzeichnung\Views\Time\Index.cshtml"
                                            
}
else
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "D:\VisualStudio2019\Arbeitszeitaufzeichnung\Arbeitszeitaufzeichnung\Views\Time\Index.cshtml"
Write(Html.ActionLink("Come", "Come", "Time"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "D:\VisualStudio2019\Arbeitszeitaufzeichnung\Arbeitszeitaufzeichnung\Views\Time\Index.cshtml"
Write(Html.ActionLink("Go", "Go", "Time"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "D:\VisualStudio2019\Arbeitszeitaufzeichnung\Arbeitszeitaufzeichnung\Views\Time\Index.cshtml"
                                        
}

#line default
#line hidden
#nullable disable
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
