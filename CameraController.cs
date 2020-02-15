using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject Player; // this is so we can attach the player GameObject and use it 
    public float offset; // how far off center the camera is relative to the player
    private Vector3 playerPosition; 
    public float offsetSmoothing; // how quick the camera centers on the player (high # is quicker)
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {        
        playerPosition = new Vector3(Player.transform.position.x, Player.transform.position.y, -1.0f); // put the z to -1 so that the camera doesnt move from its -1.0f position
        
        transform.position = Vector3.Lerp(transform.position, playerPosition, offsetSmoothing * Time.deltaTime); // camera moves to player position
    }
}
