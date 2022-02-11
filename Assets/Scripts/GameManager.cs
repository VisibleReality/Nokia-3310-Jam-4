using System;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public Data gameData;
	public Upgrade[] upgrades;


	[SerializeField] private double clickGrowth;

	[SerializeField] private float autoSaveTime;
	[SerializeField] private float iconStayTime;

	[SerializeField] private SpriteRenderer autoSaveIcon;

	public double GrowthSpeed { get; private set; }
	public string FormattedHeightString { get; private set; }

	private void Start ()
	{
		gameData = InitialLoader.gameData ?? new Data(upgrades.Length);
		StartCoroutine(nameof(AutoSaveLoop));
	}

	private void Update ()
	{
		gameData.plantHeight += GrowthSpeed * Time.deltaTime;

		FormattedHeightString = Utilities.GetFormattedHeightString(gameData.plantHeight);
	}

	private void OnApplicationQuit ()
	{
		SaveGame();
	}

	// ReSharper disable once IteratorNeverReturns
	private IEnumerator AutoSaveLoop ()
	{
		while (true)
		{
			yield return new WaitForSeconds(autoSaveTime);
			StartCoroutine(nameof(SaveGameCoroutine));
		}
	}

	private IEnumerator SaveGameCoroutine ()
	{
		autoSaveIcon.enabled = true;

		SaveGame();

		yield return new WaitForSeconds(iconStayTime); // keep save icon on screen for a bit of time
		autoSaveIcon.enabled = false;
	}

	private void RecalculateGrowthSpeed ()
	{
		GrowthSpeed = 0;
		for (var i = 0; i < upgrades.Length; i++) GrowthSpeed += upgrades[i].growthPerUnit * gameData.upgradeCounts[i];
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
	
	public void SaveGameAsync ()
	{
		StartCoroutine(nameof(SaveGameCoroutine));
	}

	public void SaveGame ()
	{
		BinaryFormatter bf = new BinaryFormatter();
		Directory.CreateDirectory(Application.persistentDataPath);
		using FileStream saveFile = File.Create($"{Application.persistentDataPath}/{GlobalConfig.saveFileName}");
		bf.Serialize(saveFile, gameData);
	}
}