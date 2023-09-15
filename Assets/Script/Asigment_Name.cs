using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asigment_Name : ProcessingLite.GP21
{
    [Header("Line1")]
    public float x1;
    public float y2;
    public float x2;
    public float y1;

    [Header("TopCircle")]
    public float CircleX;
    public float CircleY;
    public float Diameter;

    [Header("BottomCircle")]
    public float Circle2X;
    public float Circle2Y;
    public float Diameter2;

    [Header("CircleColors")]
    public int red;   
    public int green;
    public int blue;
        




    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        Background(128, 128, 128);
        Line(x1, y1, x2, y2); 

        Circle(CircleX, CircleY, Diameter);

        Fill(red, green, blue);

        Circle(Circle2X, Circle2Y, Diameter2);


        Line(x1, y1, x2, y2);


    }


    }
