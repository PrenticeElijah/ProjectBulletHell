using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiralThree : Enemy
{
    
    public int spwn_idx = 0;        //current bullet spawner index
    public int spwn_idx2 = 23;      //flipped index of bullet spawner

    public float rotate_count;      //rotate count and rate determine the frequency at which bullets are fired
    public float rotate_rate;

    public float max_rotate;        //holds onto the number of rotations needed

    // Start is called before the first frame update
    void Start()
    {   
        
        //set the values for the rotation variables
        max_rotate = 17;
        rotate_count = 17;
        rotate_rate = 6;

        //find the Enemy spawner
        spawner = FindObjectOfType<SpawnEnemy>();
    }

    /*
    // Update is called once per frame
    void Update(){}
    */
    
    void FixedUpdate()
    {
        Pattern();
    }

    void Pattern()
    {

        //decrement the number of rotations
        rotate_count--;

        //only fire according to the rate of rotation
        if(rotate_count % rotate_rate == 0)
        {
            FireBullet();
        }

        //reset the rotation count after reaching the last rotation
        if(rotate_count == 0){
            rotate_count = max_rotate;
        }
    }
    
    void FireBullet()
    {
        
        //instantiate each bullet
        Instantiate(bullet, bullet_spawners[spwn_idx].transform);
        Instantiate(bullet, bullet_spawners[spwn_idx + 1].transform);
        Instantiate(bullet, bullet_spawners[spwn_idx + 2].transform);
        Instantiate(bullet, bullet_spawners[spwn_idx + 3].transform);

        //only instantiate flipped bullets when not interfering with the first set of bullets
        //increment to skip over otherwise
        if(spwn_idx != 0){

            //instatiate bullets in the opposite direction.
            Instantiate(bullet, bullet_spawners[spwn_idx2].transform);
            Instantiate(bullet, bullet_spawners[spwn_idx2 - 1].transform);
            Instantiate(bullet, bullet_spawners[spwn_idx2 - 2].transform);
            Instantiate(bullet, bullet_spawners[spwn_idx2 - 3].transform);
        } else {
            spwn_idx2 += 4;
        }

        //reset the indexes after they reach their max indexes
        //otherwise, increment both indexes
        if(spwn_idx == 20){
            spwn_idx = 0;
            spwn_idx2 = 23;
        } else {
            spwn_idx += 4;
            spwn_idx2 -= 4;
        }
    }
}