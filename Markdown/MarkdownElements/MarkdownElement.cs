namespace Markdown
{
    /// <summary>
    /// Markdown元素
    /// </summary>
    public class MarkdownElement
    {
        /// <summary>
        /// Markdown元素类型
        /// </summary>
        public MarkdownElementEnum ElementEnum { get; set; }
        /// <summary>
        /// InnerText
        /// </summary>
        public string InnerText { get; set; }
        /// <summary>
        /// 嵌套元素
        /// </summary>
        public MarkdownElement Children { get; set; }

        /// <summary>
        /// MarkdownElement
        /// </summary>
        public MarkdownElement(){

        }

        /// <summary>
        /// MarkdownElement
        /// </summary>
        /// <param name="text">InnerText</param>
        /// <param name="markdownElementEnum">MarkdownElement类型</param>
        public MarkdownElement(string text, MarkdownElementEnum markdownElementEnum)
        {
            InnerText = text;
            ElementEnum = markdownElementEnum;
        }
    }
}
