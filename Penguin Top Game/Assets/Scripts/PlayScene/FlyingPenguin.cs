using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;

public class FlyingPenguin : MonoBehaviour
{

    [SerializeField]
    private float jumpPower = 10.0f;

    [SerializeField]
    private GameObject defaultPenguin;


    private Rigidbody2D rigid;

    private GameObject parent;

    private GameObject bubbleGen;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        parent = GameObject.Find("Penguin");
        bubbleGen = GameObject.Find("BubbleGenerator");
    }
    
    void Start()
    {
        rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name.Contains("Penguin"))
        {
            Destroy(gameObject);

            float posX = collision.transform.position.x;
            float posY = transform.position.y - 0.1f;
            Quaternion rot = Quaternion.Euler(0, 0, 0);

            // ���� ������ 0.15 ���� ū ��� ���� �Ѵ�.
            if (Math.Abs(Math.Abs(transform.position.x) - Math.Abs(collision.gameObject.transform.position.x)) > 0.15f)
            {
                posX = (transform.position.x < collision.transform.position.x) ? collision.transform.position.x - 0.2f : collision.transform.position.x + 0.2f;
                rot = Quaternion.Euler(0, 0, (transform.position.x < collision.transform.position.x) ? 7 : -7); // �������� ����
            }



            defaultPenguin.GetComponent<SpriteRenderer>().sortingOrder = GameManager.instance.GetPenguins() + 1;

            // ��ǥ ������
            Vector3 pos = new Vector3(posX, posY, transform.position.z);

            // ������Ʈ ����
            GameObject peng = Instantiate(defaultPenguin, pos, rot);
            peng.transform.SetParent(parent.transform, true);

            GameManager.instance.IncreaseScore(false);
        }


    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "TOP")
        {
            gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
            other.tag = "Untagged";
        }
        
    }


    void OnDestroy()
    {
        if(!GameManager.instance.GetGameStatus())
        {
            bubbleGen.GetComponent<BubbleGenerator>().Generate();
        }


    }
}
