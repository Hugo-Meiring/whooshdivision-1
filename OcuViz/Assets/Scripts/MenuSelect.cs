using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using EntityProvider;

public class MenuSelect : MonoBehaviour {
    public GameObject scene1;
    public GameObject scene2;

    void Update()
    {
        Transform camera = Camera.main.transform;
        Ray ray;
        RaycastHit[] hits;
        GameObject hitObject;

        Debug.DrawRay(camera.position, camera.rotation * Vector3.forward * 100.0f);     // ray is 100 units long

        ray = new Ray(camera.position, camera.rotation * Vector3.forward);
        hits = Physics.RaycastAll(ray);

        //        if (Physics.Raycast (ray, out hit))
        //        {
        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit hit = hits[i];
            hitObject = hit.collider.gameObject;
            if (hitObject == scene1)
            {
                Debug.Log("Test");
                //loadingImage.SetActive(true);
                EntityProvider.EntityProvider.sceneNumber = 1;
                SceneManager.LoadScene(1);
            }
            else if (hitObject == scene2)
            {
                //loadingImage.SetActive(true);
                EntityProvider.EntityProvider.sceneNumber = 2;
                SceneManager.LoadScene(1);
            }
        }
    }
}
