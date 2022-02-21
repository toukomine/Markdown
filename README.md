# Markdown
Markdown文本转Html

### 用法
`
string html = new MarkdownBuilder()<br/>
                .From("test.txt")<br/>
                .SetTextHelper(new DefaultMarkdownTextHelperImpl())<br/>
                .SetMarkdownGrammarHelper(new DefaultMarkdownGrammarHelperImpl())<br/>
                .SetMarkdownToHtmlHelper(new DefaultMarkdownToHtmlHelperImpl())<br/>
                .SetCssStyle(new DefaultCssStyleImpl("css.css"))<br/>
                .Builder()
                .ToHtml();
`
