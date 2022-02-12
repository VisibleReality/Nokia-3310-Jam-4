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

	private bool inDetailsView;

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
		upgradeCostText.text =
			$"Cost: {Utilities.GetFormattedHeightString(currentUpgrade.GetCurrentCost(currentUpgradeCount))}";
	}

	private bool CanAffordCurrentUpgrade ()
	{
		return currentUpgrade.GetCurrentCost(currentUpgradeCount) <= gameManager.gameData.plantHeight;
	}

	private void Update ()
	{
		if (!CanAffordCurrentUpgrade())
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

		inDetailsView = false;
		lastPage = gameManager.upgrades.Length - 1;
		SetPage(0);
	}

	public override void OnFocus ()
	{
		SetPage(0);
	}

	public override void OnSelect ()
	{
		if (CanAffordCurrentUpgrade())
		{
			cameraManager.PlaySound(1);
			if (!inDetailsView)
			{
				gameManager.BuyUpgrade(currentPage);
				RefreshCostAndCount();
			}
			else
			{
				while (CanAffordCurrentUpgrade())
				{
					gameManager.BuyUpgrade(currentPage);
					RefreshCostAndCount();
				}
			}
		}
		else
		{
			cameraManager.PlaySound(2);
		}
	}

	public override void OnUp ()
	{
		if (currentPage != 0 && !inDetailsView)
		{
			cameraManager.PlaySound(0);
			SetPage(currentPage - 1);
		}
		else
		{
			cameraManager.PlaySound(2);
		}
	}

	public override void OnDown ()
	{
		if (currentPage != lastPage && !inDetailsView)
		{
			cameraManager.PlaySound(0);
			SetPage(currentPage + 1);
		}
		else
		{
			cameraManager.PlaySound(2);
		}
	}

	public override void OnLeft ()
	{
		if (!inDetailsView)
		{
			cameraManager.PlaySound(0);
			inDetailsView = true;
			cameraManager.MoveCameraToObject(detailsView);
		}
	}

	public override void OnRight ()
	{
		if (!inDetailsView)
		{
			cameraManager.PlaySound(0);
			cameraManager.ChangeContext(mainView);
		}
		else
		{
			cameraManager.PlaySound(0);
			inDetailsView = false;
			cameraManager.MoveCameraToObject(gameObject);
		}
	}
}