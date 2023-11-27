using Cinemachine;
using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : NetworkBehaviour
{
	[SerializeField] private CinemachineVirtualCamera _cam;

	private void Start()
	{
		if (!isLocalPlayer)
		{
			_cam.enabled = false;
			return;
		}
	}
}
