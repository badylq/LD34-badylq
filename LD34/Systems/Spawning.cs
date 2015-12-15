using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LD34.Animations;
using LD34.Components;
using Microsoft.Xna.Framework;

namespace LD34.Systems
{
	class Spawning : System
	{
		public override void Update(GameTime gameTime, Entities entities)
		{
			for (int i = 0; i < entities.Count; i++)
			{
				if (entities[i].HasComponent(ComponentId.Spawner) && entities[i].HasComponent(ComponentId.Position))
				{
					Spawner spawner = entities[i].GetComponent(ComponentId.Spawner) as Spawner;
					Position position = entities[i].GetComponent(ComponentId.Position) as Position;
					if (spawner.TimeToNextSpawn < spawner.TimeSinceLastSpawn)
					{
						spawner.TimeSinceLastSpawn = 0;
						Random random = new Random();
						spawner.TimeToNextSpawn = spawner.Interval * 1000 + random.Next((int)(spawner.IntervalVariation * 2000)) - spawner.IntervalVariation * 1000;

						float missDirection = ((float)spawner.Inaccuracy/(float)random.Next((int)spawner.StartingVelocity)) * (random.Next(3) - 1) * 1000;
						if (missDirection > spawner.StartingVelocity/2)
						{
							missDirection = spawner.StartingVelocity/2;
						}
						
						Vector2 velocity = new Vector2(0,0);
						Direction startingDirection = Direction.Right;
						

						if (spawner.SpawnDirection == SpawnDirection.Down)
						{
							velocity = new Vector2(missDirection, spawner.StartingVelocity);
							if (missDirection < 0)
							{
								startingDirection = Direction.Left;
							}
						}
						else
						{
							if (spawner.SpawnDirection == SpawnDirection.Up)
							{
								velocity = new Vector2(missDirection, -spawner.StartingVelocity);
								if (missDirection < 0)
								{
									startingDirection = Direction.Left;
								}
							}
							else
							{
								if (spawner.SpawnDirection == SpawnDirection.Left)
								{
									velocity = new Vector2(-spawner.StartingVelocity, missDirection);
									startingDirection = Direction.Left;
								}
								else
								{
									velocity = new Vector2(spawner.StartingVelocity, missDirection);
								}
							}

						}

						Entity entity = new Entity(Config.Instance.EntityId++);
						entity.AddComponent(new Collider() { Width = 64, Height = 62, Id = ComponentId.Collider, Type = ColliderType.Enemy, EntityId = entity.Id, CanJump = false });
						entity.AddComponent(new Sprite() { DrawOrder = 2, Id = ComponentId.Sprite, Texture = TextureManager.Instance.GetTexture("enemy"), TextureRect = new Rectangle(0, 0, 64, 64), Height = 64, Width = 64 });
						entity.AddComponent(EnemyMashroomAnimation.GetAnimation(TextureManager.Instance.GetTexture("enemy")));
						entity.AddComponent(new Position() { Id = ComponentId.Position, Pos = new Vector2() { X = position.Pos.X, Y = position.Pos.Y } });
						entity.AddComponent(new Input() { Id = ComponentId.Input, KeyJump = false, KeyLeft = false, KeyRight = false });
						entity.AddComponent(new Enemy() { Id = ComponentId.Enemy, Direction = startingDirection });
						entity.AddComponent(new Velocity() { Id = ComponentId.Velocity, X = velocity.X, Y = velocity.Y, MaxVelocity = spawner.EnemyMaxSpeed });
						entity.AddComponent(new Damage() { Id = ComponentId.Damage});
						entity.AddComponent(new Growing() {Id = ComponentId.Growing, Scale = 0.1f, Interval = 2});
						entities.AddEntity(entity);
					}
					else
					{
						spawner.TimeSinceLastSpawn += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
					}
				}
			}
		}
	}
}
