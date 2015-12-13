using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LD34
{
	class TileMap
	{
		public static RenderTarget2D GetMap(int[,] map, Texture2D texture, int textureWidth, int textureHeight, int columns, int rows)
		{

			RenderTarget2D mapTexture = new RenderTarget2D(Config.Instance.GraphicsDevice, columns*textureWidth,
				rows*textureHeight);
			Config.Instance.GraphicsDevice.SetRenderTarget(mapTexture);
			mapTexture.GraphicsDevice.Clear(Color.FromNonPremultiplied(new Vector4(255,255,255,0)));
			Config.Instance.SpriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, null, null);

			int columnCount = texture.Width/textureWidth;
			for (int i = 0; i < rows; i++)
			{
				for (int j = 0; j < columns; j++)
				{
					if (map[i, j] != 0)
					{
						int row = (map[i, j] - 1)/columnCount;
						int column = (map[i, j] - 1)%columnCount;
						Rectangle sourceRectangle = new Rectangle(textureWidth*column, textureWidth*row, textureWidth, textureHeight);
						Rectangle destinaRectangle = new Rectangle(j*textureWidth, i*textureHeight, textureWidth,textureHeight);
						Config.Instance.SpriteBatch.Draw(texture, destinaRectangle, sourceRectangle, Color.White);
					}
				}
			}

			Config.Instance.SpriteBatch.End();
			Config.Instance.GraphicsDevice.SetRenderTarget(null);
			return mapTexture;
		}
	}
}
