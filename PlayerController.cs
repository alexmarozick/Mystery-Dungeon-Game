using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Animator animator;

    public float x_displacement; // the change in x passed into move function
    public float y_displacement; // the change in y passed into move function
    //public bool move_to_point; // the "is moving test"
    
    // Bellow is how to use SerializeField to show private global vars in the unity inspector
    [SerializeField] private float moveSpeed = 5.0f;
    
    public Vector3 newPosition;

    public Vector3 prevPosition;

    public enum State {
        moving,
        idle,
        combat
    }

    public State currState = State.idle;

    void Start() 
    {
        newPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }


    // void move(float xd, float yd) {
    //     /*
    //     *  
    //     */
    //     if (currState == State.moving) {    
    //         if (xd != 0) { // move left or right
                
    //             while (transform.position.x != newPosition.x) {
                    
    //                 transform.position = Vector2.MoveTowards(transform.position, newPosition, moveSpeed * Time.deltaTime);
                    
    //                 // if (transform.position.x >= newPosition.x)
    //                 //     break;
    //             }
    //             x_displacement = 0.0f;  //reset magnitude so it doesnt grow over multiple calls in the same direction
    //         }
    //         if(yd != 0) { // move up or down
                
    //             while (transform.position.y != newPosition.y) {
                    
    //                 transform.position = Vector2.MoveTowards(transform.position, newPosition, moveSpeed * Time.deltaTime);

    //                 // if (transform.position.y >= newPosition.y)
    //                 //     break;
    //             }
    //             y_displacement = 0.0f;  //reset magnitude so it doesnt grow over multiple calls in the same direction
    //         }
    //     }
    // }


    void FixedUpdate()
    {
        // move(x_displacement, y_displacement);

        // Debug.Log("CurrState : " + currState);

        if (currState == State.moving) {

            animator.SetBool("isMoving", true);

            if (x_displacement != 0) { // move left or right
                
                if (transform.position.x != newPosition.x) {
                    
                    transform.position = Vector2.MoveTowards(transform.position, newPosition, moveSpeed * Time.deltaTime);
                    
                    // if (transform.position.x >= newPosition.x)
                    //     break;
                }
                else {
                    currState = State.idle;
                    animator.SetBool("isMoving", false);
                    newPosition = transform.position;
                    x_displacement = 0.0f;  //reset magnitude so it doesnt grow over multiple calls in the same direction
                    animator.SetFloat("playerVelocityX", x_displacement);
                }
            }
            if(y_displacement != 0) { // move up or down
                
                if (transform.position.y != newPosition.y) {
                    
                    transform.position = Vector2.MoveTowards(transform.position, newPosition, moveSpeed * Time.deltaTime);

                    // if (transform.position.y >= newPosition.y)
                    //     break;
                }
                else {
                    currState = State.idle;
                    animator.SetBool("isMoving", false);
                    newPosition = transform.position;
                    y_displacement = 0.0f;  //reset magnitude so it doesnt grow over multiple calls in the same direction
                    animator.SetFloat("playerVelocityY", y_displacement);
                }
            }
        }
    }


    void Update()
    {
        
        prevPosition = transform.position;
        
        // Debug.Log("prev : " + prevPosition);
        // Debug.Log("On Update Call - new : " + newPosition);
        // Debug.Log("Curr pos : " + transform.position);
        
        if (currState != State.moving) {    
            // Left
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) { // move left
                x_displacement = -1.0f;
                y_displacement = 0.0f;
                animator.SetFloat("playerVelocityX", x_displacement);
                newPosition += new Vector3(x_displacement, y_displacement, 0.0f);
                // Debug.Log("After calculation - new : " + newPosition);
                currState = State.moving;
                // move(x_displacement, y_displacement);
            }
            
            // Right
            else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) {
                x_displacement = 1.0f;
                y_displacement = 0.0f;
                animator.SetFloat("playerVelocityX", x_displacement);
                newPosition += new Vector3(x_displacement, y_displacement, 0.0f);
                // Debug.Log("After calculation - new : " + newPosition);
                currState = State.moving;
                // move(x_displacement, y_displacement);
            }
            
            // Up
            else if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) {
                x_displacement = 0.0f;
                y_displacement = 1.0f;
                animator.SetFloat("playerVelocityY", y_displacement);
                newPosition += new Vector3(x_displacement, y_displacement, 0.0f);
                // Debug.Log("After calculation - new : " + newPosition);
                currState = State.moving;
                // move(x_displacement, y_displacement);
            }

            //Down
            else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) {
                x_displacement = 0.0f;
                y_displacement = -1.0f;
                animator.SetFloat("playerVelocityY", y_displacement);
                newPosition += new Vector3(x_displacement, y_displacement, 0.0f);
                // Debug.Log("After calculation - new : " + newPosition);
                currState = State.moving;
                // move(x_displacement, y_displacement);
            }
        }

        // newPosition = transform.position;  // Resets newPosition to current position for next update call

    }
}