
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NotesManager : MonoBehaviour
{
    [SerializeField] List<Transform> notes_trans = new List<Transform>();

    [SerializeField] GameObject notes;

    GManager gm;

    [SerializeField] NotesDataAsset notesdata;

    float playTime;
    float finishTime;
    [SerializeField] List<float> finishtimelist = new List<float>();

    bool[] isCreatedOne;
    bool[] isCreatedTwo;
    bool[] isCreatedThree;
    bool[] isCreatedFour;

    // Start is called before the first frame update
    void Start()
    {
        gm = FindAnyObjectByType<GManager>();

        isCreatedOne = new bool[notesdata.notesdataList[gm.musicindex].oneline.Count];
        isCreatedTwo = new bool[notesdata.notesdataList[gm.musicindex].twoline.Count];
        isCreatedThree = new bool[notesdata.notesdataList[gm.musicindex].threeline.Count];
        isCreatedFour = new bool[notesdata.notesdataList[gm.musicindex].fourline.Count];

        NotesCreate(isCreatedOne);
        NotesCreate(isCreatedTwo);
        NotesCreate(isCreatedThree);
        NotesCreate(isCreatedFour);

        for(int i = 0; i < gm.musicbool.Count; i++)
        {
            if (gm.musicbool[i])
            {
                finishTime = finishtimelist[i];
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        playTime += Time.deltaTime;

        NotesGenerate(notesdata.notesdataList[gm.musicindex].oneline.Count, notesdata.notesdataList[gm.musicindex].oneline, isCreatedOne, notes_trans[0]);
        NotesGenerate(notesdata.notesdataList[gm.musicindex].twoline.Count, notesdata.notesdataList[gm.musicindex].twoline, isCreatedTwo, notes_trans[1]);
        NotesGenerate(notesdata.notesdataList[gm.musicindex].threeline.Count, notesdata.notesdataList[gm.musicindex].threeline, isCreatedThree, notes_trans[2]);
        NotesGenerate(notesdata.notesdataList[gm.musicindex].fourline.Count, notesdata.notesdataList[gm.musicindex].fourline, isCreatedFour, notes_trans[3]);

            if (playTime >= finishTime)
            {
                gm.finish = true;
            }


    }

    void NotesCreate(bool[] isCreated)
    {
        isCreated = isCreated.Select((bool b) => b = false).ToArray();
    }
    
    void NotesGenerate(int index, List<float> timedata, bool[] isCreated, Transform trans)
    {
        for (int i = 0; i < index; i++)
        {
            if (playTime >= timedata[i] && !isCreated[i])
            {
                isCreated[i] = true;
                Instantiate(notes, trans.position, trans.localRotation);
            }
        }
    }
}
