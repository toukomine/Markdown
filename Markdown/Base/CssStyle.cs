using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Markdown
{
    /// <summary>
    /// Css样式
    /// </summary>
    public abstract class CssStyle
    {
        /// <summary>
        /// Css文件路径
        /// </summary>
        public string CssPath { get; set; }

        /// <summary>
        /// H1 Class
        /// </summary>
        public string H1Class { get; set; } = "h1_class";
        /// <summary>
        /// H2 Class
        /// </summary>
        public string H2Class { get; set; } = "h2_class";
        /// <summary>
        /// H3 Class
        /// </summary>
        public string H3CLASS { get; set; } = "h3_class";
        /// <summary>
        /// H4 Class
        /// </summary>
        public string H4CLASS { get; set; } = "h4_class";
        /// <summary>
        /// H5 Class
        /// </summary>
        public string H5CLASS { get; set; } = "h5_class";
        /// <summary>
        /// H6 Class
        /// </summary>
        public string H6CLASS { get; set; } = "h6_class";
        /// <summary>
        /// B Class
        /// </summary>
        public string BClass { get; set; } = "b_class";
        /// <summary>
        /// I Class
        /// </summary>
        public string InclineClass { get; set; } = "incline_class";
        /// <summary>
        /// S Class
        /// </summary>
        public string StrikeClass { get; set; } = "strike_class";
        /// <summary>
        /// B I Class
        /// </summary>
        public string BlockQuoteClass { get; set; } = "block_quote_class";
        /// <summary>
        /// Div Class
        /// </summary>
        public string SeparatorClass { get; set; } = "separator_class";
        /// <summary>
        /// Img class
        /// </summary>
        public string ImgClass { get; set; } = "img_class";
        /// <summary>
        /// A Class
        /// </summary>
        public string LinkClass { get; set; } = "link_class";
        /// <summary>
        /// UL Class
        /// </summary>
        public string UlClass { get; set; } = "ul_class,ul_li_class";
        /// <summary>
        /// Ul li Class
        /// </summary>
        public string UiLiClass { get; set; } = "ul_li_class";
        /// <summary>
        /// Ol Class
        /// </summary>
        public string OlClass { get; set; } = "ol_class,ol_li_class";
        /// <summary>
        /// Ol li Class
        /// </summary>
        public string OlLiClass { get; set; } = "ol_li_class";
        /// <summary>
        /// Table Class
        /// </summary>
        public string TableClass { get; set; } = "table_class,table_tr_class,table_td_class";
        /// <summary>
        /// Code Class
        /// </summary>
        public string CodeClass { get; set; } = "code_class";
        /// <summary>
        /// Span Class
        /// </summary>
        public string SpanClass { get; set; } = "span_class";

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="filePath">Css文件路径</param>
        public CssStyle(string filePath) {
            CssPath = filePath;
        }
    }
}
