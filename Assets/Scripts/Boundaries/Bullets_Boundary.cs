using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets_Boundary : MonoBehaviour
{
    /*
    * When either the Player or Enemy's bullets
    * exit the screen, they are deleted.
    */

    void OnTriggerExit2D(Collider2D bullet) {

        //Check the tag of the object that exits the 2D collider.
        if (bullet.tag == "Enemy Fire" || bullet.tag == "Player Fire") {
            
            //Destroy the object if it is an Enemy or Player bullet.
            Destroy(bullet.gameObject);

            //bullet.gameObject.SetActive(false);
        }
    }
}