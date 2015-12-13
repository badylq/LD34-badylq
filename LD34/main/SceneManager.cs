using System.Collections.Generic;
using LD34.Scenes;
using Microsoft.Xna.Framework;

namespace LD34
{
	internal class SceneManager : GameComponent
	{
		private Game game;
		private Scene currentScene;
		//private List<Scene> scenes; 
		public SceneManager(Game game) : base(game)
		{
			this.game = game;
		}

		public override void Update(GameTime gameTime)
		{
			base.Update(gameTime);
			currentScene.Update(gameTime);
		}

		public void Draw(GameTime gameTime)
		{
			currentScene.Draw(gameTime);
		}

		public void LoadScenes()
		{
			currentScene = new Level1(game);
		}

		public Matrix GetViewTransform()
		{
			return currentScene.GetViewTransform();
		}
	}
}