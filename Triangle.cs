using Microsoft.Xna.Framework;

namespace Colin
{
    /// <summary>
    /// 三角形.
    /// <para>[!] 该结构作者 <see href="幽银"/>; 感谢 <see href=" lntrue"/> 提供的几何帮助得以完成此结构代码.</para>
    /// </summary>
    public struct Triangle
    {
        /// <summary>
        /// 顶点A.
        /// </summary>
        public Vector2 VertexA;

        /// <summary>
        /// 顶点B
        /// </summary>
        public Vector2 VertexB;

        /// <summary>
        /// 顶点C
        /// </summary>
        public Vector2 VertexC;

        /// <summary>
        /// 三个顶点; 顺序为A/B/C.
        /// </summary>
        public List<Vector2> Vertices
        {
            get { return new List<Vector2>( ) { VertexA, VertexB, VertexC }; }
        }

        /// <summary>
        /// 定义一个三角形.
        /// </summary>
        /// <param name="a">顶点A.</param>
        /// <param name="b">顶点B.</param>
        /// <param name="c">顶点C.</param>
        /// <exception cref="Exception"></exception>
        public Triangle( Vector2 a, Vector2 b, Vector2 c )
        {
            if ( a == b || b == c || a == c ||
                 ( a - b ).Length( ) + ( b - c ).Length( ) <= ( a - c ).Length( ) ||
                 ( a - c ).Length( ) + ( b - c ).Length( ) <= ( a - b ).Length( ) ||
                 ( a - b ).Length( ) + ( a - c ).Length( ) <= ( b - c ).Length( ) )
                throw new Exception( "请输入一个正确的三角形" );
            VertexA = a;
            VertexB = b;
            VertexC = c;
        }

        /// <summary>
        /// 判断两个三角形是否发生重叠.
        /// </summary>
        /// <param name="triangle">指定三角形.</param>
        /// <returns>若发生重叠, 则返回 <see href="true"/>, 否则返回 <see href="false"/>.</returns>
        public bool Intersect( Triangle triangle )
        {
            Vector2 point, point1, n, myInterval, hisInterval;
#pragma warning disable CS0168 // 声明了变量“j”，但从未使用过
            int i, j;
#pragma warning restore CS0168 // 声明了变量“j”，但从未使用过
            for ( i = 0; i < 6; i++ )
            {
                if ( i < 3 )
                {
                    point = Vertices[ i ];
                    point1 = Vertices[ ( i + 1 ) % 3 ];
                }
                else
                {
                    point = triangle.Vertices[ i % 3 ];
                    point1 = triangle.Vertices[ ( i + 1 ) % 3 ];
                }
                n = new Vector2( point.Y - point1.Y, point1.X - point.X );
                myInterval = new Vector2( Math.Min( Math.Min( VertexA.X * n.X + VertexA.Y * n.Y, VertexB.X * n.X + VertexB.Y * n.Y ),
                    VertexC.X * n.X + VertexC.Y * n.Y ),
                    Math.Max( Math.Max( VertexA.X * n.X + VertexA.Y * n.Y, VertexB.X * n.X + VertexB.Y * n.Y ),
                        VertexC.X * n.X + VertexC.Y * n.Y ) );
                hisInterval = new Vector2( Math.Min( Math.Min( triangle.VertexA.X * n.X + triangle.VertexA.Y * n.Y, triangle.VertexB.X * n.X + triangle.VertexB.Y * n.Y ),
                    triangle.VertexC.X * n.X + triangle.VertexC.Y * n.Y ),
                    Math.Max( Math.Max( triangle.VertexA.X * n.X + triangle.VertexA.Y * n.Y, triangle.VertexB.X * n.X + triangle.VertexB.Y * n.Y ),
                        triangle.VertexC.X * n.X + triangle.VertexC.Y * n.Y ) );
                if ( myInterval.X < hisInterval.X )
                {
                    if ( myInterval.Y < hisInterval.X )
                        return false;
                }
                else
                {
                    if ( hisInterval.Y < myInterval.X )
                        return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 三角形是否包含指定位置的点.
        /// </summary>
        /// <param name="point">指定的点.</param>
        /// <returns>若包含, 则返回 <see href="true"/>, 否则返回 <see href="false"/>.</returns>
        public bool ContainPoint( Vector2 point )
        {
            //当P=Ax+By+Cz(x+y+z=1)求得x、y、z全部大于0时点被三角形包含。此处使用行列式求解
            float d = 1 * VertexB.X * VertexC.Y + 1 * VertexC.X * VertexA.Y + 1 * VertexA.X * VertexB.Y - 1 * VertexB.X * VertexA.Y - 1 * VertexA.X * VertexC.Y - 1 * VertexC.X * VertexB.Y,
                d1 = 1 * VertexB.X * VertexC.Y + 1 * VertexC.X * point.Y + 1 * point.X * VertexB.Y - 1 * VertexB.X * point.Y - 1 * point.X * VertexC.Y - 1 * VertexC.X * VertexB.Y,
                d2 = 1 * point.X * VertexC.Y + 1 * VertexC.X * VertexA.Y + 1 * VertexA.X * point.Y - 1 * point.X * VertexA.Y - 1 * VertexA.X * VertexC.Y - 1 * VertexC.X * point.Y,
                d3 = 1 * VertexB.X * point.Y + 1 * point.X * VertexA.Y + 1 * VertexA.X * VertexB.Y - 1 * VertexB.X * VertexA.Y - 1 * VertexA.X * point.Y - 1 * point.X * VertexB.Y;
            if ( d == 0 )
                return false;
            return d1 / d > 0 && d2 / d > 0 && d3 / d > 0;
        }
    }
}