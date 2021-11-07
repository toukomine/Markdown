using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Markdown
{
    /// <summary>
    /// Markdown语法解析类
    /// </summary>
    public abstract class MarkdownGrammar : IMarkdownGrammar
    {
        /// <summary>
        /// H1-H6
        /// </summary>
        public const string TITLE = "#";
        /// <summary>
        /// 字体样式
        /// </summary>
        public const string FONT1 = "*";
        /// <summary>
        /// 字体删除线
        /// </summary>
        public const string FONT2 = "~";
        /// <summary>
        /// 引用标签
        /// </summary>
        public const string QUOTE = ">";
        /// <summary>
        /// 分割线
        /// </summary>
        public const string SEPARATOR = "-";
        /// <summary>
        /// 图片
        /// </summary>
        public const string IMG = "!";
        /// <summary>
        /// 链接
        /// </summary>
        public const string LINK = "[";
        /// <summary>
        /// 无序列表
        /// </summary>
        public const string UL = "+";
        /// <summary>
        /// 有序列表
        /// </summary>
        public const string OL = ".";
        /// <summary>
        /// 表格
        /// </summary>
        public const string TABLE = "|";
        /// <summary>
        /// 代码块
        /// </summary>
        public const string CODE = "`";

        /// <summary>
        /// 一级标题
        /// </summary>
        public const string TITLE1 = "# ";
        /// <summary>
        /// 二级标题
        /// </summary>
        public const string TITLE2 = "## ";
        /// <summary>
        /// 三级标题
        /// </summary>
        public const string TITLE3 = "### ";
        /// <summary>
        /// 四级标题
        /// </summary>
        public const string TITLE4 = "#### ";
        /// <summary>
        /// 五级标题
        /// </summary>
        public const string TITLE5 = "##### ";
        /// <summary>
        /// 六级标题
        /// </summary>
        public const string TITLE6 = "###### ";
        /// <summary>
        /// 文字加粗
        /// </summary>
        public const string FONT_BOLD = "**";
        /// <summary>
        /// 文字倾斜
        /// </summary>
        public const string FONT_TILT = "*";
        /// <summary>
        /// 文件加粗倾斜
        /// </summary>
        public const string FONT_BOLD_TILT = "***";
        /// <summary>
        /// 删除线
        /// </summary>
        public const string STRIKETHROUGH = "~~";

        /// <summary>
        /// 将Markdown文本转换成对应的Markdown元素
        /// </summary>
        /// <param name="line">要转换的文本</param>
        /// <param name="elements">要转换的文本集合</param>
        /// <param name="index">当前索引</param>
        /// <returns>Markdown元素</returns>
        public MarkdownElement GetMarkdownElement(string line, ref string[] elements, ref int index)
        {

            MarkdownElement rootElement = null;

            if (string.IsNullOrWhiteSpace(line))
            {
                return null;
            }

            string head = line[0].ToString();
            switch (head)
            {
                case TITLE:
                    rootElement = GetTitleElement(line);
                    break;
                case FONT1:
                    rootElement = GetFontElement(line);
                    break;
                case FONT2:
                    rootElement = GetFont2Element(line);
                    break;
                case QUOTE:
                    rootElement = GetQuoteElement(ref elements, ref index);
                    break;
                case SEPARATOR:
                    rootElement = GetSeparatorElement(line);
                    break;
                case IMG:
                    rootElement = GetImageElement(line);
                    break;
                case UL:
                    rootElement = GetUlElement(ref elements, ref index);
                    break;
                case LINK:
                    rootElement = GetLinkElement(line);
                    break;
                case TABLE:
                    rootElement = GetTableElement(ref elements, ref index);
                    break;
                case CODE:
                    rootElement = GetCodeElement(line);
                    break;
                default:

                    break;
            }

            if (rootElement != null)
            {
                if (rootElement.ElementEnum != MarkdownElementEnum.Text && rootElement.ElementEnum != MarkdownElementEnum.Table)
                {
                    //递归遍历嵌套语法
                    rootElement.Children = GetMarkdownElement(rootElement.InnerText, ref elements, ref index);
                }
            }

            return rootElement;
        }

        /// <summary>
        /// 解析1 ~ 6级标题语法
        /// </summary>
        /// <param name="text">要解析的文本</param>
        /// <returns>Markdown元素</returns>
        public virtual MarkdownElement GetTitleElement(string text)
        {
            var regex1 = "^# .*$";
            var regex2 = "^## .*$";
            var regex3 = "^### .*$";
            var regex4 = "^#### .*$";
            var regex5 = "^##### .*$";
            var regex6 = "^###### .*$";

            MarkdownElement element = new MarkdownElement();

            if (Regex.IsMatch(text, regex1))
            {
                element.ElementEnum = MarkdownElementEnum.Title1;
                element.InnerText = text.Substring(2);
            }
            else if (Regex.IsMatch(text, regex2))
            {
                element.ElementEnum = MarkdownElementEnum.Title2;
                element.InnerText = text.Substring(3);
            }
            else if (Regex.IsMatch(text, regex3))
            {
                element.ElementEnum = MarkdownElementEnum.Title3;
                element.InnerText = text.Substring(4);
            }
            else if (Regex.IsMatch(text, regex4))
            {
                element.ElementEnum = MarkdownElementEnum.Title4;
                element.InnerText = text.Substring(5);
            }
            else if (Regex.IsMatch(text, regex5))
            {
                element.ElementEnum = MarkdownElementEnum.Title5;
                element.InnerText = text.Substring(6);
            }
            else if (Regex.IsMatch(text, regex6))
            {
                element.ElementEnum = MarkdownElementEnum.Title6;
                element.InnerText = text.Substring(7);
            }
            else
            {
                element.ElementEnum = MarkdownElementEnum.Text;
                element.InnerText = text;
            }

            element.Children = GetMarkdownElement(element.InnerText, element.InnerText[0].ToString(), true);

            return element;
        }

        /// <summary>
        /// 解析Table语法
        /// </summary>
        /// <param name="elements">要解析的文本集合</param>
        /// <param name="index">当前索引</param>
        /// <returns>TableElement</returns>
        public virtual MarkdownElement GetTableElement(ref string[] elements, ref int index)
        {
            TableElement tableElement = new TableElement();
            tableElement.ElementEnum = MarkdownElementEnum.Table;

            string text = elements[index];
            while (IsColumnElement(text, ref index))
            {
                string[] columnStr = text.Split('|');
                List<MarkdownElement> columns = new List<MarkdownElement>();
                foreach (var item in columnStr)
                {
                    if (string.IsNullOrWhiteSpace(item))
                    {
                        continue;
                    }
                    string head = item[0].ToString();
                    columns.Add(GetMarkdownElement(item, head));
                }
                tableElement.Rows.Add(columns);

                index++;
                if (index < elements.Count())
                {
                    text = elements[index];
                }
                else
                {
                    break;
                }
            }

            return tableElement;
        }

        /// <summary>
        /// 根据头字符解析对应的元素
        /// </summary>
        /// <param name="item">要解析的文本</param>
        /// <param name="head">item[0]</param>
        /// <param name="hasIteration">是否解析嵌套语法</param>
        /// <returns>Markdown元素</returns>
        public MarkdownElement GetMarkdownElement(string item, string head, bool hasIteration = false)
        {
            MarkdownElement element;
            switch (head)
            {
                case TITLE:
                    element = GetTitleElement(item);
                    break;
                case FONT1:
                    element = GetFontElement(item);
                    break;
                case FONT2:
                    element = GetFont2Element(item);
                    break;
                case SEPARATOR:
                    element = GetSeparatorElement(item);
                    break;
                case IMG:
                    hasIteration = false;
                    element = GetImageElement(item);
                    break;
                case LINK:
                    element = GetLinkElement(item);
                    break;
                case CODE:
                    element = GetCodeElement(item);
                    break;
                default:
                    return new MarkdownElement(item, MarkdownElementEnum.Text);
            }
            if (hasIteration && element.ElementEnum != MarkdownElementEnum.Text && element.ElementEnum != MarkdownElementEnum.Table)
            {
                //递归遍历嵌套语法
                element.Children = GetMarkdownElement(element.InnerText, element.InnerText[0].ToString());
            }

            return element;
        }

        /// <summary>
        /// 判断文本是否属于Table元素的一部分
        /// </summary>
        /// <param name="element">要解析的文本</param>
        /// <param name="index">当前集合的索引</param>
        /// <returns>判断结果</returns>
        public virtual bool IsColumnElement(string element, ref int index)
        {
            if (element[0].Equals('|'))
            {
                return true;
            }
            index--;
            return false;
        }

        /// <summary>
        /// 解析Ul无序列表
        /// </summary>
        /// <param name="elements">要解析的文本集合</param>
        /// <param name="index">当前索引</param>
        /// <returns>ULElement元素</returns>
        public virtual MarkdownElement GetUlElement(ref string[] elements, ref int index)
        {
            ULElement element = new ULElement();
            element.ElementEnum = MarkdownElementEnum.Ul;

            string text = elements[index];
            while (IsLiElement(text, ref index))
            {
                string temp = text.Substring(2);
                string head = temp[0].ToString();

                var liElement = GetMarkdownElement(temp, head, true);
                element.Rows.Add(liElement);
                index++;
                text = elements[index];
            }

            return element;
        }

        /// <summary>
        /// 判断当前文本是否属于无序列表的一部分
        /// </summary>
        /// <param name="text">要解析的文本</param>
        /// <param name="index">当前集合的索引</param>
        /// <returns>判断结果</returns>
        public virtual bool IsLiElement(string text, ref int index)
        {
            var regex = "^[+][ ].*$";
            if (Regex.IsMatch(text, regex))
            {
                return true;
            }
            index--;
            return false;
        }

        /// <summary>
        /// 解析引用
        /// </summary>
        /// <param name="elements">要解析的文本集合</param>
        /// <param name="index">当前集合的索引</param>
        /// <returns>QuoteElement</returns>
        public virtual MarkdownElement GetQuoteElement(ref string[] elements, ref int index)
        {
            QuoteElement element = new QuoteElement();
            element.ElementEnum = MarkdownElementEnum.Quote;

            string text = elements[index];
            int level = 1;
            if (IsQoute(text))
            {
                element.InnerText = text.Substring(level + 1);
                element.Children = GetMarkdownElement(element.InnerText, element.InnerText[0].ToString(), true);
                element.NextQuote = GetQuoteNext(ref elements, ref index, ref level, element);
            }

            else
            {
                MarkdownElement markdownElement = new MarkdownElement();
                markdownElement.ElementEnum = MarkdownElementEnum.Text;
                markdownElement.InnerText = text;

                return markdownElement;
            }

            return element;
        }

        /// <summary>
        /// 获取引用的下一级引用
        /// </summary>
        /// <param name="elements">要解析的文本结合</param>
        /// <param name="index">当前集合的索引</param>
        /// <param name="level">当前引用的层级</param>
        /// <param name="rootQoute">上一级引用</param>
        /// <returns></returns>
        public virtual QuoteElement GetQuoteNext(ref string[] elements, ref int index, ref int level, QuoteElement rootQoute)
        {
            index++;
            if (index >= elements.Length)
            {
                return null;
            }
            string text = elements[index];
            QuoteElement element = new QuoteElement();
            element.ElementEnum = MarkdownElementEnum.Quote;
            if (IsQoute(text))
            {
                level++;
                element.InnerText = text.Substring(level + 1);
                element.Children = GetMarkdownElement(element.InnerText, element.InnerText[0].ToString(), true);
                element.NextQuote = GetQuoteNext(ref elements, ref index, ref level, element);
            }
            else
            {
                index--;
                return null;
            }

            return element;
        }

        /// <summary>
        /// 判断是否引用
        /// </summary>
        /// <param name="text">要解析的文本</param>
        /// <returns>判断结果</returns>
        public virtual bool IsQoute(string text)
        {
            var regex = "^[>]+[ ].*$";
            if (Regex.IsMatch(text, regex))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 解析代码块
        /// </summary>
        /// <param name="text">要解析的文本</param>
        /// <returns>MarkdownElement</returns>
        public virtual MarkdownElement GetCodeElement(string text)
        {
            MarkdownElement element = new MarkdownElement();

            var regex = "^`.*`$";
            if (Regex.IsMatch(text, regex))
            {
                element.ElementEnum = MarkdownElementEnum.Code;
                element.InnerText = text.Substring(1, text.Length - 1);
            }
            else
            {
                element.ElementEnum = MarkdownElementEnum.Text;
                element.InnerText = text;
            }

            return element;
        }

        /// <summary>
        /// 解析链接
        /// </summary>
        /// <param name="text">要解析的文本</param>
        /// <returns>LinkElement</returns>
        public virtual MarkdownElement GetLinkElement(string text)
        {
            var temp = text.Replace('[', 'l').Replace(']', 'r').Replace('(', '-').Replace(')', '!');

            LinkElement element = new LinkElement();

            var regex = "^l.*r-.*!$";
            if (Regex.IsMatch(temp, regex))
            {
                element.ElementEnum = MarkdownElementEnum.Link;
                int altStartIndex = text.IndexOf('[');
                int altEndIndex = text.LastIndexOf(']');
                int linkStartIndex = text.IndexOf('(');
                int linkeEndIndex = text.LastIndexOf(')');

                string alt = text.Substring(altStartIndex + 1, altEndIndex - altStartIndex - 1);
                string link = text.Substring(linkStartIndex + 1, linkeEndIndex - linkStartIndex - 1);

                element.InnerText = alt;
                element.Href = link;
            }
            else
            {
                element.ElementEnum = MarkdownElementEnum.Text;
                element.InnerText = text;
            }

            return element;
        }

        /// <summary>
        /// 解析图片
        /// </summary>
        /// <param name="text">要解析的文本</param>
        /// <returns>LinkElement</returns>
        public virtual MarkdownElement GetImageElement(string text)
        {
            var temp = text.Replace('[', 'l').Replace(']', 'r').Replace('(', '-').Replace(')', '!');

            LinkElement element = new LinkElement();

            var regex = "^!l.*r-.*!$";
            if (Regex.IsMatch(temp, regex))
            {
                element.ElementEnum = MarkdownElementEnum.Img;
                int altStartIndex = text.IndexOf('[');
                int altEndIndex = text.LastIndexOf(']');
                int linkStartIndex = text.IndexOf('(');
                int linkeEndIndex = text.LastIndexOf(')');

                string alt = text.Substring(altStartIndex + 1, altEndIndex - altStartIndex - 1);
                string link = text.Substring(linkStartIndex + 1, linkeEndIndex - linkStartIndex - 1);

                element.InnerText = alt;
                element.Href = link;
            }
            else
            {
                element.ElementEnum = MarkdownElementEnum.Text;
                element.InnerText = text;
            }

            return element;
        }

        /// <summary>
        /// 解析分割线
        /// </summary>
        /// <param name="text">要解析的文本</param>
        /// <returns>MarkdownElement</returns>
        public virtual MarkdownElement GetSeparatorElement(string text)
        {
            var regex = "^---+$";

            MarkdownElement element = new MarkdownElement();

            if (Regex.IsMatch(text, regex))
            {
                element.ElementEnum = MarkdownElementEnum.Separator;
                element.InnerText = "";
            }
            else
            {
                element.ElementEnum = MarkdownElementEnum.Text;
                element.InnerText = text;
            }

            return element;
        }

        /// <summary>
        /// 解析字体样式
        /// </summary>
        /// <param name="text">要解析的文本</param>
        /// <returns>MarkdownElement</returns>
        public virtual MarkdownElement GetFontElement(string text)
        {
            var temp = text.Replace('*', 'x');

            MarkdownElement element = new MarkdownElement();

            var regex1 = "^x[^x].*[^x]x$";
            var regex2 = "^xx[^x].*[^x]xx$";
            var regex3 = "^xxx[^x].*[^x]xxx$";

            if (Regex.IsMatch(temp, regex1))
            {
                element.ElementEnum = MarkdownElementEnum.Font_Tilt;
                element.InnerText = text.Substring(1, text.Length - 2);
            }
            else if (Regex.IsMatch(temp, regex2))
            {
                element.ElementEnum = MarkdownElementEnum.Font_Bold;
                element.InnerText = text.Substring(2, text.Length - 4);
            }
            else if (Regex.IsMatch(temp, regex3))
            {
                element.ElementEnum = MarkdownElementEnum.Font_Bold_Tilt;
                element.InnerText = text.Substring(3, text.Length - 6);
            }
            else
            {
                element.ElementEnum = MarkdownElementEnum.Text;
                element.InnerText = text;
            }

            element.Children = GetMarkdownElement(element.InnerText, element.InnerText[0].ToString(), true);

            return element;
        }

        /// <summary>
        /// 解析删除线
        /// </summary>
        /// <param name="text">要解析的文本</param>
        /// <returns>MarkdownElement</returns>
        public virtual MarkdownElement GetFont2Element(string text)
        {
            MarkdownElement element = new MarkdownElement();

            var regex = "^~~.*[^~]~~$";
            if (Regex.IsMatch(text, regex))
            {
                element.ElementEnum = MarkdownElementEnum.Font_Strikethrough;
                element.InnerText = text.Substring(2, text.Length - 2);
                element.Children = GetMarkdownElement(element.InnerText, element.InnerText[0].ToString(), true);
            }
            else
            {
                element.ElementEnum = MarkdownElementEnum.Text;
                element.InnerText = text;
            }

            return element;
        }
    }
}
