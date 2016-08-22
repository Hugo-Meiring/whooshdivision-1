using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class readytest : MonoBehaviour {

	public void ChangeScene(string sceneName)
	{
		SceneManager.LoadScene (sceneName);
	}
}
