using System;
using System.Collections.Generic;
using System.Text;

namespace Markdown
{
    /// <summary>
    /// Markdown元素转Html标签
    /// </summary>
    public abstract class MarkdownToHtml
    {
        /// <summary>
        /// 将MarkdownElement转换成Html标签
        /// </summary>
        /// <param name="markdownElement">要转换的markdown元素</param>
        /// <param name="style">Css样式</param>
        /// <returns></returns>
        public HtmlTag GetHtmlTag(MarkdownElement markdownElement,CssStyle style) {
            HtmlTag tag = new HtmlTag();
            switch (markdownElement.ElementEnum)
            {
                case MarkdownElementEnum.Title1:
                    tag.Head = $"<h1 class = '{style.H1Class}'>";
                    tag.End = "</h1>";
                    tag.HtmlElementEnum = HtmlElementEnum.H1;
                    break;
                case MarkdownElementEnum.Title2:
                    tag.Head = $@"<h2 class = '{style.H2Class}'>";
                    tag.End = "</h2>";
                    tag.HtmlElementEnum = HtmlElementEnum.H2;
                    break;
                case MarkdownElementEnum.Title3:
                    tag.Head = $"<h3 class = '{style.H3CLASS}'>";
                    tag.End = "</h3>";
                    tag.HtmlElementEnum = HtmlElementEnum.H3;
                    break;
                case MarkdownElementEnum.Title4:
                    tag.Head = $"<h4 class = '{style.H4CLASS}'>";
                    tag.End = "</h4>";
                    break;
                case MarkdownElementEnum.Title5:
                    tag.Head = $"<h5 class = '{style.H5CLASS}'>";
                    tag.End = "</h5>";
                    tag.HtmlElementEnum = HtmlElementEnum.H5;
                    break;
                case MarkdownElementEnum.Title6:
                    tag.Head = $"<h6 class = '{style.H6CLASS}'>";
                    tag.End = "</h6>";
                    tag.HtmlElementEnum = HtmlElementEnum.H6;
                    break;
                case MarkdownElementEnum.Font_Tilt:
                    tag.Head = $"<i class = '{style.InclineClass}'>";
                    tag.End = "</i>";
                    tag.HtmlElementEnum = HtmlElementEnum.Bold_Incline;
                    break;
                case MarkdownElementEnum.Font_Bold:
                    tag.Head = $"<b class =  '{style.BClass}'>";
                    tag.End = "</b>";
                    tag.HtmlElementEnum = HtmlElementEnum.Bold;
                    break;
                case MarkdownElementEnum.Font_Bold_Tilt:
                    tag.Head = $"<b class = '{style.BClass}'><i class = '{style.InclineClass}'>";
                    tag.End = "</i></b>";
                    tag.HtmlElementEnum = HtmlElementEnum.Bold_Incline;
                    break;
                case MarkdownElementEnum.Font_Strikethrough:
                    tag.Head = $"<s class = '{style.StrikeClass}'>";
                    tag.End = "</s>";
                    tag.HtmlElementEnum = HtmlElementEnum.Strike;
                    break;
                case MarkdownElementEnum.Quote:
                    var blocQuoteTag = new HtmlBlockQuoteTag();
                    var blockQuoteElement = markdownElement as QuoteElement;
                    blocQuoteTag.HtmlElementEnum = HtmlElementEnum.BlockQuote;
                    blocQuoteTag.Head = $"<blockquote class = '{style.BlockQuoteClass}'>";
                    blocQuoteTag.End = "</blockquote>";
                    if (blockQuoteElement.NextQuote != null) {
                        blocQuoteTag.NextQuote = (HtmlBlockQuoteTag)GetHtmlTag(blockQuoteElement.NextQuote, style);
                    }
                    tag = blocQuoteTag;
                    break;
                case MarkdownElementEnum.Separator:
                    tag.Head = $"<div class = '{style.SeparatorClass}' style = 'width:100%;height:5px;background-color:#ddd;'>";
                    tag.End = "</div>";
                    tag.HtmlElementEnum = HtmlElementEnum.Separator;
                    break;
                case MarkdownElementEnum.Img:
                    var element = markdownElement as LinkElement;
                    tag.Head = $"<img class = '{style.ImgClass}' src = '{element.Href}' title = '{element.InnerText}' alt = '{element.InnerText}'/>";
                    tag.End = "";
                    tag.HtmlElementEnum = HtmlElementEnum.Img;
                    break;
                case MarkdownElementEnum.Link:
                    tag.Head = $"<a class = '{style.LinkClass}' href = '{((LinkElement)markdownElement).Href}'>";
                    tag.End = "</a>";
                    tag.HtmlElementEnum = HtmlElementEnum.Link;
                    break;
                case MarkdownElementEnum.Ul:
                    var ulElement = markdownElement as ULElement;
                    var ulHtmlTag = new ULHtmlTag();
                    ulHtmlTag.Head = $"<ul class = '{style.UlClass}'>";

                    foreach (var row in ulElement.Rows){
                        ulHtmlTag.Rows.Add(GetHtmlTag(row, style));
                    }

                    ulHtmlTag.End = "</ul>";
                    tag = ulHtmlTag;
                    break;
                case MarkdownElementEnum.Ol:
                    tag.Head = $"<ol class = '{style.OlClass}'><li class = '{style.OlLiClass}'>";
                    tag.End = "</li></ol>";
                    tag.HtmlElementEnum = HtmlElementEnum.Ol;
                    break;
                case MarkdownElementEnum.Table:
                    var tableElement = markdownElement as TableElement;
                    var tableTag = new HtmlTableTag();
                    tableTag.Head = $"<table class = '{style.TableClass}'>";
                    
                    foreach (var row in tableElement.Rows){
                        var columns = new List<HtmlTag>();
                        foreach (var cellElement in row){
                            columns.Add(GetHtmlTag(cellElement, style));
                        }
                        tableTag.Rows.Add(columns);
                    }
                    tableTag.End = "</table>";
                    tag = tableTag;
                    break;
                case MarkdownElementEnum.Code:
                    tag.Head = $"<code class = '{style.CodeClass}'>";
                    tag.End = "</code>";
                    tag.HtmlElementEnum = HtmlElementEnum.Code;
                    break;
                case MarkdownElementEnum.Text:
                    tag.Head = $"<span class = '{style.SpanClass}'>";
                    tag.End = "</sapn>";
                    tag.HtmlElementEnum = HtmlElementEnum.Text;
                    break;
                default:
                    tag.Head = $"<span class = '{style.SpanClass}'>";
                    tag.End = "</span>";
                    tag.HtmlElementEnum = HtmlElementEnum.Text;
                    break;
            }
            if (markdownElement.Children != null){
                //递归解析嵌套语法
                tag.Children = GetHtmlTag(markdownElement.Children, style);
            }
            else {
                if (markdownElement.ElementEnum != MarkdownElementEnum.Link || markdownElement.ElementEnum != MarkdownElementEnum.Img || markdownElement.ElementEnum != MarkdownElementEnum.Table) {
                    tag.Content = markdownElement.InnerText;
                }
            }

            return tag;
        }
    }
}
