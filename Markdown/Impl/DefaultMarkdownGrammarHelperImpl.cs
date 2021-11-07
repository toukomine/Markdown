using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Markdown
{
    /// <summary>
    /// 默认字符串转Markdown元素实现类
    /// </summary>
    public class DefaultMarkdownGrammarHelperImpl : MarkdownGrammar,IMarkdownGrammarHelper
    {
        /// <summary>
        /// 将字符串数组转换成Markdown元素集合
        /// </summary>
        /// <param name="markdownLines">要转换的字符串数组</param>
        /// <returns>MarkdownElement集合</returns>
        public IList<MarkdownElement> Process(string[] markdownLines) {

            IList<MarkdownElement> markdownElements = new List<MarkdownElement>();

            int len = markdownLines.Length;
            for (int i = 0; i < len; i++)
            {
                var element = GetMarkdownElement(markdownLines[i], ref markdownLines, ref i);
                if (element != null) {
                    markdownElements.Add(element);
                }
            }

            return markdownElements;
        }
    }
}
