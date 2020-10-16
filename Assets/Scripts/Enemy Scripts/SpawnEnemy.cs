using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    
    public GameObject[] enemy = new GameObject[5];      //all Enemies available to spawn
    public bool should_spawn = true;                    //whether or not an Enemy needs to spawn
    public float wait = 180;                            //wait time before spawning an Enemy

    /*
    // Start is called before the first frame update
    void Start(){}
    */

    // Update is called once per frame
    void Update() {
        
        //if an Enemy is allow to spawn
        if (should_spawn) {

            //if the wait time is over,
            //instantiate the Enemy, reset the wait time,
            //and set should_spawn to false to stop spawning
            if (wait <= 0) {

                Instantiate(enemy[Random.Range(0,4)], new Vector3(0,1.5f,0), new Quaternion(0,0,0,0));
                should_spawn = false;
                wait = 180;
            } else {
                wait -= (Time.deltaTime * 60);          //otherwise, decrement the wait time
            }
        }
    }
}