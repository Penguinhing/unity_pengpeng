using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SaveScoreButton : MonoBehaviour
{

    private GameObject scoreSavePanel;
    private TMP_InputField inputField;


    private void Awake()
    {
        scoreSavePanel = GameObject.Find("ScoreSavePanel").gameObject;
        inputField = scoreSavePanel.GetComponentInChildren<TMP_InputField>();
    }

    public void save()
    {
        scoreSavePanel.SetActive(false);
        RankManager.instance.Save(inputField.text, GameManager.instance.GetScore());
    }
}
