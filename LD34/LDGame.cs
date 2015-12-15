using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LD34
{
	/// <summary>
	/// This is the main type for your game.
	/// </summary>
	public class LDGame : Game
	{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;
		private SceneManager sceneManager;
		public LDGame()
		{
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
		}

		/// <summary>
		/// Allows the game to perform any initialization it needs to before starting to run.
		/// This is where it can query for any required services and load any non-graphic
		/// related content.  Calling base.Initialize will enumerate through any components
		/// and initialize them as well.
		/// </summary>
		protected override void Initialize()
		{
			Config.Instance.XResolution = 1280;
			Config.Instance.YResolution = 720;
			graphics.PreferredBackBufferWidth = Config.Instance.XResolution;
			graphics.PreferredBackBufferHeight = Config.Instance.YResolution;
			//graphics.IsFullScreen = true;
			graphics.ApplyChanges();

			sceneManager = SceneManager.Instance;

			base.Initialize();
		}

		/// <summary>
		/// LoadContent will be called once per game and is the place to load
		/// all of your content.
		/// </summary>
		protected override void LoadContent()
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new SpriteBatch(GraphicsDevice);
			Config.Instance.SpriteBatch = spriteBatch;
			Config.Instance.GraphicsDevice = graphics.GraphicsDevice;
			TextureManager.Instance.LoadTextures(Content);

			sceneManager.LoadScenes();
		}

		/// <summary>
		/// UnloadContent will be called once per game and is the place to unload
		/// game-specific content.
		/// </summary>
		protected override void UnloadContent()
		{
		}

		/// <summary>
		/// Allows the game to run logic such as updating the world,
		/// checking for collisions, gathering input, and playing audio.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Update(GameTime gameTime)
		{
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();

			sceneManager.Update(gameTime);

			base.Update(gameTime);
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.DeepSkyBlue);
			spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, null, null, null,
				sceneManager.GetViewTransform());
			sceneManager.Draw(gameTime);
			spriteBatch.End();

			base.Draw(gameTime);
		}
	}
}
