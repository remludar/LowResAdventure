using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace LowResAdventure
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class GameManager : Game
    {
        public static Texture2D[] textures;
        public static float scale = 0.25f;
        public static int tileSize = 64;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        
        private Camera2D _camera;


        public GameManager()
        {
            graphics = new GraphicsDeviceManager(this);
            TargetElapsedTime = TimeSpan.FromSeconds(1.0f / 144.0f);
            graphics.SynchronizeWithVerticalRetrace = true;
            Window.IsBorderless = true;
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
            textures = new Texture2D[5];
            _camera = new Camera2D();
            
            //Everything after this is done AFTER LoadContent
            base.Initialize();
            World.Generate();
            Player.texture = GameManager.textures[0];

        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            textures[0] = Content.Load<Texture2D>("Textures/Player");
            textures[1] = Content.Load<Texture2D>("Textures/Grass_01");
            textures[2] = Content.Load<Texture2D>("Textures/Grass_02");
            textures[3] = Content.Load<Texture2D>("Textures/Grass_03");
            textures[4] = Content.Load<Texture2D>("Textures/Dirt_01");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
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

            // TODO: Add your update logic here
            var deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            InputManager.ProcessInput();
            Player.Update(deltaTime);


            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, transformMatrix: _camera.GetViewMatrix());

                World.Draw(spriteBatch);
                Player.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
