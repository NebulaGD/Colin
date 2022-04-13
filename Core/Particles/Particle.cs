﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colin.Core.Particles
{
    /// <summary>
    /// 一个粒子.
    /// </summary>
    public class Particle : EngineElement, IPoolObject, IEmptyState
    {
        /// <summary>
        /// 粒子的活跃时间.
        /// <para>[!] 逐帧递减.</para>
        /// </summary>
        public float ActiveTime;

        protected override Vector2 SetSize( ) => Vector2.Zero;

        protected override void Update( )
        {
            if ( ActiveTime <= 0 )
            {
                Empty = true;
                OnDormancy( );
            }
            Behavior( );
            base.Update( );
            ActiveTime--;
        }

        /// <summary>
        /// 该粒子的行为方式.
        /// </summary>
        protected virtual void Behavior( )
        {

        }
    }
}