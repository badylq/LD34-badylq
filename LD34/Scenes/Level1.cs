using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LD34.Animations;
using LD34.Components;
using LD34.Systems;
using LD34.Systems.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LD34.Scenes
{
	class Level1 : Scene
	{
		private RenderTarget2D tileMap;
		public Level1()
		{
			this.Initialize();
		}

		public override void Update(GameTime gameTime)
		{
			base.Update(gameTime);

			for (int i = 0; i < systems.Count; i++)
			{
				systems[i].Update(gameTime, entities);
			}
		}

		public override void Draw(GameTime gameTime)
		{
			Config.Instance.SpriteBatch.Draw((Texture2D)tileMap, new Rectangle(0, 16, width*64, height*64), Color.White);
			drawSystem.Update(gameTime,entities);
		}

		public override void Initialize()
		{
			width = 122;
			height = 11;
			Texture2D tx = TextureManager.Instance.GetTexture("world");
			
			tileMap = TileMap.GetMap(Level1Tiles.GetTileMapping(), tx, 32, 32, width, height);
			base.Initialize();
			systems.Add(new PlayerInput());
			systems.Add(new AI());
			systems.Add(new Gravity());
			systems.Add(new Movement());
			
			systems.Add(new Collisions());
			systems.Add(new TakingDamage());
			systems.Add(new Animate());
			systems.Add(new Spawning());
			systems.Add(new Grow());
			systems.Add(new FinishingGame());
			//systems.Add(new DeleteUselessEntities());

			Entity entity = new Entity(Config.Instance.EntityId++);
			entity.AddComponent(new Sprite() { DrawOrder = 3, Id = ComponentId.Sprite, Texture = TextureManager.Instance.GetTexture("finish"), TextureRect = new Rectangle(0, 0, 384, 384), Height = 384, Width = 384 });
			entity.AddComponent(new Position() { Id = ComponentId.Position, Pos = Helper.GetPositionOnMap(114, 4) });
			entity.AddComponent(new Collider() { Width = 384, Height = 384, Id = ComponentId.Collider, Type = ColliderType.Item, EntityId = entity.Id, Pos = Helper.GetPositionOnMap(114, 4) });
			entity.AddComponent(new Finish() { Id = ComponentId.Finish });
			entities.AddEntity(entity);

			entity = new Entity(Config.Instance.EntityId++);
			entity.AddComponent(new Collider() {Width = 64, Height = 64, Id = ComponentId.Collider, Type = ColliderType.Player, EntityId = entity.Id, CanJump = false});
			entity.AddComponent(new Sprite() {DrawOrder = 3, Id = ComponentId.Sprite, Texture = TextureManager.Instance.GetTexture("player"), TextureRect = new Rectangle(64,64,64,64), Height = 64,Width = 64});
			entity.AddComponent(PlayerAnimation.GetAnimation(TextureManager.Instance.GetTexture("player")));
			entity.AddComponent(new Position() {Id = ComponentId.Position,Pos = new Vector2() {X = 200.0f, Y = 300.0f} });
			entity.AddComponent(new Input() {Id = ComponentId.Input, KeyJump = false, KeyLeft = false, KeyRight = false});
			entity.AddComponent(new Player() {Id=ComponentId.Player});
			entity.AddComponent(new Velocity() {Id = ComponentId.Velocity, X = 0.0f, Y=0.0f, MaxVelocity = 400.0f});
			view.SetEntityToFollow(entity);
			entities.AddEntity(entity);

			entity = new Entity(Config.Instance.EntityId++);
			entity.AddComponent(new Collider() { Width = 32, Height = 720, Id = ComponentId.Collider, Type = ColliderType.Object, EntityId = entity.Id, Pos = new Vector2() { X = -32.0f, Y = 0.0f } });
			entities.AddEntity(entity);
			//view.SetWorldBorder(((Collider)entity.GetComponent(ComponentId.Collider))); TODO:Player can't go oudside of left side of screen
			entity = new Entity(Config.Instance.EntityId++);
			entity.AddComponent(new Collider() { Width = 10000, Height = 64, Id = ComponentId.Collider, Type = ColliderType.Ground, EntityId = entity.Id, Pos = new Vector2() { X = 0.0f, Y = 656.0f } });
			entities.AddEntity(entity);

			//world colliders
			//Helper.CreateObject(entities,,,,);
			Helper.CreateObject(entities, 12, 3, 128, 448);
			Helper.CreateObject(entities, 3, 5, 256, 64);
			Helper.CreateObject(entities, 10, 7, 64, 64);
			Helper.CreateObject(entities, 7, 2, 128, 64);
			Helper.CreateObject(entities, 23, 7, 128, 64);
			Helper.CreateObject(entities, 26, 6, 128, 256);
			Helper.CreateObject(entities, 28, 8, 64, 64);
			Helper.CreateObject(entities, 30, 3, 192, 64);
			Helper.CreateObject(entities, 36, 6, 256, 64);
			Helper.CreateObject(entities, 45, 5, 192, 64);
			Helper.CreateObject(entities, 48, 2, 128, 512);
			Helper.CreateObject(entities, 55, 0, 128, 256);
			Helper.CreateObject(entities, 55, 7, 128, 192);
			Helper.CreateObject(entities, 62, 4, 192, 64);
			Helper.CreateObject(entities, 66, 1, 128, 64);
			Helper.CreateObject(entities, 67, 6, 512, 64);
			Helper.CreateObject(entities, 69, 2, 64, 64);
			Helper.CreateObject(entities, 72, 2, 128, 64);
			Helper.CreateObject(entities, 76, 2, 64, 192);
			Helper.CreateObject(entities, 77, 5, 64, 64);
			Helper.CreateObject(entities, 76, 9, 128, 64);
			Helper.CreateObject(entities, 78, 1, 128, 128);
			Helper.CreateObject(entities, 78, 6, 128, 256);
			Helper.CreateObject(entities, 80, 9, 64, 64);
			Helper.CreateObject(entities, 83, 6, 256, 64);
			Helper.CreateObject(entities, 87, 3, 192, 64);
			Helper.CreateObject(entities, 94, 3, 128, 448);
			Helper.CreateObject(entities, 121, 0, 64, 640);


			//end of world colliders

			entity = new Entity(Config.Instance.EntityId++);
			entity.AddComponent(new Spawner() { Id = ComponentId.Spawner, Interval = 16, IntervalVariation = 2.5f, SpawnDirection = SpawnDirection.Up, StartingVelocity = 100, Inaccuracy = 50, EnemyMaxSpeed = 300});
			entity.AddComponent(new Position() { Id = ComponentId.Position, Pos = Helper.GetPositionOnMap(19,4) });
			entities.AddEntity(entity);

			entity = new Entity(Config.Instance.EntityId++);
			entity.AddComponent(new Spawner() { Id = ComponentId.Spawner, Interval = 16, IntervalVariation = 2.5f, SpawnDirection = SpawnDirection.Up, StartingVelocity = 100, Inaccuracy = 50, EnemyMaxSpeed = 300 });
			entity.AddComponent(new Position() { Id = ComponentId.Position, Pos = Helper.GetPositionOnMap(39, 2) });
			entities.AddEntity(entity);

			entity = new Entity(Config.Instance.EntityId++);
			entity.AddComponent(new Spawner() { Id = ComponentId.Spawner, Interval = 16, IntervalVariation = 2.5f, SpawnDirection = SpawnDirection.Up, StartingVelocity = 100, Inaccuracy = 50, EnemyMaxSpeed = 300 });
			entity.AddComponent(new Position() { Id = ComponentId.Position, Pos = Helper.GetPositionOnMap(60, 8) });
			entities.AddEntity(entity);

			entity = new Entity(Config.Instance.EntityId++);
			entity.AddComponent(new Spawner() { Id = ComponentId.Spawner, Interval = 16, IntervalVariation = 2.5f, SpawnDirection = SpawnDirection.Up, StartingVelocity = 100, Inaccuracy = 50, EnemyMaxSpeed = 300 });
			entity.AddComponent(new Position() { Id = ComponentId.Position, Pos = Helper.GetPositionOnMap(94, 1) });
			entities.AddEntity(entity);
		}
	}
}
