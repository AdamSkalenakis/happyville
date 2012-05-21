/************************************************************************************
 * Circle.cs        Circle used for bounding boxes
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
    class Circle : Shape
    {

        #region Data Members
        public float radius = 5;                         // Radius of the item (bounding box)
        #endregion

        #region Collision
        /****************************************************************************
         * IsColliding()    Checks if this Shape is colliding with another.
         * Arguments        Shape other - the other shape to check for collision
         * Returns          ---
         ****************************************************************************/
        public override bool IsColliding(Circle other)
        {
            if (Vector2.Distance(position, other.position) > radius + other.radius)
                return true;

            // Default false
            return false;
        }
        /****************************************************************************
         * IsColliding()    Checks if this Shape is colliding with another.
         * Arguments        Shape other - the other shape to check for collision
         * Returns          ---
         ****************************************************************************/
        public override bool IsColliding(Rectangle other)
        {
            // If position is inside other, return true
            if (PointInRectangle(position, other)
                return true;


            

            // Default false
            return false;
        }
        #endregion

    }
}
