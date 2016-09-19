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
            EntityProvider.EntityProvider.sceneNumber = 1;
            SceneManager.LoadScene(1);
        }

        else if(SceneManager.GetActiveScene().name == "scene")
        {

        }
	}

    public void two()
    {
        loadingImage.SetActive(true);
        EntityProvider.EntityProvider.sceneNumber = 2;
        SceneManager.LoadScene(1);
    }
}
