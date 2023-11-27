using Mirror;
using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

namespace StarterAssets
{
	public class StarterAssetsInputs : NetworkBehaviour
	{
		[Header("Character Input Values")]
		public Vector2 move;
		public Vector2 look;
		public bool jump;
		public bool sprint;

		[Header("Movement Settings")]
		public bool analogMovement;

		[Header("Mouse Cursor Settings")]
		public bool cursorLocked = true;
		public bool cursorInputForLook = true;

#if ENABLE_INPUT_SYSTEM
		public void OnMove(InputValue value)
		{
			if (!isLocalPlayer) return;

			MoveInput(value.Get<Vector2>());
		}

		public void OnLook(InputValue value)
		{
			if (!isLocalPlayer) return;

			if (cursorInputForLook)
			{
				LookInput(value.Get<Vector2>());
			}
		}

		public void OnJump(InputValue value)
		{
			if (!isLocalPlayer) return;

			JumpInput(value.isPressed);
		}

		public void OnSprint(InputValue value)
		{
			if (!isLocalPlayer) return;

			SprintInput(value.isPressed);
		}
#endif


		public void MoveInput(Vector2 newMoveDirection)
		{
			if (!isLocalPlayer) return;

			move = newMoveDirection;
		} 

		public void LookInput(Vector2 newLookDirection)
		{
			if (!isLocalPlayer) return;

			look = newLookDirection;
		}

		public void JumpInput(bool newJumpState)
		{
			if (!isLocalPlayer) return;

			jump = newJumpState;
		}

		public void SprintInput(bool newSprintState)
		{
			if (!isLocalPlayer) return;

			sprint = newSprintState;
		}

		private void OnApplicationFocus(bool hasFocus)
		{
			if (!isLocalPlayer) return;

			SetCursorState(cursorLocked);
		}

		private void SetCursorState(bool newState)
		{
			if (!isLocalPlayer) return;

			Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
		}
	}
	
}