/************************************************************************************
 * MouseHandler.cs  Handles mouse clicks for the game
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
    public delegate void MouseCallback(MouseState current_state);

    public static class MouseHandler
    {
        #region Data Members

        static MouseState current_state, previous_state;       // Mouse states for mouse control

        // Callback functions
        static Dictionary<string, List<MouseCallback>> Callbacks = new Dictionary<string, List<MouseCallback>>();
        #endregion

        /****************************************************************************
         * Constructor  Sets up the empty handler
         * Arguments    ---
         * Returns      ---
         ****************************************************************************/
        static MouseHandler()
        {
            Callbacks.Add("RIGHTBUTTONDOWN", new List<MouseCallback>());
            Callbacks.Add("RIGHTBUTTONUP", new List<MouseCallback>());
            Callbacks.Add("RIGHTBUTTONHELD", new List<MouseCallback>());
            Callbacks.Add("LEFTBUTTONDOWN", new List<MouseCallback>());
            Callbacks.Add("LEFTBUTTONUP", new List<MouseCallback>());
            Callbacks.Add("LEFTBUTTONHELD", new List<MouseCallback>());
        }

        /****************************************************************************
         * UpdateState  Updates the mouse state, checks for clicks
         * Arguments    MouseState new_state - new state of the mouse
         * Returns      ---
         ****************************************************************************/
        public static void UpdateState()
        {
            // Set current and previous states
            previous_state = current_state;
            current_state = Mouse.GetState();
            
            // Mouse-clicks
            if (current_state.LeftButton == ButtonState.Pressed && previous_state.LeftButton == ButtonState.Released)
                Call("LEFTBUTTONDOWN");
            if (current_state.LeftButton == ButtonState.Released && previous_state.LeftButton == ButtonState.Pressed)
                Call("LEFTBUTTONUP");
            if (current_state.LeftButton == ButtonState.Pressed && previous_state.LeftButton == ButtonState.Pressed)
                Call("LEFTBUTTONHELD");
            if (current_state.RightButton == ButtonState.Pressed && previous_state.RightButton == ButtonState.Released)
                Call("RIGHTBUTTONDOWN");
            if (current_state.RightButton == ButtonState.Released && previous_state.RightButton == ButtonState.Pressed)
                Call("RIGHTBUTTONUP");
            if (current_state.RightButton == ButtonState.Pressed && previous_state.RightButton == ButtonState.Pressed)
                Call("RIGHTBUTTONHELD");

        }

        /****************************************************************************
         * Call()           Calls associated functions
         * Arguments        string type - type of callback function to call
         * Returns          ---
         ****************************************************************************/
        private static void Call(string type)
        {
            if (Callbacks.ContainsKey(type))
            {
                foreach (MouseCallback Callback in Callbacks[type])
                {
                    Callback(current_state);
                }
            }
        }


        /****************************************************************************
         * AddListener()    Sets listener to callback the passed in function
         * Arguments        string type - type of callback function to add
         *                  MouseCallback ToAdd - callback function to be added
         * Returns          int - 1 if successful, else 0
         ****************************************************************************/
        public static int AddListener(string type, MouseCallback ToAdd)
        {
            if (Callbacks.ContainsKey(type))
            {
                Callbacks[type].Add(ToAdd);
                return 1;
            }
            return 0;
        }
    }
}
