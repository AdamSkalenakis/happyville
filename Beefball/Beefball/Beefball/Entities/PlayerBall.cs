using System;
using System.Collections.Generic;
using System.Text;
using FlatRedBall;
using FlatRedBall.Input;
using FlatRedBall.AI.Pathfinding;
using FlatRedBall.Graphics.Animation;
using FlatRedBall.Graphics.Particle;

using FlatRedBall.Math.Geometry;
using FlatRedBall.Math.Splines;
using BitmapFont = FlatRedBall.Graphics.BitmapFont;
using Cursor = FlatRedBall.Gui.Cursor;
using GuiManager = FlatRedBall.Gui.GuiManager;

#if FRB_XNA || SILVERLIGHT
using Keys = Microsoft.Xna.Framework.Input.Keys;
using Vector3 = Microsoft.Xna.Framework.Vector3;
using Texture2D = Microsoft.Xna.Framework.Graphics.Texture2D;


#endif

namespace Beefball.Entities
{
    public partial class PlayerBall
    {
        private void CustomInitialize()
        {


        }

        private void CustomActivity()
        {
            float movementSpeed = 30;
            InputManager.Xbox360GamePads[0].ControlPositionedObject(this, movementSpeed);
            float desiredRotation = 361;
            float rotateSpeed = 0.05F;
            if (Math.Abs(this.XVelocity) > 0 || Math.Abs(this.YVelocity) > 0)
            {
                desiredRotation = (float)Math.Atan2(
                this.YVelocity, this.XVelocity);

            }
            if (GuiManager.Cursor.PrimaryDown)
            {

                float worldX = GuiManager.Cursor.WorldXAt(this.Z);
                float worldY = GuiManager.Cursor.WorldYAt(this.Z);
                desiredRotation = (float)Math.Atan2(
                    worldY - this.Y, worldX - this.X);
            }
            if (desiredRotation != 361)
            {
                float currentAngle = this.RotationZ;
                float angleToRotate = FlatRedBall.Math.MathFunctions.AngleToAngle(currentAngle, desiredRotation);


                float actualRotation = angleToRotate;
                if (angleToRotate > rotateSpeed)
                {
                    actualRotation = rotateSpeed;
                }
                else if (angleToRotate < (-1 * rotateSpeed))
                {
                    actualRotation = -1 * rotateSpeed;
                }

                this.RotationZ = this.RotationZ + actualRotation;
            }
            SpriteManager.Camera.X = this.X;
            SpriteManager.Camera.Y = this.Y;
        }

        private void CustomDestroy()
        {


        }

        private static void CustomLoadStaticContent(string contentManagerName)
        {


        }
    }
}