# Markdown
Markdown文本转Html

### 用法
```
string html = new MarkdownBuilder()
                .From("test.txt")
                .SetTextHelper(new DefaultMarkdownTextHelperImpl())
                .SetMarkdownGrammarHelper(new DefaultMarkdownGrammarHelperImpl())
                .SetMarkdownToHtmlHelper(new DefaultMarkdownToHtmlHelperImpl())
                .SetCssStyle(new DefaultCssStyleImpl("css.css"))
                .Builder()
                .ToHtml();
```
