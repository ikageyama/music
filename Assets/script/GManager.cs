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

    //どの音楽を選択しているかどうか
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

    //このスクリプト（クラス）が破棄されるときインスタンスも破棄する。
    private void OnDestroy()
    {
        if (instance == this)
        {
            instance = null;
        }

    }
}
