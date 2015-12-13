using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LD34.Systems;
using Microsoft.Xna.Framework;

namespace LD34
{
	class Scene : GameComponent
	{
		protected Game game;
		protected List<Entity> entities;
		protected Draw drawSystem;
		protected List<System> systems;
		protected int width;
		protected int height;
		protected Camera view;
		public Scene(Game game) : base(game)
		{
			this.game = game;
			entities = new List<Entity>();
			drawSystem = new Draw();
			systems = new List<System>();
			view = new Camera();
		}

		public new virtual void Update(GameTime gameTime)
		{
			base.Update(gameTime);
			view.Update(gameTime);
		}

		public new virtual void Initialize()
		{
			base.Initialize();
		}

		public virtual void Draw(GameTime gameTime)
		{
		}

		public Matrix GetViewTransform()
		{
			return view.GetTransform();
		}
	}
}
