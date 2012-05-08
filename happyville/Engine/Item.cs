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
        Texture2D graphic = null;                   // Graphic for this Item
        Vector2 graphic_position = Vector2.Zero;    // The graphic's location on 
                                                    // screen
        float facing = 0;                           // Angle of facing (radians)
        collision collision = collision.NONE;       // What the object collides with
        string interact = "None";                   // What can interact with the object        !!! TODO: Decide on data type for this
        int level = 1;                              // Display level                            !!! TODO: Might need to rethink how this is specified
        string visible = "Never";                   // When this object is visible              !!! TODO: Decide on data type for this
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

    }
}
