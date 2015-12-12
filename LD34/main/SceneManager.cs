using Microsoft.Xna.Framework;

namespace LD34
{
	internal class SceneManager : GameComponent
	{
		private Game game;
		public SceneManager(Game game) : base(game)
		{
			this.game = game;
		}

		public override void Update(GameTime gameTime)
		{
			base.Update(gameTime);
		}

		public void Draw(GameTime gameTime)
		{
		}
	}
}