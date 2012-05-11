﻿/************************************************************************************
 * Entity.cs        Base class from which all moving entities are derived.
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
    class Entity : Item
    {

        #region Data Members
        protected Boolean moveable = true;      // Whether the entity moves                 !!! TODO: Might want to move up to Item
        protected string type = "Human";        // Type of entity                           !!! TODO: Might be unnecessary
        #endregion
        
        #region Initialization
        /****************************************************************************
         * Constructor  Creates a new object
         * Arguments    ---
         * Returns      ---
         ****************************************************************************/
        public Entity()
        {
            layer = 8;
            interact = "All";
            visible = "In Sight";
            collides = collision.NONENTITY;
        }
        #endregion
    }
}
