using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject bird;

    [SerializeField]
    private GameObject redFish;

    private GameObject signal;


    private const float fishDelay = 5.0f;
    private float fishTimer = 0.0f;

    private const float birdDelay = 13.0f;
    private float birdTimer = 0.0f;


    private void Awake()
    {
        signal = GameObject.Find("Signal");
        
    }

    void Update()
    {
        fishTimer += Time.deltaTime;
        birdTimer += Time.deltaTime;

        if(fishTimer >= fishDelay)
        {
            fishTimer = 0.0f;
            FishGenerate();
        }

        if (birdTimer >= birdDelay)
        {
            birdTimer = 0.0f;
            BirdGenerate();
        }

        
        
    }

    void FishGenerate()
    {
        if (transform.Find("RedFish") == null)
        {
            float x = Random.Range(-1.66f, 1.66f);
            Vector3 pos = new Vector3(x, 12.0f);


            GameObject fish = Instantiate(redFish, pos, Quaternion.identity);
            fish.name = "RedFish";
            fish.transform.parent = transform;

            // 시그널 표시
            signal.gameObject.transform.position = new Vector3(fish.transform.position.x, signal.transform.position.y);
            signal.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);

        }
    }

    void BirdGenerate()
    {
        if (GameObject.Find("Bird") == null) // 새가 없는 경우에만 생성한다.
        {
            float x = Random.Range(-1.66f, 1.66f);
            Vector3 pos = new Vector3(x, 6.0f);


            GameObject birdPrefab = Instantiate(bird, pos, Quaternion.identity);
            birdPrefab.name = "Bird";
        }
    }
}
