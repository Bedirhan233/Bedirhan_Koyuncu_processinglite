using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementExample : MonoBehaviour
{
    public float speed = 0.05f;
    Vector2 position;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        // get input from the user
        position.x += Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
        position.y += Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;

        // move the player
        transform.position = position;
    }
}
