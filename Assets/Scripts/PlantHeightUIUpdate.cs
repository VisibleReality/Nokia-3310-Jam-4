using UnityEngine;
using UnityEngine.UI;

public class PlantHeightUIUpdate : MonoBehaviour
{
	private GameManager gameManager;
	private Text text;

	// Start is called before the first frame update
	void Start ()
	{
		gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
		text = gameObject.GetComponent<Text>();
	}

	// Update is called once per frame
	void Update ()
	{
		text.text = gameManager.FormattedHeightString;
	}
}