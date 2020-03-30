using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    public GameObject pro;
    public Camera gameCamera;

    public float shootingCooldown = 0.5f;
    private float shootingTimer;
    void Start()
    {
        Cursor.visible = false;
    }

 
    void Update()
    {
        shootingTimer -= Time.deltaTime;
        MouseMovement();
        Shoot();
    }

    void Shoot()
    {
        if(Input.GetMouseButtonDown(0)&& shootingTimer <= 0)
        {
            shootingTimer = shootingCooldown;
            
            // array
            Vector2[] directions = new Vector2[]
                       {Vector2.up,
                        Vector2.down,
                        Vector2.left,
                        Vector2.right
                        };

            foreach (Vector2 direction in directions)
            {
                //Instantiate(pro, transform.position, Quaternion.identity);
                GameObject bulletObj = Instantiate(pro);
                bulletObj.transform.position = this.transform.position;
             
                Projectile project = bulletObj.GetComponent<Projectile>();
                project.movementDirection = direction;
            }

        }
    }

    void MouseMovement()
    {
        Vector2 mousePosition = Input.mousePosition;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        this.transform.position = new Vector3(worldPosition.x, worldPosition.y, this.transform.position.z);
    }
}
