namespace Markdown
{
    /// <summary>
    /// Markdown构造器
    /// </summary>
    public class MarkdownBuilder
    {
        private ITextHelper _textHelper;
        private IMarkdownGrammarHelper _markdownGrammarHelper;
        private IMarkdownToHtmlHelper _markdownToHtmlHelper;
        private CssStyle _cssStyle;

        /// <summary>
        /// 构造默认的Markdown解析器
        /// </summary>
        public MarkdownBuilder() {
            _textHelper = new DefaultMarkdownTextHelperImpl();
            _markdownGrammarHelper = new DefaultMarkdownGrammarHelperImpl();
            _markdownToHtmlHelper = new DefaultMarkdownToHtmlHelperImpl();
            _cssStyle = new DefaultCssStyleImpl(string.Empty);
        }

        /// <summary>
        /// 设置Markdown文本处理器
        /// </summary>
        /// <param name="textHelper">ITextHelper</param>
        /// <returns>MarkdownBuilder</returns>
        public MarkdownBuilder SetTextHelper(ITextHelper textHelper)
        {
            _textHelper = textHelper;

            return this;
        }

        /// <summary>
        /// 设置Markdown文本语法处理器
        /// </summary>
        /// <param name="markdownGrammarHelper">IMarkdownGrammarHelper</param>
        /// <returns>MarkdownBuilder</returns>
        public MarkdownBuilder SetMarkdownGrammarHelper(IMarkdownGrammarHelper markdownGrammarHelper)
        {
            _markdownGrammarHelper = markdownGrammarHelper;

            return this;
        }

        /// <summary>
        /// 设置Markdown元素转Html标签处理器
        /// </summary>
        /// <param name="markdownToHtmlHelper">IMarkdownToHtmlHelper</param>
        /// <returns>MarkdownBuilder</returns>
        public MarkdownBuilder SetMarkdownToHtmlHelper(IMarkdownToHtmlHelper markdownToHtmlHelper)
        {
            _markdownToHtmlHelper = markdownToHtmlHelper;

            return this;
        }

        /// <summary>
        /// 设置Css实现器
        /// </summary>
        /// <param name="style">CssStyle</param>
        /// <returns>MarkdownBuilder</returns>
        public MarkdownBuilder SetCssStyle(CssStyle style)
        {
            _cssStyle = style;

            return this;
        }

        /// <summary>
        /// 构建Markdown解析器
        /// </summary>
        /// <returns>MarkdownHelper</returns>
        public MarkdownHelper Builder()
        {
            MarkdownHelper markdownHelper = new MarkdownHelper
            {
                TextHelper = _textHelper,
                MarkdownGrammarHelper = _markdownGrammarHelper,
                MarkdownToHtmlHelper = _markdownToHtmlHelper,
                CssStyle = _cssStyle
            };

            return markdownHelper;
        }
    }
}
