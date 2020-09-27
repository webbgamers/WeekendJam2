using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    public Text timeOverlay;
    public Text healthOverlay;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeOverlay.text = Time.timeSinceLevelLoad.ToString();
        healthOverlay.text = player.GetComponent<PlayerController>().health.ToString();
    }
}
