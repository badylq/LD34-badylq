using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LD34.Systems;
using Microsoft.Xna.Framework;

namespace LD34
{
	class Scene
	{
		protected Entities entities;
		protected Draw drawSystem;
		protected List<System> systems;
		protected int width;
		protected int height;
		protected Camera view;
		public Scene()
		{
			entities = new Entities();
			drawSystem = new Draw();
			systems = new List<System>();
			view = new Camera();
			Config.Instance.FramesSinceCleaning = 0;
		}

		public virtual void Update(GameTime gameTime)
		{
			view.Update(gameTime);
		}

		public virtual void Initialize()
		{
			
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
