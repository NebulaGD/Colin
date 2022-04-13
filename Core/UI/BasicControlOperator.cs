using Microsoft.Xna.Framework.Graphics;

namespace Colin.Core.UI
{
    /// <summary>
    /// 表示一个控件执行器
    /// </summary>
    public class BasicControlOperator : EngineComponent
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

         protected override void Update( )
        {
            base.Update( );
            OldAtControl = ControlSeekAt( );
            for ( int Count = 0; Count < Controls.Count; Count++ )
                Controls[ Count ].Update( HardwareInfo.GameTimeCache );
            BasicControl control = ControlSeekAt( );
            if ( control != null && control.Enable )
            {
                if ( control != null )
                {
                    if ( control.Interactive && Input.MouseLeftClick )
                        control.MouseLeftClickEvent( );
                    else if ( control.Interactive && Input.MouseLeftPressed )
                        control.MouseLeftPressedEvent( );
                    else if ( control.Interactive && Input.MouseLeftUp )
                        control.MouseLeftUpEvent( );
                    if ( control != null )
                    {
                        if ( control.Interactive && Input.MouseRightUp )
                            control.MouseRightUpEvent( );
                        else if ( control.Interactive && Input.MouseRightPressed )
                            control.MouseRightPressedEvent( );
                        else if ( control.Interactive && Input.MouseRightUp )
                            control.MouseRightUpEvent( );
                        if ( control.Interactive )
                            control.MouseHoverEvent( );
                        if ( control != null )
                            if ( control.Interactive && !control.OldInteractive )
                                control.MouseIntoEvent( );
                    }
                }
            }
            if ( OldAtControl != null )
                if ( control == null && OldAtControl.Interactive )
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