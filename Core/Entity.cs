using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colin.Core
{
    /// <summary>
    /// 实体; 
    /// </summary>
    public abstract class Entity : EngineElement
    {
        #region ECS 组件系统部分

        private List<EntityComponent> _components = new List<EntityComponent>( );

        /// <summary>
        /// 根据特定的 <seealso cref="EntityComponent"/> 类型, 从该 <seealso cref="Entity"/> 中判断是否可以获取到指定类型的 <seealso cref="EntityComponent"/>.
        /// </summary>
        /// <typeparam name="T">作为判断依据的 <seealso cref="EntityComponent"/> 类型.</typeparam>
        /// <returns>如若获取到了指定类型的 <seealso cref="EntityComponent"/>, 返回 <see href="true"/>, 否则返回 <see href="false"/>.</returns>
        public bool HasComponent<T>( ) where T : EntityComponent
        {
            return _components.Find( a => a._typeFullName == typeof( T ).FullName ) != null;
        }

        /// <summary>
        /// 从该 <seealso cref="Entity"/> 中获取指定类型的 <seealso cref="EntityComponent"/>.
        /// </summary>
        /// <typeparam name="T">要获取的特定类型的 <seealso cref="EntityComponent"/>.</typeparam>
        /// <returns></returns>
        public T GetComponent<T>( ) where T : EntityComponent
        {
            return (T)_components.Find( a => a._typeFullName == typeof( T ).FullName );
        }

        /// <summary>
        /// 向该 <seealso cref="Entity"/> 添加具有指定引用的 <seealso cref="EntityComponent"/>.
        /// </summary>
        /// <param name="component">要添加的具有指定引用的 <seealso cref="EntityComponent"/>.</param>
        public void AddComponent( EntityComponent component ) 
        {
            component.Entity = this;
            if( !component._added )
            {
                component._added = true;
                _components.Add( component );
            }
            else
                throw new Exception( "名为: " + component.Name + " 的组件已经被添加过, 请检查某组件是否被重复地添加至不同的实体." );
        }

        /// <summary>
        ///  从该 <seealso cref="Entity"/> 删除具有指定引用的 <seealso cref="EntityComponent"/>.
        /// </summary>
        /// <param name="component">要删除的 <seealso cref="EntityComponent"/>.</param>
        public void RemoveComponent( EntityComponent component )
        {
            if ( !_components.Remove( component ))
                throw new Exception( "在实体: " + " 中没有找到 " + component.GetType().FullName + " 类型的组件." );
            else
            {
                component._added = false;
                component.Entity = null;
            }
        }

        #endregion

        protected override void PreUpdate( )
        {
            for ( int count = 0; count < _components.Count; count++ )
            {
                if ( _components[ count ].Enable )
                    _components[ count ].Update( );
            }
            base.PreUpdate( );
        }

    }
}