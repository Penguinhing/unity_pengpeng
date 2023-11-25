using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneButton : MonoBehaviour
{
    public void OnClickStart()
    {
        SceneManager.LoadScene("Play");
    }

    public void OnClickRanking()
    {
        SceneManager.LoadScene("Ranking");
    }
}
