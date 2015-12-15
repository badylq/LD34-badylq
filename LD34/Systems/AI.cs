using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LD34.Components;
using Microsoft.Xna.Framework;

namespace LD34.Systems
{
	class AI : System
	{
		public override void Update(GameTime gameTime, Entities entities)
		{
			for (int i = 0; i < entities.Count; i++)
			{
				if (entities[i].HasComponent(ComponentId.Input) && entities[i].HasComponent(ComponentId.Enemy))
				{
					Input input = entities[i].GetComponent(ComponentId.Input) as Input;
					Enemy enemy = entities[i].GetComponent(ComponentId.Enemy) as Enemy;
					if (entities[i].HasComponent(ComponentId.Collider) && entities[i].HasComponent(ComponentId.Velocity))
					{
						Collider collider = entities[i].GetComponent(ComponentId.Collider) as Collider;
						Collider objectCollider = collider.CollidingWith.FirstOrDefault(x => x.Type.Equals(ColliderType.Object));
						if (objectCollider != null && objectCollider.Pos.Y < collider.Pos.Y + collider.Height)
						{
							if (enemy.Direction == Direction.Right)
								enemy.Direction = Direction.Left;
							else
								enemy.Direction = Direction.Right;
						}
					}

					if (enemy.Direction == Direction.Right)
					{
						input.KeyRight = true;
						input.KeyLeft = false;
					}
					if (enemy.Direction == Direction.Left)
					{
						input.KeyLeft = true;
						input.KeyRight = false;
					}
				}
			}
		}
	}
}
