using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Image scoreGage;

    [SerializeField] List<TextMeshProUGUI> uiText = new List<TextMeshProUGUI>();

    public int totalScore;

    public int combo;

    public List<bool> hantei = new List<bool>();

    [SerializeField] SoundManager soundManager;
    [SerializeField] GManager gm;

    [SerializeField]
    private AudioClip clip1; //音源データ1

    [SerializeField]
    private AudioClip clip2; //音源データ2

    [SerializeField]
    private AudioClip clip3; //音源データ3

    public enum UIText
    {
        rank,
        score,
        hantei,
        combo
    }

    public enum HanteiName
    {
        perfect,
        good,
        miss
    }
    void Start()
    {
        gm = FindAnyObjectByType<GManager>();

        StartCoroutine(HanteiReset());
    }

    // Update is called once per frame
    void Update()
    {
        Score();

        float scoreG = (int)totalScore / 28000f;
        scoreGage.fillAmount = scoreG;

        uiText[(int)UIText.score].text = ""+ totalScore;

        uiText[(int)UIText.combo].text = combo + " combo";

        Hantei();
    }

    void Score()
    {
        if (totalScore < 7000)
        {
            uiText[(int)UIText.rank].text = "D";
        }
        if (totalScore >= 7000 && totalScore < 14000)
        {
            uiText[(int)UIText.rank].text = "C";
        }
        if (totalScore >= 14000 && totalScore < 21000)
        {
            uiText[(int)UIText.rank].text = "B";
        }
        if (totalScore >= 21000 && totalScore < 28000)
        {
            uiText[(int)UIText.rank].text = "A";
        }
        if (totalScore >= 28000)
        {
            uiText[(int)UIText.rank].text = "S";
        }
    }

    void Hantei()
    {
        if (hantei[(int)HanteiName.perfect])
        {
            uiText[(int)UIText.hantei].text = "Perfect";
            uiText[(int)UIText.hantei].color = new Color(255, 0, 0);
            soundManager.Play(clip1);
        }

        if (hantei[(int)HanteiName.good])
        {
            uiText[(int)UIText.hantei].text = "Good";
            uiText[(int)UIText.hantei].color = new Color(255, 150, 0);
            soundManager.Play(clip2);
        }

        if (hantei[(int)HanteiName.miss])
        {
            uiText[(int)UIText.hantei].text = "miss";
            uiText[(int)UIText.hantei].color = new Color(0, 0, 255);
            soundManager.Play(clip3);
        }

    }

    IEnumerator HanteiReset()
    {
        while (!gm.finish)
        {
            if (hantei[(int)HanteiName.perfect] || hantei[(int)HanteiName.good] || hantei[(int)HanteiName.miss])
            {
                yield return new WaitForSeconds(0.1f);
                hantei[(int)HanteiName.perfect] = false;
                hantei[(int)HanteiName.good] = false;
                hantei[(int)HanteiName.miss] = false;
            }

            yield return null;
        }
    }
}
