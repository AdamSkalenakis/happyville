using System;
using System.Collections.Generic;
using System.Text;
using FlatRedBall.Math.Geometry;
using FlatRedBall.AI.Pathfinding;
using FlatRedBall.Input;
using FlatRedBall.IO;
using FlatRedBall.Instructions;
using FlatRedBall.Math.Splines;
using FlatRedBall.Utilities;
using BitmapFont = FlatRedBall.Graphics.BitmapFont;

using Cursor = FlatRedBall.Gui.Cursor;
using GuiManager = FlatRedBall.Gui.GuiManager;

#if XNA4
using Color = Microsoft.Xna.Framework.Color;
#else
using Color = Microsoft.Xna.Framework.Graphics.Color;
#endif

#if FRB_XNA || SILVERLIGHT
using Keys = Microsoft.Xna.Framework.Input.Keys;
using Vector3 = Microsoft.Xna.Framework.Vector3;
using Texture2D = Microsoft.Xna.Framework.Graphics.Texture2D;
using Microsoft.Xna.Framework.Media;
#endif

// Generated Usings
using FlatRedBall.Broadcasting;
using happyvilleFRB.Entities;
using FlatRedBall;

namespace happyvilleFRB.Screens
{
	public partial class PlayArea : Screen
	{
		// Generated Fields
		#if DEBUG
		static bool HasBeenLoadedWithGlobalContentManager = false;
		#endif
		private Scene SceneFile;
		
		private happyvilleFRB.Entities.Character CharInstance;

		public PlayArea()
			: base("PlayArea")
		{
		}

        public override void Initialize(bool addToManagers)
        {
			// Generated Initialize
			LoadStaticContent(ContentManagerName);
			if (!FlatRedBallServices.IsLoaded<Scene>(@"content/screens/playarea/scenefile.scnx", ContentManagerName))
			{
			}
			SceneFile = FlatRedBallServices.Load<Scene>(@"content/screens/playarea/scenefile.scnx", ContentManagerName);
			CharInstance = new happyvilleFRB.Entities.Character(ContentManagerName, false);
			CharInstance.Name = "CharInstance";
			
			
			PostInitialize();
			base.Initialize(addToManagers);
			if (addToManagers)
			{
				AddToManagers();
			}

        }
        
// Generated AddToManagers
		public override void AddToManagers ()
		{
			base.AddToManagers();
			AddToManagersBottomUp();
			CustomInitialize();
		}


		public override void Activity(bool firstTimeCalled)
		{
			// Generated Activity
			if (!IsPaused)
			{
				
				CharInstance.Activity();
			}
			else
			{
			}
			base.Activity(firstTimeCalled);
			if (!IsActivityFinished)
			{
				CustomActivity(firstTimeCalled);
			}
			SceneFile.ManageAll();


				// After Custom Activity
				
            
		}

		public override void Destroy()
		{
			// Generated Destroy
			if (this.UnloadsContentManagerWhenDestroyed)
			{
				SceneFile.RemoveFromManagers(ContentManagerName != "Global");
			}
			else
			{
				SceneFile.RemoveFromManagers(false);
			}
			
			if (CharInstance != null)
			{
				CharInstance.Destroy();
				CharInstance.Detach();
			}

			base.Destroy();

			CustomDestroy();

		}

		// Generated Methods
		public virtual void PostInitialize ()
		{
			bool oldShapeManagerSuppressAdd = FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue;
			FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue = true;
			FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue = oldShapeManagerSuppressAdd;
		}
		public virtual void AddToManagersBottomUp ()
		{
			SceneFile.AddToManagers(mLayer);
			CharInstance.AddToManagers(mLayer);
		}
		public virtual void ConvertToManuallyUpdated ()
		{
			SceneFile.ConvertToManuallyUpdated();
			CharInstance.ConvertToManuallyUpdated();
		}
		public static void LoadStaticContent (string contentManagerName)
		{
			#if DEBUG
			if (contentManagerName == FlatRedBallServices.GlobalContentManager)
			{
				HasBeenLoadedWithGlobalContentManager = true;
			}
			else if (HasBeenLoadedWithGlobalContentManager)
			{
				throw new Exception("This type has been loaded with a Global content manager, then loaded with a non-global.  This can lead to a lot of bugs");
			}
			#endif
			happyvilleFRB.Entities.Character.LoadStaticContent(contentManagerName);
			CustomLoadStaticContent(contentManagerName);
		}
		object GetMember (string memberName)
		{
			switch(memberName)
			{
				case  "SceneFile":
					return SceneFile;
			}
			return null;
		}


	}
}
