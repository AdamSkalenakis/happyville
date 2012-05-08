/************************************************************************************
 * Game.cs          Contains main game loops and logic
 * Project		    happyville - a social game involving people and monsters and 
 *                  their interactions.
 * Author		    Sarah Herzog 
 * Version		    0.1
 * All content in this file is copyright Sarah Herzog and Adam Skalenakis, 2012, 
 * all rights reserved.
 ************************************************************************************/
#region Libraries
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
#endregion

namespace happyville
{
    public class Game : Microsoft.Xna.Framework.Game
    {
        #region Data Members
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        #endregion

        #region Initialization

        /****************************************************************************
         * Constructor  Creates a new game
         * Arguments    ---
         * Returns      ---
         ****************************************************************************/
        public Game()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            // Change of resolution
            graphics.PreferredBackBufferWidth = 1152;
            graphics.PreferredBackBufferHeight = 864;
        }

        /****************************************************************************
         * Initialize() Allows the game to perform any initialization it needs to 
         *              before starting to run. This is where it can query for any 
         *              required services and load any non-graphic related content.  
         *              Calling base.Initialize will enumerate through any components
         *              and initialize them as well.
         * Arguments    ---
         * Returns      ---
         ****************************************************************************/
        protected override void Initialize()
        {
            // Turn mouse visibility on
            this.IsMouseVisible = true;

            base.Initialize();
        }

        /****************************************************************************
         * LoadContent()    LoadContent will be called once per game and is the place 
         *                  to load all of your content.
         * Arguments        ---
         * Returns          ---
         ****************************************************************************/
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        /****************************************************************************
         * UnloadContent()  UnloadContent will be called once per game and is the 
         *                  place to unload all content.
         * Arguments        ---
         * Returns          ---
         ****************************************************************************/
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }
        #endregion

        #region Update
        /****************************************************************************
         * Update()     Allows the game to run logic such as updating the world,
         *              checking for collisions, gathering input, and playing audio.
         * Arguments    GameTime gameTime - Provides a snapshot of timing values
         * Returns      ---
         ****************************************************************************/
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }
        #endregion

        #region Draw
        /****************************************************************************
         * Draw()       This is called when the game should draw itself.
         * Arguments    GameTime gameTime - Provides a snapshot of timing values
         * Returns      ---
         ****************************************************************************/
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
        #endregion
    }
}
