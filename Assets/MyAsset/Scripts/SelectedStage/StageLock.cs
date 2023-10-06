using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageLock : MonoBehaviour
{
    public int NowStage;
    public GameObject stageNumObject;

    private void Start()
    {
        Button[] stages = stageNumObject.GetComponentsInChildren<Button>();

        NowStage = PlayerPrefs.GetInt("stage");
        Debug.Log(NowStage.ToString());

        for (int i = NowStage + 1; i < stages.Length; i++)
            stages[i].interactable = false;
    }
}
