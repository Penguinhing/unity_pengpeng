using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleGenerator : MonoBehaviour
{


    [SerializeField]
    private GameObject bubble;


    public void Generate()
    {
        float x = transform.position.x + Random.Range(0.0f, 2.0f);
        Vector3 pos = new Vector3(x, transform.position.y);
        Instantiate(bubble, pos, transform.rotation);
    }


    void Start()
    {
        Generate();
    }


}
