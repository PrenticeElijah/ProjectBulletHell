using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayInBox : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        /*
        * Keeping the character within the boundaries of the screen
        * using the Mathf Clamp function.
        * 
        * Code by Alexander Zotov:
        * https://www.youtube.com/watch?v=CFf2woe4gdg
        */
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -1.045f, 1.045f), Mathf.Clamp(transform.position.y, -1.9f,1.9f));
    }
}
