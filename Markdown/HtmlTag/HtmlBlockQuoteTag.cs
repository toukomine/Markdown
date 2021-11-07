using System;
using System.Collections.Generic;
using System.Text;

namespace Markdown
{
    /// <summary>
    /// Html blockquote标签
    /// </summary>
    public class HtmlBlockQuoteTag:HtmlTag
    {
        /// <summary>
        /// 下级引用
        /// </summary>
        public HtmlBlockQuoteTag NextQuote { get; set; }

        /// <summary>
        /// 将多级blockquote转换成html字符串
        /// </summary>
        /// <returns>html字符串</returns>
        public override string ToString()
        {
            StringBuilder htmlTag = new StringBuilder();
            htmlTag.Append(Head);
            htmlTag.Append(Children.ToString());

            Append(NextQuote, htmlTag);

            htmlTag.Append(End);

            return htmlTag.ToString();
        }

        private void Append(HtmlBlockQuoteTag rootTag, StringBuilder htmlTag) {
            if (rootTag == null) {
                return;
            }
            htmlTag.Append(rootTag.Head);
            htmlTag.Append(rootTag.Children);

            var nextQuote = rootTag.NextQuote;

            if (rootTag != null){
                Append(nextQuote, htmlTag);
            }

            htmlTag.Append(rootTag.End);
        }
    }
}
