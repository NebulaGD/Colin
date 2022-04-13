﻿using Colin.Localizations;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colin
{
    /// <summary>
    /// 提供游戏窗口中可进行逻辑刷新、纹理绘制的元素.
    /// </summary>
    public abstract class EngineElement : ILocalizable, IPoolObject, IEmptyState
    {
        /// <summary>
        /// 指示该元素是否进行逻辑刷新.
        /// </summary>
        public virtual bool Enable { get; protected set; } = false;

        /// <summary>
        /// 指示该元素是否进行绘制.
        /// </summary>
        public virtual bool Visable { get; protected set; } = false;

        /// <summary>
        /// 元素的旋转角度.
        /// </summary>
        public float Rotation = 0;

        /// <summary>
        /// 元素的旋转中心.
        /// </summary>
        public Vector2 RotationCenter;

        /// <summary>
        /// 元素的横坐标
        /// </summary>
        public float PositionX
        { get { return Position.X; } set { Position.X = value; } }

        /// <summary>
        /// 元素的纵坐标
        /// </summary>
        public float PositionY
        { get { return Position.Y; } set { Position.Y = value; } }

        /// <summary>
        /// 元素的坐标
        /// </summary>
        public Vector2 Position = Vector2.One * -9999;

        /// <summary>
        /// 元素中心坐标
        /// </summary>
        public Vector2 Center
        { get { return Position + Size / 2; } }

        /// <summary>
        /// 元素的宽
        /// </summary>
        public int Width
        { get { return (int)Size.X; } set { Size.X = value; } }

        /// <summary>
        /// 元素的高
        /// </summary>
        public int Height
        { get { return (int)Size.Y; } set { Size.Y = value; } }

        /// <summary>
        /// 元素的缩放.
        /// </summary>
        public float Scale = 1f;

        /// <summary>
        /// 元素的长宽.
        /// </summary>
        public Vector2 Size = Vector2.Zero;

        /// <summary>
        /// 元素的长宽的一半.
        /// </summary>
        public Vector2 Half => Size / 2;

        /// <summary>
        /// 元素的横向分速度
        /// </summary>
        public float VelocityX
        { get { return Velocity.X; } set { Velocity.X = value; } }

        /// <summary>
        /// 元素的纵向分速度
        /// </summary>
        public float VelocityY
        { get { return Velocity.Y; } set { Velocity.Y = value; } }

        /// <summary>
        /// 元素的速度
        /// </summary>
        public Vector2 Velocity = Vector2.Zero;

        /// <summary>
        /// 获取元素的基础矩形
        /// </summary>
        public Rectangle Rectangle
        { get { return new Rectangle( (int)PositionX, (int)PositionY, Width, Height ); } }

        public bool Empty { get; set; } = true;

        public int ActiveIndex { get; set; } = -1;

        public int PoolIndex { get; set; } = -1;

        /// <summary>
        /// 元素的颜色.
        /// </summary>
        public Color ElementColor;

        public void Initialize( )
        {
            _updateStarted = false;
            _drawStarted = false;
            Size = SetSize( );
            Initialization( );
        }
        protected virtual void Initialization( )
        {

        }
        protected abstract Vector2 SetSize( );

        bool _updateStarted;
        public void Update( GameTime gameTime )
        {
            if ( !Enable )
                return;
            if ( !_updateStarted )
            {
                UpdateStart( );
                _updateStarted = true;
            }
            if ( this != null )
                PreUpdate( );
            if ( this != null )
                Update( );
            Position += Velocity;
            if ( this != null )
                PostUpdate( );
        }
        protected virtual void UpdateStart( )
        {

        }
        protected virtual void PreUpdate( )
        {
        }
        protected virtual void Update( )
        {
        }
        protected virtual void PostUpdate( )
        {
        }

        bool _drawStarted;
        public void Draw( GameTime gameTime )
        {
            if ( !Visable )
                return;
            if ( !_drawStarted )
            {
                DrawStart( HardwareInfo.SpriteBatch );
                _drawStarted = true;
            }
            if ( this != null )
                PreDraw( HardwareInfo.SpriteBatch );
            if ( this != null )
                Draw( HardwareInfo.SpriteBatch );
            if ( this != null )
                PostDraw( HardwareInfo.SpriteBatch );
        }
        protected virtual void DrawStart( SpriteBatch spriteBatch )
        {

        }
        protected virtual void PreDraw( SpriteBatch spriteBatch )
        {
        }
        protected virtual void Draw( SpriteBatch spriteBatch )
        {
        }
        protected virtual void PostDraw( SpriteBatch spriteBatch )
        {
        }

        public virtual string GetName( )
        {
            return "EngineElement";
        }

        public virtual string GetInformation( )
        {
            return "A engine element.";
        }

        public virtual void CreateEmpty( )
        {
            Empty = true;
        }
    }
}