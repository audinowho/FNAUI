using Nez;
using Nez.ImGuiTools;
using ImGuiNET;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace FNAImgui
{
    class Game1 : Core
    {
        public Game1() : base()
        {
			// uncomment this line for scaled pixel art games
			// System.Environment.SetEnvironmentVariable("FNA_OPENGL_BACKBUFFER_SCALE_NEAREST", "1");
        }

        override protected void Initialize()
        {
            base.Initialize();

            // optionally render Nez in an ImGui window
            var imgui = new ImGuiManager();
            Manager = imgui;
            imgui.OnEnabled();

        }

        int _buttonClickCounter;

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            GraphicsDevice.SetRenderTarget(_sceneRenderTarget);

            // do your actual drawing here
            ImGui.Begin("Your ImGui Window", ImGuiWindowFlags.AlwaysAutoResize);
            ImGui.Text("This is being drawn in DemoComponent");
            if (ImGui.Button($"Clicked me {_buttonClickCounter} times"))
                _buttonClickCounter++;
            ImGui.End();
        }
    }
}

