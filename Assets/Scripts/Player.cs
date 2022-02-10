using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Projectile laserPrefab;
    [SerializeField] float speed = 2f;
    [SerializeField] Transform shootingPoint;


    void Start()
    {
        InvokeRepeating("Shoot", 1f, 1f);
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }        
    }

    void Shoot()
    {        
        Instantiate(laserPrefab, shootingPoint.position, Quaternion.identity);        
    }

}
