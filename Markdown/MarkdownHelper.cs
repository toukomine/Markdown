using System;
using System.Collections.Generic;
using System.Text;

namespace Markdown
{
    /// <summary>
    /// Markdown解析器
    /// </summary>
    public class MarkdownHelper
    {
        /// <summary>
        /// 文本处理
        /// </summary>
        public ITextHelper TextHelper { get; set; }
        /// <summary>
        /// 语法转换
        /// </summary>
        public IMarkdownGrammarHelper MarkdownGrammarHelper { get; set; }
        /// <summary>
        /// html转换
        /// </summary>
        public IMarkdownToHtmlHelper MarkdownToHtmlHelper { get; set; }
        /// <summary>
        /// 样式实现
        /// </summary>
        public CssStyle CssStyle { get; set; }
        /// <summary>
        /// markdown文本或路径
        /// </summary>
        public string MarkdownStr { get; set; }

        internal MarkdownHelper() { 
            
        }

        /// <summary>
        /// 将markdown转换成html标签
        /// </summary>
        /// <param name="filePath">markdown文件/路径</param>
        /// <returns>html标签文本</returns>
        public string ToHtml() {
            var lines = TextHelper.Process(MarkdownStr);
            var markdownElements = MarkdownGrammarHelper.Process(lines);
            var htmlTags = MarkdownToHtmlHelper.Process(markdownElements,CssStyle);

            return htmlTags;
        }

        /// <summary>
        /// 获取markdown元素转换的html标签集合
        /// </summary>
        /// <param name="filePath">markdown文件/路径</param>
        /// <returns>IList集合</returns>
        public IList<HtmlTag> GetHtmlTags(string filePath) {
            var lines = TextHelper.Process(filePath);
            var markdownElements = MarkdownGrammarHelper.Process(lines);

            return MarkdownToHtmlHelper.GetHtmlTags(markdownElements, CssStyle);
        }

        /// <summary>
        /// 获取markdown文本转换的markdown元素集合
        /// </summary>
        /// <param name="filePath">markdown文件/路径</param>
        /// <returns>IList集合</returns>
        public IList<MarkdownElement> GetMarkdownElements(string filePath) {
            var lines = TextHelper.Process(filePath);

            return MarkdownGrammarHelper.Process(lines);
        }
    }
}
