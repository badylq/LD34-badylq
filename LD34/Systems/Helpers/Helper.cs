using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LD34.Components;
using Microsoft.Xna.Framework;

namespace LD34.Systems.Helpers
{
	class Helper
	{
		public static Rectangle GetDestinaRectangle(Vector2 position, Sprite sprite)
		{
			return new Rectangle((int)position.X, (int)position.Y, sprite.Width, sprite.Height);
		}

		public static Rectangle GetBounds(Collider collider)
		{
			return new Rectangle((int)collider.Pos.X, (int)collider.Pos.Y, collider.Width, collider.Height);
		}

		public static Vector2 GetPositionOnMap(int x, int y)
		{
			return new Vector2(x*64,y*64+16);
		}

		public static void CreateObject(Entities entities, int x, int y, int width, int height)
		{
			Entity entity = new Entity(Config.Instance.EntityId++);
			entity.AddComponent(new Collider() { Width = width, Height = height, Id = ComponentId.Collider, Type = ColliderType.Object, EntityId = entity.Id, Pos = GetPositionOnMap(x, y) });
			entities.AddEntity(entity);
		}
	}
}
