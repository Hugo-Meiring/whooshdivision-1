using UnityEngine;
using System.Collections;

public class FPSDisplay : MonoBehaviour {

    private static int w = Screen.width;
    private static int h = Screen.height;

    private float deltaTime = 0.0f;
    private GUIStyle style = new GUIStyle();
    private Rect rect = new Rect(0, 0, w, h * 2 / 100);

    private Color green = new Color(0.0f, 1.0f, 0.0f, 1.0f);
    private Color orange = new Color(1.0f, 0.75f, 0.0f, 1.0f);
    private Color red = new Color(1.0f, 0.0f, 0.0f, 1.0f);

    private bool displayFPS = true;

	// Update is called once per frame
	void Update () {
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;

        // If P is pressed, toggle whether FPS is displayed or not
        if (Input.GetKeyDown(KeyCode.P))
        {
            displayFPS = !displayFPS;
        }
    }

    // OnGUI is called for rendering and handling GUI events
    void OnGUI()
    {
        if (!displayFPS) return;

        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = h * 2 / 50;
        style.normal.textColor = new Color(0.1f, 0.1f, 0.1f, 1.0f);

        float fps = 1.0f / deltaTime;
        float msec = deltaTime * 1000.0f;

        if (fps >= 75)
            style.normal.textColor = green;
        else if (fps >= 70)
            style.normal.textColor = orange;
        else
            style.normal.textColor = red;

        string text = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);
        GUI.Label(rect, text, style);
    }
}
