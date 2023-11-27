using UnityEngine;
using Mirror;
using UnityEngine.UI;

namespace UI
{
	public class BackToLobby : MonoBehaviour
	{
		[SerializeField] private Button _stopGameBtn;

		private void Start()
		{
			Cursor.lockState = CursorLockMode.Confined;
			if (_stopGameBtn == null) Debug.Log(gameObject.name);
			_stopGameBtn.onClick.AddListener(StopGame);
		}

		private void StopGame()
		{
			if (NetworkServer.active && NetworkClient.isConnected)
			{
				NetworkManager.singleton.StopHost();
			}
			else if (NetworkClient.isConnected)
			{
				NetworkManager.singleton.StopClient();
			}
			else if (NetworkServer.active)
			{
				NetworkManager.singleton.StopServer();
			}
		}

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.Escape))
			{
				StopGame();
			}
		}
	}
}