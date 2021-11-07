using System;
using System.Collections.Generic;
using System.Text;

namespace Markdown
{
    /// <summary>
    /// 默认Markdown转html实现类
    /// </summary>
    public class DefaultMarkdownToHtmlHelperImpl :MarkdownToHtml,IMarkdownToHtmlHelper
    {
        /// <summary>
        /// 将Markdown元素集合转换成html
        /// </summary>
        /// <param name="markdownElements">markdown元素集合</param>
        /// <param name="cssStyle">Css样式</param>
        /// <returns></returns>
        public string Process(IList<MarkdownElement> markdownElements,CssStyle cssStyle) {
            StringBuilder html = new StringBuilder();

            List<HtmlTag> tags = new List<HtmlTag>();
            foreach (var element in markdownElements){
                html.Append("\r\n");
                var tag = GetHtmlTag(element, cssStyle);
                if (tag != null) {
                    tags.Add(tag);
                }
                html.Append(tag.ToString());
                html.Append("\r\n");
            }

            return html.ToString();
        }

        /// <summary>
        /// 获取Markdown元素集合的HtmlTag集合
        /// </summary>
        /// <param name="markdownElements">MarkdownElement</param>
        /// <param name="cssStyle">Css样式</param>
        /// <returns>HtmlTag集合</returns>
        public IList<HtmlTag> GetHtmlTags(IList<MarkdownElement> markdownElements, CssStyle cssStyle) {
            List<HtmlTag> tags = new List<HtmlTag>();
            foreach (var element in markdownElements){
                var tag = GetHtmlTag(element, cssStyle);
                if (tag != null) {
                    tags.Add(tag);
                }
            }
            return tags;
        }
    }
}
