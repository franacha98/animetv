#pragma checksum "D:\AnimeTV\AnimeTv\AnimeTv\Views\Ficha\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9be1f1b74c810c31f95bf4019a2cc4e707ca836b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Ficha_Index), @"mvc.1.0.view", @"/Views/Ficha/Index.cshtml")]
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
#line 1 "D:\AnimeTV\AnimeTv\AnimeTv\Views\_ViewImports.cshtml"
using AnimeTv;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\AnimeTV\AnimeTv\AnimeTv\Views\_ViewImports.cshtml"
using AnimeTv.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9be1f1b74c810c31f95bf4019a2cc4e707ca836b", @"/Views/Ficha/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"45fa66bd9b7206828382601f0a68650b5b094956", @"/Views/_ViewImports.cshtml")]
    public class Views_Ficha_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<FichaViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\AnimeTV\AnimeTv\AnimeTv\Views\Ficha\Index.cshtml"
  
    ViewData["Title"] = "Ficha";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"row\">\r\n    <div class=\"col-sm-4\">\r\n        <div class=\"card\" style=\"border:none;\">\r\n            <img");
            BeginWriteAttribute("src", " src=\"", 225, "\"", 268, 1);
#nullable restore
#line 10 "D:\AnimeTV\AnimeTv\AnimeTv\Views\Ficha\Index.cshtml"
WriteAttributeValue("", 231, Model.AnimeData.images.jpg.image_url, 231, 37, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"card-img-top\" alt=\"Cartel del anime\">\r\n");
#nullable restore
#line 11 "D:\AnimeTV\AnimeTv\AnimeTv\Views\Ficha\Index.cshtml"
             if (Model.Estado == "airing")
            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                <div class=""card-body d-flex justify-content-center"" style=""background-color: #00c853; margin-top: 3%; border-radius: 10px;"">
                    <span style=""color: white;""><i class=""fa fa-play-circle""></i>&nbsp;&nbsp;&nbsp;EN EMISIÓN</span>
                </div>
");
#nullable restore
#line 16 "D:\AnimeTV\AnimeTv\AnimeTv\Views\Ficha\Index.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                <div class=""card-body d-flex justify-content-center"" style=""background-color: #e62f41; margin-top: 3%; border-radius: 5px;"">
                    <span style=""color: white; font-weight: bold; font-size: 20px""><i class=""fa fa-check-circle""></i>FINALIZADO</span>
                </div>
");
#nullable restore
#line 22 "D:\AnimeTV\AnimeTv\AnimeTv\Views\Ficha\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n    <div class=\"col-sm-8\" id=\"panel-central\" style=\"margin-top: 3%;\">\r\n        <div class=\"d-flex justify-content-around\">\r\n            <h1 class=\"display-4 p-2\">");
#nullable restore
#line 28 "D:\AnimeTV\AnimeTv\AnimeTv\Views\Ficha\Index.cshtml"
                                 Write(Model.Nombre);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n            <div class=\"p-2 d-flex flex-column justify-content-center\">\r\n                <span class=\"p-2\" style=\"background-color: #01bcf3; color: white; font-weight: 700; font-size: 25px \">");
#nullable restore
#line 30 "D:\AnimeTV\AnimeTv\AnimeTv\Views\Ficha\Index.cshtml"
                                                                                                                 Write(Model.AnimeData.score);

#line default
#line hidden
#nullable disable
            WriteLiteral("&nbsp;&nbsp;&nbsp;&nbsp;<i class=\"fa fa-star\" style=\"color: orange; font-size: 30px;\"></i></span>\r\n                <small class=\"p-2\" style=\"background-color: #01bcf3; color: white; \">\r\n                    ");
#nullable restore
#line 32 "D:\AnimeTV\AnimeTv\AnimeTv\Views\Ficha\Index.cshtml"
               Write(Model.AnimeData.scored_by);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" VOTOS
                </small>
            </div>
        </div>
        <div style=""margin-top: 5%;"">
            <h2 class=""subtitulo border-bottom"">Información general</h2>
            <ul class=""list-group"">
                <li class=""list-group-item"">
                    <div class=""d-flex"">
                        <i class=""p-2 fa fa-star""></i>
                        <span class=""p-2"">
                            Géneros:
");
#nullable restore
#line 44 "D:\AnimeTV\AnimeTv\AnimeTv\Views\Ficha\Index.cshtml"
                             foreach (var genero in Model.AnimeData.genres)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <span class=\"border\" style=\"background-color: silver; padding:5px; border-radius: 10px;\">");
#nullable restore
#line 46 "D:\AnimeTV\AnimeTv\AnimeTv\Views\Ficha\Index.cshtml"
                                                                                                                    Write(genero.name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n");
#nullable restore
#line 47 "D:\AnimeTV\AnimeTv\AnimeTv\Views\Ficha\Index.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        </span>
                    </div>
                </li>
                <li class=""list-group-item"">
                    <div class=""d-flex"">
                        <i class=""p-2 fa fa-television""></i>
                        <span class=""p-2"">Episodios: ");
#nullable restore
#line 54 "D:\AnimeTV\AnimeTv\AnimeTv\Views\Ficha\Index.cshtml"
                                                Write(Model.Capitulos);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                    </div>\r\n                </li>\r\n                <li class=\"list-group-item\">\r\n                    <div class=\"d-flex\">\r\n                        <i class=\"p-2 fa fa-calendar\"></i>\r\n                        <span class=\"p-2\">Año: ");
#nullable restore
#line 60 "D:\AnimeTV\AnimeTv\AnimeTv\Views\Ficha\Index.cshtml"
                                          Write(Model.AnimeData.year);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                    </div>
                </li>
                <li class=""list-group-item"">
                    <div class=""d-flex"">
                        <i class=""p-2 fa fa-user-o""></i>
                        <span class=""p-2"">Seguidores: ");
#nullable restore
#line 66 "D:\AnimeTV\AnimeTv\AnimeTv\Views\Ficha\Index.cshtml"
                                                 Write(Model.AnimeData.members);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                    </div>
                </li>
                <li class=""list-group-item"">
                    <div class=""d-flex"">
                        <i class=""p-2 fa fa-trophy""></i>
                        <span class=""p-2"">Posición en el ranking: ");
#nullable restore
#line 72 "D:\AnimeTV\AnimeTv\AnimeTv\Views\Ficha\Index.cshtml"
                                                             Write(Model.AnimeData.rank);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                    </div>\r\n                </li>\r\n                <li class=\"list-group-item\">\r\n                    <div class=\"d-flex\">\r\n                        <i class=\"p-2 fa fa-star\"></i>\r\n                        <span class=\"p-2\">Rating: ");
#nullable restore
#line 78 "D:\AnimeTV\AnimeTv\AnimeTv\Views\Ficha\Index.cshtml"
                                             Write(Model.AnimeData.rating);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                    </div>
                </li>
            </ul>

        </div>
        <div style=""margin-top: 5%;"">
            <h2 class=""subtitulo border-bottom"">Sinopsis</h2>
            <p style=""text-align: justify; text-justify: inter-word;"">
                ");
#nullable restore
#line 87 "D:\AnimeTV\AnimeTv\AnimeTv\Views\Ficha\Index.cshtml"
           Write(Model.AnimeData.synopsis);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </p>\r\n        </div>\r\n        <div style=\"margin-top: 5%;\">\r\n            <h2 class=\"subtitulo border-bottom\">Trailer</h2>\r\n            <iframe style=\"width: 100%; height: 400px;\"");
            BeginWriteAttribute("src", " src=\"", 4346, "\"", 4386, 1);
#nullable restore
#line 92 "D:\AnimeTV\AnimeTv\AnimeTv\Views\Ficha\Index.cshtml"
WriteAttributeValue("", 4352, Model.AnimeData.trailer.embed_url, 4352, 34, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></iframe>\r\n        </div>\r\n    </div>\r\n</div>\r\n<div>\r\n    <h2 class=\"subtitulo border-bottom\">Lista de episodios</h2>\r\n    <ul class=\"list-group\">\r\n");
#nullable restore
#line 99 "D:\AnimeTV\AnimeTv\AnimeTv\Views\Ficha\Index.cshtml"
         foreach (var episodio in Model.Episodios)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <li class=\"list-group-item\">\r\n                <div class=\"d-flex justify-content-between\">\r\n                    <img style=\"width: 10%;\"");
            BeginWriteAttribute("src", " src=\"", 4747, "\"", 4790, 1);
#nullable restore
#line 103 "D:\AnimeTV\AnimeTv\AnimeTv\Views\Ficha\Index.cshtml"
WriteAttributeValue("", 4753, Model.AnimeData.images.jpg.image_url, 4753, 37, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                    <div class=\"d-flex flex-column\">\r\n                        <h4 class=\"p-2\">");
#nullable restore
#line 105 "D:\AnimeTV\AnimeTv\AnimeTv\Views\Ficha\Index.cshtml"
                                   Write(Model.Nombre);

#line default
#line hidden
#nullable disable
            WriteLiteral(" - ");
#nullable restore
#line 105 "D:\AnimeTV\AnimeTv\AnimeTv\Views\Ficha\Index.cshtml"
                                                   Write(episodio.title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n                        <small class=\"p-2\">Episodio ");
#nullable restore
#line 106 "D:\AnimeTV\AnimeTv\AnimeTv\Views\Ficha\Index.cshtml"
                                                Write(++Model.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</small>
                    </div>
                    <button class=""p-2 btn btn-info play-ep"" style=""background-color:white; border: none;""><i class=""fa fa-play-circle play-ep"" style=""color: #01bcf3; font-size: 80px;""></i></button>
                </div>
            </li>
");
#nullable restore
#line 111 "D:\AnimeTV\AnimeTv\AnimeTv\Views\Ficha\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    </ul>
</div>
<!--comentarios-->
<div id=""disqus_thread"" style=""margin-top: 5%""></div>
<script>
    (function () {
        var d = document, s = d.createElement('script');
        s.src = 'https://animetv-5.disqus.com/embed.js';
        s.setAttribute('data-timestamp', +new Date());
        (d.head || d.body).appendChild(s);
    })();
</script>
<noscript>Please enable JavaScript to view the <a href=""https://disqus.com/?ref_noscript"">comments powered by Disqus.</a></noscript>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<FichaViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
