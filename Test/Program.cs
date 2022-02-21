using Markdown;
using System;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            string html = new MarkdownBuilder()
                .From("test.txt")
                .SetTextHelper(new DefaultMarkdownTextHelperImpl())
                .SetMarkdownGrammarHelper(new DefaultMarkdownGrammarHelperImpl())
                .SetMarkdownToHtmlHelper(new DefaultMarkdownToHtmlHelperImpl())
                .SetCssStyle(new DefaultCssStyleImpl("css.css"))
                .Builder()
                .ToHtml();

            Console.WriteLine(html);
            Console.ReadKey();
        }
    }
}
