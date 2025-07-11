using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    private GManager gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = FindAnyObjectByType<GManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            gm.perfect = 0;
            gm.good = 0;
            gm.miss = 0;
            gm.finishScore = 0;
            SceneManager.LoadScene("SelectScene");
        }
    }
}
