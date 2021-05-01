#pragma checksum "C:\Users\Abbas\source\repos\Web Resume Solution\Web Resume\Views\Home\Resume.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "21eaba83110594a245125268ab464c4f09c84578"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Resume), @"mvc.1.0.view", @"/Views/Home/Resume.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"21eaba83110594a245125268ab464c4f09c84578", @"/Views/Home/Resume.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ca24ab2b549cb081871d639ee99246da6f4b56f8", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Resume : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Person>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Abbas\source\repos\Web Resume Solution\Web Resume\Views\Home\Resume.cshtml"
  
    ViewData["Title"] = "Resume";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"col-md-8\">\r\n    <div class=\"inside-sec\">\r\n        <!-- BIO AND SKILLS -->\r\n        <h5 class=\"tittle\">");
#nullable restore
#line 9 "C:\Users\Abbas\source\repos\Web Resume Solution\Web Resume\Views\Home\Resume.cshtml"
                      Write(Model.BioInfo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n        <div class=\"bio-info padding-30\">\r\n            ");
#nullable restore
#line 11 "C:\Users\Abbas\source\repos\Web Resume Solution\Web Resume\Views\Home\Resume.cshtml"
       Write(Html.Raw(Model.BioDesc));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            <div class=\"skills\">\r\n\r\n                <!-- HARD SKILLS -->\r\n");
#nullable restore
#line 15 "C:\Users\Abbas\source\repos\Web Resume Solution\Web Resume\Views\Home\Resume.cshtml"
                 foreach (var parentCategory in Model.Skills.Select(delegate (PersonSkillItem s)
             {
                 var category = s.Skill.SkillCategory;

                 while (category.ParentId != null)
                 {
                     category = category.Parent;
                 }

                 return category;


             }).Distinct())
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <h5 class=\"margin-top-30\">");
#nullable restore
#line 29 "C:\Users\Abbas\source\repos\Web Resume Solution\Web Resume\Views\Home\Resume.cshtml"
                                         Write(parentCategory.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n");
#nullable restore
#line 30 "C:\Users\Abbas\source\repos\Web Resume Solution\Web Resume\Views\Home\Resume.cshtml"
                    foreach (var childCategory in parentCategory.Children)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <h6>");
#nullable restore
#line 32 "C:\Users\Abbas\source\repos\Web Resume Solution\Web Resume\Views\Home\Resume.cshtml"
                       Write(childCategory.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n                        <div class=\"panel-group accordion\" id=\"accordion1\">\r\n");
#nullable restore
#line 34 "C:\Users\Abbas\source\repos\Web Resume Solution\Web Resume\Views\Home\Resume.cshtml"
                             foreach (var skill in Model.Skills.Where(s=> s.Skill.CategoryId == childCategory.Id))
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                            <div class=""panel panel-default"">
                                <div class=""row"">
                                    <div class=""col-sm-4"">
                                        <!-- PANEL HEADING -->
                                        <div class=""panel-heading"">
                                            <h4 class=""panel-title"">
                                                <a data-toggle=""collapse"" 
                                                   data-parent=""#accordion1""");
            BeginWriteAttribute("href", " \r\n                                                   href=\"", 1731, "\"", 1816, 2);
            WriteAttributeValue("", 1791, "#collapse", 1791, 9, true);
#nullable restore
#line 44 "C:\Users\Abbas\source\repos\Web Resume Solution\Web Resume\Views\Home\Resume.cshtml"
WriteAttributeValue("", 1800, skill.SkillId, 1800, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" \r\n                                                   class=\"collapsed\">");
#nullable restore
#line 45 "C:\Users\Abbas\source\repos\Web Resume Solution\Web Resume\Views\Home\Resume.cshtml"
                                                                Write(skill.Skill.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                                </a>
                                            </h4>
                                        </div>
                                    </div>

                                    <!-- Skillls Bars -->
                                    <div class=""col-sm-8"">
                                        <div class=""progress"">
                                            <div class=""progress-bar"" role=""progressbar"" aria-valuenow=""100"" aria-valuemin=""0"" aria-valuemax=""100"" style=""width: 100%;""> <span class=""sr-only"">");
#nullable restore
#line 54 "C:\Users\Abbas\source\repos\Web Resume Solution\Web Resume\Views\Home\Resume.cshtml"
                                                                                                                                                                                          Write(skill.Skill.Score);

#line default
#line hidden
#nullable disable
            WriteLiteral("% Complete</span> </div>\r\n                                        </div>\r\n\r\n                                        <!-- Skillls Text -->\r\n                                        <div");
            BeginWriteAttribute("id", " id=\"", 2682, "\"", 2711, 2);
            WriteAttributeValue("", 2687, "collapse", 2687, 8, true);
#nullable restore
#line 58 "C:\Users\Abbas\source\repos\Web Resume Solution\Web Resume\Views\Home\Resume.cshtml"
WriteAttributeValue("", 2695, skill.SkillId, 2695, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"panel-collapse collapse\">\r\n                                            <div class=\"panel-body\">\r\n                                                <p>");
#nullable restore
#line 60 "C:\Users\Abbas\source\repos\Web Resume Solution\Web Resume\Views\Home\Resume.cshtml"
                                              Write(skill.Skill.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                            </div>\r\n                                        </div>\r\n                                    </div>\r\n                                </div>\r\n                            </div>\r\n");
#nullable restore
#line 66 "C:\Users\Abbas\source\repos\Web Resume Solution\Web Resume\Views\Home\Resume.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </div>\r\n");
#nullable restore
#line 68 "C:\Users\Abbas\source\repos\Web Resume Solution\Web Resume\Views\Home\Resume.cshtml"
                    }
                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"


                <!-- Soft Skills -->

                <!-- Application of knowledge -->
                <!--<h6>Application of knowledge</h6>-->

                <!-- Follow ethical -->
                <!--<div class=""ethical"">
                    <h6>Follow ethical work practices</h6>
                    <a href=""#."">Prioritize Learning Tasks</a> <a href=""#."">Make Ethical Choices</a> <a href=""#."">Social Work</a> <a href=""#."">Community Work</a>
                </div>-->
            </div>
        </div>
    </div>

    <!-- Professional Experience -->
    <div class=""inside-sec margin-top-30"">
        <!-- Professional Experience -->
        <h5 class=""tittle"">Professional Experience</h5>
        <div class=""padding-30 exp-history"">

            <!-- Wordpress Developer -->
");
#nullable restore
#line 94 "C:\Users\Abbas\source\repos\Web Resume Solution\Web Resume\Views\Home\Resume.cshtml"
             foreach (var experience in @Model.Experiences)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"exp\">\r\n                    <div class=\"media-left\"> <span class=\"sun\">");
#nullable restore
#line 97 "C:\Users\Abbas\source\repos\Web Resume Solution\Web Resume\Views\Home\Resume.cshtml"
                                                          Write(experience.StartDate);

#line default
#line hidden
#nullable disable
            WriteLiteral(" - ");
#nullable restore
#line 97 "C:\Users\Abbas\source\repos\Web Resume Solution\Web Resume\Views\Home\Resume.cshtml"
                                                                                  Write(experience.EndDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span> </div>\r\n                    <div class=\"media-body\">\r\n\r\n                        <!-- COmpany Logo -->\r\n                        <div class=\"company-logo\"> <img src=\"images/company-logo-1.jpg\"");
            BeginWriteAttribute("alt", " alt=\"", 4450, "\"", 4456, 0);
            EndWriteAttribute();
            WriteLiteral("> </div>\r\n                        <h6>");
#nullable restore
#line 102 "C:\Users\Abbas\source\repos\Web Resume Solution\Web Resume\Views\Home\Resume.cshtml"
                       Write(experience.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n                        <p>");
#nullable restore
#line 103 "C:\Users\Abbas\source\repos\Web Resume Solution\Web Resume\Views\Home\Resume.cshtml"
                      Write(experience.Position);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                        <p>");
#nullable restore
#line 104 "C:\Users\Abbas\source\repos\Web Resume Solution\Web Resume\Views\Home\Resume.cshtml"
                      Write(experience.Location);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                        <p class=\"margin-top-10\">");
#nullable restore
#line 105 "C:\Users\Abbas\source\repos\Web Resume Solution\Web Resume\Views\Home\Resume.cshtml"
                                            Write(experience.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("<a href=\"#.\">Read More</a> </p>\r\n                    </div>\r\n                </div>\r\n");
#nullable restore
#line 108 "C:\Users\Abbas\source\repos\Web Resume Solution\Web Resume\Views\Home\Resume.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            <!-- html5 and css3 Developer -->
        </div>
    </div>

    <!-- Academic Background -->
    <div class=""inside-sec margin-top-30"">
        <!-- Academic Background -->
        <h5 class=""tittle"">Academic Background</h5>
        <div class=""padding-30 exp-history"">

            <!-- Wordpress Developer -->
            <div class=""exp"">
                <div class=""media-left""> <span class=""sun"">2002 - 2008</span> </div>
                <div class=""media-body"">
                    <!-- COmpany Logo -->
                    <div class=""company-logo""> <span class=""diploma""><i class=""fa fa-graduation-cap""></i> Download Diploma</span> </div>
                    <h6>Multimedia Arts</h6>
                    <p>Market Network</p>
                    <p>San Francisco, California, USA</p>
                    <p class=""margin-top-10""> Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin nibh augue, suscipit a, scelerisque sed, lacinia in, mi. Cras vel lorem. Etiam pellentesque");
            WriteLiteral(@" aliquet tellus. Phasellus pharetra nulla ac diam (...) <a href=""#."">Read More</a> </p>
                </div>
            </div>

            <!-- html5 and css3 Developer -->
            <div class=""exp"">
                <div class=""media-left""> <span class=""sun"">2009 - 2016</span> </div>
                <div class=""media-body"">
                    <!-- COmpany Logo -->
                    <div class=""company-logo""> <span class=""diploma""><i class=""fa fa-graduation-cap""></i> Download Diploma</span> </div>
                    <h6>Mathematics in computer science</h6>
                    <p>Market Network</p>
                    <p>San Francisco, California, USA</p>
                    <p class=""margin-top-10""> Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin nibh augue, suscipit a, scelerisque sed, lacinia in, mi. Cras vel lorem. Etiam pellentesque aliquet tellus. Phasellus pharetra nulla ac diam (...) <a href=""#."">Read More</a> </p>
                </div>
            </div>
     ");
            WriteLiteral("   </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Person> Html { get; private set; }
    }
}
#pragma warning restore 1591
