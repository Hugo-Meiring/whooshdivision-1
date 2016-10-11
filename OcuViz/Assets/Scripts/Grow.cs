using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class Grow : MonoBehaviour
{
    // Public fields are visible and their values can be changed dirrectly in the editor

    // Drag and drop here the Voxel from the Scene
    // Used to create new instaces
    public GameObject player;
    public RigidbodyFirstPersonController controller;

    // Use this for initialization
    void Start()
    {

    }

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

        if (Input.GetKeyDown(KeyCode.M))
        {
            
            //player.transform.localScale += new Vector3(1.2F, 1.2F, 1.2F);
            //player.GetComponent<RigidbodyFirstPersonController>().height = player.GetComponent<CharacterController>().height * 1.2f;
            controller.movementSettings.ForwardSpeed = controller.movementSettings.ForwardSpeed * 1.2F;
            controller.movementSettings.BackwardSpeed = controller.movementSettings.BackwardSpeed * 1.2F;
            controller.movementSettings.StrafeSpeed = controller.movementSettings.StrafeSpeed * 1.2F;
            controller.movementSettings.RunMultiplier = controller.movementSettings.RunMultiplier * 1.2F;
            controller.movementSettings.JumpForce = controller.movementSettings.JumpForce * 1.2F;
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            //player.transform.localScale -= new Vector3(1.2F, 1.2F, 1.2F);
            //player.GetComponent<CharacterController>().height = player.GetComponent<CharacterController>().height / 1.2f;
            controller.movementSettings.ForwardSpeed = controller.movementSettings.ForwardSpeed / 1.2F;
            controller.movementSettings.BackwardSpeed = controller.movementSettings.BackwardSpeed / 1.2F;
            controller.movementSettings.StrafeSpeed = controller.movementSettings.StrafeSpeed / 1.2F;
            controller.movementSettings.RunMultiplier = controller.movementSettings.RunMultiplier / 1.2F;
        }
    }
}
