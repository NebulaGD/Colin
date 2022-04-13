using Colin.Extensions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Colin.Core.UI
{
    /// <summary>
    /// 定义带有可视化表示形式的控件的基类.
    /// </summary>
    public abstract class BasicControl : EngineElement
    {
        /// <summary>
        /// 指示该元素是否允许拖动.
        /// </summary>
        public bool DropPermit = false;

        /// <summary>
        /// 指示是否被父元素锁定坐标.
        /// </summary>
        public bool LockOnParent = true;

        /// <summary>
        /// 指示控件是否可进行交互的值.
        /// </summary>
        public bool Interactive
        {
            get
            {
                return CalculationInteractive( );
            }
        }

        /// <summary>
        /// 控件上一帧的交互状态
        /// </summary>
        public bool OldInteractive { get; private set; } = false;

        /// <summary>
        /// 重载该函数以设置计算该控件的交互状态的方法.
        /// </summary>
        protected virtual bool CalculationInteractive( )
        {
            bool result = false;
            if ( !Enable )
                result = false;
            if ( Enable && Rectangle.IntersectMouse( ) )
            {
                result = true;
                Input.MouseContorl = true;
            }
            else
                result = false;
            return result;
        }

        /// <summary>
        /// 启用该控件.
        /// </summary>
        public virtual void StartUsing( )
        {
            Enable = true;
            Visable = true;
            foreach ( BasicControl item in SubControls )
            {
                item.StartUsing( );
            }
        }

        /// <summary>
        /// 令该控件休眠.
        /// </summary>
        public virtual void Dormancy( )
        {
            Enable = false;
            Visable = false;
            foreach ( BasicControl item in SubControls )
            {
                item.Dormancy( );
            }
        }

        /// <summary>
        /// 控件相对于父控件的横位置坐标
        /// </summary>
        public float SubPositionX
        {
            get
            {
                return SubPosition.X;
            }
            set
            {
                SubPosition.X = value;
            }
        }

        /// <summary>
        /// 控件相对于父控件的纵位置坐标
        /// </summary>
        public float SubPosititonY
        {
            get
            {
                return SubPosition.Y;
            }
            set
            {
                SubPosition.Y = value;
            }
        }

        /// <summary>
        /// 控件相对于父控件的位置坐标
        /// </summary>
        public Vector2 SubPosition = Vector2.Zero;

        /// <summary>
        /// 控件的上级控件, 控件只可以拥有一个上级控件
        /// </summary>
        public BasicControl? Parent { get; private set; }

        /// <summary>
        /// 控件的子控件.控件可以拥有多个子控件
        /// </summary>
        public List<BasicControl> SubControls { get; private set; } = new List<BasicControl>( );

        /// <summary>
        /// 表示控件所属的执行器.
        /// </summary>
        public BasicControlOperator? Manager { get; set; }

        /// <summary>
        /// 将一个具有指定引用的控件注册进该控件
        /// <para>被注册的控件将会成为该控件的子控件</para>
        /// </summary>
        /// <param name="control"></param>
        public virtual void Register( BasicControl control )
        {
            control.Manager = Manager;
            control.Parent = this;
            SubControls.Add( control );
        }

        /// <summary>
        /// 将具有指定引用的控件从该控件的子控件列表内删除
        /// </summary>
        /// <param name="element"></param>
        public void Remove( BasicControl element )
        {
            SubControls.Remove( element );
        }

        /// <summary>
        /// 发生在鼠标左键单击时.
        /// </summary>
        public event Action? OnMouseLeftClick;

        /// <summary>
        /// 发生在鼠标左键按下时.
        /// </summary>
        public event Action? OnMouseLeftPressed;

        /// <summary>
        /// 发生在鼠标左键释放时.
        /// </summary>
        public event Action? OnMouseLeftReleased;

        /// <summary>
        /// 发生在鼠标左键释放的最后一刻.
        /// </summary>
        public event Action? OnMouseLeftUp;

        /// <summary>
        /// 发生在鼠标右键单击时.
        /// </summary>
        public event Action? OnMouseRightClick;

        /// <summary>
        /// 发生在鼠标右键按下时.
        /// </summary>
        public event Action? OnMouseRightPressed;

        /// <summary>
        /// 发生在鼠标右键释放时.
        /// </summary>
        public event Action? OnMouseRightReleased;

        /// <summary>
        /// 发生在鼠标右键释放的最后一刻.
        /// </summary>
        public event Action? OnMouseRightUp;

        /// <summary>
        /// 发生在鼠标悬浮在该控件上、且该控件目前可交互时.
        /// </summary>
        public event Action? OnMouseHover;

        /// <summary>
        /// 发生在鼠标进入可交互状态时.
        /// </summary>
        public event Action? OnMouseInto;

        /// <summary>
        /// 发生在鼠标结束可交互状态时;
        /// </summary>
        public event Action? OnMouseLeave;

         protected override sealed void Initialization( )
        {
            OnMouseLeftClick += MouseLeftClick;
            OnMouseLeftPressed += MouseLeftPressed;
            OnMouseLeftReleased += MouseLeftReleased;
            OnMouseLeftUp += MouseLeftUp;
            OnMouseRightClick += MouseRightClick;
            OnMouseRightPressed += MouseRightPressed;
            OnMouseRightReleased += MouseRightReleased;
            OnMouseRightUp += MouseRightUp;
            OnMouseHover += MouseHover;
            OnMouseInto += MouseInto;
            OnMouseLeave += MouseLeave;
            InitializeControl( );
            foreach ( BasicControl element in SubControls )
                element.Initialization( );
        }


        /// <summary>
        /// 初始化该控件.
        /// </summary>
        protected virtual void InitializeControl( )
        {

        }

        /// <summary>
        /// 在鼠标左键单击时执行.
        /// </summary>
        protected virtual void MouseLeftClick( )
        {

        }
        internal void MouseLeftClickEvent( ) => OnMouseLeftClick?.Invoke( );

         protected int positionCacheX = 0;
         protected int positionCacheY = 0;
         protected bool isClicked = true;
         protected bool inDrop = false;
         protected bool cantDrop = false;

        /// <summary>
        /// 在鼠标左键长按时执行.
        /// </summary>
        protected virtual void MouseLeftPressed( )
        {

        }
        internal void MouseLeftPressedEvent( )
        {
            if ( !Rectangle.IntersectMouseLast( ) && Input.MouseStateLast.LeftButton == ButtonState.Pressed )
                cantDrop = true;
            if ( DropPermit && isClicked )
            {
                positionCacheX = (int)( Input.MouseState.X - PositionX );
                positionCacheY = (int)( Input.MouseState.Y - PositionY );
                if ( !cantDrop )
                    inDrop = true;
                isClicked = false;
            }
            OnMouseLeftPressed?.Invoke( );
        }


        /// <summary>
        /// 在鼠标左键释放时执行.
        /// </summary>
        protected virtual void MouseLeftReleased( )
        {

        }
        internal void MouseLeftReleasedEvent( ) => OnMouseLeftReleased?.Invoke( );

        /// <summary>
        /// 在鼠标左键释放的最后一帧执行.
        /// </summary>
        protected virtual void MouseLeftUp( )
        {

        }
        internal void MouseLeftUpEvent( )
        {
            if ( DropPermit )
            {
                positionCacheX = 0;
                positionCacheY = 0;
                inDrop = false;
                isClicked = true;
            }
            OnMouseLeftUp?.Invoke( );
        }


        /// <summary>
        /// 在鼠标右键单击时执行.
        /// </summary>
        protected virtual void MouseRightClick( )
        {

        }
        internal void MouseRightClickEvent( ) => OnMouseRightClick?.Invoke( );


        /// <summary>
        /// 在鼠标右键长按时执行.
        /// </summary>
        protected virtual void MouseRightPressed( )
        {

        }
        internal void MouseRightPressedEvent( ) => OnMouseRightPressed?.Invoke( );


        /// <summary>
        /// 在鼠标右键释放时执行.
        /// </summary>
        protected virtual void MouseRightReleased( )
        {

        }
        internal void MouseRightReleasedEvent( ) => OnMouseRightReleased?.Invoke( );


        /// <summary>
        /// 在鼠标右键释放的最后一帧执行.
        /// </summary>
        protected virtual void MouseRightUp( )
        {

        }
        internal void MouseRightUpEvent( ) => OnMouseRightUp?.Invoke( );


        /// <summary>
        /// 在鼠标悬浮在该控件上、且允许交互时执行.
        /// </summary>
        protected virtual void MouseHover( )
        {

        }
        internal void MouseHoverEvent( ) => OnMouseHover?.Invoke( );

        /// <summary>
        /// 在鼠标进入可交互状态时执行.
        /// </summary>
        protected virtual void MouseInto( )
        {

        }
        internal void MouseIntoEvent( ) => OnMouseInto?.Invoke( );

        /// <summary>
        /// 在鼠标结束可交互状态时执行.
        /// </summary>
        protected virtual void MouseLeave( )
        {

        }
        internal void MouseLeaveEvent( ) => OnMouseLeave?.Invoke( );

         protected override void PreUpdate( )
        {
            OldInteractive = Interactive;
            base.PreUpdate( );
        }

        /// <summary>
        /// 执行子控件的逻辑刷新
        /// </summary>
        protected virtual void UpdateSubControls( )
        {
            foreach ( BasicControl sub in SubControls )
            {
                sub.CalculationInteractive( );
                if ( sub.LockOnParent )
                    sub.Position = Position + sub.SubPosition;
                sub.Update( HardwareInfo.GameTimeCache );
            }
        }

         protected override void Update( )
        {
            if ( inDrop )
                Position = Input.MousePosition - new Vector2( positionCacheX, positionCacheY );
            cantDrop = false;
            UpdateSubControls( );
            if ( !Input.MouseLeftPressed )
            {
                inDrop = false;
                isClicked = true;
                positionCacheX = 0;
                positionCacheY = 0;
            }
        }

        /// <summary>
        /// 执行子控件的纹理绘制.
        /// </summary>
        protected virtual void DrawSubControls( )
        {
            foreach ( BasicControl sub in SubControls )
                sub.Draw( HardwareInfo.GameTimeCache );
        }

        /// <summary>
        /// 执行控件的纹理绘制.
        /// </summary>
        /// <param name="spriteBatch"></param>
        protected override void Draw( SpriteBatch spriteBatch )
        {
            DrawSubControls( );
        }

        /// <summary>
        /// 返回该控件目前可最先交互的控件.
        /// </summary>
        /// <returns>如果寻找到非该控件之外的控件, 则返回寻找到的控件; 否则返回自己.</returns>
        public virtual BasicControl SeekAt( )
        {
            BasicControl? target = null;
            for ( int sub = SubControls.Count - 1; sub >= 0; sub-- )
            {
                if ( SubControls[ sub ].SeekAt( ) == null )
                {
                    target = null;
                }
                else if ( SubControls[ sub ].SeekAt( ) != null )
                {
                    target = SubControls[ sub ].SeekAt( );
                    return target;
                }
            }
            if ( Interactive )
            {
                return this;
            }
            return target;
        }
    }
}