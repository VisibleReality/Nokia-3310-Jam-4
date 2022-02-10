
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitialLoader : MonoBehaviour
{
	public static Data gameData;

	public static string saveFileName;
	
	[SerializeField] private string _saveFileName;
	
	// Start is called before the first frame update
	void Start ()
	{
		saveFileName = _saveFileName;
		
		if (File.Exists($"{Application.persistentDataPath}/{_saveFileName}"))
		{
			BinaryFormatter bf = new BinaryFormatter();
			using (FileStream saveFile = File.Open($"{Application.persistentDataPath}/{_saveFileName}", FileMode.Open))
			{
				gameData = (Data)bf.Deserialize(saveFile);
			}

			SceneManager.LoadScene("Game");
		}
		else
		{
			gameData = null;
			SceneManager.LoadScene("Game");
		}
	}
}