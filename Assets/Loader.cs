using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Colin.Assets
{
    public static class Loader
    {
        /// <summary>
        /// 对程序内所有的 <seealso cref="ILoadable"/> 对象执行加载操作.
        /// </summary>
        public static void LoadAssets( )
        {
            foreach ( Type type in Assembly.GetEntryAssembly( ).GetTypes( ) )
            {
                if ( !type.IsAbstract && type.GetInterfaces( ).Contains( typeof( ILoadable ) ) )
                {
                    var instance = (ILoadable)Activator.CreateInstance( type );
                    instance.LoadContents( );
                }
            }
        }
    }
}