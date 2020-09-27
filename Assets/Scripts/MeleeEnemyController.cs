using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyController : MonoBehaviour
{
    public float speed = 5f;
    public float attackRange = 0.5f;
    public int health = 20;
    public int damage = 10;
    public AudioClip attackSound;
    GameObject target;


    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // Point at target
        Vector3 targetPoint = target.transform.position;
        targetPoint.x -= transform.position.x;
        targetPoint.y -= transform.position.y;
        float angle = Mathf.Atan2(targetPoint.y, targetPoint.x) * Mathf.Rad2Deg;
        angle -= 90f;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        // Move towards target
        float movement = speed * Time.deltaTime;
        transform.Translate(new Vector3(0, movement, 0));
    }

    // Take damage on hit
    void OnTriggerEnter2D(Collider2D triggerCollider) {
        print("Collided with " + triggerCollider.gameObject.ToString());
        if (triggerCollider.tag == "Projectile") {
            int damage = triggerCollider.GetComponent<ProjectileController>().damage;
            health -= damage;
            if (health < 1) {
                Destroy(triggerCollider.gameObject);
            }
        }
        else if (triggerCollider.tag == "Player") {
            triggerCollider.GetComponent<PlayerController>().health -= damage;
            triggerCollider.GetComponent<AudioSource>().PlayOneShot(attackSound);
        }
        Destroy(gameObject);
    }
}
