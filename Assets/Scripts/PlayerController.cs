using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float normalShotCooldown = 0.5f;
    public float spreadShotCooldown = 1f;
    public float spreadShotSpread = 30f;
    public int spreadShotAmount = 4;
    public AudioClip shootSound;
    public GameObject projectile;
    public int health = 200;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
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
        if (Time.time > nextShotTime) {
            // Normal shot
            if (Input.GetKey(KeyCode.Mouse0)) {
                nextShotTime = Time.time + normalShotCooldown;
                Vector3 spawnPosition = transform.position;
                GameObject newProjectile = (GameObject)Instantiate(projectile, spawnPosition, transform.rotation);
                audioSource.PlayOneShot(shootSound);
            // Shotgun shot
            } else if (Input.GetKey(KeyCode.Mouse1)) {
                nextShotTime = Time.time + spreadShotCooldown;
                for (int i = 0; i < spreadShotAmount; i++) {
                    Vector3 spawnPosition = transform.position;
                    float spawnAngleOffset = Random.Range(-(spreadShotSpread/2), spreadShotSpread/2);
                    float spawnAngle = transform.eulerAngles.z + spawnAngleOffset;
                    GameObject newProjectile = (GameObject)Instantiate(projectile, spawnPosition, Quaternion.Euler(0, 0, spawnAngle));
                }
                audioSource.PlayOneShot(shootSound);
            }
        }
        if (health < 1) {
            Time.timeScale = 0f;
        }
    }
}
