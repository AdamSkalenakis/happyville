/************************************************************************************
 * Item.cs          Base class from which all in-game objects are derived
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

    class Item
    {

        #region Data Members
        // Fields
        protected Texture2D graphic = null;                 // Graphic for this Item
        protected Vector2 position = Vector2.Zero;          // The position of the item in the game level
        protected float facing = 0;                         // Angle of facing (radians)
        protected collision collides = collision.NONE;     // What the object collides with
        protected string interact = "None";                 // What can interact with the object        !!! TODO: Decide on data type for this
        protected int layer = 1;                            // Display layer                            !!! TODO: Might need to rethink how this is specified
        protected string visible = "Never";                 // When this object is visible              !!! TODO: Decide on data type for this
        protected SpriteBatch spriteBatch;                  // Used to draw to the screen

        // Properties (Derived)
        protected Vector2 graphic_position // The graphic's location on screen
        {
            get
            {
                if (graphic == null) return position;
                else
                {
                    Vector2 temp = Vector2.Zero;
                    temp.Y = graphic.Height/2;
                    temp.X = graphic.Width/2;
                    return position - temp;
                }
            }
        }
        #endregion

        #region Initialization
        /****************************************************************************
         * Constructor  Creates a new object
         * Arguments    ---
         * Returns      ---
         ****************************************************************************/
        public Item()
        {
        }
        #endregion

        #region Draw
        /****************************************************************************
         * Draw()       This is called when the Item should draw itself.
         * Arguments    ---
         * Returns      ---
         ****************************************************************************/
        public virtual void Draw()
        {
            if (graphic == null) return;
            // Draw the sprite.
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
            spriteBatch.Draw(graphic, graphic_position, Color.White);
            spriteBatch.End(); 
        }

        /****************************************************************************
         * LoadContent()    LoadContent will be called once per game and is the place 
         *                  to load all of your content.
         * Arguments        ---
         * Returns          ---
         ****************************************************************************/
        public virtual void LoadContent(GraphicsDevice GraphicsDevice, ContentManager Content)
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }
        #endregion

        #region Update
        /****************************************************************************
         * Update()     Allows the game to run logic such as updating the world,
         *              checking for collisions, gathering input, and playing audio.
         * Arguments    GameTime gameTime - Provides a snapshot of timing values
         * Returns      ---
         ****************************************************************************/
        public virtual void Update(GameTime gameTime)
        {
        }
        #endregion
    }
}
