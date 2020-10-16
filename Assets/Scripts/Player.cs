using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    Touch touched;
    private Vector3 finger_position;        //the position of the Player's finger on screen
    private Rigidbody2D rigid;              //the rigidbody of the Player, allows movement

    public GameObject gun;                  //the GameObject from where bullets will be instantiated
    public GameObject bullet;               //the Player's bullet/ammunition

    private float delta_X, delta_Y;         //used to calculate the offset between the finger and the Player ship

    private int shot_rate = 6;              //shot count and rate determine the frequency at which the Player's bullets are fired
    private float shot_counter;
    private const float max_shot = 17;      //holds onto the max value of shot counter
    
    // Start is called before the first frame update
    void Start() {

        //get the player's rigidbody
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        
        /*
        * Moving the Player ship using touchscreen
        * with an offset.
        * 
        * Code by Alexander Zotov:
        * https://www.youtube.com/watch?v=eSdjNGNj6uk
        */
        
        //if the screen is touched by the Player's finger
        if (Input.touchCount > 0) {

            touched = Input.GetTouch(0);    //assign value to 'touched'

            //obtain the position of the finger on the screen through the 'touched' variable
            finger_position = Camera.main.ScreenToWorldPoint(touched.position);

            switch (touched.phase) {

                //if the Player's finger started touching the screen
                case TouchPhase.Began:

                    //calculate the offset between the Player ship and the Player's finger
                    delta_X = finger_position.x - transform.position.x;
                    delta_Y = finger_position.y - transform.position.y;
                    break;

                //if the Player's finger is moving across the screen
                case TouchPhase.Moved:

                    //move the Player's ship using the calculated offset
                    rigid.MovePosition(new Vector2(finger_position.x - delta_X, finger_position.y - delta_Y));
                    break;

                //if the Player's finger is no longer touching the screen
                case TouchPhase.Ended:

                    //the Player's ship is no longer moving
                    rigid.velocity = Vector2.zero;
                    break;
            }
        }
    }

    void PlayerShoot() {

        //if there is no need to reset the counter
        if (shot_counter >= 0) {

            //decrement the shot counter
            shot_counter -= 1;

            //only fire according to the rate of fire
            if (shot_counter % shot_rate == 0) {

                //instantiate the Player bullet
                Instantiate(bullet, new Vector3(gun.transform.position.x, gun.transform.position.y, 0), new Quaternion(0,0,0,0));
            }

        } else {

            //reset the shot counter
            shot_counter = max_shot;
        }
    }
    
    void FixedUpdate()
    {
        PlayerShoot();
    }

    void OnTriggerEnter2D(Collider2D enemy_bullet) {   

        //if an Enemy bullet collides with the Player
        if (enemy_bullet.tag == "Enemy Fire") {
            //destroy the Enemy bullet
            Destroy(enemy_bullet.gameObject);

            //set the 'Game Over' screen as active
            FindObjectOfType<GameManager>().EndGame();

            //destroy the Player
            Destroy(this.gameObject);
        }
    }
}