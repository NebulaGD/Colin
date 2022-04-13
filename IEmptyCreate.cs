using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colin
{
    /// <summary>
    /// 表示一个可以在创建空对象时执行特定操作的对象.
    /// </summary>
    public interface IEmptyCreate
    {
        /// <summary>
        /// 创建一个空对象.
        /// </summary>
        void CreateEmpty( );
    }
}
