using System;
using System.Collections.Generic;
using System.Text;

namespace Markdown
{
    /// <summary>
    /// 无序列表标签
    /// </summary>
    public class ULHtmlTag:HtmlTag
    {
        private List<HtmlTag> _rows;
        /// <summary>
        /// Ul列表集合
        /// </summary>
        public List<HtmlTag> Rows
        {
            get
            {
                if (_rows == null) {
                    _rows = new List<HtmlTag>();
                }
                return _rows;
            }
        }

        /// <summary>
        /// 将ul列表转换成html字符串
        /// </summary>
        /// <returns>html字符串</returns>
        public override string ToString()
        {
            StringBuilder htmlTag = new StringBuilder();

            htmlTag.Append(Head);

            foreach (var row in Rows){
                htmlTag.Append("<li>");
                htmlTag.Append(row.ToString());
                htmlTag.Append("</li>");
            }

            htmlTag.Append(End);

            return htmlTag.ToString();
        }
    }
}
