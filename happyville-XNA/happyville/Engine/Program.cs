/************************************************************************************
 * Program.cs       Creates and starts the game.
 * Project		    happyville - a social game involving people and monsters and 
 *                  their interactions.
 * Author		    Sarah Herzog 
 * Version		    0.1
 * All content in this file is copyright Sarah Herzog and Adam Skalenakis, 2012, 
 * all rights reserved.
 ************************************************************************************/
#region Libraries
using System;
#endregion

namespace happyville
{
#if WINDOWS || XBOX
    static class Program
    {

        /****************************************************************************
         * Main()       The main entry point for the application.
         * Arguments    string[] args - command line arguments to the program.
         * Returns      ---
         ****************************************************************************/
        static void Main(string[] args)
        {
            using (Game game = new Game())
            {
                game.Run();
            }
        }

    }
#endif
}

