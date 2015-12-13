using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LD34.Components;
using Microsoft.Xna.Framework;

namespace LD34.Systems.Helpers
{
	class Helper
	{
		public static Rectangle GetDestinaRectangle(Vector2 position, Sprite sprite)
		{
			return new Rectangle((int)position.X, (int)position.Y, sprite.Width, sprite.Height);
		}

		public static Rectangle GetBounds(Collider collider)
		{
			return new Rectangle((int)collider.Pos.X, (int)collider.Pos.Y, collider.Width, collider.Height);
		}
	}
}
