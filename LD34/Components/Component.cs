using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LD34.Components;

namespace LD34
{
	public class Component
	{
		public ComponentId Id { get; set; }
	}

	public enum ComponentId
	{
		Collider,
		Growing,
		Input,
		Position,
		Sprite,
		Velocity,
		Player,
		Enemy,
		Animated,
		Spawner,
		Damage,
		Finish
	}
}
