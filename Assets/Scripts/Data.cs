using System;

[Serializable]
public class Data
{
	public double plantHeight;
	public long[] upgradeCounts;
	public DateTime saveTime;

	public Data (int numUpgrades)
	{
		plantHeight = 0;
		upgradeCounts = new long[numUpgrades];
		saveTime = DateTime.Now;
	}
}