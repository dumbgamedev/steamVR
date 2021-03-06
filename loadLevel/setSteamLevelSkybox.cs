// Custom Action by DumbGameDev
// www.dumbgamedev.com
// Eric Vander Wal 2017

using UnityEngine;
using Valve.VR;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Steam VR")]
	[Tooltip("Steam VR load level skybox")]

	public class setSteamLevelSkybox : FsmStateAction
	{

     	[RequiredField]
     	[CheckForComponent(typeof(SteamVR_LoadLevel))]
     	[Tooltip("The game object which holds the steam script.")]
		public FsmOwnerDefault gameObject;
		
		[RequiredField]
		public FsmTexture top;
		[RequiredField]
		public FsmTexture bottom;
		[RequiredField]
		public FsmTexture front;
		[RequiredField]
		public FsmTexture back;
		[RequiredField]
		public FsmTexture left;
		[RequiredField]
		public FsmTexture right;

		private SteamVR_LoadLevel loader;

        public override void Reset()
		{

			gameObject = null;
			top = null;
			bottom = null;
			right = null;
			left = null;
			front = null;
			back = null;
			
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
			
			loader.top = top.Value;
			loader.back = back.Value;
			loader.front = front.Value;
			loader.bottom = bottom.Value;
			loader.right = right.Value;
			loader.left = left.Value;
		}
	}
}