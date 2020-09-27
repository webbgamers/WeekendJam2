using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    public bool fitToCamera = true;

    // Start is called before the first frame update
    void Start()
    {
        if (fitToCamera) {
            Camera mainCamera = Camera.main;
            float cameraHight = 2f * mainCamera.orthographicSize;
            float cameraWidth = cameraHight * mainCamera.aspect;
            transform.localScale = new Vector3(cameraWidth, cameraHight);
            transform.position = new Vector3(mainCamera.transform.position.x, mainCamera.transform.position.y, transform.position.z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
