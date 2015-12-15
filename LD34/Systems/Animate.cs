using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LD34.Animations;
using LD34.Components;
using Microsoft.Xna.Framework;

namespace LD34.Systems
{
	class Animate : System
	{
		public override void Update(GameTime gameTime, Entities entities)
		{
			Animation animationToPlay = null;
			for (int i = 0; i < entities.Count; i++)
			{
				if (entities[i].HasComponent(ComponentId.Sprite) && entities[i].HasComponent(ComponentId.Animated))
				{
					Sprite sprite = entities[i].GetComponent(ComponentId.Sprite) as Sprite;
					Animated animation = entities[i].GetComponent(ComponentId.Animated) as Animated;
					if (entities[i].HasComponent(ComponentId.Velocity))
					{
						Velocity velocity = entities[i].GetComponent(ComponentId.Velocity) as Velocity;
						int margin = 60;
						if (velocity.X >= 0)
						{
							if (Math.Abs(velocity.Y) < margin)
							{
								if(velocity.X < margin)
									animationToPlay = animation.Standing;
								else
									animationToPlay = animation.WalkRight;
							}
							else
							{
								if (velocity.Y < 0)
								{
									animationToPlay = animation.JumpRight;
								}
								else
								{
									animationToPlay = animation.FallRight;
								}
							}
						}
						else
						{
							if (Math.Abs(velocity.Y) < margin)
							{
								if (velocity.X > -margin)
									animationToPlay = animation.Standing;
								else
									animationToPlay = animation.WalkLeft;
							}
							else
							{
								if (velocity.Y < 0)
								{
									animationToPlay = animation.JumpLeft;
								}
								else
								{
									animationToPlay = animation.FallLeft;
								}
							}
						}
					}

					if (animationToPlay != null)
					{
						if (animation.CurrentlyPlaying != animationToPlay)
						{
							if (animation.CurrentlyPlaying != null)
								animation.CurrentlyPlaying.GoToBegining();
							animation.CurrentlyPlaying = animationToPlay;
						}
					}
					if (animation.CurrentlyPlaying != null)
					{
						sprite.TextureRect = animation.CurrentlyPlaying.Play(gameTime);
					}
				}
			}
		}
	}
}
