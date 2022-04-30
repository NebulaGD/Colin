using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colin.Core.UI
{
    /// <summary>
    /// 表示一个可以朝着 <seealso cref="MoveTarget"/> 进行移动的控件.
    /// </summary>
    public interface IMoveableControl
    {
        /// <summary>
        /// 移动的目标.
        /// </summary>
        public Vector2 MoveTarget { get; set; }
    }
}