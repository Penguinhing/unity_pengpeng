using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpText : MonoBehaviour
{
    private float timer = 0.0f;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 1.0f)
        {
            timer = 0.0f;
            gameObject.SetActive(false);
        }
    }

    
}
