using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using EntityProvider;

public class SceneLoader: MonoBehaviour {

    public GameObject loadingImage;
	public void one()
    {
        loadingImage.SetActive(true);
        EntityProvider.EntityProvider.sceneNumber = 1;
        SceneManager.LoadScene(1);
	}

    public void two()
    {
        loadingImage.SetActive(true);
        EntityProvider.EntityProvider.sceneNumber = 2;
        SceneManager.LoadScene(1);
    }

    public void newScene()
    {
        //this can be used to create a new scene, copy things over
        //and then save the scene for retrieval later.
        //scene = SceneManager.CreateScene(list[1]);
    }
}
