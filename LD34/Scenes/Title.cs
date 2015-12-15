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
using Microsoft.Xna.Framework.Input;

namespace LD34.Scenes
{
	class Title : Scene
	{
		public Title()
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

			if (Keyboard.GetState().IsKeyDown(Keys.Space))
			{
				SceneManager.Instance.ChangeScene("level1");
			}
		}

		public override void Draw(GameTime gameTime)
		{
			drawSystem.Update(gameTime, entities);
		}

		public override void Initialize()
		{
			Entity entity = new Entity(Config.Instance.EntityId++);
			entity.AddComponent(new Sprite() { DrawOrder = 3, Id = ComponentId.Sprite, Texture = TextureManager.Instance.GetTexture("title"), TextureRect = new Rectangle(0, 0, 640, 360), Height = 720, Width = 1280 });
			entity.AddComponent(new Position() { Id = ComponentId.Position, Pos = new Vector2() { X = 0.0f, Y = 0.0f } });
			entities.AddEntity(entity);

		}
	}
}
