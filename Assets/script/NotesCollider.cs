using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using static UIManager;

public class NotesCollider : MonoBehaviour
{
    //各列の当たり判定
    [SerializeField] List<GameObject> notes_collider = new List<GameObject>();

    //ノーツの速さ
    [SerializeField] float notes_speed;

    //押したキーの種類
    [SerializeField] List<bool> keyKindDown = new List<bool>();
    //パーフェクトを取ったキーの種類
    [SerializeField] List<bool> keykindPerfect = new List<bool>();
    //グットを取ったキーの種類
    [SerializeField] List<bool> keykindGood = new List<bool>();
    //ミスを取ったキーの種類
    [SerializeField] List<bool> keykindMiss = new List<bool>(); 
    //判定のbool
    [SerializeField] List<bool> judgment = new List<bool>();

    UIManager uiManager;
    GManager gm;

    public enum KeyName
    {
        dkey,
        fkey,
        jkey,
        kkey
    }

    public enum Judge
    {
        perfect,
        good,
        miss
    }

    // Start is called before the first frame update
    void Start()
    {
        uiManager = FindAnyObjectByType<UIManager>();
        gm = FindAnyObjectByType<GManager>();

    }

    // Update is called once per frame
    void Update()
    {
        DistanceCollider();

        var speed = Vector3.zero;

        speed.z -= notes_speed;

        transform.Translate(speed);

        Get_Key();

        JudgeDkey();
        JudgeFkey();
        JudgeJkey();
        JudgeKkey();

        //パーフェクト時の更新
        if (judgment[(int)Judge.perfect])
        {
            uiManager.totalScore += 200;
            uiManager.hantei[(int)HanteiName.perfect] = true;
            uiManager.combo++;
            gm.perfect++;
            gm.finishScore += 200;
            judgment[(int)Judge.perfect] = false;
        }
        //グット時の更新
        if (judgment[(int)Judge.good])
        {
            uiManager.totalScore += 100;
            uiManager.hantei[(int)HanteiName.good] = true;
            uiManager.combo++;
            gm.good++;
            gm.finishScore += 100;
            judgment[(int)Judge.good] = false;
        }
        //ミスした時の更新
        if (judgment[(int)Judge.miss])
        {
            uiManager.hantei[(int)HanteiName.miss] = true;
            uiManager.combo = 0;
            gm.miss++;
            Destroy(this.gameObject);
        }
    }
    //各列の距離判定
    void DistanceCollider()
    {
        //1列目の距離判定
        float onedis = Vector3.Distance(this.transform.position, notes_collider[0].transform.position);

        if (onedis <= 2)
        {
            keykindPerfect[(int)KeyName.dkey] = true;
            keykindGood[(int)KeyName.dkey] = false;
            keykindMiss[(int)KeyName.dkey] = false;
        }
        else if(onedis <= 4)
        {
            keykindPerfect[(int)KeyName.dkey] = false;
            keykindGood[(int)KeyName.dkey] = true;
            keykindMiss[(int)KeyName.dkey] = false;
        }
        else if (onedis <= 6)
        {
            keykindPerfect[(int)KeyName.dkey] = false;
            keykindGood[(int)KeyName.dkey] = false;
            keykindMiss[(int)KeyName.dkey] = true;
        }
        else
        {
            keyKindDown[(int)KeyName.dkey] = false;
        }

            //2列目の距離判定
            float twodis = Vector3.Distance(this.transform.position, notes_collider[1].transform.position);

        if (twodis <= 2)
        {
            keykindPerfect[(int)KeyName.fkey] = true;
            keykindGood[(int)KeyName.fkey] = false;
            keykindMiss[(int)KeyName.fkey] = false;
        }
        else if (twodis <= 4)
        {
            keykindPerfect[(int)KeyName.fkey] = false;
            keykindGood[(int)KeyName.fkey] = true;
            keykindMiss[(int)KeyName.fkey] = false;
        }
        else if (twodis <= 6)
        {
            keykindPerfect[(int)KeyName.fkey] = false;
            keykindGood[(int)KeyName.fkey] = false;
            keykindMiss[(int)KeyName.fkey] = true;
        }
        else
        {
            keyKindDown[(int)KeyName.fkey] = false;
        }

        //3列目の距離判定
        float threedis = Vector3.Distance(this.transform.position, notes_collider[2].transform.position);

        if (threedis <= 2)
        {
            keykindPerfect[(int)KeyName.jkey] = true;
            keykindGood[(int)KeyName.jkey] = false;
            keykindMiss[(int)KeyName.jkey] = false;
        }
        else if (threedis <= 4)
        {
            keykindPerfect[(int)KeyName.jkey] = false;
            keykindGood[(int)KeyName.jkey] = true;
            keykindMiss[(int)KeyName.jkey] = false;
        }
        else if (threedis <= 6)
        {
            keykindPerfect[(int)KeyName.jkey] = false;
            keykindGood[(int)KeyName.jkey] = false;
            keykindMiss[(int)KeyName.jkey] = true;
        }
        else
        {
            keyKindDown[(int)KeyName.jkey] = false;
        }

        float fourdis = Vector3.Distance(this.transform.position, notes_collider[3].transform.position);

        if (fourdis <= 2)
        {
            keykindPerfect[(int)KeyName.kkey] = true;
            keykindGood[(int)KeyName.kkey] = false;
            keykindMiss[(int)KeyName.kkey] = false;
        }
        else if (fourdis <= 4)
        {
            keykindPerfect[(int)KeyName.kkey] = false;
            keykindGood[(int)KeyName.kkey] = true;
            keykindMiss[(int)KeyName.kkey] = false;
        }
        else if (fourdis <= 6)
        {
            keykindPerfect[(int)KeyName.kkey] = false;
            keykindGood[(int)KeyName.kkey] = false;
            keykindMiss[(int)KeyName.kkey] = true;
        }
        else
        {
            keyKindDown[(int)KeyName.kkey] = false;
        }
    }
    //各キーの判定を入手
    void Get_Key()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            keyKindDown[(int)KeyName.dkey] = true;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            keyKindDown[(int)KeyName.fkey] = true;
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            keyKindDown[(int)KeyName.jkey] = true;
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            keyKindDown[(int)KeyName.kkey] = true;
        }
    }
   
    void JudgeDkey()
    {
        if (keyKindDown[(int)KeyName.dkey] && keykindPerfect[(int)KeyName.dkey])
        {
            Destroy(this.gameObject);
            keyKindDown[(int)KeyName.dkey] = false;
            keykindPerfect[(int)KeyName.dkey] = false;
            judgment[(int)Judge.perfect] = true;
        }

        if (keyKindDown[(int)KeyName.dkey] && keykindGood[(int)KeyName.dkey])
        {
            Destroy(this.gameObject);
            keyKindDown[(int)KeyName.dkey] = false;
            keykindGood[(int)KeyName.dkey] = false;
            judgment[(int)Judge.good] = true;
        }

        if (keyKindDown[(int)KeyName.dkey] && keykindMiss[(int)KeyName.dkey])
        {
            Destroy(this.gameObject);
            keyKindDown[(int)KeyName.dkey] = false;
            keykindMiss[(int)KeyName.dkey] = false;
            judgment[(int)Judge.miss] = true;
        }
    }
   
    void JudgeFkey()
    {
        if (keyKindDown[(int)KeyName.fkey] && keykindPerfect[(int)KeyName.fkey])
        {
            Destroy(this.gameObject);
            keyKindDown[(int)KeyName.fkey] = false;
            keykindPerfect[(int)KeyName.fkey] = false;
            judgment[(int)Judge.perfect] = true;
        }

        if (keyKindDown[(int)KeyName.fkey] && keykindGood[(int)KeyName.fkey])
        {
            Destroy(this.gameObject);
            keyKindDown[(int)KeyName.fkey] = false;
            keykindGood[(int)KeyName.fkey] = false;
            judgment[(int)Judge.good] = true;
        }

        if (keyKindDown[(int)KeyName.fkey] && keykindMiss[(int)KeyName.fkey])
        {
            Destroy(this.gameObject);
            keyKindDown[(int)KeyName.fkey] = false;
            keykindMiss[(int)KeyName.fkey] = false;
            judgment[(int)Judge.miss] = true;
        }
    }
   
    void JudgeJkey()
    {
        if (keyKindDown[(int)KeyName.jkey] && keykindPerfect[(int)KeyName.jkey])
        {
            Destroy(this.gameObject);
            keyKindDown[(int)KeyName.jkey] = false;
            keykindPerfect[(int)KeyName.jkey] = false;
            judgment[(int)Judge.perfect] = true;
        }

        if (keyKindDown[(int)KeyName.jkey] && keykindGood[(int)KeyName.jkey])
        {
            Destroy(this.gameObject);
            keyKindDown[(int)KeyName.jkey] = false;
            keykindGood[(int)KeyName.jkey] = false;
            judgment[(int)Judge.good] = true;
        }

        if (keyKindDown[(int)KeyName.jkey] && keykindMiss[(int)KeyName.jkey])
        {
            Destroy(this.gameObject);
            keyKindDown[(int)KeyName.jkey] = false;
            keykindMiss[(int)KeyName.jkey] = false;
            judgment[(int)Judge.miss] = true;
        }
    }
   
    void JudgeKkey()
    {
        if (keyKindDown[(int)KeyName.kkey] && keykindPerfect[(int)KeyName.kkey])
        {
            Destroy(this.gameObject);
            keyKindDown[(int)KeyName.kkey] = false;
            keykindPerfect[(int)KeyName.kkey] = false;
            judgment[(int)Judge.perfect] = true;
        }

        if (keyKindDown[(int)KeyName.kkey] && keykindGood[(int)KeyName.kkey])
        {
            Destroy(this.gameObject);
            keyKindDown[(int)KeyName.kkey] = false;
            keykindGood[(int)KeyName.kkey] = false;
            judgment[(int)Judge.good] = true;
        }

        if (keyKindDown[(int)KeyName.kkey] && keykindMiss[(int)KeyName.kkey])
        {
            Destroy(this.gameObject);
            keyKindDown[(int)KeyName.kkey] = false;
            keykindMiss[(int)KeyName.kkey] = false;
            judgment[(int)Judge.miss] = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Miss hantei"))
        {
            judgment[(int)Judge.miss] = true;
        }
    }

}
