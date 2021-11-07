using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Markdown
{
    /// <summary>
    /// Markdown表格元素
    /// </summary>
    public class TableElement:MarkdownElement
    {
        private IList<IList<MarkdownElement>> _rows;
        /// <summary>
        /// 表格行
        /// </summary>
        public IList<IList<MarkdownElement>> Rows
        {
            get
            {
                if (_rows == null) {
                    _rows = new List<IList<MarkdownElement>>();
                }
                return _rows;
            }
        }
    }
}
