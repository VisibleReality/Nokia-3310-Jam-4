using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public Data gameData;

	public Text counterText;

	// Start is called before the first frame update
	private void Start ()
	{
		gameData = new Data();
	}

	private void Update ()
	{
		counterText.text = gameData.plantHeight.ToString(CultureInfo.InvariantCulture);
	}

	private void OnSelect ()
	{
		gameData.plantHeight += 1;
	}
}