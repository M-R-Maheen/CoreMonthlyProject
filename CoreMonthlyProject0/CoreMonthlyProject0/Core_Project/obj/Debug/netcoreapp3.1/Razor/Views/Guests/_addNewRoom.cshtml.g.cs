#pragma checksum "C:\Users\Mamun\Downloads\CoreMonthlyProject0\CoreMonthlyProject0\Core_Project\Views\Guests\_addNewRoom.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f42ce287a2904ff70f5c80031005e630b2689c5c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Guests__addNewRoom), @"mvc.1.0.view", @"/Views/Guests/_addNewRoom.cshtml")]
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
#line 1 "C:\Users\Mamun\Downloads\CoreMonthlyProject0\CoreMonthlyProject0\Core_Project\Views\_ViewImports.cshtml"
using Core_Project;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Mamun\Downloads\CoreMonthlyProject0\CoreMonthlyProject0\Core_Project\Views\_ViewImports.cshtml"
using Core_Project.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f42ce287a2904ff70f5c80031005e630b2689c5c", @"/Views/Guests/_addNewRoom.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"93bae4d5cbbd9b3edbd35b79b5b210735ad680e0", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Guests__addNewRoom : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Core_Project.Models.Guest>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"row form-group mt-2\">\r\n    <div class=\"col-md-10\">\r\n        ");
#nullable restore
#line 5 "C:\Users\Mamun\Downloads\CoreMonthlyProject0\CoreMonthlyProject0\Core_Project\Views\Guests\_addNewRoom.cshtml"
   Write(Html.DropDownListFor(x=>x.GuestId, ViewBag.Rooms as SelectList,"--Select--",htmlAttributes:new{@class="form-control"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n    <div class=\"col-md-2\">\r\n        <a class=\"btn btn-danger text-white\" id=\"btnDeleteRoom\">Delete</a>\r\n    </div>\r\n</div>\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Core_Project.Models.Guest> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
