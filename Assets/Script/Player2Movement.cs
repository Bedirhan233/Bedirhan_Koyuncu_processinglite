using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Player2Movement : MonoBehaviour
{

    Vector2 position;
    Vector2 acceleration = new Vector2(0, 0);
    Vector2 direction;
    public float brake = 0.5f;
    Rigidbody2D rb;
    Vector2 velocity;

    public UIHandler Score; 

    public int winScore;
    public float FirstEnemyDamage;

    public float SecondEnemyDamage;

    Vector2 input;

    Vector2 gravity = new Vector2(0, -0.9f);

    public float maxspeed = 5;

    public float accelaration = 10;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }
    
    // Update is called once per frame
    void Update()
    {
        Movement();
        
    }

    private void OnCollisionEnter2D(Collision2D collider)
    {
        if(collider.gameObject.tag == "Enemy")
        {
            Score.ScoreManagment(0, FirstEnemyDamage);
        }
        if (collider.gameObject.tag == "Enemy")
        {
            Score.ScoreManagment(0, SecondEnemyDamage);
        }


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Food(Clone)")
        {

            Score.ScoreManagment(winScore, 0);

            Destroy(other.gameObject);
        }
    }

    private void Movement()
    {
        if (Input.GetKey(KeyCode.D)) direction.x = 1;
        if (Input.GetKeyUp(KeyCode.D)) direction.x = 0;

        if (Input.GetKey(KeyCode.A)) direction.x = -1;
        if (Input.GetKeyUp(KeyCode.A)) direction.x = 0;

        if (Input.GetKey(KeyCode.W)) direction.y = 1;
        if (Input.GetKeyUp(KeyCode.W)) direction.y = 0;

        if (Input.GetKey(KeyCode.S)) direction.y = -1;
        if (Input.GetKeyUp(KeyCode.S)) direction.y = 0;

        //input.x += Input.GetAxisRaw("Horizontal");
        //input.y += Input.GetAxisRaw("Vertical");

        velocity += direction * accelaration * Time.deltaTime;

        // maxspeed
        if (velocity.magnitude > maxspeed * maxspeed)
        {
            velocity.Normalize();
            velocity = velocity * maxspeed;
        }


        //if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
        //{
        //    velocity *= 1 - brake * Time.deltaTime;
        //}

        if (direction.sqrMagnitude == 0)
        {
            velocity *= brake - Time.deltaTime;
        }




        // move the player
        position += velocity;

        rb.velocity = velocity;
    }
}
