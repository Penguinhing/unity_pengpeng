using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class DeadLine : MonoBehaviour
{
    private AudioSource sound;

    private void Awake()
    {
        sound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);

        if(collision.gameObject.tag != "TimeCap")
        {
            sound.Play();
            GameManager.instance.KillPenguin();
        }
    }

}
