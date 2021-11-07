using System;
using System.Collections.Generic;
using System.Text;

namespace Markdown
{
    /// <summary>
    /// Markdown引用元素
    /// </summary>
    public class QuoteElement:MarkdownElement
    {
        /// <summary>
        /// 下级引用
        /// </summary>
        public QuoteElement NextQuote { get; set; }
    }
}
