using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LD34.Components;
using Microsoft.Xna.Framework;

namespace LD34
{
	class Camera
	{

		// The position of the camera.
		public Vector2 Position
		{
			get { return mCameraPosition; }
			set { mCameraPosition = value; }
		}

		Vector2 mCameraPosition;

		private Vector2 Origin;

		private float Zoom { get; set; }

		private float Rotation { get; set; }

		private int margin;
		private Entity entityToFollow;
		private Collider border;

		public Camera()
		{
			Position = new Vector2(0, 0);
			Origin = new Vector2(0, 0);
			Zoom = 1;
			Rotation = 0;
			margin = 500;
			entityToFollow = null;
			border = null;
		}

		public void SetEntityToFollow(Entity entity)
		{
			entityToFollow = entity;
		}

		public void SetWorldBorder(Collider collider)
		{
			border = collider;
		}

		public void Update(GameTime gameTime)
		{
			if (entityToFollow != null && entityToFollow.HasComponent(ComponentId.Position))
			{
				Position entityPosition = entityToFollow.GetComponent(ComponentId.Position) as Position;
				if (-mCameraPosition.X + Config.Instance.XResolution - margin < entityPosition.Pos.X)
				{
					mCameraPosition.X -= entityPosition.Pos.X -(-mCameraPosition.X + Config.Instance.XResolution - margin);
					if (border != null)
					{
						Console.WriteLine();
						border.Pos.X = entityPosition.Pos.X + margin - Config.Instance.XResolution - border.Width;
					}
				}
				if (-mCameraPosition.X + margin > entityPosition.Pos.X)
				{
					if (mCameraPosition.X < 0)
						mCameraPosition.X += -mCameraPosition.X + margin - entityPosition.Pos.X;
					else
						mCameraPosition.X = 0;
				}
			}
		}

		public Matrix GetTransform()
		{
			return Matrix.CreateTranslation(new Vector3(mCameraPosition, 0.0f))*
			       Matrix.CreateRotationZ(Rotation)*
			       Matrix.CreateScale(Zoom, Zoom, 1.0f)*
			       Matrix.CreateTranslation(new Vector3(Origin, 0.0f));
		}
	}
}
