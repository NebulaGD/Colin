﻿using Microsoft.Xna.Framework;

namespace Colin.Core
{
    /// <summary>
    /// 2D摄像机.
    /// </summary>
    public class Camera2D
    {
        public Vector2 Target = Vector2.Zero;

        public Vector2 Position = Vector2.Zero;

        public Vector2 Velocity;

        public virtual float Zoom { get; } = 1f;

        public virtual float Rotation { get; } = 0f;

        public virtual float MoveFactor { get; } = 0.09f;

        public virtual void Update( GameTime gameTime )
        {
            Velocity = ( Target - Position ) * MoveFactor;
            Position += Velocity;
        }

        public Matrix GetTransformation( )
        {
            return Matrix.CreateTranslation( new Vector3( -Position.X, -Position.Y, 0f ) ) *
                        Matrix.CreateRotationZ( Rotation ) *
                        Matrix.CreateScale( new Vector3( Zoom, Zoom, 1f ) ) *
                        Matrix.CreateTranslation( new Vector3(
                            HardwareInfo.Graphics.GraphicsDevice.Viewport.Width * 0.5f,
                            HardwareInfo.Graphics.GraphicsDevice.Viewport.Height * 0.5f, 0f ) );
        }
    }
}