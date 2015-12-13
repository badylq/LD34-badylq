using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LD34.Components;
using LD34.Systems.Helpers;
using Microsoft.Xna.Framework;

namespace LD34.Systems
{
	class Draw : System
	{
		public override void Update(GameTime gameTime, List<Entity> entities)
		{
			for (int i = 0; i < entities.Count; i++)
			{
				if(entities[i].HasComponent(ComponentId.Sprite) && entities[i].HasComponent(ComponentId.Position))
				{
					Sprite sprite = entities[i].GetComponent(ComponentId.Sprite) as Sprite;
					Position position = entities[i].GetComponent(ComponentId.Position) as Position;
					Config.Instance.SpriteBatch.Draw(sprite.Texture, Helper.GetDestinaRectangle(position.Pos, sprite), sprite.TextureRect,Color.White);
				}
			}
		}
	}
}
