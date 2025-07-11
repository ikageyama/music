using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{
    //スタートボタン
    [SerializeField] Button start_button;
    //終了ボタン
    [SerializeField] Button exit_button;

    // Start is called before the first frame update
    void Start()
    {
        //選択画面に移動
        start_button.onClick.AddListener(() => { SceneManager.LoadScene("SelectScene"); });
        //ゲームを終了する
        exit_button.onClick.AddListener(() =>
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;//ゲームプレイ終了
#else
                       Application.Quit();//ゲームプレイ終了
#endif
        });
    }

}
