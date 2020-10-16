using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiralTwo : Enemy
{

    public int[] spwn_idx = {0,1,2,3};          //first set of bullet spawner indexes
    public int[] spwn_idx2 = {12,13,14,15};     //flipped set of bullet spawner indexes

    public float rotate_count;      //rotate count and rate determine the frequency at which bullets are fired
    public float rotate_rate;

    public float max_rotate;        //holds onto the number of rotations needed

    // Start is called before the first frame update
    void Start() {
        
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
    
    void FixedUpdate() {
        Pattern();
    }

    void Pattern() {

        //decrement the number of rotations
        rotate_count--;

        //only fire according to the rate of rotation
        if(rotate_count % rotate_rate == 0)
        {
            FireSpiral(spwn_idx);
            FireSpiral(spwn_idx2);
        }

        //reset the rotation count after reaching the last rotation
        if(rotate_count == 0){
            rotate_count = max_rotate;
        }
    }

    void FireSpiral(int[] index){

        //instantiate each bullet
        Instantiate(bullet, bullet_spawners[index[0]].transform);
        Instantiate(bullet, bullet_spawners[index[1]].transform);
        Instantiate(bullet, bullet_spawners[index[2]].transform);
        Instantiate(bullet, bullet_spawners[index[3]].transform);

        //increment the indexes based on each of the indexes
        //set it to 0 if it reaches the max index
        if (index[0] == 23){

            index[0] = 0;      index[1] += 1;
            index[2] += 1;     index[3] += 1;
        } else if(index[3] == 23){

            index[0] += 1;    index[1] += 1;
            index[2] += 1;    index[3] = 0;
        } else if(index[2] == 23){

            index[0] += 1;    index[1] += 1;
            index[2] = 0;     index[3] += 1;
        } else if(index[1] == 23){

            index[0] += 1;    index[1] = 0;
            index[2] += 1;    index[3] += 1;
        } else {

            index[0] += 1;     index[1] += 1;
            index[2] += 1;     index[3] += 1;
        }
    }

}