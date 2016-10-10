using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ShowMainMenu : MonoBehaviour {
    public bool visibleGUI = false;
    public GameObject gui;

    void Start()
    {
        gui.SetActive(visibleGUI);
    }
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKey(KeyCode.JoystickButton6))
        {
            Application.Quit();
            StartCoroutine("toggleMenu");
        }
	}

    IEnumerator toggleMenu()
    {
        visibleGUI = !visibleGUI;
        gui.SetActive(visibleGUI);
        gui.transform.position = this.transform.position;
        gui.transform.position = gui.transform.position + this.transform.forward * 1;
        gui.transform.rotation = this.transform.rotation;
        yield return new WaitForSeconds(0.1f);
    }

    public void quit()
    {
        Application.Quit();
        Application.ForceCrash(0);
    }

    public void backToMain()
    {
        if (SceneManager.GetActiveScene().name == "menu")
        {

        }

        else if (SceneManager.GetActiveScene().name == "scene")
        {
            SceneManager.LoadScene(0);
            EntityProvider.EntityProvider.sceneNumber = 0;
            SceneManager.LoadScene(0);
        }
    }
}
