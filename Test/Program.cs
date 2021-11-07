using Markdown;
using System;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            string html = new MarkdownBuilder()
                            .SetTextHelper(new DefaultMarkdownTextHelperImpl())
                            .SetMarkdownGrammarHelper(new DefaultMarkdownGrammarHelperImpl())
                            .SetMarkdownToHtmlHelper(new DefaultMarkdownToHtmlHelperImpl())
                            .SetCssStyle(new DefaultCssStyleImpl("css.css"))
                            .Builder()
                            .Process("test.txt");

            Console.WriteLine(html);
            Console.ReadKey();
        }
    }
}
