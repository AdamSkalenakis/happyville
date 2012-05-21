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

        /****************************************************************************
         * PointInRectangle()   Checks if a point is inside the rectangle.
         * Arguments            Vector2 point - the point to check
         *                      Rectangle rect - the rectangle to check
         * Returns              bool - true if point is in rect, else false
         ****************************************************************************/
        public virtual bool PointInRectangle(Vector2 point, Rectangle rect)
        {
            // TODO: fix for angle
            if ((point.X > rect.position.X - 0.5 * rect.width) &&
                (point.X < rect.position.X + 0.5 * rect.width) &&
                (point.Y < rect.position.Y + 0.5 * rect.height) &&
                (point.Y > rect.position.Y - 0.5 * rect.height))
                return true;

            // Default false
            return false;
        }

        /****************************************************************************
         * IntersectCircle()    Checks if the line intersects the circle.
         * Arguments            Circle circ - the circle to check
         *                      Vector2 A - the beginning of the line
         *                      Vector2 B - the end of the line
         * Returns              bool - true if point is in rect, else false
         ****************************************************************************/
        public virtual bool IntersectCircle(Circle circ, Vector2 A, Vector2 B)
        {
            //TODO

            // Default false
            return false;
        }

        #endregion

    }
}
