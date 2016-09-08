using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using EntityProvider;

public class SceneLoader: MonoBehaviour {

    // Use this for initialization
    public GameObject loadingImage;
	public void one() {
	    if(SceneManager.GetActiveScene().name == "main")
        {
            loadingImage.SetActive(true);
            
            SceneManager.LoadScene(1);
        }

        else if(SceneManager.GetActiveScene().name == "scene")
        {

        }
	}
}
