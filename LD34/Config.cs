using Microsoft.Xna.Framework.Graphics;

namespace LD34
{
	internal class Config
	{
		private static Config _instance;
		public int XResolution;
		public int YResolution;
		public SpriteBatch SpriteBatch;
		public GraphicsDevice GraphicsDevice;

		protected Config()
		{
		}

		public static Config Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new Config();
				}
				return _instance;
			}
		}
	}
}