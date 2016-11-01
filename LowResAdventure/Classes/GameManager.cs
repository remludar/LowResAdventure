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

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        
        private Camera2D _camera;

        //---------------------------
        #region C O N S T R U C T O R
        //---------------------------
        public GameManager()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            TargetElapsedTime = TimeSpan.FromSeconds(1.0f / 144.0f);
            graphics.SynchronizeWithVerticalRetrace = true;
            Window.IsBorderless = true;
        }
        #endregion

        //-------------
        #region I N I T
        //-------------
        protected override void Initialize()
        {
            _camera = new Camera2D();
            
            //Everything after this is done AFTER LoadContent
            base.Initialize();
            TextureManager.Init();
            Player.Init();
            World.Generate();
            
        }
        #endregion

        //---------------------
        #region L O A D
        //---------------------
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            TextureManager.tileSheet = Content.Load<Texture2D>("Textures/Sheet");

        }
        #endregion

        //---------------------
        #region U N L O A D
        //---------------------
        protected override void UnloadContent()
        {
            
        }
        #endregion

        //---------------------
        #region U P D A T E
        //---------------------
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
        #endregion

        //---------------------
        #region D R A W
        //---------------------
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
        #endregion

    }
}
