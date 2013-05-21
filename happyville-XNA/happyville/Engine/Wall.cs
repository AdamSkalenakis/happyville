/************************************************************************************
 * Wall.cs          A rectangle which blocks passage through it.
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
    class Wall : Item
    {

        #region Data Members              
        #endregion
        
        #region Initialization
        /****************************************************************************
         * Constructor  Creates a new object
         * Arguments    ---
         * Returns      ---
         ****************************************************************************/
        public Wall()
        {
            layer = 2;
            visible = "Always";
            collides = true;
            width = 20;
            height = 5;
            facing = 0.0f;
            position = new Vector2(100, 100);
        }

        /****************************************************************************
         * LoadContent()    LoadContent will be called once per game and is the place 
         *                  to load all of your content.
         * Arguments        ---
         * Returns          ---
         ****************************************************************************/
        public override void LoadContent(GraphicsDevice GraphicsDevice, ContentManager Content, SpriteBatch SpriteBatch)
        {
            // Load texture for this Player
            graphic = new Texture2D(GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
            graphic.SetData(new[] { Color.Black });

            // Call parent's LoadContent
            base.LoadContent(GraphicsDevice, Content, SpriteBatch);
        }
        #endregion

        #region Draw
        /****************************************************************************
         * Draw()       This is called when the Item should draw itself.
         * Arguments    ---
         * Returns      ---
         ****************************************************************************/
        public override void Draw(GameTime gameTime)
        {
            if (graphic == null) return;
            // Draw the sprite.
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
            spriteBatch.Draw(graphic, graphic_position, null, Color.Black,
              (float)facing, Vector2.Zero, new Vector2((float)width, (float)height),
              SpriteEffects.None, 0);
            spriteBatch.End();
        }
        #endregion

    }
}
