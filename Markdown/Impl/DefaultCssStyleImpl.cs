using System;
using System.Collections.Generic;
using System.Text;

namespace Markdown
{
    /// <summary>
    /// 默认Css样式实现
    /// </summary>
    public class DefaultCssStyleImpl : CssStyle
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="filePath">Css文件路径</param>
        public DefaultCssStyleImpl(string filePath):base(filePath) {
            CssPath = filePath;
        }
    }
}
