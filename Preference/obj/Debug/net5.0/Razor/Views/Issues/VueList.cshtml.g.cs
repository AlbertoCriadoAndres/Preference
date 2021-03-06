#pragma checksum "C:\GitCode\Preference\Preference\Views\Issues\VueList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "95c071de7474c5c2fc615adc7c876fa24d974b4f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Issues_VueList), @"mvc.1.0.view", @"/Views/Issues/VueList.cshtml")]
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
#line 1 "C:\GitCode\Preference\Preference\Views\_ViewImports.cshtml"
using Preference;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\GitCode\Preference\Preference\Views\_ViewImports.cshtml"
using Preference.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"95c071de7474c5c2fc615adc7c876fa24d974b4f", @"/Views/Issues/VueList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"310244292401a0f514ef2b075f2fed25f289b5ae", @"/Views/_ViewImports.cshtml")]
    public class Views_Issues_VueList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Preference.Models.VueListViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\GitCode\Preference\Preference\Views\Issues\VueList.cshtml"
  
    ViewData["Title"] = "Vue list";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div id=""app"">
    <div class=""text-center"">
        <h1 class=""display-4"">Vue list</h1>
        <hr />
        <div v-if=""issues.length > 0"">
            <table class=""table"">
                <thead>
                    <tr>
                        <th>
                            Title
                        </th>
                        <th>
                            Severity
                        </th>
                        <th>
                            Status
                        </th>
                        <th>
                            Asignee
                        </th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for=""issue in issues"">
                        <td>
                            <input type=""text"" v-model=""issue.title"" v-on:change=""autoSave(issue)"" />
                        </td>
                        <td>
                            <v-select v-m");
            WriteLiteral(@"odel=""issue.severity"" v-on:input=""autoSave(issue)"" :options=""severities"" label=""description""></v-select>
                        </td>
                        <td>
                            <v-select v-model=""issue.status"" v-on:input=""autoSave(issue)"" :options=""statuses"" label=""description""></v-select>
                        </td>
                        <td>
                            <v-select v-model=""issue.asignee"" v-on:input=""autoSave(issue)"" :options=""users"" label=""name"" :reduce=""name => name.id""></v-select>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
</div>

");
            DefineSection("scripts", async() => {
                WriteLiteral("\r\n    <script>\r\n        /*External component*/\r\n        Vue.component(\'v-select\', VueSelect.VueSelect);\r\n\r\n        let app = new Vue({\r\n            el: \'#app\',\r\n            data: {\r\n                issues: ");
#nullable restore
#line 59 "C:\GitCode\Preference\Preference\Views\Issues\VueList.cshtml"
                   Write(Html.Raw(Json.Serialize(Model.Issues)));

#line default
#line hidden
#nullable disable
                WriteLiteral(",\r\n                severities: ");
#nullable restore
#line 60 "C:\GitCode\Preference\Preference\Views\Issues\VueList.cshtml"
                       Write(Html.Raw(Json.Serialize(Model.Severities)));

#line default
#line hidden
#nullable disable
                WriteLiteral(",/*Combo data*/\r\n                statuses: ");
#nullable restore
#line 61 "C:\GitCode\Preference\Preference\Views\Issues\VueList.cshtml"
                     Write(Html.Raw(Json.Serialize(Model.Statuses)));

#line default
#line hidden
#nullable disable
                WriteLiteral(@",/*Combo data*/
                users: [],/*Combo data*/
                connection: null,
            },
            created() {
                /*Get users*/
                fetch('https://jsonplaceholder.typicode.com/users')
                    .then(response => response.json())
                    .then(json => this.users = json);

                /*Init SignalR*/
                this.connection = new signalR.HubConnectionBuilder().withUrl(""/issueHub"").build();

                this.connection.on(""ReceiveIssue"", function (issue) {
                    let foundIndex = app.issues.findIndex(x => x.id == issue.id);
                    Vue.set(app.issues, foundIndex, issue);
                });

                this.connection.start().catch(function (err) {
                    return console.error(err.toString());
                });
            },
            methods: {
                /*TODO:Add event listener,more maintainable and reusable code (vs attributes)*/
                autoS");
                WriteLiteral(@"ave: function (issue) {
                    /*TODO:Optimize to save by property not by record*/
                    fetch(`../Issues/AutoSave?Id=${issue.id}&Title=${issue.title}&SeverityId=${issue.severity.id}&StatusId=${issue.status.id}&Asignee=${issue.asignee}`,
                        {method: 'POST'})
                        .then(response => response.json())
                        .then(data => {
                            if (data) {
                                /*TODO: Invoke in the sever part, like entity(Issue) event(onChange)*/
                                this.connection.invoke(""SendIssue"", issue).catch(function (err) {
                                    return console.error(err.toString());
                                });
                            } else {
                                alert('Ops... Could you try again?');
                            }
                        });
                }
            }
        })
    </script>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Preference.Models.VueListViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
