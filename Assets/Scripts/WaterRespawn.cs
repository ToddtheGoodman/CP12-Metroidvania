using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterRespawn : MonoBehaviour
{

    public Transform respawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameObject.Find("Player").GetComponent<PlayerController>().playerLives -= 1;
            other.transform.position = respawnPoint.transform.position;
        }
    }
}
