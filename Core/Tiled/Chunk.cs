﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colin.Core.Tiled
{
    /// <summary>
    /// 一个区块.
    /// </summary>
    public class Chunk
    {
        public int TileWidth { get; private set; } = -1;

        public int TileHeight { get; private set; } = -1;

        public int Width { get; private set; } = -1;

        public int Height { get; private set; } = -1;

        public Tile[,]? Tiles { get; private set; }

        /// <summary>
        /// 初始化一个区块.
        /// </summary>
        /// <param name="tileWidth">该区块中瓦片的宽度.</param>
        /// <param name="tileHeight">该区块中瓦片的高度.</param>
        /// <param name="width">该区块的宽度.</param>
        /// <param name="height">该区块的高度.</param>
        public Chunk( int tileWidth, int tileHeight, int width, int height )
        {
            TileWidth = tileWidth;
            TileHeight = tileHeight;
            Width = width;
            Height = height;
            Tiles = new Tile[ Width, Height ];
            for ( int x = 0; x < Width ; x++ )
            {
                for ( int y = 0; y < Height; y++ )
                {
                    Tiles[ x, y ] = new Tile( );
                    Tiles[ x, y ].Chunk = this;
                }
            }
        }

        public virtual void Initialize( ) { }

        public virtual void Update( GameTime gameTime ) { }

        public virtual void Draw( GameTime gameTime ) { }

    }
}