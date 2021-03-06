// Custom Action by DumbGameDev
// www.dumbgamedev.com
// Eric Vander Wal 2017

using UnityEngine;
using Valve.VR;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Steam VR")]
	[Tooltip("Quick trigger the steam VR load level script")]

	public class triggerSteamLevelLoad : FsmStateAction
	{
        // Playmaker variables

     	[RequiredField]
     	[CheckForComponent(typeof(SteamVR_LoadLevel))]
		[Tooltip("Nav agent game object.")]
		public FsmOwnerDefault gameObject;
		
		private SteamVR_LoadLevel loader;

        public override void Reset()
		{

			gameObject = null;
		}

		public override void OnEnter()
		{

            var go = Fsm.GetOwnerDefaultTarget(gameObject);
			loader = go.GetComponent<SteamVR_LoadLevel>();

			if(loader == null)
			{
				Finish();
			}
			
			triggerYourLoad();
			Finish ();

        }

		void triggerYourLoad()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);
			if (go == null)
			{
				return;
			}  
			
			if (loader == null)
			{
				return;
			}     
			
			loader.Trigger();
		}
	}
}