#region Using Statements
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Threading;
using System.Collections.Generic;
#endregion

namespace ExampleFNA
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class GameBase : Game
    {

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public static List<(Vector2, byte)> pts = new List<(Vector2, byte)>();
        public static int lum = 255;

        MouseState prevState;
        Texture2D pixel;

        public GameBase()
            : base()
        {
            //IsFixedTimeStep = false;
            IsFixedTimeStep = true;
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredDepthStencilFormat = DepthFormat.Depth24Stencil8;
            IsMouseVisible = true;
            Window.Title = "Example";
            Content.RootDirectory = "Content";
            prevState = new MouseState();
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            pixel = getBasicTexture();

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
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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
            //update here
            base.Update(gameTime);

            MouseState state = Mouse.GetState();
            Vector2 mouseVec = new Vector2(state.X, state.Y);

            if (state.LeftButton == ButtonState.Pressed && prevState.LeftButton == ButtonState.Released)
                pts.Add((mouseVec, (byte)lum));

            prevState = state;
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            float scale = 1f;
            Matrix matrix = Matrix.CreateScale(new Vector3(scale, scale, 1));
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, null, null, null, matrix);

            //draw here
            foreach ((Vector2, byte) vec in pts)
                spriteBatch.Draw(pixel, new Rectangle((int)vec.Item1.X, (int)vec.Item1.Y, 8, 8), null, new Color(vec.Item2, vec.Item2, vec.Item2, 255));

            spriteBatch.End();
            base.Draw(gameTime);
        }

        private Texture2D getBasicTexture()
        {
            Texture2D defaultTex = new Texture2D(graphics.GraphicsDevice, 1, 1);
            Color[] color = new Color[1];
            color[0] = Color.White;
            defaultTex.SetData<Color>(0, new Rectangle(0, 0, 1, 1), color, 0, color.Length);
            return defaultTex;
        }
    }
}
