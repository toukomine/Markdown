using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Markdown
{
    /// <summary>
    /// 默认Markdown文本处理实现
    /// </summary>
    public class DefaultMarkdownTextHelperImpl :ITextHelper
    {
        /// <summary>
        /// 将指定路径的Markdown文件转换成字符串数组
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public string[] Process(string filePath) {

            if (string.IsNullOrWhiteSpace(filePath)) {
                return null;
            }

            if (!File.Exists(filePath)) {
                return null;
            }

            return File.ReadAllLines(filePath);
        }
    }
}
