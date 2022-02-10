using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public Data gameData;
	public Upgrade[] upgrades;

	[SerializeField] private double growthSpeed;
	[SerializeField] private double clickGrowth;

	[SerializeField] private float autoSaveTime;
	[SerializeField] private float iconStayTime;

	[SerializeField] private SpriteRenderer autoSaveIcon;

	public string FormattedHeightString { get; private set; }

	private void Start ()
	{
		gameData = InitialLoader.gameData ?? new Data(upgrades.Length);
		StartCoroutine(nameof(SaveGame));
	}

	private void Update ()
	{
		gameData.plantHeight += growthSpeed * Time.deltaTime;

		FormattedHeightString = Utilities.GetFormattedHeightString(gameData.plantHeight);
	}
	
	// ReSharper disable once IteratorNeverReturns
	private IEnumerator SaveGame ()
	{
		while (true)
		{
			yield return new WaitForSeconds(autoSaveTime);
			
			autoSaveIcon.enabled = true;

			BinaryFormatter bf = new BinaryFormatter();
			using (FileStream saveFile = File.Create($"{Application.persistentDataPath}/{InitialLoader.saveFileName}"))
			{
				bf.Serialize(saveFile, gameData);
			}
			
			yield return new WaitForSeconds(iconStayTime); // keep save icon on screen for a bit of time
			autoSaveIcon.enabled = false;
		}
		
	}

	private void RecalculateGrowthSpeed ()
	{
		growthSpeed = 0;
		for (var i = 0; i < upgrades.Length; i++) growthSpeed += upgrades[i].growthPerUnit * gameData.upgradeCounts[i];
	}

	public void GrowPlant ()
	{
		gameData.plantHeight += clickGrowth;
	}

	public void BuyUpgrade (int upgradeIndex)
	{
		gameData.plantHeight -= upgrades[upgradeIndex].GetCurrentCost(gameData.upgradeCounts[upgradeIndex]);
		gameData.upgradeCounts[upgradeIndex] += 1;
		RecalculateGrowthSpeed();
	}
}