#pragma checksum "C:\Users\ishiva\Desktop\CRM\Source\CRM\CRM\Views\Shared\_ErrorMessage.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "59d31eb56a1139e7ce5839a4ad8b4b5c6b5f04ee"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(CRM.Pages.Shared.Views_Shared__ErrorMessage), @"mvc.1.0.view", @"/Views/Shared/_ErrorMessage.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/_ErrorMessage.cshtml", typeof(CRM.Pages.Shared.Views_Shared__ErrorMessage))]
namespace CRM.Pages.Shared
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\ishiva\Desktop\CRM\Source\CRM\CRM\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#line 2 "C:\Users\ishiva\Desktop\CRM\Source\CRM\CRM\Views\_ViewImports.cshtml"
using CRM.Areas.Identity;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"59d31eb56a1139e7ce5839a4ad8b4b5c6b5f04ee", @"/Views/Shared/_ErrorMessage.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1dc2386f03b626b8abae1218e58c166a57a2f665", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__ErrorMessage : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "C:\Users\ishiva\Desktop\CRM\Source\CRM\CRM\Views\Shared\_ErrorMessage.cshtml"
  
    string error = string.Empty;
    if (ViewData != null)
    {
        if (ViewData["error"] != null)
        {

            error = ((CRM.Helper.Error)ViewData["error"]).description;
        }
    }


#line default
#line hidden
#line 13 "C:\Users\ishiva\Desktop\CRM\Source\CRM\CRM\Views\Shared\_ErrorMessage.cshtml"
 if (error != string.Empty)
{

#line default
#line hidden
            BeginContext(252, 632, true);
            WriteLiteral(@"    <script>
        var options = options = {
            ""closeButton"": false,
            ""debug"": false,
            ""newestOnTop"": false,
            ""progressBar"": false,
            ""positionClass"": ""toast-top-center"",
            ""preventDuplicates"": false,
            ""onclick"": null,
            ""showDuration"": ""300"",
            ""hideDuration"": ""1000"",
            ""timeOut"": ""5000"",
            ""extendedTimeOut"": ""1000"",
            ""showEasing"": ""swing"",
            ""hideEasing"": ""linear"",
            ""showMethod"": ""fadeIn"",
            ""hideMethod"": ""fadeOut""
        };
        toastr.success('");
            EndContext();
            BeginContext(885, 5, false);
#line 33 "C:\Users\ishiva\Desktop\CRM\Source\CRM\CRM\Views\Shared\_ErrorMessage.cshtml"
                   Write(error);

#line default
#line hidden
            EndContext();
            BeginContext(890, 29, true);
            WriteLiteral("\', options);\r\n    </script>\r\n");
            EndContext();
#line 35 "C:\Users\ishiva\Desktop\CRM\Source\CRM\CRM\Views\Shared\_ErrorMessage.cshtml"
}

#line default
#line hidden
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
