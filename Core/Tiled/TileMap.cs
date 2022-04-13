using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colin.Core.Tiled
{
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
            foreach ( Tile tile in Tiles )
            {
                tile.TileMap = this;
                tile.CreateEmpty( );
            }
        }


    }
}