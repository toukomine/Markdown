using System;
using System.Collections.Generic;
using System.Text;

namespace Markdown
{
    /// <summary>
    /// Markdown语法解析接口
    /// </summary>
    public interface IMarkdownGrammar
    {
        /// <summary>
        /// 解析Markdown元素
        /// </summary>
        /// <param name="line">要解析的文本</param>
        /// <param name="elements">要解析的文本集合</param>
        /// <param name="index">当前集合的索引</param>
        /// <returns>MarkdownElement</returns>
        MarkdownElement GetMarkdownElement(string line, ref string[] elements, ref int index);
    }
}
