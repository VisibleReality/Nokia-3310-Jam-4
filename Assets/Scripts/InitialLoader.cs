using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitialLoader : MonoBehaviour
{
	public static Data gameData;

	// Start is called before the first frame update
	void Start ()
	{
		if (File.Exists($"{Application.persistentDataPath}/{GlobalConfig.saveFileName}"))
		{
			BinaryFormatter bf = new BinaryFormatter();
			using (FileStream saveFile = File.Open($"{Application.persistentDataPath}/{GlobalConfig.saveFileName}",
				       FileMode.Open))
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