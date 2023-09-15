using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject gun1;
    public GameObject gun2;

    public GameObject laserPrefab;
    float timer;
    public float fireRate = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        transform.up = direction;

        if (Input.GetMouseButton(0) && timer > fireRate)
        {

            timer = 0;
            Instantiate(laserPrefab, gun1.transform.position, transform.localRotation);
            Instantiate(laserPrefab, gun2.transform.position, transform.localRotation);

            
        }



            timer += Time.deltaTime;
    }
}
