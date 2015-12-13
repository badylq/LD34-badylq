﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LD34.Components;
using LD34.Systems.Helpers;
using Microsoft.Xna.Framework;

namespace LD34.Systems
{
	class Collisions : System
	{
		public override void Update(GameTime gameTime, List<Entity> entities)
		{
			List<Entity> entitiesWithColliders = new List<Entity>();
			List<Entity> collidingEntities = new List<Entity>();
			for (int i = 0; i < entities.Count; i++)
			{
				if (entities[i].HasComponent(ComponentId.Collider) && entities[i].HasComponent(ComponentId.Position))
				{
					entitiesWithColliders.Add(entities[i]);
					((Collider)entities[i].GetComponent(ComponentId.Collider)).CollidingWith = new List<Collider>();
				}
			}
			for (int i = 0; i < entitiesWithColliders.Count; i++)
			{
				ColliderType type = ((Collider) entitiesWithColliders[i].GetComponent(ComponentId.Collider)).Type;
				if (type != ColliderType.Object && type != ColliderType.Platform && type != ColliderType.Ground)
				{
					for (int j = 0; j < entitiesWithColliders.Count; j++)
					{
						if (entitiesWithColliders[i].Id != entitiesWithColliders[j].Id)
						{
							if (CheckCollision(entitiesWithColliders[i], entitiesWithColliders[j]))
							{
								if (entitiesWithColliders[i].HasComponent(ComponentId.Position) && entitiesWithColliders[i].HasComponent(ComponentId.Velocity) && collidingEntities.FirstOrDefault(x => x.Id.Equals(entitiesWithColliders[i])) == null)
								{
									collidingEntities.Add(entitiesWithColliders[i]);
								}
							}
						}
					}
				}
			}

			for (int i = 0; i < entitiesWithColliders.Count; i++)
			{
				Collider collider = entitiesWithColliders[i].GetComponent(ComponentId.Collider) as Collider;
				Position position = entitiesWithColliders[i].GetComponent(ComponentId.Position) as Position;
				Velocity velocity = entitiesWithColliders[i].GetComponent(ComponentId.Velocity) as Velocity;
				Rectangle bounds1 = Helper.GetBounds(collider);
				for (int j = 0; j < collider.CollidingWith.Count; j++)
				{
					Rectangle bounds2 = Helper.GetBounds(collider.CollidingWith[j]);

					

					if (Math.Abs(bounds1.Center.Y - bounds2.Center.Y) < Math.Abs(bounds1.Center.X - bounds2.Center.X))
					{
						velocity.Y = 0.0f;
						if (bounds1.Top > bounds2.Top)
						{
							position.Pos.Y = bounds2.Y + bounds2.Height;
							continue;
						}
						else
						{
							position.Pos.Y = bounds2.Y - collider.Height;
							collider.Pos = position.Pos;
							continue;
						}
					}
					//if (velocity.X != 0 && bounds1.Right < bounds2.Right)
					//{
					//	position.Pos.X = bounds2.X - collider.Width;
					//	collider.Pos = position.Pos;

					//}
					//if (velocity.X != 0)
					//{
					//	position.Pos.X = bounds2.X + bounds2.Width;
					//	collider.Pos = position.Pos;

					//}
				}
			}
			
		}

		private bool CheckCollision(Entity entity1, Entity entity2)
		{
			Collider collider1 = entity1.GetComponent(ComponentId.Collider) as Collider;
			Rectangle bounds1 = Helper.GetBounds(collider1);
			Collider collider2 = entity2.GetComponent(ComponentId.Collider) as Collider;
			Rectangle bounds2 = Helper.GetBounds(collider2);
			if (bounds1.X < bounds2.Right &&
				bounds1.Right > bounds2.X &&
				bounds1.Y < bounds2.Bottom &&
				bounds1.Bottom > bounds2.Y)
			{
				collider1.CollidingWith.Add(collider2);
				return true;
			}
			return false;
		}
	}
}
