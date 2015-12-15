using System.Collections.Generic;
using System.Dynamic;
using LD34.Scenes;
using Microsoft.Xna.Framework;

namespace LD34
{
	internal class SceneManager
	{
		public static SceneManager Instance
		{
			get
			{
				if (_instance == null)
					_instance = new SceneManager();
				return _instance;
			}
		}

		private static SceneManager _instance;
		private Scene currentScene;
		//private List<Scene> scenes; 
		protected SceneManager()
		{
		}

		public void Update(GameTime gameTime)
		{
			currentScene.Update(gameTime);
		}

		public void Draw(GameTime gameTime)
		{
			currentScene.Draw(gameTime);
		}

		public void LoadScenes()
		{
			currentScene = new Title();
		}

		public Matrix GetViewTransform()
		{
			return currentScene.GetViewTransform();
		}

		public void ChangeScene(string scene)
		{
			if (scene == "level1")
			{
				currentScene = new Level1();
				return;
			}
			if (scene == "title")
			{
				currentScene = new Title();
				return;
			}
			if (scene == "death")
			{
				currentScene = new Death();
			}
			if (scene == "win")
			{
				currentScene = new Win();
			}
		}
	}
}