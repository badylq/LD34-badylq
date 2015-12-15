using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LD34.Components;
using Microsoft.Xna.Framework;

namespace LD34.Systems
{
	class Grow : System
	{
		public override void Update(GameTime gameTime, Entities entities)
		{
			for (int i = 0; i < entities.Count; i++)
			{
				if (entities[i].HasComponent(ComponentId.Growing) && entities[i].HasComponent(ComponentId.Sprite))
				{
					Growing growing = entities[i].GetComponent(ComponentId.Growing) as Growing;
					if (growing.TimeSinceLastGrow >= growing.Interval)
					{
						growing.TimeSinceLastGrow = 0;
						Sprite sprite = entities[i].GetComponent(ComponentId.Sprite) as Sprite;

						float height = sprite.Height*growing.Scale;
						float width = sprite.Width*growing.Scale;

						
						sprite.Height += (int)height;
						sprite.Width += (int)width;

						if (entities[i].HasComponent(ComponentId.Position))
						{
							Position position = entities[i].GetComponent(ComponentId.Position) as Position;
							position.Pos.X -= (int)width;
							position.Pos.Y -= (int)height+5;
							if (entities[i].HasComponent(ComponentId.Collider))
							{
								Collider collider = entities[i].GetComponent(ComponentId.Collider) as Collider;
								collider.Height += (int)(collider.Height * growing.Scale);
								collider.Width += (int)(collider.Width * growing.Scale);
								collider.Pos.X = (int)(collider.Width * growing.Scale);
								collider.Pos.Y -= (int)(collider.Height * growing.Scale) + 5;
							}
						}
						
					}
					else
					{
						growing.TimeSinceLastGrow += (float)gameTime.ElapsedGameTime.TotalSeconds;
					}

				}
			}
		}
	}
}
