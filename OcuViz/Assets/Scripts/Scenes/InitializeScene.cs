using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using EntityProvider;

public class InitializeScene : MonoBehaviour {
    public void openScene1()
    {
        if (SceneManager.GetActiveScene().name == "menu")
        {
            //loadingImage.SetActive(true);
            EntityProvider.EntityProvider.sceneNumber = 1;
            SceneManager.LoadScene(1);
        }

        else if (SceneManager.GetActiveScene().name == "scene")
        {

        }
    }

    public void openScene2()
    {
        if (SceneManager.GetActiveScene().name == "menu")
        {
            //loadingImage.SetActive(true);
            EntityProvider.EntityProvider.sceneNumber = 2;
            SceneManager.LoadScene(2);
        }

        else if (SceneManager.GetActiveScene().name == "scene")
        {

        }
    }

    public void openScene3()
    {
        //EntityProvider.EntityProvider.sceneNumber = 3;
        //SceneManager.LoadScene(3);
    }
}
