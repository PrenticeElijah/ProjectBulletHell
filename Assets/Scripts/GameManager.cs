using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    bool game_over = false;             //whether or not to show the 'Game Over' screen
    public GameObject game_over_panel;  //'Game Over' screen
    
    // Start is called before the first frame update
    void Start() {
        //hide the 'Game Over' screen (make it inactive)
        game_over_panel.SetActive(false);
    }

    /*
    // Update is called once per frame
    void Update(){}
    */

    /*
    *  EndGame and Restart functions by Brakeys on YouTube:
    *  https://www.youtube.com/watch?v=VbZ9_C4-Qbo 
    */

    //end game functio
    public void EndGame() {
        
        //activate the 'Game Over' screen
        if (!game_over) {

            game_over = true;

            game_over_panel.SetActive(true);
        }
    }

    //game restart function
    public void Restart() {
        //reload the scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}