using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LD34.Animations;

namespace LD34.Components
{
	class Animated : Component
	{
		public Animation Standing = null;
		public Animation WalkRight = null;
		public Animation WalkLeft = null;
		public Animation JumpRight = null;
		public Animation JumpLeft = null;
		public Animation FallRight = null;
		public Animation FallLeft = null;
		public Animation Collision = null;
		public Animation CurrentlyPlaying = null;
	}
}
