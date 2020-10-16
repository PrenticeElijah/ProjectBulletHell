using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{   
    private Rigidbody2D bul_body;       //rigidbody of the Enemy bullet, allows it to move

    private float angle_x, angle_y;     //where the bullet is instantiated and the direction it moves afterwards
    
    // Start is called before the first frame update
    void Start() {
        //get the bullet's rigidbody
        bul_body = GetComponent<Rigidbody2D>();

        //determine the x and y position of the bullet based on the position of the Enemy and the spawner
        angle_x = transform.parent.position.x;
        angle_y = transform.parent.parent.position.y - transform.parent.position.y;

        //Debug.Log(angle_x);
        //Debug.Log(angle_y);
    }

    // Update is called once per frame
    void Update() {
        //update the bullet's position
        bul_body.MovePosition(new Vector2(transform.position.x + (0.25f * angle_x), transform.position.y - (0.25f * angle_y)));
    }
}