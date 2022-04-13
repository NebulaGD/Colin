using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Colin.Assets
{
    /// <summary>
    /// 表示一个可在初始化场景时被加载的对象.
    /// </summary>
    public interface ILoadable
    {
        void LoadContents( );
    }
}