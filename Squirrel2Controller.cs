using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squirrel2Controller : MonoBehaviour
{
     public float pos_y = 1.0f;
    public float neg_y = -1.0f;
    private bool go_down = true;
    private Vector3 newPosition;
    [SerializeField] private float moveSpeed = 6.0f;


    // Start is called before the first frame update
    void Start()
    {
        newPosition = new Vector3(transform.position.x, transform.position.y, 0.0f);
            
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y >= 1) {
            go_down = true;
        }
        if (transform.position.y <= -5){
            go_down = false; // so we will be going right 
        }
        if (go_down == true) {
            newPosition = new Vector3(transform.position.x, transform.position.y + neg_y, 0.0f);
            transform.position = Vector2.MoveTowards(transform.position, newPosition, moveSpeed * Time.deltaTime); //movetowards new position
            newPosition = transform.position; //resets newPosition
        }
        if(go_down == false) {
            newPosition = new Vector3(transform.position.x, transform.position.y + pos_y, 0.0f);
            transform.position = Vector2.MoveTowards(transform.position, newPosition, moveSpeed * Time.deltaTime); //movetowards new position
            newPosition = transform.position; //resets newPosition
        }
    }
}