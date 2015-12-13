using System.Collections.Generic;
using System.Linq;
using LD34.Components;
using Microsoft.Xna.Framework;

namespace LD34.Systems
{
	internal class Gravity : System
	{
		public override void Update(GameTime gameTime, List<Entity> entities)
		{
			for (var i = 0; i < entities.Count; i++)
			{
				if (entities[i].HasComponent(ComponentId.Velocity))
				{
					var velocity = entities[i].GetComponent(ComponentId.Velocity) as Velocity;
					velocity.Y += (float)(1700 * gameTime.ElapsedGameTime.TotalSeconds);
					//if (entities[i].HasComponent(ComponentId.Collider))
					//{
					//	Collider collider = entities[i].GetComponent(ComponentId.Collider) as Collider;
						
					//}

				}
			}
		}
	}
}