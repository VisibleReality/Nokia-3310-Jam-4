using System;

[Serializable]
public class Data
{
	public double plantHeight;
	public long[] upgradeCounts;

	public Data (int numUpgrades)
	{
		plantHeight = 0;
		upgradeCounts = new long[numUpgrades];
	}
}