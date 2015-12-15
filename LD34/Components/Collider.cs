using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace LD34.Components
{
	internal class Collider : Component
	{
		public List<Collider> CollidingWith = new List<Collider>();
		public int Height = 0;
		public int Width = 0;
		public Vector2 Pos = new Vector2(0,0);
		public ColliderType Type= ColliderType.Unknown;
		public int EntityId;
		public bool CanJump = false;
		public bool Grounded = false;
	}

	internal enum ColliderType
	{
		Item,
		Ground,
		Object,
		Player,
		Enemy,
		Unknown,
		Finish
	}
}