using UnityEngine;

public class PlatformVisual : MonoBehaviour
{
	[SerializeField] private GameObject _androidBody;
	[SerializeField] private GameObject _pcBody;

	private void Awake()
	{
		_androidBody.SetActive(false);
		_pcBody.SetActive(true);

#if UNITY_ANDROID
		_androidBody.SetActive(true);
		_pcBody.SetActive(false);
#endif
	}

	private void Start()
	{
		Cursor.lockState = CursorLockMode.Locked;
	}
}
