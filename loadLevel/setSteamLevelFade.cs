// Custom Action by DumbGameDev
// www.dumbgamedev.com
// Eric Vander Wal 2017

using UnityEngine;
using Valve.VR;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Steam VR")]
	[Tooltip("Steam VR load level fade options")]

	public class setSteamLevelFade : FsmStateAction
	{

     	[RequiredField]
     	[CheckForComponent(typeof(SteamVR_LoadLevel))]
     	[Tooltip("The game object which holds the steam script.")]
		public FsmOwnerDefault gameObject;
		
		[ActionSection("Fade Time")]
		[RequiredField]
		public FsmFloat fadeOutTime;
		[RequiredField]
		public FsmFloat fadeInTime;
		
		[ActionSection("Loading Screen Fade Time")]
		[RequiredField]
		public FsmFloat LoadingFadeIn;
		[RequiredField]
		public FsmFloat LoadingFadeOut;

		private SteamVR_LoadLevel loader;

        public override void Reset()
		{

			gameObject = null;
			fadeOutTime = 0.5f;
			fadeInTime = 0.5f;
			LoadingFadeIn = 1f;
			LoadingFadeOut = 0.25f;
			
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
			
			loader.fadeInTime = fadeInTime.Value;
			loader.fadeOutTime = fadeOutTime.Value;
			loader.loadingScreenFadeInTime = LoadingFadeIn.Value;
			loader.loadingScreenFadeOutTime = LoadingFadeOut.Value;
		}
	}
}