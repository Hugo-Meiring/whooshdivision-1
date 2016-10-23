using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class Grow : MonoBehaviour
{
    // Public fields are visible and their values can be changed dirrectly in the editor

    // Drag and drop here the Voxel from the Scene
    // Used to create new instaces
    public GameObject player;
    public FirstPersonController controller;
    private bool m_isAxisInUse = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            player.transform.position = player.transform.position + new Vector3(0, 100, 0);
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            player.transform.position = player.transform.position + new Vector3(0, -100, 0);
        }

        if (Input.GetKeyDown(KeyCode.M) || Input.GetKeyDown(KeyCode.JoystickButton2))
        {
            controller.m_RunSpeed = controller.m_RunSpeed * 1.2f;
            controller.m_WalkSpeed = controller.m_WalkSpeed * 1.2f;
            //player.transform.localScale += new Vector3(1.2F, 1.2F, 1.2F);
            //player.GetComponent<RigidbodyFirstPersonController>().height = player.GetComponent<CharacterController>().height * 1.2f;
        }

        if (Input.GetKeyDown(KeyCode.N) || Input.GetKeyDown(KeyCode.JoystickButton1))
        {
            controller.m_RunSpeed = controller.m_RunSpeed / 1.2f;
            controller.m_WalkSpeed = controller.m_WalkSpeed / 1.2f;
            //player.transform.localScale -= new Vector3(1.2F, 1.2F, 1.2F);
            //player.GetComponent<CharacterController>().height = player.GetComponent<CharacterController>().height / 1.2f;
        }

        // Xbox Y button (3)
        if (Input.GetKeyDown(KeyCode.JoystickButton3))
        {
            player.transform.localScale += new Vector3(1.2f, 1.2f, 1.2f);
            controller.m_JumpSpeed = controller.m_JumpSpeed * 1.2f;
            controller.m_GravityMultiplier = controller.m_GravityMultiplier * 1.2f;
        }

        // Xbox A button (0)
        if (Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            player.transform.localScale -= new Vector3(1.2f, 1.2f, 1.2f);
            controller.m_JumpSpeed = controller.m_JumpSpeed / 1.2f;
            controller.m_GravityMultiplier = controller.m_GravityMultiplier / 1.2f;
        }
    }
}
