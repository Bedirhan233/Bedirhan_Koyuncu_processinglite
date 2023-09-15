using UnityEngine;


public class test : MonoBehaviour
{
    float currentSpeed = 0.05f;
    public float initialSpeed = 0.05f;
    Vector2 position;
    Vector2 acceleration = new Vector2(0, 0);
    Vector2 direction;
    public float brake = 0.5f;
    Rigidbody2D rb;
    Vector2 velocity;

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
        Debug.Log(direction);

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








        //take down the speed

        //if (Input.GetAxis("Horizontal") == 0)
        //{
        //    if (velocity.x < 0)
        //    {
        //        velocity.x = velocity.x + brake * Time.deltaTime;

        //    }
        //    if (velocity.x > 0)
        //    {
        //        velocity.x = velocity.x - brake * Time.deltaTime;
        //    }
        //}
        //if (Input.GetAxis("Vertical") == 0)
        //{
        //    if (velocity.y < 0)
        //    {
        //        velocity.y = velocity.y + brake * Time.deltaTime;
        //    }
        //    if (velocity.y > 0)
        //    {
        //        velocity.y = velocity.y - brake * Time.deltaTime;
        //    }
        //}



        //if (velocity.magnitude < 0)
        //{
        //    velocity = new Vector2(0, -0.01f);
        //}




    }
}
