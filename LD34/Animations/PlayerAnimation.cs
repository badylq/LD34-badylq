using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LD34.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LD34.Animations
{
	class PlayerAnimation
	{
		public static Animated GetAnimation(Texture2D texture)
		{
			Animated animated = new Animated();
			animated.Id = ComponentId.Animated;
			int[] frames;
			animated.CurrentlyPlaying = null;
			frames = new int[] {0};
			animated.Standing = Animation.CreateFromTexture(texture, new Vector2(64, 64), frames);
			frames = new int[] {4, 5, 6, 7};
			animated.WalkRight = Animation.CreateFromTexture(texture, new Vector2(64, 64), frames, 15);
			frames = new int[] {8, 9, 10, 11};
			animated.WalkLeft = Animation.CreateFromTexture(texture, new Vector2(64, 64), frames, 15);
			frames = new int[] {12};
			animated.JumpRight = Animation.CreateFromTexture(texture, new Vector2(64, 64), frames);
			frames = new int[] {14};
			animated.JumpLeft = Animation.CreateFromTexture(texture, new Vector2(64, 64), frames);
			frames = new int[] {16};
			animated.FallRight = Animation.CreateFromTexture(texture, new Vector2(64, 64), frames);
			frames = new int[] {18};
			animated.FallLeft = Animation.CreateFromTexture(texture, new Vector2(64, 64), frames);
			return animated;
		}
	}
}
