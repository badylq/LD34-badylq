using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LD34.Components
{
	class Enemy : Component
	{
		public Direction Direction= Direction.Right;
	}
	enum Direction
	{
		Left,
		Right
	}
}
