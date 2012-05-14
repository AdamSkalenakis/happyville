/************************************************************************************
 * Shape.cs         Shape used for bounding boxes
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
    abstract class Shape
    {
        #region Data Members
        public Vector2 position = Vector2.Zero;          // The position of the item in the game level
        public float rotation = 0;                       // Angle of rotation (radians)
        #endregion

        #region Collision
        /****************************************************************************
         * IsColliding()    Checks if this Shape is colliding with another.
         * Arguments        Circle other - the other shape to check for collision
         * Returns          ---
         ****************************************************************************/
        public virtual bool IsColliding(Circle other)
        {
            // This should never be invoked.
            return false;
        }
        /****************************************************************************
         * IsColliding()    Checks if this Shape is colliding with another.
         * Arguments        Rectangle other - the other shape to check for collision
         * Returns          ---
         ****************************************************************************/
        public virtual bool IsColliding(Rectangle other)
        {
            // This should never be invoked.
            return false;
        }
        #endregion
    }
}
