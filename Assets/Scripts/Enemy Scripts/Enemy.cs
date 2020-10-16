using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    /*
    * The parent class for the different types of enemies.
    * Handles updating the Enemy's health, bullet spawners, and the Enemy spawner.
    */
    
    
    public GameObject[] bullet_spawners = new GameObject[24];   //all of the bullet spawners for the Enemy
    public GameObject bullet;                                   //bullet prefab to spawn/fire

    /*
    * Reference for the angles/positions of the spawners
    * (multiplied by .13 to account for the offset of each spawner from the Enemy)
    * //https://marksmath.org/visualization/unit_circle/
    */

    public int health, max_health;      //the current and starting health of the Enemy
    public Text health_points;          //text showing the Enemy's health
    public SpawnEnemy spawner;          //the Enemy's spawner

    
    // Start is called before the first frame update
    void Start() {
        
        //set Enemy health to start from 100
        health = 100;
        max_health = 100;

        //display the Enemy's starting health
        health_points.text = health.ToString()  + "/" + health.ToString();
    }

    /*
    // Update is called once per frame
    void Update(){}
    */

    void OnTriggerEnter2D(Collider2D players_bullet) {

        //check if a Player bullet has collided with the Enemy
        if (players_bullet.tag == "Player Fire") {

            //destroy the Player bullet and decrement the Enemy's health
            Destroy(players_bullet.gameObject);
            health--;

            //destroy this Enemy if the health reaches 0
            //then signal to the Enemy spawner that a new Enemy should spawn
            if (health == 0) {
                spawner.should_spawn = true;
                Destroy(this.gameObject);
            } else {

                //otherwise, update the display of the Enemy's health
                health_points.text = health.ToString()  + "/" + max_health.ToString();
            }
        }
    }
}