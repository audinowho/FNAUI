using ImGuiNET;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Nez.ImGuiTools
{
	public class ImGuiManager : GlobalManager
	{
		public bool ShowDemoWindow = false;
		public bool ShowStyleEditor = false;
		public bool ShowSceneGraphWindow = true;
		public bool ShowCoreWindow = true;
		public bool ShowSeperateGameWindow = true;
		public bool ShowMenuBar = true;

		public bool FocusGameWindowOnMiddleClick = false;
		public bool FocusGameWindowOnRightClick = false;
		public bool DisableKeyboardInputWhenGameWindowUnfocused = true;
		public bool DisableMouseWheelWhenGameWindowUnfocused = true;

		System.Reflection.MethodInfo[] _themes;

		CoreWindow _coreWindow = new CoreWindow();

		ImGuiRenderer _renderer;

		public ImGuiManager()
		{
			_renderer = new ImGuiRenderer(Core.Instance);

			_renderer.RebuildFontAtlas();
			NezImGuiThemes.DarkTheme1();

			// tone down indent
			ImGui.GetStyle().IndentSpacing = 12;
			ImGui.GetIO().ConfigWindowsMoveFromTitleBarOnly = true;

			// find all themes
			_themes = typeof(NezImGuiThemes).GetMethods(System.Reflection.BindingFlags.Static |
			                                            System.Reflection.BindingFlags.Public);
		}


		public void OnEnabled()
		{
			// why call beforeLayout here? If added from the DebugConsole we missed the GlobalManger.update call and ImGui needs NextFrame
			// called or it fails. Calling NextFrame twice in a frame causes no harm, just missed input.
			_renderer.BeforeLayout(0);
		}

		public override void Update(float deltaTime)
		{
			// we have to do our layout in update so that if the game window is not focused or being displayed we can wipe
			// the Input, essentially letting ImGui consume it
			_renderer.BeforeLayout(deltaTime);
			LayoutGui();
		}


		/// <summary>
		/// this is where we issue any and all ImGui commands to be drawn
		/// </summary>
		void LayoutGui()
		{
			if (ShowMenuBar)
				DrawMainMenuBar();

			_coreWindow.Show(ref ShowCoreWindow);

			if (ShowDemoWindow)
				ImGui.ShowDemoWindow(ref ShowDemoWindow);

			if (ShowStyleEditor)
			{
				ImGui.Begin("Style Editor", ref ShowStyleEditor);
				ImGui.ShowStyleEditor();
				ImGui.End();
			}
		}

		/// <summary>
		/// draws the main menu bar
		/// </summary>
		void DrawMainMenuBar()
		{
			if (ImGui.BeginMainMenuBar())
			{
				if (ImGui.BeginMenu("File"))
				{
					ImGui.MenuItem("Quit ImGui");
					ImGui.EndMenu();
				}


				if (_themes.Length > 0 && ImGui.BeginMenu("Themes"))
				{
					foreach (var theme in _themes)
					{
						if (ImGui.MenuItem(theme.Name))
							theme.Invoke(null, new object[] { });
					}

					ImGui.EndMenu();
				}

				if (ImGui.BeginMenu("Game View"))
				{
					if (ImGui.BeginMenu("Resize"))
					{
						ImGui.MenuItem("0.25x");
						ImGui.MenuItem("0.5x");
						ImGui.MenuItem("0.75x");
						ImGui.MenuItem("1x");
						ImGui.MenuItem("1.5x");
						ImGui.MenuItem("2x");
						ImGui.MenuItem("3x");
						ImGui.EndMenu();
					}

					if (ImGui.BeginMenu("Reposition"))
					{
						ImGui.MenuItem("Position");
						ImGui.EndMenu();
					}


					ImGui.EndMenu();
				}

				if (ImGui.BeginMenu("Window"))
				{
					ImGui.MenuItem("ImGui Demo Window", null, ref ShowDemoWindow);
					ImGui.MenuItem("Style Editor", null, ref ShowStyleEditor);
					if (ImGui.MenuItem("Open imgui_demo.cpp on GitHub"))
					{
						var url = "https://github.com/ocornut/imgui/blob/master/imgui_demo.cpp";
						var startInfo = new System.Diagnostics.ProcessStartInfo(url) { UseShellExecute = true };
						System.Diagnostics.Process.Start(startInfo);
					}

					ImGui.Separator();
					ImGui.MenuItem("Core Window", null, ref ShowCoreWindow);
					ImGui.MenuItem("Scene Graph Window", null, ref ShowSceneGraphWindow);
					ImGui.MenuItem("Separate Game Window", null, ref ShowSeperateGameWindow);
					ImGui.EndMenu();
				}

				ImGui.EndMainMenuBar();
			}
		}


		public override void HandleFinalRender(RenderTarget2D finalRenderTarget, Color letterboxColor,
													RenderTarget2D source, Rectangle finalRenderDestinationRect,
													SamplerState samplerState)
		{
			Core.GraphicsDevice.SetRenderTarget(finalRenderTarget);
			Core.GraphicsDevice.Clear(letterboxColor);

			Core.Instance.SpriteBatch.Begin(SpriteSortMode.Deferred, BlendState.Opaque, samplerState, null, null);
			Core.Instance.SpriteBatch.Draw(source, finalRenderDestinationRect, Color.White);
			Core.Instance.SpriteBatch.End();

			_renderer.AfterLayout();
		}


	}
}
