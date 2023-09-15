using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public UIHandler Score;

    public GameObject storeGold;
    
    
    Transform target;
    Rigidbody2D rb2D;

    public GameObject enemy;
    public GameObject food;

    public int EnemyScore;

    public float speed = 5;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;  
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = target.position - transform.position;
        direction.Normalize();
        rb2D.velocity = direction * speed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.GetComponent<Laser>() != null)
        {
            Instantiate(food, transform.position, transform.rotation);
            Destroy(other.gameObject);
            
            Invoke("death", 0.1f);
        }
    }

    void death ()
    {
        Destroy(gameObject);
    }
    
}
