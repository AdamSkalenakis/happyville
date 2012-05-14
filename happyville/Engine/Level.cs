/************************************************************************************
 * Level.cs         Holds level-wide information, assets and methdos
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
using System.Text;
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
    class Level
    {

        #region Data Members
        GraphicsDevice GraphicsDevice;              // The game's graphics device
        SpriteBatch spriteBatch;                    // Used to draw to the screen
        Player user = new Player();                 // The player controlled by this user
        Vector2 start_position = Vector2.Zero;      // Startin position for the user
        List<Wall> walls = new List<Wall>();        // Collection of walls
        List<Player> players = new List<Player>();  // Collection of other players
        #endregion
        
        #region Initialization
        /****************************************************************************
         * Constructor  Creates a new object
         * Arguments    ---
         * Returns      ---
         ****************************************************************************/
        public Level()
        {
            // Set player's starting position
            user.Position = start_position;

            // Add Listener for mouse right click and hold
            MouseHandler.AddListener("RIGHTBUTTONUP", new MouseCallback(OnRightClick));
            MouseHandler.AddListener("RIGHTBUTTONHELD", new MouseCallback(OnRightClick));

            walls.Add(new Wall());
            players.Add(new Player());
        }

        /****************************************************************************
         * LoadContent()    LoadContent will be called once per game and is the place 
         *                  to load all of your content.
         * Arguments        ---
         * Returns          ---
         ****************************************************************************/
        public void LoadContent(GraphicsDevice GraphicsDevice, ContentManager Content)
        {
            this.GraphicsDevice = GraphicsDevice;

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // Load content for everything in the level
            user.LoadContent(GraphicsDevice, Content, spriteBatch);
            foreach (Wall wall in walls)
                wall.LoadContent(GraphicsDevice, Content, spriteBatch);
            foreach (Player player in players)
                player.LoadContent(GraphicsDevice, Content, spriteBatch);
        }
        #endregion

        #region Update
        /****************************************************************************
         * Update()     Allows the game to run logic such as updating the world,
         *              checking for collisions, gathering input, and playing audio.
         * Arguments    GameTime gameTime - Provides a snapshot of timing values
         * Returns      ---
         ****************************************************************************/
        public void Update(GameTime gameTime)
        {
            // Check collision
            foreach (Wall wall in walls)
            {
                user.IsColliding(wall);
            } 
            foreach (Player player in players)
            {
                user.IsColliding(player);
            }

            // Update everything in the level (server side / other clients)
            foreach (Wall wall in walls)
                wall.Update(gameTime);
            foreach (Player player in players)
                player.Update(gameTime);

            // Our client
            user.Update(gameTime);
        }
        #endregion

        #region Draw
        /****************************************************************************
         * Draw()       This is called when the game should draw itself.
         * Arguments    GameTime gameTime - Provides a snapshot of timing values
         * Returns      ---
         ****************************************************************************/
        public void Draw(GameTime gameTime)
        {
            // Draw everything in the level
            foreach (Wall wall in walls)
                wall.Draw(gameTime);
            foreach (Player player in players)
                player.Draw(gameTime);
            user.Draw(gameTime);

        }
        #endregion

        /****************************************************************************
         * OnRightClick()   This is called when the game should draw itself.
         * Arguments        MouseState current_state - Current state of the mouse
         * Returns          ---
         ****************************************************************************/
        public void OnRightClick(MouseState current_state)
        {
            if (!(current_state.X < 0
                || current_state.X > GraphicsDevice.Viewport.Width
                || current_state.Y < 0
                || current_state.Y > GraphicsDevice.Viewport.Height))
            {
                Vector2 destination;
                destination.X = current_state.X;
                destination.Y = current_state.Y;
                user.MoveTo(destination);
            }
        }

    }
}
