using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LD34
{
	class Component
	{
		public ComponentId Id;
	}

	enum ComponentId
	{
		Collider,
		Growing,
		Input,
		Position,
		Sprite,
		Velocity
	}
}
