using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinishManager : MonoBehaviour
{
    GManager gm;

    [SerializeField] List<TextMeshProUGUI> judgeText = new List<TextMeshProUGUI>();

    [SerializeField] Button backbutton;

    public enum JudgeName
    {
        perfect,
        good,
        miss,
        score
    }
    // Start is called before the first frame update
    void Start()
    {
        gm = FindAnyObjectByType<GManager>();

        for(int i = 0; i < gm.musicbool.Count; i++)
        {
            gm.musicbool[i] = false;
        }

        judgeText[(int)JudgeName.perfect].text = "Perfect: " + gm.perfect;
        judgeText[(int)JudgeName.good].text = "Good: " + gm.good;
        judgeText[(int)JudgeName.miss].text = "Miss: " + gm.miss;
        judgeText[(int)JudgeName.score].text = "Score: " + gm.finishScore;

        backbutton.onClick.AddListener(() => 
        {
            gm.perfect = 0;
            gm.good = 0;
            gm.miss = 0;
            gm.finishScore = 0;
            SceneManager.LoadScene("SelectScene"); 
        });
    }

}
