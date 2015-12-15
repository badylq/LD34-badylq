using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LD34
{
	class Entities
	{
		private List<Entity> entities;

		public Entities()
		{
			entities = new List<Entity>();
		}

		public Entity GetEntity(int id)
		{
			var entity = entities.FirstOrDefault(x => x.Id.Equals(id));
			return entity;
		}

		public void AddEntity(Entity entity)
		{
			if (this.HasEntity(entity.Id))
			{
				ReplaceEntity(entity);
			}
			else
			{
				entities.Add(entity);
			}
		}

		public void RemoveEntity(int id)
		{
			entities.Remove(GetEntity(id));
		}

		public bool HasEntity(int id)
		{
			if (null != entities.FirstOrDefault(x => x.Id.Equals(id)))
			{
				return true;
			}
			return false;
		}

		private void ReplaceEntity(Entity entity)
		{
			var ent = entities.FirstOrDefault(x => x.Id.Equals(entity.Id));
			ent = entity;
		}

		public int Count
		{
			get { return entities.Count; }
		}

		public Entity this[int key]
		{
			get
			{
				return entities[key];
			}
			set
			{
				entities[key] = value;
			}
		}

		public Entity GetPlayer()
		{
			return entities.FirstOrDefault(x => x.HasComponent(ComponentId.Player).Equals(true));
		}
	}
}
