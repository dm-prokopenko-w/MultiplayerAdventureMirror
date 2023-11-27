using UnityEngine;

public class PlatformVisual : MonoBehaviour
{
	[SerializeField] private GameObject _uiControl;

	private void Awake()
	{
		_uiControl.SetActive(false);

#if UNITY_ANDROID
		_uiControl.SetActive(true);
#endif
	}

	private void Start()
	{
		Cursor.lockState = CursorLockMode.Locked;
	}
}
