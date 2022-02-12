
using UnityEngine;

public class MovePlant : MonoBehaviour
{
	[SerializeField] private float maxPlantHeight;
	
	[SerializeField] private GameManager gameManager;

	private Vector3 basePosition;
	
	private void Start ()
	{
		basePosition = transform.position;
	}

	private void Update ()
	{
		if (gameManager.gameData.plantHeight <= 0)
		{
			transform.position = basePosition;
		}
		else if (gameManager.gameData.plantHeight <= maxPlantHeight)
		{
			transform.position = basePosition + new Vector3(0, (float)gameManager.gameData.plantHeight, 0);
		}
		else
		{
			transform.position = basePosition + new Vector3(0, maxPlantHeight, 0);
		}
	}
}