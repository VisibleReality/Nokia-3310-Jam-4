using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradesViewInputHandler : InputHandler
{
	[SerializeField] private InputHandler mainView;
	[SerializeField] private GameObject detailsView;

	[SerializeField] private Text upgradeTitleText;
	[SerializeField] private Text upgradeCountText;
	[SerializeField] private Text upgradeCostText;
	[SerializeField] private Text upgradeDescriptionText;
	[SerializeField] private RawImage upgradeIcon;

	[SerializeField] private Image scrollUpIndicator;
	[SerializeField] private Image scrollDownIndicator;

	[SerializeField] private Image buyButton;
	[SerializeField] private Image buyMaxButton;

	private Upgrade currentUpgrade;
	private long currentUpgradeCount;
	private int currentPage;
	private int lastPage;

	private void SetPage (int page)
	{
		currentPage = page;
		scrollUpIndicator.enabled = page != 0;
		scrollDownIndicator.enabled = page != lastPage;

		currentUpgrade = gameManager.upgrades[page];

		upgradeTitleText.text = currentUpgrade.name;
		upgradeDescriptionText.text = currentUpgrade.description;
		upgradeIcon.texture = currentUpgrade.icon;
		
		RefreshCostAndCount();
	}

	private void RefreshCostAndCount ()
	{
		currentUpgradeCount = gameManager.gameData.upgradeCounts[currentPage];

		upgradeCountText.text = $"Owned: {currentUpgradeCount}";
		upgradeCostText.text = $"Cost: {currentUpgrade.GetCurrentCost(currentUpgradeCount)}";
	}

	private void Update ()
	{
		if (currentUpgrade.GetCurrentCost(currentUpgradeCount) < gameManager.gameData.plantHeight)
		{
			buyButton.enabled = false;
			buyMaxButton.enabled = false;
		}
		else
		{
			buyButton.enabled = true;
			buyMaxButton.enabled = true;
		}
	}

	private new void Start ()
	{
		base.Start();
		
		lastPage = gameManager.upgrades.Length - 1;
		SetPage(0);
	}

	public override void OnFocus ()
	{
		SetPage(0);
	}

	public override void OnSelect ()
	{
		
	}

	public override void OnUp ()
	{
		if (currentPage != 0)
		{
			SetPage(currentPage - 1);
		}
	}

	public override void OnDown ()
	{
		if (currentPage != lastPage)
		{
			SetPage(currentPage + 1);
		}
	}

	public override void OnLeft ()
	{
	}

	public override void OnRight ()
	{
		cameraManager.ChangeContext(mainView);
	}
}