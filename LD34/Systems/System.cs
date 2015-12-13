using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace LD34
{
	abstract class System
	{
		abstract public void Update(GameTime gameTime, List<Entity> entities);
	}
}
