using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assigment : ProcessingLite.GP21
{
    public float spaceBetweenLines = 0.2f;

    public int redColorvalue;
    public int greenColorvalue;
    public int blueColorvalue;  
    public int alphaColorvalue;

    public float x1;
    public float y2;
    public float x2;
    public float y1;

    // Start is called before the first frame update
    void Start()
    {
        //Line(2, 7, 4, 3);
        //Line(2, 5, 6, 5);
        //Line(6, 7, 6, 3);

        //Line(8, 5.5f, 8, 3);
        //Line(8, 7, 8, 6.8f);


    }

    // Update is called once per frame
    
    void Update()
    {


        Background(0);

        //Clear background



        for (int i = 0; i < 10; i++)
        {
            if(i % 3 == 0)
            {
                Stroke(128);
            }
            else
            {
                Stroke(255);
            }
            Line(0, 10 - i, i * 2, 0);
        }

        //Draw our art/stuff, or in this case a rectangle
        Rect(x1, y1, x2, y2);
        Fill(redColorvalue, greenColorvalue, blueColorvalue);
            

        Fill(redColorvalue, greenColorvalue, blueColorvalue);

            //Prepare our stroke settings
            Stroke(128, 128, 128, 64);
            StrokeWeight(0.5f);

            //Draw our scan lines
            //for (int i = 0; i < Height / spaceBetweenLines; i++)
            //{
            //    //Increase y-cord each time loop run
            //    float y = i * spaceBetweenLines;

            //    //Draw a line from left side of screen to the right
            //    Line(0, y, Width, y);
            //}
        
    }
}
