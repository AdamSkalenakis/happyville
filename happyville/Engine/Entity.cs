/************************************************************************************
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
        protected Boolean moveable = true;              // Whether the entity moves                 !!! TODO: Might want to move up to Item
        protected string type = "Human";                // Type of entity                           !!! TODO: Might be unnecessary
        protected Vector2 destination = Vector2.Zero;   // Current destination
        protected bool has_destination = false;         // Whether the character has a destination
        protected int speed = 5;                        // Relative speed of this entity
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

        #region Movement
        /****************************************************************************
         * MoveTo()         Sets an entities destination.
         * Arguments        Vector2 location
         * Returns          ---
         ****************************************************************************/
        public void MoveTo(Vector2 location)
        {
            has_destination = true;
            destination = location;
        }
        #endregion

        #region Update
        /****************************************************************************
         * Update()     Allows the game to run logic such as updating the world,
         *              checking for collisions, gathering input, and playing audio.
         * Arguments    GameTime gameTime - Provides a snapshot of timing values
         * Returns      ---
         ****************************************************************************/
        public override void Update(GameTime gameTime)
        {
            // Movement
            if (has_destination)
            {

                // Check for overshoot
                float target_d = Vector2.Distance(position, destination);
                float speed_d = speed * Constants.SPEED;                                            // TODO: multiply in time passed

                // If we have overshot, or just arrived, set our position to 
                // destination and remove the destination.
                // If we have arrived at our destination, remove it.
                if (speed_d >= target_d)
                {
                    position = destination;
                    has_destination = false;
                    destination = Vector2.Zero;
                }
                // Otherwise, move us closer.
                else
                {
                    // Create a direction vector
                    Vector2 distance = Vector2.Add(destination, Vector2.Negate(position));
                    Vector2 direction = Vector2.Normalize(distance); // Unit vector

                    // Scale it with speed
                    Vector2 velocity = Vector2.Multiply(direction, speed_d);

                    position = Vector2.Add(position, velocity);
                }
            }

            base.Update(gameTime);
        }
        #endregion
    }
}
