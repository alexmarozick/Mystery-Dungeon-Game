/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public GameObject Player; // so we can attach the enemy to the player

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //TODO: Make it so that they dont overlap when they get within collision radius

        // if the x displacement is larger, enemy will go left or right first. If the y displacment is larger, the enemy will go up and down first
        if(abs(player.transform.position.x - transform.position.x) > abs(player.transform.position.y - transform.position.y)) { // go left or right
            if (player.transform.position.x < transform.position.x) {
                //enemy go left
            }
            else {
                //enemy go right
            }
        }
        if (abs(player.transform.position.x - transform.position.x) < abs(player.transform.position.y - transform.position.y)) { // go up and down
            if (player.transform.position.y > transform.position.y) {
                //enemy go up
            }
            else {
                //enemy go down
            }
        if (abs(Player.transform.position.x - transform.position.x) == abs(Player.transform.position.y - transform.position.y)) {
            // no preferance on where enemy goes
        }
    }
}
*/
