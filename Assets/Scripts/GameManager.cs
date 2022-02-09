using Unity.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public Data gameData;
	public Upgrade[] upgrades;

	[SerializeField] private double growthSpeed;

	public string FormattedHeightString { get; private set; }

	private void Start ()
	{
		gameData = new Data(upgrades.Length);
	}

	private void Update ()
	{
		// TODO: make this run only on upgrade purchase
		RecalculateGrowthSpeed();

		gameData.plantHeight += growthSpeed * Time.deltaTime;

		FormattedHeightString = Utilities.GetFormattedHeightString(gameData.plantHeight);

	}

	private void RecalculateGrowthSpeed ()
	{
		growthSpeed = 0;
		for (var i = 0; i < upgrades.Length; i++) growthSpeed += upgrades[i].growthPerUnit * gameData.upgradeCounts[i];
	}

	public void GrowPlant ()
	{
		gameData.plantHeight += 0.01;
	}
}