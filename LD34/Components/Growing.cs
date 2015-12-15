﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LD34.Components
{
	class Growing : Component
	{
		public float Scale = 0.05f;
		public float Interval = 1;
		public float TimeSinceLastGrow = 0;
	}
}
