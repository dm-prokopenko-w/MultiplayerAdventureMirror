using UnityEngine;
using Mirror.Discovery;
using Mirror;
using UnityEngine.UI;

namespace UI
{
	public class LobbyMenu : MonoBehaviour
	{
		[SerializeField] private NetworkDiscovery _networkDiscovery;
		[SerializeField] private Button _playBtn;
		[SerializeField] private Button _connectBtn;
		private ServerResponse _info;

		private void Start()
		{
			_networkDiscovery.StartDiscovery();
			_playBtn.onClick.AddListener(NewGame);
			_connectBtn.onClick.AddListener(ConnectToGame);
			_connectBtn.interactable = false;
			Cursor.lockState = CursorLockMode.Confined;
		}

		private void NewGame()
		{
			NetworkManager.singleton.StartHost();
			_networkDiscovery.AdvertiseServer();
		}

		private void ConnectToGame()
		{
			_networkDiscovery.StopDiscovery();
			NetworkManager.singleton.StartClient(_info.uri);
		}

		public void OnDiscoveredServer(ServerResponse info)
		{
			_info = info;
			_connectBtn.interactable = true;
			_networkDiscovery.StopDiscovery();
		}
	}
}