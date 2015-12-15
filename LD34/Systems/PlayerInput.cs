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
		public override void Update(GameTime gameTime, Entities entities)
		{
			for (int i = 0; i < entities.Count; i++)
			{
				if (entities[i].HasComponent(ComponentId.Player) && entities[i].HasComponent(ComponentId.Player))
				{
					Input input = entities[i].GetComponent(ComponentId.Input) as Input;
					input.PrevKeyJump = input.KeyJump;
					if (!input.PrevKeyRight && !input.PrevKeyLeft)
					{
						input.PrevKeyRight = true;
					}
					if (Keyboard.GetState().IsKeyDown(Keys.Space))
					{
						input.KeyJump = false;
						if (input.PrevKeyRight)
						{
							input.KeyRight = true;
						}
						if (input.PrevKeyLeft)
						{
							input.KeyLeft = true;
						}
					}
					else
					{
						if(input.PrevSpace && (input.KeyRight || input.PrevKeyLeft))
						{
							if (input.PrevKeyRight)
							{
								input.KeyRight = false;
								input.KeyJump = true;
							}
							else
							{
								if (input.PrevKeyLeft)
								{
									input.KeyLeft = false;
									input.KeyJump = true;
								}
							}
						}
						else
						{
							input.KeyJump = false;
						}
					}
					if (!input.PrevEnter)
					{
						if (Keyboard.GetState().IsKeyDown(Keys.Enter))
						{
							if (input.PrevKeyRight)
							{
								input.PrevKeyRight = false;
								input.PrevKeyLeft = true;
								Console.WriteLine("Zmiana");
							}
							else
							{
								if (input.PrevKeyLeft)
								{
									input.PrevKeyLeft = false;
									input.PrevKeyRight = true;
								}
							}
						}
					}
					input.PrevEnter = Keyboard.GetState().IsKeyDown(Keys.Enter);
					input.PrevSpace = Keyboard.GetState().IsKeyDown(Keys.Space);

				}
			}
		}
	}
}
