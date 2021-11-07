using System;
using System.Collections.Generic;
using System.Text;

namespace Markdown
{
    /// <summary>
    /// 字符集合转Markdown集合接口
    /// </summary>
    public interface IMarkdownGrammarHelper
    {
        /// <summary>
        /// 字符串集合转Markdown集合
        /// </summary>
        /// <param name="markdownLines">要解析的文本集合</param>
        /// <returns>Markdown集合</returns>
        IList<MarkdownElement> Process(string[] markdownLines);
    }
}
