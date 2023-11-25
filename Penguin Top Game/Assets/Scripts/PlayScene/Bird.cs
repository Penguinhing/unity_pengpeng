using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class Bird : MonoBehaviour
{


    [SerializeField]
    GameObject timeCapsule;


    // 떠나기 관련 변수
    private float leaveTimer = 0.0f;
    private const float leaveTime = 6.0f;


    // 애니메이션 관련 변수
    private float aniTimer = 0.0f;
    private float aniDelay = 1.0f;
    private bool endAnim = false;
    private Animator animator;

    private AudioSource[] sound;


    void Awake()
    {
        animator = GetComponent<Animator>();
        sound = GetComponents<AudioSource>();
    }

    void Start()
    {
        StartCoroutine(Appear());
    }

    void Update()
    {


        animate();
        OnClick(); // 클릭되었을 때


        leaveTimer += Time.deltaTime;
        if(leaveTimer >= leaveTime)
        {
            leaveTimer = 0.0f;
            StartCoroutine(Leave());
        }

        

    }



    public IEnumerator Appear()
    {
        sound[0].Play();
        while (transform.position.y > 2.85)
        {
            transform.position += Vector3.down * 1.5f * Time.deltaTime;
            yield return null;
        }
    }



    public IEnumerator Leave()
    {
        sound[0].Play();
        while (transform.position.y < 6.0f)
        {
            transform.position += Vector3.up * 1.5f * Time.deltaTime;
            yield return null;
        }
        Destroy(gameObject);
    }




    void animate()
    {
        // 애니메이션 1초에 한번씩 반복
        if (endAnim == true)
        {
            aniTimer += Time.deltaTime;
        }

        if (aniTimer >= aniDelay)
        {
            animator.Play("bird", -1, 0f);
            aniTimer = 0f;
            endAnim = false;
        }
    }
   




    void OnClick()
    {
        

        if (Input.GetMouseButtonDown(0))
        {
            
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);
            if (hit.collider != null && hit.collider.name.Contains("Bird"))
            {
                SoundManager.instance.PlayBirdClickSound();
                Destroy(hit.collider.gameObject);
                Instantiate(timeCapsule, new Vector3(transform.position.x - 0.25f, transform.position.y - 0.35f, transform.position.z), transform.rotation);
            }

        }
    }

    /*
     * 애니메이션 종료 시 실행되는 함수
     */
    void EndAnimation()
    {
        endAnim = true;
    }
}
