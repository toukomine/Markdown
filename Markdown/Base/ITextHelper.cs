using System;
using System.Collections.Generic;
using System.Text;

namespace Markdown
{
    /// <summary>
    /// Markdown文本处理接口
    /// </summary>
    public interface ITextHelper
    {
        /// <summary>
        /// 将markdown文本转换字符串数组
        /// </summary>
        /// <param name="filePath">markdown文件路径/markdown文本</param>
        /// <returns>markdown文本数组</returns>
        string[] Process(string filePath);
    }
}
