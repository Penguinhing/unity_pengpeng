using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{


    private GameObject[] background;

    private void Awake()
    {
        background = GameObject.FindGameObjectsWithTag("InfiniteBackground");
    }

    public IEnumerator Refresh()
    {
        GameObject top = GameObject.FindWithTag("TOP");
        if (top != null)
        {
            float y = Camera.main.WorldToViewportPoint(top.gameObject.transform.position).y;
            while (y >= 0.35)
            {
                transform.position += Vector3.down * 3.0f * Time.deltaTime; // ������ ��ü ������
                y = Camera.main.WorldToViewportPoint(top.gameObject.transform.position).y;


                for (int i = 0; i < background.Length; i++)
                {
                    if (Camera.main.WorldToViewportPoint(background[i].transform.position).y <= -0.5) // ��� ���� �ø���
                    {
                        background[i].transform.position += new Vector3(0, 34.0f, 0);
                    }

                }

                yield return null;
            }
        }
      
    }
}
