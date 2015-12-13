using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LD34.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace LD34.Systems
{
	class PlayerInput : System
	{
		public override void Update(GameTime gameTime, List<Entity> entities)
		{
			for (int i = 0; i < entities.Count; i++)
			{
				if (entities[i].HasComponent(ComponentId.Player) && entities[i].HasComponent(ComponentId.Player))
				{
					Input input = entities[i].GetComponent(ComponentId.Input) as Input;
					input.PrevKeyJump = input.KeyJump;
					input.PrevKeyLeft = input.KeyLeft;
					input.PrevKeyRight = input.KeyRight;
					input.KeyRight = Keyboard.GetState().IsKeyDown(Keys.D);
					input.KeyLeft = Keyboard.GetState().IsKeyDown(Keys.A);
					input.KeyJump = Keyboard.GetState().IsKeyDown(Keys.W);
				}
			}
		}
	}
}
