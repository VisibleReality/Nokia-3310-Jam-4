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
		if (File.Exists(Path.Combine(Application.persistentDataPath, GlobalConfig.saveFileName)))
		{
			BinaryFormatter bf = new BinaryFormatter();
			using (FileStream saveFile =
			       File.Open(Path.Combine(Application.persistentDataPath, GlobalConfig.saveFileName), FileMode.Open))
			{
				gameData = (Data)bf.Deserialize(saveFile);
			}

			SceneManager.LoadScene("Game");
		}
		else if (File.Exists(Path.Combine("/idbfs/5121db68ccbbbfde032b2c190736c278", GlobalConfig.saveFileName)) && Application.platform == RuntimePlatform.WebGLPlayer)
		{
			BinaryFormatter bf = new BinaryFormatter();
			using (FileStream saveFile =
			       File.Open(Path.Combine(Path.Combine("/idbfs/5121db68ccbbbfde032b2c190736c278", GlobalConfig.saveFileName)), FileMode.Open))
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