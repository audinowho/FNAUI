using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using System.Collections;
using System.Diagnostics;


[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("Nez.ImGui")]
[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("Nez.Persistence")]


namespace Nez
{
	public class Core : Game
	{
		/// <summary>
		/// enables/disables if we should quit the app when escape is pressed
		/// </summary>
		public static bool ExitOnEscapeKeypress = true;

		/// <summary>
		/// enables/disables pausing when focus is lost. No update or render methods will be called if true when not in focus.
		/// </summary>
		public static bool PauseOnFocusLost = true;

		/// <summary>
		/// enables/disables debug rendering
		/// </summary>
		public static bool DebugRenderEnabled = false;

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
		/// clear color that is used in preRender to clear the screen
		/// </summary>
		public Color ClearColor = Color.CornflowerBlue;

		/// <summary>
		/// clear color for the final render of the RenderTarget to the framebuffer
		/// </summary>
		public Color LetterboxColor = Color.Black;

		/// <summary>
		/// this gets setup based on the resolution policy and is used for the final blit of the RenderTarget
		/// </summary>
		Rectangle _finalRenderDestinationRect;

		public RenderTarget2D _sceneRenderTarget;

		GraphicsDeviceManager graphicsManager;
		public int Width { get { return graphicsManager.PreferredBackBufferWidth; } }
		public int Height { get { return graphicsManager.PreferredBackBufferHeight; } }

		public Core(int width = 1280, int height = 720, bool isFullScreen = false, string windowTitle = "Nez", string contentDirectory = "Content")
		{

			_instance = this;

			graphicsManager = new GraphicsDeviceManager(this)
			{
				PreferredBackBufferWidth = width,
				PreferredBackBufferHeight = height,
				IsFullScreen = isFullScreen,
				SynchronizeWithVerticalRetrace = true
			};
			graphicsManager.PreferredDepthStencilFormat = DepthFormat.Depth24Stencil8;

			base.Content.RootDirectory = contentDirectory;
			IsMouseVisible = true;
			IsFixedTimeStep = false;

		}


		#region Passthroughs to Game

		public new static void Exit()
		{
			((Game) _instance).Exit();
		}

		#endregion


		#region Game overides

		protected override void Initialize()
		{
			base.Initialize();

			// prep the default Graphics system
			GraphicsDevice = base.GraphicsDevice;
			SpriteBatch = new SpriteBatch(Core.GraphicsDevice);

			SetDesignResolution(Width, Height);

			// prep our render textures
			UpdateResolutionScaler();
			GraphicsDevice.SetRenderTarget(_sceneRenderTarget);
		}

		protected override void Update(GameTime gameTime)
		{
			if (PauseOnFocusLost && !IsActive)
			{
				SuppressDraw();
				return;
			}

			// update all our systems and global managers
			Input.Update();

			if (ExitOnEscapeKeypress &&
			    (Input.IsKeyDown(Keys.Escape)))
			{
				base.Exit();
				return;
			}

			Manager.Update((float)gameTime.ElapsedGameTime.TotalSeconds);

		}

		protected override void Draw(GameTime gameTime)
		{
			if (PauseOnFocusLost && !IsActive)
				return;

			GraphicsDevice.SetRenderTarget(_sceneRenderTarget);
			GraphicsDevice.Clear(ClearColor);

			var currentRenderTarget = _sceneRenderTarget;
			Manager.HandleFinalRender(null, LetterboxColor, currentRenderTarget, _finalRenderDestinationRect, Core.DefaultSamplerState);
		}

		protected override void OnExiting(object sender, EventArgs args)
		{
			base.OnExiting(sender, args);
		}

		#endregion

		public void SetDesignResolution(int width, int height)
		{
			UpdateResolutionScaler();
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
			_sceneRenderTarget = new RenderTarget2D(Core.GraphicsDevice, renderTargetWidth, renderTargetHeight, false, graphicsManager.PreferredBackBufferFormat, graphicsManager.PreferredDepthStencilFormat,
				0, RenderTargetUsage.PreserveContents);

		}
	}
}