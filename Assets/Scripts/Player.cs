using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    [SerializeField] Projectile laserPrefab;
    [SerializeField] float speed = 1f;
    [SerializeField] Transform shootingPoint;
    InGameMenu menu;

    float _border = 3f;
    float lives = 3;
    float shootingRate = 1f;
    float timeToNextShot;


    void Start()
    {
        menu = FindObjectOfType<InGameMenu>();

        //uncomment for shooting every shootingRate second.
        //InvokeRepeating("Shoot", shootingRate, shootingRate);
    }
    void Update()
    {
        //uncomment for movement with touchScreen
        /*if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            
            if (touchPos.x < 0)
            {
                if (transform.position.x > -_border)
                {
                    transform.position += Vector3.left * speed * Time.deltaTime;
                }
            }
            else if (touchPos.x > 0)
            {
                if (transform.position.x < _border)
                {                
                    transform.position += Vector3.right * speed * Time.deltaTime;
                }
            }
        }*/
        //uncomment for movement with keyboard keys
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {            
            if (transform.position.x > -_border)
            {
                transform.position += Vector3.left * speed * Time.deltaTime;
            }
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {            
            if (transform.position.x < _border)
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
            }
        } 
        if (Input.GetKeyDown(KeyCode.Space)&& timeToNextShot <= 0)
        {
            
            Shoot();
        }
        timeToNextShot -= Time.deltaTime;
    }

    void Shoot()
    {
        timeToNextShot = shootingRate;
        Instantiate(laserPrefab, shootingPoint.position, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        lives--;
        menu.LivesLeft(lives);
        if(lives < 1)
        {
            Destroy(gameObject);
            menu.GameOver();
        }        
    }

}
