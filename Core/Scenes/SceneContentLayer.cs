using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colin.Core.Scenes
{
    /// <summary>
    /// 表示一个场景中的内容层.
    /// </summary>
    public class SceneContentLayer
    {
        /// <summary>
        /// 获取该内容层所绑定的场景.
        /// </summary>
        public Scene? Scene { get; internal set; }

        public bool Enable { get; set; } = true;

        public bool Visable { get; set; } = true;

        public virtual void Initialize( )
        {

        }

        public virtual void Update( GameTime gameTime )
        {

        }

        public virtual void Draw( GameTime gameTime )
        {

        }

    }
}