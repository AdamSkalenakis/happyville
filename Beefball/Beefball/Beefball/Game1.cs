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
using FlatRedBall;
using FlatRedBall.Graphics;
using FlatRedBall.Utilities;

using Beefball.Screens;

namespace Beefball
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = 600;
            Content.RootDirectory = "Content";
			
			BackStack<string> bs = new BackStack<string>();
			bs.Current = string.Empty;
        }

        protected override void Initialize()
        {
            Renderer.UseRenderTargets = false;
            FlatRedBallServices.InitializeFlatRedBall(this, graphics);
			GlobalContent.Initialize();

            if (FlatRedBall.Input.InputManager.Xbox360GamePads[0].IsConnected == false)
            {
                FlatRedBall.Input.InputManager.Xbox360GamePads[0].CreateDefaultButtonMap();
            }

			Screens.ScreenManager.Start(typeof(Beefball.Screens.GameScreen).FullName);

            base.Initialize();
        }


        protected override void Update(GameTime gameTime)
        {
            FlatRedBallServices.Update(gameTime);

            ScreenManager.Activity();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            FlatRedBallServices.Draw();

            base.Draw(gameTime);
        }
    }
}
