using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneSelection : MonoBehaviour {

	public Button button;
	public string sceneName;

	void Start()
	{
		button = GetComponent<Button>();
		button.onClick.AddListener(() => LoadEmptyScene());
	}

	public void LoadEmptyScene() 
	{
		Debug.Log ("Clicked");
		SceneManager.LoadScene ("EmptyScene");
	}
}
