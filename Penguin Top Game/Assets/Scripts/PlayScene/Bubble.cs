using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleController : MonoBehaviour
{
    private float speed;

    [SerializeField]
    private GameObject flyingPenguin;


    private bool arrow = true; // true : ¿À¸¥ÂÊ, false : ¿ÞÂÊ


    private void Awake()
    {
        this.speed = GameManager.instance.GetBubbleSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(speed);
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);


        if (pos.x >= 0.87f)
        {
            arrow = false;
        }

        if (pos.x <= 0.13f)
        {
            arrow = true;
        }


        transform.position = arrow ? 
            transform.position + new Vector3(1.0f * speed * Time.deltaTime, 0, 0) : 
            transform.position - new Vector3(1.0f * speed * Time.deltaTime, 0, 0);

        if (Input.GetKey(KeyCode.Space))
        {
            Destroy(gameObject);
            flyingPenguin.GetComponent<SpriteRenderer>().sortingOrder = 100;
            Instantiate(flyingPenguin, transform.position, transform.rotation);
            

        }
        
    }
}
