using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colin.Core.Tiled
{
    /// <summary>
    /// 一块单独的瓦片.
    /// </summary>
    public class Tile : IEmptyState, IEmptyCreate
    {
        public bool Empty { get; set; } = true;

        /// <summary>
        /// 获取该物块在瓦片地图中的横坐标.
        /// </summary>
        public int CoordinateX { get; private set; } = -1;

        /// <summary>
        /// 获取该物块在瓦片地图中的纵坐标.
        /// </summary>
        public int CoordinateY { get; private set; } = -1;

        /// <summary>
        /// 获取该瓦片所在的瓦片地图.
        /// </summary>
        public TileMap? TileMap { get; internal set; }

        /// <summary>
        /// 在该物块所绑定的瓦片地图中的指定坐标放置该物块.
        /// </summary>
        public void Place( int coordinateX , int coordinateY )
        {
            Empty = false;
            CoordinateX = coordinateX;
            CoordinateY = coordinateY;
            TileMap.Tiles[ coordinateX, coordinateY ] = this;
            ModifyOnPlace( );
        }
        /// <summary>
        /// 在该物块被放置时执行.
        /// </summary>
        protected virtual void ModifyOnPlace( ) { }

        /// <summary>
        /// 破坏该物块.
        /// </summary>
        public void Destruction( )
        {
            TileMap.Tiles[ CoordinateX, CoordinateY ].CreateEmpty();
            ModifyOnDestruction( );
        }
        /// <summary>
        /// 在该物块被破坏时执行.
        /// </summary>
        protected virtual void ModifyOnDestruction( ) { }

        public virtual void CreateEmpty( )
        {
            Empty = true;
        }
    }
}