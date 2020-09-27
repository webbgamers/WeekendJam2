using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public Sprite[] idle;
    public float idleAnimationSpeed;
    public Sprite[] shoot;
    public float shootAnimationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        StartCoroutine("Idle");
    }

    // Update is called once per frame
    void Update()
    {
        // Shoot animation
        if (Input.GetKeyDown(KeyCode.Mouse0) | Input.GetKeyDown(KeyCode.Mouse1)) {
            StopAllCoroutines();
            StartCoroutine("Shoot");
        }
    }

    // Idle animation
    IEnumerator Idle() {
        for (int i = 0; i < idle.Length; i++) {
            spriteRenderer.sprite = idle[i];
            print("Switched to frame " + i.ToString());
            yield return new WaitForSeconds(60f / idleAnimationSpeed);
        }
        StartCoroutine("Idle");
    }

    // Shoot animation
    IEnumerator Shoot() {
        for (int i = 0; i< shoot.Length; i++) {
            spriteRenderer.sprite = shoot[i];
            yield return new WaitForSeconds(60f / idleAnimationSpeed);
        }
        StartCoroutine("Idle");
    }
}
