using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace LD34
{
	class Scene : GameComponent
	{
		private Game game;
		private List<Entity> entities;
		public Scene(Game game) : base(game)
		{
			this.game = game;
			entities = new List<Entity>();
		}

		public new virtual void Update(GameTime gameTime)
		{
			base.Update(gameTime);
		}
	}
}
