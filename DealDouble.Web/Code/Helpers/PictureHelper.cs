using DealDouble.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DealDouble.Web.Code.Helpers
{
    public static class PictureHelper
    {
        public static MvcHtmlString Picture(this HtmlHelper htmlHelper, Picture picture, string classes = "", string style = "", string alt = "")
        {
            var picURL = picture != null ? picture.URL : "";

            return Picture(htmlHelper, picURL, classes, style, alt);
        }

        public static MvcHtmlString Picture(this HtmlHelper htmlHelper, string pictureURL, string classes = "", string style = "", string alt = "")
        {
            pictureURL = string.IsNullOrEmpty(pictureURL) ? "site/default-picture.png" : pictureURL;

            var image = new TagBuilder("img");
            image.AddCssClass(classes);
            image.MergeAttribute("style", style);
            image.MergeAttribute("src", string.Format("/content/images/{0}", pictureURL));
            image.MergeAttribute("alt", alt);

            return MvcHtmlString.Create(image.ToString());
        }
    }
}