using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LD34.Animations
{
	class Animation
	{
		private List<Rectangle> frames;
		private int currentFrame;
		private int fps;
		private float currentTimePassed;
		private int numerOfFrames;
		private float frameTime;

		public Animation()
		{
			frames = new List<Rectangle>();
			currentFrame = 0;
			fps = 1;
			currentTimePassed = 0.0f;
			numerOfFrames = 0;
			UpdateFrameTime();
		}
		public void AddFrame(Rectangle frame)
		{
			frames.Add(frame);
			numerOfFrames++;
			UpdateFrameTime();
		}

		public Rectangle Play(GameTime gameTime)
		{
			if (numerOfFrames != 1)
			{
				currentTimePassed += (float) gameTime.ElapsedGameTime.TotalMilliseconds;
				if (currentTimePassed > frameTime)
				{
					currentTimePassed -= frameTime;
					currentFrame++;
					if (currentFrame >= numerOfFrames)
					{
						currentFrame = 0;
					}
				}
			}
			return frames[currentFrame];
		}

		public void GoToBegining()
		{
			currentFrame = 0;
			currentTimePassed = 0;
		}

		public void SetFPS(int fps)
		{
			this.fps = fps;
			UpdateFrameTime();
		}

		private void UpdateFrameTime()
		{
			frameTime = 1000 / fps;
		}

		public static Animation CreateFromTexture(Texture2D texture,Vector2 frameSize, int[] frames, int fps = 1)
		{
			Animation animation = new Animation();
			animation.SetFPS(fps);
			int columnCount = texture.Width / (int)frameSize.X;
			foreach (var frame in frames)
			{
				int row = (frame) / columnCount;
				int column = (frame) % columnCount;
				Rectangle frameRect = new Rectangle((int)frameSize.X * column, (int)frameSize.Y * row, (int)frameSize.X, (int)frameSize.Y);
				animation.AddFrame(frameRect);
			}
			return animation;
		}
	}
}
