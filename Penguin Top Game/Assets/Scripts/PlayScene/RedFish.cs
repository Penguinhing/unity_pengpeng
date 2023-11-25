using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedFish : MonoBehaviour
{
    private GameObject signal;

    private void Awake()
    {
        signal = GameObject.Find("Signal");
    }


    private void Update()
    {
        GameObject penguin = GameObject.FindWithTag("TOP");
        if (penguin != null)
        {
            float rangeMinX = transform.position.x - 1.0f;
            float rangeMaxX = transform.position.x + 1.0f;
            float rangeMinY = transform.position.y - 1.0f;
            float rangeMaxY = transform.position.y + 1.0f;

            float px = penguin.gameObject.transform.position.x;
            float py = penguin.gameObject.transform.position.y;

            if (px >= rangeMinX && px <= rangeMaxX && py >= rangeMinY && py <= rangeMaxY) // ������ �� ó��
            {
                SoundManager.instance.PlayPlusSound();
                Destroy(gameObject);
                GameManager.instance.IncreaseScore(true);
            }
            
        }

        float y = Camera.main.WorldToViewportPoint(transform.position).y;

        if (y < 1.0f) // ȭ�鿡 ��ü�� ���̸� �ñ׳� �Ⱥ��̰� ó��
        {
            signal.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
        }

        if (y <= 0.3) // ������ �������� ���ֱ�
        {
            Destroy(gameObject);
        }
    }
}
