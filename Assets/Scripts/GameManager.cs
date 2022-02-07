using Unity.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public Data gameData;
	public Text counterText;
	public Upgrade[] upgrades;
	
	[SerializeField]
	private double growthSpeed;
	
	private void Start ()
	{
		gameData = new Data(upgrades.Length);
	}

	private void Update ()
	{
		// TODO: make this run only on upgrade purchase
		RecalculateGrowthSpeed();

		gameData.plantHeight += growthSpeed * Time.deltaTime;
		
		counterText.text = Utilities.GetFormattedHeightString(gameData.plantHeight);
	}

	private void RecalculateGrowthSpeed ()
	{
		growthSpeed = 0;
		for (int i = 0; i < upgrades.Length; i++)
		{
			growthSpeed += upgrades[i].growthPerUnit * gameData.upgradeCounts[i];
		}
	}
	
	private void OnSelect ()
	{
		gameData.plantHeight += 0.01;
	}

	private void OnUp ()
	{
		gameData.upgradeCounts[0] += 1;
	}
	
}