using System;
using System.Collections.Generic;
using System.Text;

namespace Markdown
{
    /// <summary>
    /// Markdown元素类型
    /// </summary>
    public enum MarkdownElementEnum
    {
        /// <summary>
        /// H1标签
        /// </summary>
        Title1,
        /// <summary>
        /// H2标签
        /// </summary>
        Title2,
        /// <summary>
        /// H3标签
        /// </summary>
        Title3,
        /// <summary>
        /// H4标签
        /// </summary>
        Title4,
        /// <summary>
        /// H5标签
        /// </summary>
        Title5,
        /// <summary>
        /// H6标签
        /// </summary>
        Title6,
        /// <summary>
        /// 字体倾斜
        /// </summary>
        Font_Tilt,
        /// <summary>
        /// 字体加粗
        /// </summary>
        Font_Bold,
        /// <summary>
        /// 字体倾斜加粗
        /// </summary>
        Font_Bold_Tilt,
        /// <summary>
        /// 删除线
        /// </summary>
        Font_Strikethrough,
        /// <summary>
        /// 引用
        /// </summary>
        Quote,
        /// <summary>
        /// 分割线
        /// </summary>
        Separator,
        /// <summary>
        /// 图片
        /// </summary>
        Img,
        /// <summary>
        /// 链接
        /// </summary>
        Link,
        /// <summary>
        /// 无序列表
        /// </summary>
        Ul,
        /// <summary>
        /// 有序列表
        /// </summary>
        Ol,
        /// <summary>
        /// 表格
        /// </summary>
        Table,
        /// <summary>
        /// 代码块
        /// </summary>
        Code,
        /// <summary>
        /// 普通文本
        /// </summary>
        Text
    }
}
