using System;
using UnityEngine;

[Serializable]
public class Upgrade
{
	public String name;
	public String description;
	public Texture icon;
	public double growthPerUnit;
	
	[SerializeField]
	private double baseCost;
	[SerializeField]
	private double costMultiplier;
	
	public Upgrade (String name, String description, Texture icon, double baseCost, double costMultiplier,
		double growthPerUnit)
	{
		this.name = name;
		this.description = description;
		this.icon = icon;
		this.baseCost = baseCost;
		this.costMultiplier = costMultiplier;
		this.growthPerUnit = growthPerUnit;
	}

	public double GetCurrentCost (int currentUnitCount)
	{
		return baseCost * Math.Pow(costMultiplier, currentUnitCount);
	}
}