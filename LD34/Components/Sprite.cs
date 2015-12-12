using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LD34.Components
{
	internal class Sprite
	{
		public int DrawOrder { get; set; }
		public Texture2D Texture { get; set; }
		public Rectangle TextureRect { get; set; }
	}
}