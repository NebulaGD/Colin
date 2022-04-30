using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colin.Core.UI
{
    /// <summary>
    /// 表示一个可以以 <seealso cref="ScaleTarget"/> 为目标值进行缩放的控件.
    /// </summary>
    public interface IScaleableControl
    {
        /// <summary>
        /// 控件缩放的增量.
        /// </summary>
        public float ScaleAdd { get; set; }

        /// <summary>
        /// 控件的缩放.
        /// </summary>
        public float Scale { get; set; }

        /// <summary>
        /// 缩放的目标值.
        /// </summary>
        public float ScaleTarget { get; set; }

    }
}