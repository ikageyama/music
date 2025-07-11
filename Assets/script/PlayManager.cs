using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayManager : MonoBehaviour
{
    [SerializeField] GManager gm;

    [SerializeField] List<GameObject> soundDecision = new List<GameObject>();

    void Awake()
    {
        gm = FindAnyObjectByType<GManager>();
        SoundSelect();
    }

    //���U���g��ʂɈڍs
    void Update()
    {
        if (gm.finish)
        {
            SceneManager.LoadScene("FinishScene");
            gm.finish = false;
        }
    }
    //�Ȃ̑I��
    void SoundSelect()
    {
        for (int i = 0; i < gm.musicbool.Count; i++)
        {
            if (gm.musicbool[i])
            {
                soundDecision[i].SetActive(true);
            }
        }
    }
}
