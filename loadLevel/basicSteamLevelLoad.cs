// Custom Action by DumbGameDev
// www.dumbgamedev.com
// Eric Vander Wal 2017

using UnityEngine;
using Valve.VR;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Steam VR")]
	[Tooltip("Steam VR load level")]

	public class basicSteamLevelLoad : FsmStateAction
	{

     	[RequiredField]
     	[CheckForComponent(typeof(SteamVR_LoadLevel))]
     	[Tooltip("The game object which holds the steam script.")]
		public FsmOwnerDefault gameObject;
		
		[RequiredField]
		[Tooltip("Scene name. Case sensitive.")]
		public FsmString sceneName;
		
		public FsmBool loadAdditive;
		public FsmBool loadAsync;
		
		private SteamVR_LoadLevel loader;

        public override void Reset()
		{

			gameObject = null;
			sceneName = null;
			loadAdditive = false;
			loadAsync = true;
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
			
			loader.levelName = sceneName.Value;
			loader.loadAsync = loadAsync.Value;
			loader.loadAdditive = loadAdditive.Value;
			loader.Trigger();
			
		}
	}
}