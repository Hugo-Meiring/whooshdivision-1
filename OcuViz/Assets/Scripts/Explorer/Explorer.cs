using UnityEngine;
using System.Collections;

public class Explorer : MonoBehaviour {

	// Use this for initialization
	void Start () {
        ShowExplorer("C:/Users/whmei/Documents/whooshdivision/OcuViz/Assets");

    }

    public void ShowExplorer(string itemPath)
    {
        itemPath = itemPath.Replace(@"/", @"\");   // explorer doesn't like front slashes
        System.Diagnostics.Process.Start("explorer.exe", "/select," + itemPath);
    }
}
