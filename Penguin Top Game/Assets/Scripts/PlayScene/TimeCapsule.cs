using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeCapsule : MonoBehaviour
{

    private GameObject timer;

    private void Awake()
    {
      timer = GameObject.Find("Timer");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bubble")
        {
            SoundManager.instance.PlayPlusSound();
            Destroy(gameObject);
            timer.GetComponent<Timer>().AddTime(10.0f);

        }
    }
}
