using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy2 : MonoBehaviour
{
    Vector2 ScaleUpEnemy;
    Vector2 MoveTheEnemyDown = new Vector2(0, -1);
    public float FinalSize = 3f;

    public float speed = 5;

    Rigidbody2D rb2;

    bool ScaleUp = true;
    // Start is called before the first frame update
    void Start()
    {
        ScaleUpEnemy = gameObject.transform.localScale;

        rb2 = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if(ScaleUpEnemy.x >= FinalSize && ScaleUpEnemy.y >= FinalSize)
        {

            ScaleUp = false;
           
        }

        if(ScaleUp)
        {
            ScaleUpEnemy.x = ScaleUpEnemy.x + 0.01f;
            ScaleUpEnemy.y = ScaleUpEnemy.y + 0.01f;

            gameObject.transform.localScale = ScaleUpEnemy;

        }




        if (ScaleUp == false)
        {
            rb2.velocity = speed * MoveTheEnemyDown;
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.name == "DownBorder")
        {
            Destroy(gameObject);
        }
    }
}
