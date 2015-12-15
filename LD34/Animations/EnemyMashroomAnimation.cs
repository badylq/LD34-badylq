using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LD34.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LD34.Animations
{
	class EnemyMashroomAnimation
	{
		public static Animated GetAnimation(Texture2D texture)
		{
			Animated animated = new Animated();
			animated.Id = ComponentId.Animated;
			int[] frames;
			animated.CurrentlyPlaying = animated.Standing;
			frames = new int[] { 3 };
			animated.Standing = Animation.CreateFromTexture(texture, new Vector2(64, 64), frames);
			animated.FallRight = animated.Standing;
			animated.FallLeft = animated.Standing;
			frames = new int[] { 0, 1, 2, 1 };
			animated.WalkRight = Animation.CreateFromTexture(texture, new Vector2(64, 64), frames, 10);
			animated.WalkLeft = animated.WalkRight;
			return animated;
		}
	}
}
