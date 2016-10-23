using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ShorcutKeys : MonoBehaviour {	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            if (SceneManager.GetActiveScene().name == "menu")
            {
                EntityProvider.EntityProvider.sceneNumber = 1;
                SceneManager.LoadScene(1);
            }
        }

        if (Input.GetKey(KeyCode.Alpha2))
        {
            if (SceneManager.GetActiveScene().name == "menu")
            {
                EntityProvider.EntityProvider.sceneNumber = 2;
                SceneManager.LoadScene(1);
            }
        }

        if (Input.GetKey(KeyCode.Alpha3))
        {
            if (SceneManager.GetActiveScene().name == "menu")
            {
                EntityProvider.EntityProvider.sceneNumber = 3;
                SceneManager.LoadScene(1);
            }
        }

    }
}
