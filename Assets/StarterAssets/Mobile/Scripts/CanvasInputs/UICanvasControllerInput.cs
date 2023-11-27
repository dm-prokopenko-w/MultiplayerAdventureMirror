using Mirror;
using UnityEngine;

namespace StarterAssets
{
    public class UICanvasControllerInput : NetworkBehaviour
    {

        [Header("Output")]
        public StarterAssetsInputs starterAssetsInputs;

        public void VirtualMoveInput(Vector2 virtualMoveDirection)
        {
			if (!isLocalPlayer) return;

			starterAssetsInputs.MoveInput(virtualMoveDirection);
        }

        public void VirtualLookInput(Vector2 virtualLookDirection)
        {
			if (!isLocalPlayer) return;

			starterAssetsInputs.LookInput(virtualLookDirection);
        }

        public void VirtualJumpInput(bool virtualJumpState)
        {
			if (!isLocalPlayer) return;

			starterAssetsInputs.JumpInput(virtualJumpState);
        }

        public void VirtualSprintInput(bool virtualSprintState)
        {
			if (!isLocalPlayer) return;

			starterAssetsInputs.SprintInput(virtualSprintState);
        }
        
    }

}
