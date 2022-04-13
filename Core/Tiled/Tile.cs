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
    public class Tile : IEmptyState , IEmptyCreate
    {
        public bool Empty { get; set; } = true;

        /// <summary>
        /// 获取该瓦片所在的瓦片地图.
        /// </summary>
        public TileMap? TileMap { get; internal set; }

        public virtual void SetDefault( )
        {

        }

        public void CreateEmpty( )
        {
            Empty = true;
        }
    }
}