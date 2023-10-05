using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject player, explosion;
    public PowerUp powerUp;
    public Transform respawnPoint;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "RespawnPoint")
        {
            respawnPoint = other.transform;
        }
        else
        {
            powerUp = other.GetComponent<PowerUp>();
        }
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Instantiate(explosion, transform.position, transform.rotation);
            player.transform.position = respawnPoint.transform.position;
            player.transform.rotation = respawnPoint.transform.rotation;
        }
    }
}
