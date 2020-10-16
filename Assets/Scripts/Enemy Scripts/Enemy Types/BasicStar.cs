using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicStar : Enemy
{
    
    public float max_shot;          //holds onto the max value of shot counter

    public float shot_counter;     //shot count and rate determine the frequency at which bullets are fired
    public int shot_rate;

    public float shoot_time;            //the period of time the Enemy is allowed to fire
    public float cool_down;             //the period of time for the Enemy to prepare to fire again
    public bool is_shooting = false;    //if true, the Enemy is firing, in cooldown otherwise
    
    // Start is called before the first frame update
    void Start() {

        //set the values for the shot and cooldown variables
        max_shot = 17;
        shot_rate = 8;
        shoot_time = 50;
        cool_down = 180;

        spawner = FindObjectOfType<SpawnEnemy>();
    }

    /*// Update is called once per frame
    void Update(){}*/
    
    void FixedUpdate() {
        Pattern();
    }

    //Basic Star Bullet Pattern
    void Pattern() {

        //shoot while true
        if (is_shooting) {
            
            //decrement the shooting time and the counter
            shoot_time -= (Time.deltaTime * 60);
            shot_counter -= 1;

            //only fire according to the rate of fire
            if (shot_counter % shot_rate == 0) {
                FireBullet();
            }
            
            //stop shooting when the time is less than 0
            //reset shooting time and counter
            if(shoot_time < 0)
            {
                shoot_time = 50;
                is_shooting = false;
                shot_counter = max_shot;
            }

        } else {
            
            //decrement the cooldown time
            cool_down -= (Time.deltaTime * 60);

            //start shooting again when the cooldown is less than 0
            //reset the cooldown time
            if (cool_down < 0) {
                cool_down = 180;
                is_shooting = true;
            }
        }
    }
    
    void FireBullet() {
        
        //instantiate each bullet
        for(int i = 0; i < 8; i++){
            Instantiate(bullet, bullet_spawners[i].transform);
        }
    }
}