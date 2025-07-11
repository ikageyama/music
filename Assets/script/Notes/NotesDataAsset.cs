using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MyScriptable/Create NotesData")]
public class NotesDataAsset : ScriptableObject
{
    public List<NotesData> notesdataList = new List<NotesData>();
}

[System.Serializable]
public class NotesData
{
    public List<float> oneline = new List<float>();
    public List<float> twoline = new List<float>();
    public List<float> threeline = new List<float>();
    public List<float> fourline = new List<float>();
}
