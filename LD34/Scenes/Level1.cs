using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
		public Level1(Game game) : base(game)
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
			width = 40;
			height = 11;
			Texture2D tx = TextureManager.Instance.GetTexture("world");
			
			tileMap = TileMap.GetMap(Level1Tiles.GetTileMapping(), tx, 32, 32, width, height);
			int id = 0;
			base.Initialize();
			systems.Add(new PlayerInput());
			systems.Add(new Gravity());
			systems.Add(new Movement());
			systems.Add(new Collisions());
			
			Entity entity = new Entity(id++);
			entity.AddComponent(new Collider() {Width = 64, Height = 64, Id = ComponentId.Collider, Type = ColliderType.Moving, EntityId = entity.Id});
			entity.AddComponent(new Sprite() {DrawOrder = 1, Id = ComponentId.Sprite, Texture = TextureManager.Instance.GetTexture("player"), TextureRect = new Rectangle(0,0,32,32), Height = 64,Width = 64});
			entity.AddComponent(new Position() {Id = ComponentId.Position,Pos = new Vector2() {X = 200.0f, Y = 300.0f} });
			entity.AddComponent(new Input() {Id = ComponentId.Input, KeyJump = false, KeyLeft = false, KeyRight = false});
			entity.AddComponent(new Player() {Id=ComponentId.Player});
			entity.AddComponent(new Velocity() {Id = ComponentId.Velocity, X = 0.0f, Y=0.0f, MaxVelocity = 400.0f});
			view.SetEntityToFollow(entity);
			entities.Add(entity);
			entity = new Entity(id++);
			entity.AddComponent(new Collider() { Width = 10000, Height = 64, Id = ComponentId.Collider, Type = ColliderType.Ground, EntityId = entity.Id, Pos = new Vector2() { X = 0.0f, Y = 656.0f } });
			entity.AddComponent(new Position() { Id = ComponentId.Position, Pos = new Vector2() { X = 0.0f, Y = 656.0f } });
			entities.Add(entity);
			entity = new Entity(id++);
			entity.AddComponent(new Collider() { Width = 256, Height = 64, Id = ComponentId.Collider, Type = ColliderType.Platform, EntityId = entity.Id, Pos = new Vector2() { X = 128.0f, Y = 464.0f } });
			entity.AddComponent(new Position() { Id = ComponentId.Position, Pos = new Vector2() { X = 128.0f, Y = 464.0f } });
			entities.Add(entity);
			entity = new Entity(id++);
			entity.AddComponent(new Collider() { Width = 128, Height = 192, Id = ComponentId.Collider, Type = ColliderType.Object, EntityId = entity.Id, Pos = new Vector2() { X = 768.0f, Y = 592.0f } });
			entity.AddComponent(new Position() { Id = ComponentId.Position, Pos = new Vector2() { X = 768.0f, Y = 592.0f } });
			entities.Add(entity);
		}
	}
}
