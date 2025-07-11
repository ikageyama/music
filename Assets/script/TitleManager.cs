using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{
    //�X�^�[�g�{�^��
    [SerializeField] Button start_button;
    //�I���{�^��
    [SerializeField] Button exit_button;

    // Start is called before the first frame update
    void Start()
    {
        //�I����ʂɈړ�
        start_button.onClick.AddListener(() => { SceneManager.LoadScene("SelectScene"); });
        //�Q�[�����I������
        exit_button.onClick.AddListener(() =>
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;//�Q�[���v���C�I��
#else
                       Application.Quit();//�Q�[���v���C�I��
#endif
        });
    }

}
