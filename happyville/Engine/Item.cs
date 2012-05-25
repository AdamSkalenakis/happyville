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
        protected double width = 5;                          // Width of the item (bounding box)
        protected double height = 5;                         // Height of the item (bounding box)
        protected double facing = 0;                         // Angle of facing (radians)
        protected bool collides = false;                    // What the object collides with
        protected bool is_colliding = false;                // Whether the item is currently colliding
        protected string interact = "None";                 // What can interact with the object        !!! TODO: Decide on data type for this
        protected int layer = 1;                            // Display layer                            !!! TODO: Might need to rethink how this is specified
        protected string visible = "Never";                 // When this object is visible              !!! TODO: Decide on data type for this
        protected Vector2 collision = Vector2.Zero;         // Collision vector
        protected SpriteBatch spriteBatch;                  // Used to draw to the screen

        // Properties (Derived)
        protected Vector2 graphic_position                  // The graphic's location on screen
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
        public Vector2 Position                             // Edit interface of position
        {
            set
            {
                position = value;
            }
            get
            {
                return position;
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

        /****************************************************************************
         * LoadContent()    LoadContent will be called once per game and is the place 
         *                  to load all of your content.
         * Arguments        ---
         * Returns          ---
         ****************************************************************************/
        public virtual void LoadContent(GraphicsDevice GraphicsDevice, ContentManager Content, SpriteBatch SpriteBatch)
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = SpriteBatch;
        }
        #endregion

        #region Draw
        /****************************************************************************
         * Draw()       This is called when the Item should draw itself.
         * Arguments    ---
         * Returns      ---
         ****************************************************************************/
        public virtual void Draw(GameTime gameTime)
        {
            if (graphic == null) return;
            // Draw the sprite.
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
            spriteBatch.Draw(graphic, graphic_position, null, Color.White,
              (float)facing, Vector2.Zero, Vector2.One,
              SpriteEffects.None, 0);
            spriteBatch.End(); 
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

        #region Collision
        /****************************************************************************
         * IsColliding()    Checks if this item is colliding with another.
         * Arguments        GameTime gameTime - Provides a snapshot of timing values
         * Returns          ---
         ****************************************************************************/
        public virtual bool IsColliding(Item other)
        {
            if (this.collides && other.collides)
            {
                if (Math.Abs(this.position.X - other.position.X) > this.width / 2 + other.width / 2)
                {
                    is_colliding = false;
                    return false; // Farther apart than widths
                }
                if (Math.Abs(this.position.Y - other.position.Y) > this.height / 2 + other.height / 2)
                {
                    is_colliding = false;
                    return false; // Farther apart than heights
                }

                is_colliding = true;
                collision.X = (float)Math.Cos(facing);
                collision.Y = (float)Math.Sin(facing);
                return true;
            }
            is_colliding = false;
            return false;
        }
        #endregion
    }
}
