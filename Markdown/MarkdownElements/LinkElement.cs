using System;
using System.Collections.Generic;
using System.Text;

namespace Markdown
{
    /// <summary>
    /// Markdown Link元素
    /// </summary>
    public class LinkElement:MarkdownElement
    {
        /// <summary>
        /// href地址
        /// </summary>
        public string Href { get; set; }
    }
}
