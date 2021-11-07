using System;
using System.Collections.Generic;
using System.Text;

namespace Markdown
{
    /// <summary>
    /// Markdown转Html接口
    /// </summary>
    public interface IMarkdownToHtmlHelper
    {
        /// <summary>
        /// Markdown元素集合转Html字符串
        /// </summary>
        /// <param name="markdownElements">markdown元素集合</param>
        /// <param name="cssStyle">Css样式</param>
        /// <returns>Html字符串</returns>
        string Process(IList<MarkdownElement> markdownElements, CssStyle cssStyle);

        /// <summary>
        /// Markdown元素集合转HtmlTag集合
        /// </summary>
        /// <param name="markdownElements">markdown元素集合</param>
        /// <param name="cssStyle">Css样式</param>
        /// <returns>HtmlTag集合</returns>
        IList<HtmlTag> GetHtmlTags(IList<MarkdownElement> markdownElements, CssStyle cssStyle);
    }
}
