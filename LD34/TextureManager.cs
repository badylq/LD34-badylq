using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LD34
{
	internal class TextureManager
	{
		private static TextureManager _instance;
		private readonly List<Texture> textures;

		protected TextureManager()
		{
			textures = new List<Texture>();
		}

		public static TextureManager Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new TextureManager();
				}
				return _instance;
			}
		}

		public void LoadTextures(ContentManager contentManager)
		{
			textures.Add(new Texture {Id = "player", Image = contentManager.Load<Texture2D>("img/player")});
			textures.Add(new Texture {Id = "world", Image = contentManager.Load<Texture2D>("img/world")});
			textures.Add(new Texture {Id = "enemy", Image = contentManager.Load<Texture2D>("img/enemy")});
			textures.Add(new Texture { Id = "title", Image = contentManager.Load<Texture2D>("img/title") });
			textures.Add(new Texture { Id = "death", Image = contentManager.Load<Texture2D>("img/death") });
			textures.Add(new Texture { Id = "win", Image = contentManager.Load<Texture2D>("img/win") });
			textures.Add(new Texture { Id = "finish", Image = contentManager.Load<Texture2D>("img/finish") });
		}

		public Texture2D GetTexture(string id)
		{
			var texture = textures.FirstOrDefault(x => x.Id.Equals(id));
			return texture.Image;
		}
	}
}