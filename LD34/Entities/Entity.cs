using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LD34
{
	class Entity
	{
		private List<Component> components;

		public Entity()
		{
			components = new List<Component>();
		}

		public Component GetComponent(ComponentId id)
		{
			var component = components.FirstOrDefault(x => x.Id.Equals(id));
			return component;
		}

		public void AddComponent(Component component)
		{
			if (this.HasComponent(component.Id))
			{
				ReplaceComponent(component);
			}
			else
			{
				components.Add(component);
			}
		}

		public bool HasComponent(ComponentId id)
		{
			if (null != components.FirstOrDefault(x => x.Id.Equals(id)))
			{
				return true;
			}
			return false;
		}

		private void ReplaceComponent(Component component)
		{
			var comp = components.FirstOrDefault(x => x.Id.Equals(component.Id));
			comp = component;
		}
	}
}
