using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    private Slider slider;

    private const float totalTime = 30.0f;


    private float time;

    void Awake()
    {

        slider = GetComponent<Slider>();
        time = totalTime;
    }

    // Update is called once per frame
    void Update()
    {

        if(!GameManager.instance.GetGameStatus())
        {
            if (time < 0.0f)
            {
                GameManager.instance.GameOver();
            }
            else
            {
                time -= Time.deltaTime;
                slider.value = (time / totalTime) * 100;
            }
        }

    }

    public void AddTime(float second)
    {
        time = Mathf.Min(totalTime, time+second);
    }

}
