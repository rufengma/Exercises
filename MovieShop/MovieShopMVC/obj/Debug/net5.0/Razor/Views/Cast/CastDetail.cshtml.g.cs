#pragma checksum "/Users/rufengma/Documents/Job/Antra/FinalProject/MovieShop/MovieShopMVC/Views/Cast/CastDetail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9b9bd877477e74343abc58f87699b10e85e79bc2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Cast_CastDetail), @"mvc.1.0.view", @"/Views/Cast/CastDetail.cshtml")]
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
#line 1 "/Users/rufengma/Documents/Job/Antra/FinalProject/MovieShop/MovieShopMVC/Views/_ViewImports.cshtml"
using MovieShopMVC;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/rufengma/Documents/Job/Antra/FinalProject/MovieShop/MovieShopMVC/Views/_ViewImports.cshtml"
using MovieShopMVC.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9b9bd877477e74343abc58f87699b10e85e79bc2", @"/Views/Cast/CastDetail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f0d2154f16347fb0df8a919e414827cd460665e4", @"/Views/_ViewImports.cshtml")]
    public class Views_Cast_CastDetail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ApplicationCore.Models.CastDetailsResponseModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 3 "/Users/rufengma/Documents/Job/Antra/FinalProject/MovieShop/MovieShopMVC/Views/Cast/CastDetail.cshtml"
  
    ViewData["Title"] = "CastDetails";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<div class=\"container\">\n\n    <div class=\"row bg-color-1 \">\n        <div class=\"col-3\">\n            <img class=\"detail-poster\"");
            BeginWriteAttribute("src", " src=\"", 226, "\"", 250, 1);
#nullable restore
#line 11 "/Users/rufengma/Documents/Job/Antra/FinalProject/MovieShop/MovieShopMVC/Views/Cast/CastDetail.cshtml"
WriteAttributeValue("", 232, Model.ProfilePath, 232, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 251, "\"", 268, 1);
#nullable restore
#line 11 "/Users/rufengma/Documents/Job/Antra/FinalProject/MovieShop/MovieShopMVC/Views/Cast/CastDetail.cshtml"
WriteAttributeValue("", 257, Model.Name, 257, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n        </div>\n        <div class=\"col-6\">\n            <h3 style=\"color:white\">\n                ");
#nullable restore
#line 15 "/Users/rufengma/Documents/Job/Antra/FinalProject/MovieShop/MovieShopMVC/Views/Cast/CastDetail.cshtml"
           Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
            </h3>
        </div>
        <div class=""col-3"">
            <div class=""third-column"">
                <a href=""#"" class=""btn btn-secondary btn-sm active"" role=""button"" aria-pressed=""true"">
                    <i class=""fas fa-pen-square size:2x"">REVIEW</i>
                </a>
                <p></p>
                <a href=""#"" class=""btn btn-secondary btn-sm active"" role=""button"" aria-pressed=""true"">
                    <i class=""far fa-play-circle size:2x"">TRAILER</i>
                </a>
                <p></p>
                <a href=""#"" class=""btn btn-secondary btn-sm active"" role=""button"" aria-pressed=""true"">
                    BUY 9.90
                </a>
                <p></p>
                <a href=""#"" class=""btn btn-secondary btn-sm active"" role=""button"" aria-pressed=""true"">
                    WATCH MOVIE
                </a>
                <p></p>
            </div>
        </div>
    </div>
    <div class=""row"">
        <div class=""col-4"">

        </div>
        <div class=""c");
            WriteLiteral("ol-8\">\n            <h5>WORKS</h5>\n            <table class=\"table\">\n                <tbody>\n");
#nullable restore
#line 47 "/Users/rufengma/Documents/Job/Antra/FinalProject/MovieShop/MovieShopMVC/Views/Cast/CastDetail.cshtml"
                     foreach (var movie in Model.Movies)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\n                            <td>\n                                <img");
            BeginWriteAttribute("src", " src=\"", 1671, "\"", 1693, 1);
#nullable restore
#line 51 "/Users/rufengma/Documents/Job/Antra/FinalProject/MovieShop/MovieShopMVC/Views/Cast/CastDetail.cshtml"
WriteAttributeValue("", 1677, movie.PosterUrl, 1677, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("\n                                     style=\"width:50px\"");
            BeginWriteAttribute("alt", "\n                                     alt=\"", 1750, "\"", 1805, 1);
#nullable restore
#line 53 "/Users/rufengma/Documents/Job/Antra/FinalProject/MovieShop/MovieShopMVC/Views/Cast/CastDetail.cshtml"
WriteAttributeValue("", 1793, movie.Title, 1793, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n                            </td>\n                            <td> ");
#nullable restore
#line 55 "/Users/rufengma/Documents/Job/Antra/FinalProject/MovieShop/MovieShopMVC/Views/Cast/CastDetail.cshtml"
                            Write(movie.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\n                            <td> ");
#nullable restore
#line 56 "/Users/rufengma/Documents/Job/Antra/FinalProject/MovieShop/MovieShopMVC/Views/Cast/CastDetail.cshtml"
                            Write(movie.Character);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                        </tr>\n");
#nullable restore
#line 58 "/Users/rufengma/Documents/Job/Antra/FinalProject/MovieShop/MovieShopMVC/Views/Cast/CastDetail.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </tbody>\n            </table>\n        </div>\n\n    </div>\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ApplicationCore.Models.CastDetailsResponseModel> Html { get; private set; }
    }
}
#pragma warning restore 1591