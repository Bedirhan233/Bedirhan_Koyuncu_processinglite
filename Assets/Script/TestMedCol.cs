using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMedCol : MonoBehaviour
{
    Rigidbody2D rigidbody2;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2 = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Use this for 2D collision detection
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "DownBorder")
        {
            Debug.Log("Collision with DownBorder");
            Destroy(gameObject);
        }
    }
}
