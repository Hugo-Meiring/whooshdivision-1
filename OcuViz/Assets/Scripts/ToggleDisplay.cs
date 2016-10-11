using UnityEngine;
using System.Collections;
using UnityEngine.VR;

public class ToggleDisplay : MonoBehaviour {
	// Changing VR active or not
	void Update () {
	    // If V is pressed, toggle VRSettings.enabled
        if (Input.GetKeyDown(KeyCode.V))
        {
            VRSettings.enabled = !VRSettings.enabled;
            Debug.Log("Changed VRSettings.enabled to:" + VRSettings.enabled);
        }
	}
}
