using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colin.Core.Tiled
{
    /// <para>[!] 对于固定地图, Colin建议你在初始化地图后执行 <seealso cref="SaveAsPng()"/> 将地图以.png格式保存后再绘制.</para>
    /// <para>[!] 也许这样可以节省一些性能开销.</para>
    /// <summary>
    /// 瓦片地图.
    /// </summary>
    public class TileMap
    {
        public int TileWidth { get; private set; } = -1;

        public int TileHeight { get; private set; } = -1;

        public int Width { get; private set; } = -1;

        public int Height { get; private set; } = -1;

        public Tile[,]? Tiles { get; private set; }

        /// <summary>
        /// 初始化一个瓦片地图.
        /// </summary>
        /// <param name="tileWidth">该瓦片地图中瓦片的宽度.</param>
        /// <param name="tileHeight">该瓦片地图中瓦片的高度.</param>
        /// <param name="width">该瓦片地图的宽度.</param>
        /// <param name="height">该瓦片地图的高度.</param>
        public TileMap( int tileWidth, int tileHeight, int width, int height )
        {
            TileWidth = tileWidth;
            TileHeight = tileHeight;
            Width = width;
            Height = height;
            Tiles = new Tile[ Width, Height ];
            RenderTarget = new RenderTarget2D( ISingle<Engine>.Instance.GraphicsDevice, TileWidth * Width, TileHeight * Height );
            foreach ( Tile tile in Tiles )
            {
                tile.TileMap = this;
                tile.CreateEmpty( );
            }
        }


    }
}