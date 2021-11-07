using System;
using System.Collections.Generic;
using System.Text;

namespace Markdown
{
    /// <summary>
    /// Html Tag
    /// </summary>
    public class HtmlTag
    {
        /// <summary>
        /// Html类型
        /// </summary>
        public HtmlElementEnum HtmlElementEnum { get; set; }
        /// <summary>
        /// Html标签头
        /// </summary>
        public string Head { get; set; }
        /// <summary>
        /// Html InnerText
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// Html标签尾
        /// </summary>
        public string End { get; set; }
        /// <summary>
        /// 嵌套html标签
        /// </summary>
        public HtmlTag Children { get; set; }

        /// <summary>
        /// 将html对象转换成html标签字符串
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder htmlTag = new StringBuilder();
            Append(this,htmlTag);

            return htmlTag.ToString();
        }

        /// <summary>
        /// 拼接嵌套Html标签
        /// </summary>
        /// <param name="tag">html标签</param>
        /// <param name="htmlTag">字符串拼接器</param>
        public void Append(HtmlTag tag,StringBuilder htmlTag) {

            htmlTag.Append(tag.Head);

            if (tag.Children != null){
                Append(tag.Children, htmlTag);
            }
            else {
                if (tag.HtmlElementEnum != HtmlElementEnum.Img) {
                    htmlTag.Append(tag.Content);
                }
            }

            htmlTag.Append(tag.End);

        }
    }
}
