using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colin
{
    /// <summary>
    /// 表示一个针对 <seealso cref="IPoolObject"/> 的对象池.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ObjectPool<T> : IPoolObject where T : IPoolObject, new()
    {
         public T[ ]? Objects { get; }

         public List<T>? ActiveList { get; }

         public bool Empty { get; set; } = false;

         public int ActiveIndex { get; set; } = -1;

         public int PoolIndex { get; set; } = -1;

         public ObjectPool( int poolSize )
        {
            ActiveList = new List<T>( );
            Objects = new T[ poolSize ];
            Span<T> ts = new Span<T>( );
            T t = new T( );
            t.Empty = true;
            t.ActiveIndex = -1;
            t.PoolIndex = -1;
            ts.Fill( new T( ) );
        }

         public void Initialize( )
        {
            for ( int count = 0; count < Objects.Length; count++ )
                Objects[ count ].Initialize( );
        }

         public void Update( GameTime gameTime )
        {
            for ( int count = 0; count < ActiveList.Count; count++ )
                    ActiveList[ count ].Update( gameTime );
        }

        public void Draw( GameTime gameTime )
        {
            for ( int count = 0; count < ActiveList.Count; count++ )
                ActiveList[ count ].Draw( gameTime );
        }

        public void ActiveObject( T poolObject )
        {
            if ( poolObject.Empty )
            {
                poolObject.Empty = false;
                poolObject.ActiveIndex = ActiveList.Count;
                ActiveList.Add( poolObject );
            }
        }

        /// <summary>
        /// 令指定 <seealso cref="IPoolObject"/> 休眠.
        /// </summary>
        /// <param name="element">指定的 <seealso cref="IPoolObject"/>.</param>
        public void DormancyObject( T element )
        {
            if ( ActiveList.Remove( element ) )
            {
                element.ActiveIndex = -1;
                element.Empty = true;
            }
        }
    }
}