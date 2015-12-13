using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LD34.Components;
using Microsoft.Xna.Framework;

namespace LD34.Systems
{
	class Movement : System
	{
		public override void Update(GameTime gameTime, List<Entity> entities)
		{
			for (int i = 0; i < entities.Count; i++)
			{
				if (entities[i].HasComponent(ComponentId.Velocity) && entities[i].HasComponent(ComponentId.Position))
				{
					Velocity velocity = entities[i].GetComponent(ComponentId.Velocity) as Velocity;
					Position position = entities[i].GetComponent(ComponentId.Position) as Position;
					Collider collider = null;

					if (entities[i].HasComponent(ComponentId.Collider))
					{
						collider = entities[i].GetComponent(ComponentId.Collider) as Collider;
					}

					if (entities[i].HasComponent(ComponentId.Input))
					{
						Input input = entities[i].GetComponent(ComponentId.Input) as Input;
						if (input.KeyLeft)
						{
							velocity.X -= (float) (velocity.MaxVelocity*4*gameTime.ElapsedGameTime.TotalSeconds);
							if (velocity.X < -velocity.MaxVelocity)
								velocity.X = -velocity.MaxVelocity;
						}
						if (input.KeyRight)
						{
							velocity.X += (float) (velocity.MaxVelocity*4*gameTime.ElapsedGameTime.TotalSeconds);
							if (velocity.X > velocity.MaxVelocity)
								velocity.X = velocity.MaxVelocity;
						}
						if (velocity.X != 0)
						{
							if (velocity.X > 0 && !input.KeyRight)
							{
								velocity.X -= (float) (velocity.MaxVelocity*5*gameTime.ElapsedGameTime.TotalSeconds);
								if (velocity.X < 0)
									velocity.X = 0;
							}
							else
							{
								if (velocity.X < 0 && !input.KeyLeft)
								{
									velocity.X += (float) (velocity.MaxVelocity*5*gameTime.ElapsedGameTime.TotalSeconds);
									if (velocity.X > 0)
										velocity.X = 0;
								}
							}
						}

						if (input.KeyJump && collider != null)
						{
							if(collider.CanJump)
							{
								velocity.Y = -1000.0f;
								collider.CanJump = false;
							}
						}
					}

					position.Pos.X += (float)(velocity.X * gameTime.ElapsedGameTime.TotalSeconds);
					position.Pos.Y += (float)(velocity.Y * gameTime.ElapsedGameTime.TotalSeconds);

					if (collider != null)
					{
						collider.Pos = position.Pos;
					}
				}
			}
		}
	}
}
