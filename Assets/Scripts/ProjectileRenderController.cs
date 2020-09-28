using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileRenderController : MonoBehaviour
{
    public float rotationSpeed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float rotation = rotationSpeed * Time.deltaTime;
        transform.Rotate(0, 0 , rotation);
    }
}
