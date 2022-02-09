using System;
using Unity.Mathematics;
using UnityEngine;

public static class Utilities
{
	public static readonly string[] units = { "m", "km", "Mm", "Gm", "Tm", "Pm", "Em", "Zm", "Ym" };

	public static string GetFormattedHeightString (double height)
	{
		// Special cases

		if (height < 1) // Less than 1 m
		{
			Debug.Log($"{height:G17}");
			Debug.Log($"{height * 100:G17}");
			return $"{Math.Floor(height * 100):#0} cm";
		}

		if (height < 10) // Less than 10 m (so that only 2 decimal places are displayed in this special case)
			return $"{height:0.00} m";

		// General cases
		var logBase1000Floor = Math.Floor(Math.Log(height, 1000));

		if (logBase1000Floor > 8) // If we dont' have enough metric prefixes, fall back to scientific notation
			return $"{height:G4} m";

		// Otherwise, calculate height so it's always less than 3 digits long by dividing by a power of 1000
		var heightRestricted = height / Math.Pow(1000, logBase1000Floor);

		if (heightRestricted < 10) // Height is 1 digit long (1.3)
			return $"{RoundDown(heightRestricted, 3):0.000} {units[(int)logBase1000Floor]}";

		if (heightRestricted < 100) // Height is 2 digits long (2.2)
			return $"{RoundDown(heightRestricted, 2):00.00} {units[(int)logBase1000Floor]}";

		if (heightRestricted < 1000) // Height is 3 digits long (3.1)
			return $"{RoundDown(heightRestricted, 1):000.0} {units[(int)logBase1000Floor]}";

		return $"{height:G4} m"; // Fallback if something goes wrong
	}

	private static double RoundDown (double number, double numPlaces)
	{
		var power = Math.Pow(10, numPlaces);
		return Math.Floor(number * power) / power;
	}
}