using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject enemy;
    Vector2 cameraSize;
    Vector2 cameraPos;
    float nextSpawn = 0;

    // Start is called before the first frame update
    void Start()
    {
        Camera mainCamera = Camera.main;
        float cameraHight = 2f * mainCamera.orthographicSize;
        float cameraWidth = cameraHight * mainCamera.aspect;
        cameraSize = new Vector2(cameraWidth, cameraHight);
        cameraPos = new Vector2(mainCamera.transform.position.x, mainCamera.transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (nextSpawn < Time.time) {
            int spawnSide = Random.Range(0, 4);
            float spawnX;
            float spawnY;
            if (spawnSide < 2) {
                spawnX = Random.Range(cameraPos.x - (cameraSize.x / 2), cameraPos.x + (cameraSize.x / 2));
                spawnY = ((cameraSize.y + cameraPos.y) * (int)spawnSide) - (cameraSize.y / 2);
            }
            else {
                spawnX = ((cameraSize.x + cameraPos.x) * (int)(spawnSide - 2)) - (cameraSize.x / 2);
                spawnY = Random.Range(cameraPos.y - (cameraSize.y / 2), cameraPos.y + (cameraSize.y / 2));
            }
            GameObject newProjectile = (GameObject)Instantiate(enemy, new Vector3(spawnX, spawnY), Quaternion.Euler(0, 0, 0));
            nextSpawn = Time.time + (4f - (Time.timeSinceLevelLoad / 20f));
        }
    }
}
