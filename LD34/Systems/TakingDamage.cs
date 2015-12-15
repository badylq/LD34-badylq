using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LD34.Components;
using Microsoft.Xna.Framework;

namespace LD34.Systems
{
	class TakingDamage : System
	{
		public override void Update(GameTime gameTime, Entities entities)
		{
			for (int i = 0; i < entities.Count; i++)
			{
				if (entities[i].HasComponent(ComponentId.Player) && entities[i].HasComponent(ComponentId.Collider))
				{
					Collider collider = entities[i].GetComponent(ComponentId.Collider) as Collider;
					bool tookDamage = false;
					for (int j = 0; j < collider.CollidingWith.Count; j++)
					{
						if (entities.GetEntity(collider.CollidingWith[j].EntityId).HasComponent(ComponentId.Damage))
						{
							tookDamage = true;
						}
					}
					if (tookDamage)
					{
						SceneManager.Instance.ChangeScene("death");
					}
				}
			}
		}
	}
}
