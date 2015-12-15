using System.Collections.Generic;
using System.Linq;
using LD34.Components;
using Microsoft.Xna.Framework;

namespace LD34.Systems
{
	internal class Gravity : System
	{
		public override void Update(GameTime gameTime, Entities entities)
		{
			for (var i = 0; i < entities.Count; i++)
			{
				if (entities[i].HasComponent(ComponentId.Velocity))
				{
					var velocity = entities[i].GetComponent(ComponentId.Velocity) as Velocity;
					velocity.Y += (float)(2250 * gameTime.ElapsedGameTime.TotalSeconds);

				}
			}
		}
	}
}