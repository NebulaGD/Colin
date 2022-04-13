using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colin.Extensions
{
    /// <summary>
    /// <seealso cref="Vector2"/> 的扩展类.
    /// <para>包含各种为 <seealso cref="Vector2"/> 编写的扩展方法, 旨在提高编码效率.</para>
    /// </summary>
    public static class Vector2Extensions
    {
        /// <summary>
        /// 获取指定 <seealso cref="Vector2"/> 的单位向量.
        /// </summary>
        /// <param name="vector2">指定的 <seealso cref="Vector2"/>.</param>
        /// <returns>指定 <seealso cref="Vector2"/> 的单位向量.</returns>
        public static Vector2 GetNormalize( this Vector2 vector2 )
        {
            vector2.Normalize( );
            return vector2;
        }
    }
}