#pragma checksum "C:\Users\Abbas\source\repos\Web Resume Solution\Web Resume\Views\Portfolio\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "91a9dec92cea374e372e3c5a83f1de1c44d4dabc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Portfolio_Index), @"mvc.1.0.view", @"/Views/Portfolio/Index.cshtml")]
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
#line 1 "C:\Users\Abbas\source\repos\Web Resume Solution\Web Resume\Views\_ViewImports.cshtml"
using Web_Resume.AppCode.Repositories;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Abbas\source\repos\Web Resume Solution\Web Resume\Views\_ViewImports.cshtml"
using Web_Resume.Model.Entity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"91a9dec92cea374e372e3c5a83f1de1c44d4dabc", @"/Views/Portfolio/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ca24ab2b549cb081871d639ee99246da6f4b56f8", @"/Views/_ViewImports.cshtml")]
    public class Views_Portfolio_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\Abbas\source\repos\Web Resume Solution\Web Resume\Views\Portfolio\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""col-md-8"">

    <!-- MAIN NAV -->

    <div class=""inside-sec"">
        <!-- BIO AND SKILLS -->
        <h5 class=""tittle"">PORTFOLIO</h5>

        <!-- PORTFOLIO -->
        <section class=""portfolio padding-top-50 padding-bottom-50"">
            <!-- Work Filter -->
            <ul class=""tabs portfolio-filter text-center margin-bottom-30"">
                <li class=""filter"" data-filter=""all"">all</li>
                <li class=""filter"" data-filter="".brand"">Branding</li>
                <li class=""filter"" data-filter="".design"">designing</li>
                <li class=""filter"" data-filter="".photo"">photography</li>
                <li class=""filter"" data-filter="".visual"">visual design</li>
            </ul>

            <!-- PORTFOLIO ITEMS -->
            <div id=""Container"" class=""item-space row col-3"">

                <!-- ITEM -->
                <article class=""portfolio-item mix  design photo visual"">
                    <div class=""portfolio-image"">
               ");
            WriteLiteral(@"         <a href=""#.""> <img class=""img-responsive"" alt=""Open Imagination"" src=""images/portfolio/5/img-1.jpg""> </a>
                        <div class=""portfolio-overlay style-4"">
                            <div class=""detail-info"">
                                <div class=""position-center-center"">
                                    <h3 class=""no-margin"">Assembly Branding</h3>
                                    <span><a href=""#."">Fashion / trending</a></span> <a href=""#."" class=""go""><i class=""fa fa-search""></i></a> <a href=""#."" class=""go""><i class=""fa fa-link""></i></a>
                                </div>
                            </div>
                        </div>
                    </div>
                </article>

                <!-- ITEM -->
                <article class=""portfolio-item mix brand  photo "">
                    <div class=""portfolio-image"">
                        <a href=""#.""> <img class=""img-responsive"" alt=""Open Imagination"" src=""images/portfolio/5/img-2.jpg");
            WriteLiteral(@"""> </a>
                        <div class=""portfolio-overlay style-4"">
                            <div class=""detail-info"">
                                <div class=""position-center-center"">
                                    <h3 class=""no-margin"">Assembly Branding</h3>
                                    <span><a href=""#."">Fashion / trending</a></span> <a href=""#."" class=""go""><i class=""fa fa-search""></i></a> <a href=""#."" class=""go""><i class=""fa fa-link""></i></a>
                                </div>
                            </div>
                        </div>
                    </div>
                </article>

                <!-- ITEM -->
                <article class=""portfolio-item mix  photo visual"">
                    <div class=""portfolio-image"">
                        <a href=""#.""> <img class=""img-responsive"" alt=""Open Imagination"" src=""images/portfolio/5/img-3.jpg""> </a>
                        <div class=""portfolio-overlay style-4"">
                            <div ");
            WriteLiteral(@"class=""detail-info"">
                                <div class=""position-center-center"">
                                    <h3 class=""no-margin"">Assembly Branding</h3>
                                    <span><a href=""#."">Fashion / trending</a></span> <a href=""#."" class=""go""><i class=""fa fa-search""></i></a> <a href=""#."" class=""go""><i class=""fa fa-link""></i></a>
                                </div>
                            </div>
                        </div>
                    </div>
                </article>

                <!-- ITEM -->
                <article class=""portfolio-item mix  design  visual "">
                    <div class=""portfolio-image"">
                        <a href=""#.""> <img class=""img-responsive"" alt=""Open Imagination"" src=""images/portfolio/5/img-4.jpg""> </a>
                        <div class=""portfolio-overlay style-4"">
                            <div class=""detail-info"">
                                <div class=""position-center-center"">
            ");
            WriteLiteral(@"                        <h3 class=""no-margin"">Assembly Branding</h3>
                                    <span><a href=""#."">Fashion / trending</a></span> <a href=""#."" class=""go""><i class=""fa fa-search""></i></a> <a href=""#."" class=""go""><i class=""fa fa-link""></i></a>
                                </div>
                            </div>
                        </div>
                    </div>
                </article>

                <!-- ITEM -->
                <article class=""portfolio-item mix brand  photo "">
                    <div class=""portfolio-image"">
                        <a href=""#.""> <img class=""img-responsive"" alt=""Open Imagination"" src=""images/portfolio/5/img-5.jpg""> </a>
                        <div class=""portfolio-overlay style-4"">
                            <div class=""detail-info"">
                                <div class=""position-center-center"">
                                    <h3 class=""no-margin"">Assembly Branding</h3>
                                    <");
            WriteLiteral(@"span><a href=""#."">Fashion / trending</a></span> <a href=""#."" class=""go""><i class=""fa fa-search""></i></a> <a href=""#."" class=""go""><i class=""fa fa-link""></i></a>
                                </div>
                            </div>
                        </div>
                    </div>
                </article>

                <!-- ITEM -->
                <article class=""portfolio-item mix brand "">
                    <div class=""portfolio-image"">
                        <a href=""#.""> <img class=""img-responsive"" alt=""Open Imagination"" src=""images/portfolio/5/img-9.jpg""> </a>
                        <div class=""portfolio-overlay style-4"">
                            <div class=""detail-info"">
                                <div class=""position-center-center"">
                                    <h3 class=""no-margin"">Assembly Branding</h3>
                                    <span><a href=""#."">Fashion / trending</a></span> <a href=""#."" class=""go""><i class=""fa fa-search""></i></a> <a href=""");
            WriteLiteral(@"#."" class=""go""><i class=""fa fa-link""></i></a>
                                </div>
                            </div>
                        </div>
                    </div>
                </article>

                <!-- ITEM -->
                <article class=""portfolio-item mix  photo visual"">
                    <div class=""portfolio-image"">
                        <a href=""#.""> <img class=""img-responsive"" alt=""Open Imagination"" src=""images/portfolio/5/img-7.jpg""> </a>
                        <div class=""portfolio-overlay style-4"">
                            <div class=""detail-info"">
                                <div class=""position-center-center"">
                                    <h3 class=""no-margin"">Assembly Branding</h3>
                                    <span><a href=""#."">Fashion / trending</a></span> <a href=""#."" class=""go""><i class=""fa fa-search""></i></a> <a href=""#."" class=""go""><i class=""fa fa-link""></i></a>
                                </div>
                    ");
            WriteLiteral(@"        </div>
                        </div>
                    </div>
                </article>

                <!-- ITEM -->
                <article class=""portfolio-item mix brand design visual"">
                    <div class=""portfolio-image"">
                        <a href=""#.""> <img class=""img-responsive"" alt=""Open Imagination"" src=""images/portfolio/5/img-8.jpg""> </a>
                        <div class=""portfolio-overlay style-4"">
                            <div class=""detail-info"">
                                <div class=""position-center-center"">
                                    <h3 class=""no-margin"">Assembly Branding</h3>
                                    <span><a href=""#."">Fashion / trending</a></span> <a href=""#."" class=""go""><i class=""fa fa-search""></i></a> <a href=""#."" class=""go""><i class=""fa fa-link""></i></a>
                                </div>
                            </div>
                        </div>
                    </div>
                </article");
            WriteLiteral(@">

                <!-- ITEM -->
                <article class=""portfolio-item mix brand design photo"">
                    <div class=""portfolio-image"">
                        <a href=""#.""> <img class=""img-responsive"" alt=""Open Imagination"" src=""images/portfolio/5/img-9.jpg""> </a>
                        <div class=""portfolio-overlay style-4"">
                            <div class=""detail-info"">
                                <div class=""position-center-center"">
                                    <h3 class=""no-margin"">Assembly Branding</h3>
                                    <span><a href=""#."">Fashion / trending</a></span> <a href=""#."" class=""go""><i class=""fa fa-search""></i></a> <a href=""#."" class=""go""><i class=""fa fa-link""></i></a>
                                </div>
                            </div>
                        </div>
                    </div>
                </article>
            </div>
        </section>
    </div>
</div>");
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
