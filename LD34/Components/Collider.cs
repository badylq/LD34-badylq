using System.Collections.Generic;

namespace LD34.Components
{
	internal class Collider
	{
		public List<Collider> CollidingWith { get; set; }
		public int Height { get; set; }
		public int Width { get; set; }
		public ColliderType type { get; set; }
	}

	internal enum ColliderType
	{
		Enemy,
		Item,
		Ground,
		Platform,
		Object
	}
}