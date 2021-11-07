using System;
using System.Collections.Generic;
using System.Text;

namespace Markdown
{
    /// <summary>
    /// Markdown无序列表
    /// </summary>
    public class ULElement:MarkdownElement
    {
        private List<MarkdownElement> _rows;
        /// <summary>
        /// 列表行
        /// </summary>
        public List<MarkdownElement> Rows
        {
            get
            {
                if (_rows == null) {
                    _rows = new List<MarkdownElement>();
                }
                return _rows;
            }
        }
    }
}
