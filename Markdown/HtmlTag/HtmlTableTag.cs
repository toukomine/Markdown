using System;
using System.Collections.Generic;
using System.Text;

namespace Markdown
{
    /// <summary>
    /// Html Table标签
    /// </summary>
    public class HtmlTableTag:HtmlTag
    {
        private IList<IList<HtmlTag>> _rows;
        /// <summary>
        /// Table Rows
        /// </summary>
        public IList<IList<HtmlTag>> Rows
        {
            get {
                if (_rows == null) {
                    _rows = new List<IList<HtmlTag>>();
                }
                return _rows;
            }
        }

        /// <summary>
        /// 将HtmlTable转换成Html字符串
        /// </summary>
        /// <returns>html字符串</returns>
        public override string ToString()
        {
            StringBuilder htmlTag = new StringBuilder();
            htmlTag.Append(Head);
            if (Rows == null){
                return string.Empty;
            }

            foreach (var row in Rows){
                htmlTag.Append("<tr>");
                foreach (var column in row){
                    htmlTag.Append("<td>");
                    htmlTag.Append(column.ToString());
                    htmlTag.Append("</td>");
                }
                htmlTag.Append("</tr>");
            }
            htmlTag.Append(End);
            return htmlTag.ToString();
        }
    }
}
