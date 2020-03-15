using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector3 movementDirection;
    public float speed;
    public float lifetime = 2.0f;
    void Start()
    {
        
    }    
    void Update()
    {
        this.GetComponent<Rigidbody2D>().velocity = movementDirection * speed;
        //  1.0 -> 50.0
        DestroyObject();
    }

    void DestroyObject()
    {
        lifetime -= Time.deltaTime; // count down timer + to increase

        if (lifetime <= 0)
            Destroy(this.gameObject);
    }
}
