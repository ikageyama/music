using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GManager : MonoBehaviour
{
    public static GManager instance = null;

    public int perfect;

    public int good;

    public int miss;

    public int finishScore;

    public bool finish;

    //�ǂ̉��y��I�����Ă��邩�ǂ���
    public List<bool> musicbool = new List<bool>();
    public int musicindex;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    //���̃X�N���v�g�i�N���X�j���j�������Ƃ��C���X�^���X���j������B
    private void OnDestroy()
    {
        if (instance == this)
        {
            instance = null;
        }

    }
}
