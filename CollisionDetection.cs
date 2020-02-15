using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionDetection : MonoBehaviour
{
    public PlayerController playerController;

    void Start() {
        playerController = GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Door") {
            SceneManager.LoadScene("Level1");
        }
        Debug.Log("Just entered the trigger defined by an object");
        playerController.newPosition = playerController.prevPosition;
    }
}
