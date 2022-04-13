using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Colin.Assets
{
    /// <summary>
    /// 表示一个可在初始化场景时被加载的资产.
    /// </summary>
    public interface ILoadableAsset
    {
        void LoadContents( );

        /// <summary>
        /// 对程序内所有的 <seealso cref="ILoadableAsset"/> 对象执行加载操作.
        /// </summary>
        public static void LoadAssets( )
        {
            foreach ( Type type in Assembly.GetEntryAssembly( ).GetTypes( ) )
            {
                if ( !type.IsAbstract && type.GetInterfaces( ).Contains( typeof( ILoadableAsset ) ) )
                {
                    var instance = (ILoadableAsset)Activator.CreateInstance( type );
                    instance.LoadContents( );
                }
            }
        }
    }
}