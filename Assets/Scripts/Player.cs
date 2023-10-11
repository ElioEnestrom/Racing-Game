using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public GameObject player, explosion, powerUp, winningScene;
    public CarController enemyCarController;
    public Transform respawnPoint;
    public TMP_Text powerUpText, scoreText, winningMessage;

    public bool invincible, itemPicked, halfWayPoint;
    public float timer;
    private int playerScore = 0;

    public void Update()
    {
        //Timer for power ups
        if (itemPicked)
        {
            timer += Time.deltaTime;
            if (timer >= 3)
            {
                enemyCarController.maxMotorTorque = 800;
                invincible = false;
                itemPicked = false;
                powerUp.SetActive(true);
                powerUpText.text = "";
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        //System used for scoring points and winning
        if (other.gameObject.tag == "HalfWayPoint")
        {
            halfWayPoint = true;
        }

        if (other.gameObject.tag == "Goal" && halfWayPoint == true)
        {
            halfWayPoint = false;
            playerScore++;
            scoreText.text = playerScore.ToString();
            if (playerScore == 3)
            {
                winningMessage.text = gameObject.name + " WINS!";
                winningScene.SetActive(true);
                Time.timeScale = 0;
            }
        }

        
        if (other.gameObject.tag == "RespawnPoint")
        {
            respawnPoint = other.transform;
        }
        else if (other.gameObject.tag == "PowerUp" && itemPicked == false)
        {
            //Gives a randomized power up
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
        //Makes you respawn when you drive into a wall
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
        powerUpText.text = "Invincible!";
    }
    public void Slow()
    {
        enemyCarController.maxMotorTorque = 400;
        powerUpText.text = "Enemy Slowed!";
    }
    public void IceFloor()
    {

    }
    public void Shell()
    {

    }
}
