using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LD34
{
	class Entity
	{
		private List<Component> components;

		public Component GetComponent(int id)
		{
			return null;
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

		public bool HasComponent(int id)
		{
			return false;
		}

		private void ReplaceComponent(Component component)
		{
			for (int i = 0; i < components.Count; i++)
			{
				if (components[i].Id == component.Id)
				{
					components[i] = component;
					break;
				}
			}
		}
	}
}
