using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colin.Extensions
{
     public static class RectangleExtensions
    {

        /// <summary>
        /// 判断鼠标是否与指定的 <seealso cref="Rectangle"/> 重合.
        /// </summary>
        /// <param name="rectangle">指定的 <seealso cref="Rectangle"/>.</param>
        /// <returns>如若是, 返回 <see href="true"/>, 否则返回 <see href="false"/>.</returns>
        public static bool IntersectMouse( this Rectangle rectangle )
        {
            return rectangle.Intersects( new Rectangle( Input.MousePosition.ToPoint( ), Point.Zero ) );
        }

        /// <summary>
        /// 判断上一帧鼠标是否与指定的 <seealso cref="Rectangle"/> 重合.
        /// </summary>
        /// <param name="rectangle">指定的 <seealso cref="Rectangle"/>.</param>
        /// <returns>如若是, 返回 <see href="true"/>, 否则返回 <see href="false"/>.</returns>
        public static bool IntersectMouseLast( this Rectangle rectangle )
        {
            return rectangle.Intersects( new Rectangle( Input.MouseStateLast.Position, Point.Zero ) );
        }

    }
}