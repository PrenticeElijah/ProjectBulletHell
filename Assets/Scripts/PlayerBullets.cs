using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullets : MonoBehaviour
{
    
    private Rigidbody2D bul_body;       //rigidbody of the Player bullet, allows it to move

    private float speed = 0.05f;        //speed of the Player bullet
    
    // Start is called before the first frame update
    void Start()
    {
        //get the bullet's rigidbody
        bul_body = GetComponent<Rigidbody2D>();
    }

    /*
    // Update is called once per frame
    void Update()
    {}
    */

    void FixedUpdate()
    {
        //update the bullet's position
        bul_body.MovePosition(new Vector2(transform.position.x, transform.position.y + speed));
    }
}