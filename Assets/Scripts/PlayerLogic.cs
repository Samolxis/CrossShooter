using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    public GameObject pro;
    void Start()
    {
        Cursor.visible = false;
    }

 
    void Update()
    {
        MouseMovement();
        Shoot();
    }

    void Shoot()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Instantiate(pro, transform.position, Quaternion.identity);

            Projectile project = pro.GetComponent<Projectile>();
            project.movementDirection = Vector2.right;
        }
    }

    void MouseMovement()
    {
        Vector2 mousePosition = Input.mousePosition;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        this.transform.position = new Vector3(worldPosition.x, worldPosition.y, this.transform.position.z);
    }
}
