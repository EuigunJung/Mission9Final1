using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Mission7.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission7.Infrastructure
{
    //What tag is it going to be used with?
    [HtmlTargetElement("div", Attributes = "page-blah")]

    public class PaginationTagHelper : TagHelper
    {
        //Dynamically create the page links for us 

        private IUrlHelperFactory uhf;

        public PaginationTagHelper (IUrlHelperFactory temp)
        {
            uhf = temp;
        }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext vc { get; set; }
        
        //Different than the View Context
        public PageInfo PageBlah { get; set; }
        public string PageAction { get; set; }

        public override void Process (TagHelperContext thc, TagHelperOutput tho)
        {
            IUrlHelper uh = uhf.GetUrlHelper(vc);

            TagBuilder final = new TagBuilder("div");

            // loop to add a tag with a url and action.
            for (int i = 1; i < PageBlah.TotalPages; i++)
            {
                TagBuilder tb = new TagBuilder("a");
                // Add href attribute with action, page number 
                tb.Attributes["href"] = uh.Action(PageAction, new { pageNum = i });
                tb.InnerHtml.Append(i.ToString());

                final.InnerHtml.AppendHtml(tb);
            }
            // add the final innerhtml in the "tagtaghelperoutput"
            tho.Content.AppendHtml(final.InnerHtml);
        }
    }
}
