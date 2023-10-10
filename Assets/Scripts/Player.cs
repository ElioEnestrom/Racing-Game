using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public GameObject player, explosion, powerUp;
    public CarController enemyCarController;
    public Transform respawnPoint;
    public TextMeshPro textMeshPro;

    public bool invincible, itemPicked;
    public float timer;

    public void Update()
    {
        if (itemPicked)
        {
            timer += Time.deltaTime;

            if (timer >= 3)
            {
                enemyCarController.maxMotorTorque = 800;
                invincible = false;
                itemPicked = false;
                powerUp.SetActive(true);
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "RespawnPoint")
        {
            respawnPoint = other.transform;
        }
        else if (other.gameObject.tag == "PowerUp" && itemPicked == false)
        {
            powerUp = other.GameObject();
            powerUp.SetActive(false);
            timer = 0;
            itemPicked = true;
            int randomPower = Random.Range(0, 2);
            switch(randomPower)
            {
                case 0:
                    Invulnerability();
                    Debug.Log("Invincible");
                    break;
                case 1:
                    Slow();
                    Debug.Log("Slowed");
                    break;
            }
        }
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall" && invincible == false)
        {
            Instantiate(explosion, transform.position, transform.rotation);
            player.transform.position = respawnPoint.transform.position;
            player.transform.rotation = respawnPoint.transform.rotation;
        }
    }
    public void Invulnerability()
    {
        invincible = true;
    }
    public void Slow()
    {
        enemyCarController.maxMotorTorque = 400;
    }
    public void IceFloor()
    {

    }
    public void Shell()
    {

    }
}
