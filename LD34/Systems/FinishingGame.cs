using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LD34.Components;
using Microsoft.Xna.Framework;

namespace LD34.Systems
{
	class FinishingGame : System
	{
		public override void Update(GameTime gameTime, Entities entities)
		{
			for (int i = 0; i < entities.Count; i++)
			{
				if (entities[i].HasComponent(ComponentId.Player) && entities[i].HasComponent(ComponentId.Collider))
				{
					Collider collider = entities[i].GetComponent(ComponentId.Collider) as Collider;
					Collider finish = collider.CollidingWith.FirstOrDefault(x => x.Type.Equals(ColliderType.Item));
					if (finish != null && entities.GetEntity(finish.EntityId).HasComponent(ComponentId.Finish))
					{
						SceneManager.Instance.ChangeScene("win");
					}
				}
			}
		}
	}
}
