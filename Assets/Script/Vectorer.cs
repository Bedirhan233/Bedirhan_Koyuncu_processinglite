using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Vectorer : ProcessingLite.GP21
{

    public float x2;
    public float y2;
    public float x1;
    public float y1;

    public float CircleX;
    public float CircleY;

    public float maxSpeed = 20;
    public Vector2 minSpeed = new Vector2(5, 5); 


    public Vector2 circlePosition;

    Vector2 test;

    Vector2 calculateX;
    Vector2 calculateY;

    Vector2 velocity;

 

   

   


    public float diameter = 2;
    // Start is called before the first frame update
    void Start()
    {
        circlePosition = new Vector2(CircleX, CircleY);
        
    }

    // Update is called once per frame
    void Update()
    {
        Background(0, 0, 150);
        Circle(circlePosition.x, circlePosition.y, diameter);
        Vector2 mouse = new Vector2(MouseX, MouseY);
       
        if (Input.GetMouseButtonDown(0))
        {
            circlePosition.x = mouse.x;
            circlePosition.y = mouse.y;


        }

        if (Input.GetMouseButton(0))
        {
            x1 = mouse.x;
            y1 = mouse.y;

            Line(x1, y1, circlePosition.x, circlePosition.y);

        }
        


        Vector2 linje = new Vector2(x1, y1);




        if (Input.GetMouseButtonUp(0))
        {
            
            velocity =  mouse  - circlePosition;
            if(velocity.magnitude > maxSpeed) 
            {
                velocity = minSpeed;
                velocity *= maxSpeed;
            }

        }

        circlePosition += velocity / 750;
        

        if(circlePosition.x > Width || circlePosition.x < 0) 
        {
            velocity.x *= -1;
        }

        if (circlePosition.y > Height || circlePosition.y < 0)
        {
            velocity.y *= -1;
        }

        Debug.Log("Magnitdue " + velocity.magnitude);





    }
}
