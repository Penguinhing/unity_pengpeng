using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class Data
{
    public List<string> nicknames = new List<string>();
    public List<int> scores = new List<int>();

}




public class RankManager : MonoBehaviour
{
    public static RankManager instance = null;

    private string savePath;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            savePath = Application.persistentDataPath + "/saves/ranking.json";
        }
    }


    public Data Load()
    {
        FileInfo file = new FileInfo(savePath);
        if (!file.Exists) { // 파일이 존재하지 않는 경우
            return null;
        }

        string jsonData = File.ReadAllText(savePath);
        return JsonUtility.FromJson<Data>(jsonData);
    }


    public void Save(string nickname, int score)
    {
        Data data = Load();

        nickname = (nickname == "") ? "익명" : nickname;

        if (data != null) 
        {
            data.nicknames.Add(nickname);
            data.scores.Add(score);

            // 선택 정렬로 내림차순 정렬
            for (int i = 0; i < data.nicknames.Count - 1; ++i) // 0 ~ 3 
            {
                int maxIndex = i; // 최댓값을 저장할 인덱스
                for (int j = i + 1; j < data.nicknames.Count; ++j) // i+1 ~ 4
                {
                    if (data.scores[maxIndex] < data.scores[j])
                    {
                        maxIndex = j;
                    }
                }

                // 최댓값 변경
                int tmp = data.scores[i];
                string _tmp = data.nicknames[i];
                data.scores[i] = data.scores[maxIndex];
                data.nicknames[i] = data.nicknames[maxIndex];
                data.scores[maxIndex] = tmp;
                data.nicknames[maxIndex] = _tmp;
            }
        }
        else
        { // 최초 등록의 경우
            data = new Data();
            data.nicknames.Add(nickname);
            data.scores.Add(score);
        }



        while (data.nicknames.Count > 10)
        {
            data.scores.RemoveAt(10);
            data.nicknames.RemoveAt(10);
        }
        
       

        string jsonData = JsonUtility.ToJson(data);
        File.WriteAllText(savePath, jsonData);
    }
}
