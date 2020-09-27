using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float shotCooldown = 0.5f;
    public GameObject projectile;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    float nextShotTime = 0f;

    // Update is called once per frame
    void Update()
    {
        // Point at mouse
        Vector3 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        point.x -= transform.position.x;
        point.y -= transform.position.y;
        float angle = Mathf.Atan2(point.y, point.x) * Mathf.Rad2Deg;
        angle -= 90f;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        // Shooting
        if (Input.GetKey(KeyCode.Mouse0)) {
            if (Time.time > nextShotTime) {
                nextShotTime = Time.time + shotCooldown;
                Vector3 spawnPosition = transform.localPosition;
                GameObject newProjectile = (GameObject)Instantiate(projectile, spawnPosition, transform.rotation);
            }
        }
    }
}
