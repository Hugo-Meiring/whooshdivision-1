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
	    if (Input.GetKeyDown(KeyCode.JoystickButton6) || (Input.GetKeyDown(KeyCode.Escape)))
        {
            StartCoroutine("toggleMenu");
        }
	}

    IEnumerator toggleMenu()
    {
        visibleGUI = !visibleGUI;
        gui.SetActive(visibleGUI);
        gui.transform.position = this.transform.position;
        gui.transform.position = gui.transform.position + this.transform.forward * 1 + new Vector3(0, 0.75f, 0);
        gui.transform.rotation = this.transform.rotation;
        yield return new WaitForSeconds(0.1f);
    }

    public void quitApplication()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    public void backToMain()
    {
        if (SceneManager.GetActiveScene().name == "scene")
        {
            SceneManager.LoadScene(0);
            EntityProvider.EntityProvider.sceneNumber = 0;
            SceneManager.LoadScene(0);
        }
        else
        {
            StartCoroutine("toggleMenu");
        }
    }
}
