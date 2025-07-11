using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectManager : MonoBehaviour
{
    [SerializeField] List<Button> select_button = new List<Button>();

    [SerializeField] Button operation_button;

    [SerializeField] Button operation_close;

    [SerializeField] Button title_button;

    [SerializeField] GameObject operation_Canvas;

    [SerializeField] GManager gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = FindAnyObjectByType<GManager>();

        //‹È‚Ì‘I‘ð
        for(int i = 0; i < select_button.Count; i++)
        {
            int index = i;
            select_button[i].onClick.AddListener(() => 
            {
                gm.musicindex = index;
                gm.musicbool[index] = true;
                SceneManager.LoadScene("PlayScene");
            });
        }

        title_button.onClick.AddListener(() => SceneManager.LoadScene("TitleScene"));

        operation_button.onClick.AddListener(() => operation_Canvas.SetActive(true));
        operation_close.onClick.AddListener(() => operation_Canvas.SetActive(false));
    }

}
