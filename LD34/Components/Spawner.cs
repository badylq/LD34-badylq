using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LD34.Components
{
	class Spawner : Component
	{
		public float Interval = 1;
		public float IntervalVariation = 1;
		public SpawnDirection SpawnDirection = SpawnDirection.Down;
		public byte Inaccuracy = 0;
		public float StartingVelocity = 200;
		public float TimeToNextSpawn = 0;
		public float TimeSinceLastSpawn = 0;
		public float EnemyMaxSpeed = 200;
	}

	enum SpawnDirection
	{
		Left,
		Right,
		Up,
		Down
	}
}
