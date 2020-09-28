using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public float speed = 5f;
    public float despawnDistance = 50f;
    public int damage = 15;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Movement
        float movement = speed * Time.deltaTime;
        transform.Translate(new Vector3(0, movement, 0));

        // Despawning
        if (Mathf.Abs(transform.position.x) > despawnDistance | Mathf.Abs(transform.position.y) > despawnDistance) {
            Destroy(gameObject);
        }
    }
}
