using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquirrelController : MonoBehaviour
{

    public float pos_x = 1.0f;
    public float neg_x = -1.0f;
    private bool go_left = true;
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
        if (transform.position.x >= -12.5) {
            go_left = true;
        }
        if (transform.position.x <= -21.5){
            go_left = false; // so we will be going right 
        }
        if (go_left == true) {
            newPosition = new Vector3(transform.position.x + neg_x, transform.position.y, 0.0f);
            transform.position = Vector2.MoveTowards(transform.position, newPosition, moveSpeed * Time.deltaTime); //movetowards new position
            newPosition = transform.position; //resets newPosition
        }
        if(go_left == false) {
            newPosition = new Vector3(transform.position.x + pos_x, transform.position.y, 0.0f);
            transform.position = Vector2.MoveTowards(transform.position, newPosition, moveSpeed * Time.deltaTime); //movetowards new position
            newPosition = transform.position; //resets newPosition
        }
    }
}