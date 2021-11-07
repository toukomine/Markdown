using System;
using System.Collections.Generic;
using System.Text;

namespace Markdown
{
    /// <summary>
    /// Html元素枚举
    /// </summary>
    public enum HtmlElementEnum
    {
        /// <summary>
        /// 一级标题
        /// </summary>
        H1,
        /// <summary>
        /// 二级标题
        /// </summary>
        H2,
        /// <summary>
        /// 三级标题
        /// </summary>
        H3,
        /// <summary>
        /// 四级标题
        /// </summary>
        H4,
        /// <summary>
        /// 五级标题
        /// </summary>
        H5,
        /// <summary>
        /// 六级标题
        /// </summary>
        H6,
        /// <summary>
        /// 文本加粗 br
        /// </summary>
        Bold,
        /// <summary>
        /// 文本倾斜 i
        /// </summary>
        Incline,
        /// <summary>
        /// 加粗倾斜 br i
        /// </summary>
        Bold_Incline,
        /// <summary>
        /// 删除线
        /// </summary>
        Strike,
        /// <summary>
        /// 引用
        /// </summary>
        BlockQuote,
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
        /// 文本
        /// </summary>
        Text
    }
}
