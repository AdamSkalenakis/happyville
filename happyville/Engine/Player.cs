/************************************************************************************
 * Player.cs        An Entity controlled by a user.
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
    class Player : Entity
    {

        #region Data Members
        protected string status = null;     // Status effect on this player                         !!! TODO: Change to pointers to effect objects, possibly an array or linked list
        protected Item target = null;       // Pointer to current target
        protected string mode = "Normal";   // Current character mode (Normal/Sprint/Focus)         !!! TODO: Change to enum
        #endregion
        
        #region Initialization
        /****************************************************************************
         * Constructor  Creates a new object
         * Arguments    ---
         * Returns      ---
         ****************************************************************************/
        public Player()
        {
            layer = 9;
        }

        /****************************************************************************
         * LoadContent()    LoadContent will be called once per game and is the place 
         *                  to load all of your content.
         * Arguments        ---
         * Returns          ---
         ****************************************************************************/
        public override void LoadContent(GraphicsDevice GraphicsDevice, ContentManager Content)
        {
            // Load texture for this Player
            graphic = Content.Load<Texture2D>("images/player");

            // Call parent's LoadContent
            base.LoadContent(GraphicsDevice, Content);
        }
        #endregion
    }
}
