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
        protected Vector2 direction = Vector2.Zero;     // Unit vector holding direction to travel
        protected Vector2 velocity = Vector2.Zero;      // Direction vector scaled with speed
        protected bool has_destination = false;         // Whether the character has a destination
        protected int speed = 5;                        // Relative speed of this entity
        protected bool has_face_change = false;         // Whether the character has a changing face
        protected double face_target = 0;               // Target facing value;
        protected int turn_speed = 1;                   // Relative turning speed of this entity
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
            collides = true;
        }
        #endregion

        #region Movement
        /****************************************************************************
         * MoveTo()         Sets an entity's destination.
         * Arguments        Vector2 location
         * Returns          ---
         ****************************************************************************/
        public void MoveTo(Vector2 location)
        {
            has_destination = true;
            destination = location;

            // Create a direction vector
            Vector2 distance = Vector2.Add(destination, Vector2.Negate(position));
            direction = Vector2.Normalize(distance); // Unit vector
            velocity = Vector2.Multiply(direction, speed * Constants.SPEED);
        }

        /****************************************************************************
         * Face()           Sets an entity's facing.
         * Arguments        Vector2 location
         * Returns          ---
         ****************************************************************************/
        public void Face(Vector2 location)
        {
            has_face_change = true;
            face_target = Math.Atan2(position.Y - location.Y, position.Y - location.Y);
        }

        /****************************************************************************
         * Stop()           Stops the entities movement.
         * Arguments        ---
         * Returns          ---
         ****************************************************************************/
        public void Stop()
        {
            has_destination = false;
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
                float elapsedTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
                float speed_d = speed * Constants.SPEED * elapsedTime;

                Vector2 distance = Vector2.Add(destination, Vector2.Negate(position));
                direction = Vector2.Normalize(distance); // Unit vector
                velocity = Vector2.Multiply(direction, speed_d);
                Vector2 vel = velocity;

                // Are we colliding? If so, change velocity vector
                if (is_colliding)
                {
                    vel = Vector2.Multiply(collision, (Vector2.Dot(vel, collision) / Vector2.Dot(collision, collision)));
                }

                // If we have overshot, or just arrived, set our position to 
                // destination and remove the destination.
                // If we have arrived at our destination, remove it.
                if (speed_d >= target_d)
                {
                    position = destination;
                    has_destination = false;
                    has_face_change = false;
                    destination = Vector2.Zero;
                    face_target = 0;
                }
                // Otherwise, move us closer.
                else
                {
                    position = Vector2.Add(position, vel);
                    Face(destination);
                }

                // Update facing
                double target_f = face_target - facing;
                double speed_f = turn_speed * Constants.ANG_SPEED * elapsedTime;

                // If we have overshot, or just arrived, set our position to 
                // destination and remove the destination.
                // If we have arrived at our destination, remove it.
                if (speed_f >= Math.Abs(target_f))
                {
                    facing = face_target;
                    has_face_change = false;
                    face_target = 0;
                }
                // Otherwise, move us closer.
                else
                {

                    facing += speed_f;
                }

            }

            base.Update(gameTime);
        }
        #endregion


    }
}
