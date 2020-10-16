using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiralOne : Enemy
{
    
    public int spawn_idx = 0;       //current bullet spawner index

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
        if (rotate_count % rotate_rate == 0) {
            FireBullet();
        }

        //reset the rotation count after reaching the last rotation
        if (rotate_count == 0) {
            rotate_count = max_rotate;
        }
    }
    
    void FireBullet() {

        //instantiate each bullet
        Instantiate(bullet, bullet_spawners[spawn_idx].transform);
        Instantiate(bullet, bullet_spawners[spawn_idx + 1].transform);
        Instantiate(bullet, bullet_spawners[spawn_idx + 2].transform);
        Instantiate(bullet, bullet_spawners[spawn_idx + 3].transform);

        //return to the first spawner if reaching the last spawner
        //otherwise, increment to the next spawner
        if (spawn_idx == 20) {
            spawn_idx = 0;
        } else {
            spawn_idx += 4;
        }
    }
}