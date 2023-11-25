using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class StartRankScene : MonoBehaviour
{

    void Start()
    {
        Data ranking = RankManager.instance.Load();

        if (ranking != null )
        {
            TextMeshProUGUI[] rankText = GameObject.Find("Layout").gameObject.GetComponentsInChildren<TextMeshProUGUI>();

            for (int i = 0; i < ranking.nicknames.Count; ++i)
            {
                string t = string.Format("{0}µî {1} {2}Á¡", i + 1, ranking.nicknames[i], ranking.scores[i]);
                rankText[i].SetText(t);
            }
        }
    }


}
