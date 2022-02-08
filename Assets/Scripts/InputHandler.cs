using UnityEngine;

public abstract class InputHandler : MonoBehaviour
{
	protected GameManager gameManager;
	protected CameraManager cameraManager;

	protected void Start ()
	{
		gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
		cameraManager = GameObject.Find("Main Camera").GetComponent<CameraManager>();
	}

	public abstract void OnSelect ();

	public abstract void OnUp ();

	public abstract void OnDown ();

	public abstract void OnLeft ();

	public abstract void OnRight ();
}