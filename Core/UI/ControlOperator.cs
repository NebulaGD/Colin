using Microsoft.Xna.Framework.Graphics;

namespace Colin.Core.UI
{
    /// <summary>
    /// 表示一个控件执行器
    /// </summary>
    public class ControlOperator : EngineComponent
    {
        /// <summary>
        /// 该执行器内的元素列表
        /// </summary>
        public List<BasicControl> Controls = new List<BasicControl>( );

        /// <summary>
        /// 获得上一帧鼠标所悬浮的、在界面最顶层的UI元素
        /// </summary>
        /// <returns></returns>
        public BasicControl? OldAtControl { get; private set; }

        /// <summary>
        /// 获得目前可交互的、在该运行器内最顶层的控件
        /// </summary>
        /// <returns></returns>
        public virtual BasicControl ControlSeekAt( )
        {
            BasicControl? target = null;
            for ( int element = Controls.Count - 1; element >= 0; element-- )
            {
                if ( Controls[ element ].SeekAt( ) != null )
                {
                    target = Controls[ element ].SeekAt( );
                    break;
                }
            }
            return target;
        }

        /// <summary>
        /// 将一个具有指定引用的元素注册至该状态管理器
        /// </summary>
        /// <param name="control"></param>
        public void Register( BasicControl control )
        {
            control.Manager = this;
            Controls.Add( control );
        }

         protected override void Initialization( )
        {
            for ( int Count = 0; Count < Controls.Count; Count++ )
                Controls[ Count ].Initialize( );
        }
        private BasicControl? _seekControl;
        protected override void Update( )
        {
            base.Update( );
            OldAtControl = _seekControl;
            _seekControl = ControlSeekAt( );
            for ( int Count = 0; Count < Controls.Count; Count++ )
                Controls[ Count ].Update( HardwareInfo.GameTimeCache );
            if ( _seekControl != null && _seekControl.Enable )
            {
                if ( _seekControl.Interactive && Input.MouseLeftClick )
                    _seekControl.MouseLeftClickEvent( );
                else if ( _seekControl.Interactive && Input.MouseLeftPressed )
                    _seekControl.MouseLeftPressedEvent( );
                else if ( _seekControl.Interactive && Input.MouseLeftUp )
                    _seekControl.MouseLeftUpEvent( );
                if ( _seekControl.Interactive && Input.MouseRightUp )
                    _seekControl.MouseRightUpEvent( );
                else if ( _seekControl.Interactive && Input.MouseRightPressed )
                    _seekControl.MouseRightPressedEvent( );
                else if ( _seekControl.Interactive && Input.MouseRightUp )
                    _seekControl.MouseRightUpEvent( );
                if ( _seekControl.Interactive )
                    _seekControl.MouseHoverEvent( );
                if ( _seekControl.Interactive && OldAtControl != _seekControl )
                    _seekControl.MouseIntoEvent( );
            }
            if ( _seekControl != OldAtControl && OldAtControl != null && !OldAtControl.Interactive )
                 OldAtControl.MouseLeaveEvent( );
        }

        protected override void Draw( SpriteBatch spriteBatch )
        {
            base.Draw( spriteBatch );
            for ( int Count = 0; Count < Controls.Count; Count++ )
                Controls[ Count ].Draw( HardwareInfo.GameTimeCache );
        }
    }
}