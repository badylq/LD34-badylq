using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LD34.Components
{
	public class Sprite : Component
	{
		public int DrawOrder = 0;
		public Texture2D Texture = null;
		public Rectangle TextureRect= new Rectangle(0,0,0,0);
		public int Width = 0;
		public int Height = 0;
	}
}