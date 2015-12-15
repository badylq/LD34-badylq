using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LD34.Components;
using Microsoft.Xna.Framework;

namespace LD34.Systems
{
	class DeleteUselessEntities : System
	{
		public override void Update(GameTime gameTime, Entities entities)
		{
			if (Config.Instance.FramesSinceCleaning++ > 600)
			{
				Entity player = entities.GetPlayer();
				Position playerPosition = player.GetComponent(ComponentId.Position) as Position;
				for (int i = 0; i < entities.Count; i++)
				{
					if (entities[i].HasComponent(ComponentId.Position) &&
					    (entities[i].HasComponent(ComponentId.Enemy) || entities[i].HasComponent(ComponentId.Spawner)))
					{
						Position position = entities[i].GetComponent(ComponentId.Position) as Position;
						if (playerPosition.Pos.X > position.Pos.X + (Config.Instance.XResolution * 4))
						{
							entities.RemoveEntity(entities[i].Id);
						}
					}
				}
			}
		}
	}
}
