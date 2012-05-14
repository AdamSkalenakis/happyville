/************************************************************************************
 * Rectangle.cs     Rectangle used for bounding boxes
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
    class Rectangle : Shape
    {

        #region Data Members
        public float width = 5;                          // Width of the item (bounding box)
        public float height = 5;                         // Height of the item (bounding box)
        #endregion

        #region Collision
        /****************************************************************************
         * IsColliding()    Checks if this Shape is colliding with another.
         * Arguments        Shape other - the other shape to check for collision
         * Returns          ---
         ****************************************************************************/
        public override bool IsColliding(Rectangle other)
        {
            if ( (Math.Abs(position.X - other.position.X) > width + other.width) &&
                (Math.Abs(position.Y - other.position.Y) > height + other.height) )
                return true;

            // Default false
            return false;
        }
        #endregion

    }
}
