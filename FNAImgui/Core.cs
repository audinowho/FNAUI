using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using System.Collections;
using System.Diagnostics;


namespace FNAImgui
{
	public class Core : Game
	{
		/// <summary>
		/// global access to the graphicsDevice
		/// </summary>
		public new static GraphicsDevice GraphicsDevice;

		/// <summary>
		/// default SamplerState used by Materials. Note that this must be set at launch! Changing it after that time will result in only
		/// Materials created after it was set having the new SamplerState
		/// </summary>
		public static SamplerState DefaultSamplerState = new SamplerState
		{
			Filter = TextureFilter.Point
		};

		/// <summary>
		/// provides access to the single Core/Game instance
		/// </summary>
		public static Core Instance => _instance;

		/// <summary>
		/// facilitates easy access to the global Content instance for internal classes
		/// </summary>
		internal static Core _instance;

		// globally accessible systems
		public GlobalManager Manager;

		public SpriteBatch SpriteBatch;

		/// <summary>
		/// this gets setup based on the resolution policy and is used for the final blit of the RenderTarget
		/// </summary>
		Rectangle _finalRenderDestinationRect;

		public RenderTarget2D _sceneRenderTarget;

		GraphicsDeviceManager graphicsManager;
		public int Width { get { return graphicsManager.PreferredBackBufferWidth; } }
		public int Height { get { return graphicsManager.PreferredBackBufferHeight; } }

		public Core(int width = 1280, int height = 720)
		{

			_instance = this;

			graphicsManager = new GraphicsDeviceManager(this)
			{
				PreferredBackBufferWidth = width,
				PreferredBackBufferHeight = height,
				IsFullScreen = false,
				SynchronizeWithVerticalRetrace = true
			};
			graphicsManager.PreferredDepthStencilFormat = DepthFormat.Depth24Stencil8;

			base.Content.RootDirectory = "Content";
			IsMouseVisible = true;
			IsFixedTimeStep = false;

		}

		protected override void Initialize()
		{
			base.Initialize();

			// prep the default Graphics system
			GraphicsDevice = base.GraphicsDevice;
			SpriteBatch = new SpriteBatch(GraphicsDevice);

			UpdateResolutionScaler();

			// prep our render textures
			UpdateResolutionScaler();
			GraphicsDevice.SetRenderTarget(_sceneRenderTarget);
		}

		protected override void Update(GameTime gameTime)
		{
			// update all our systems and global managers
			Input.Update();

			Manager.Update((float)gameTime.ElapsedGameTime.TotalSeconds);

		}

		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.SetRenderTarget(_sceneRenderTarget);
			GraphicsDevice.Clear(Color.CornflowerBlue);

			var currentRenderTarget = _sceneRenderTarget;
			Manager.HandleFinalRender(null, Color.Black, currentRenderTarget, _finalRenderDestinationRect, DefaultSamplerState);
		}

		void UpdateResolutionScaler()
		{
			var screenSize = new Point(Width, Height);

			var renderTargetWidth = screenSize.X;
			var renderTargetHeight = screenSize.Y;

			_finalRenderDestinationRect.X = _finalRenderDestinationRect.Y = 0;
			_finalRenderDestinationRect.Width = screenSize.X;
			_finalRenderDestinationRect.Height = screenSize.Y;


			// set some values in the Input class to translate mouse position to our scaled resolution
			var scaleX = renderTargetWidth / (float)_finalRenderDestinationRect.Width;
			var scaleY = renderTargetHeight / (float)_finalRenderDestinationRect.Height;

			Input._resolutionScale = new Vector2(scaleX, scaleY);
			Input._resolutionOffset = _finalRenderDestinationRect.Location;

			// resize our RenderTargets
			if (_sceneRenderTarget != null)
				_sceneRenderTarget.Dispose();
			_sceneRenderTarget = new RenderTarget2D(GraphicsDevice, renderTargetWidth, renderTargetHeight, false, graphicsManager.PreferredBackBufferFormat, graphicsManager.PreferredDepthStencilFormat,
				0, RenderTargetUsage.PreserveContents);

		}
	}
}