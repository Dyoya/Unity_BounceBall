using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int stageIndex = 0;

    public Ball ball;

    public Text UIStage;
    public GameObject ToListButton;
    public GameObject NextStageButton;
    public GameObject ResultToListButton;
    public GameObject RestartButton;


    private void Start()
    {
        PlayerRePosition(stageIndex);
        UIStage.text = "STAGE : " + stageIndex.ToString();
    }
    public void NextStage()
    {

        Debug.Log("게임 클리어!");
        ToListButton.SetActive(false);
        NextStageButton.SetActive(true);
        ResultToListButton.SetActive(true);
        RestartButton.SetActive(true);

        PlayerPrefs.SetInt("stage", stageIndex);
    }
    public void PlayerRePosition(int stage)
    {
        switch(stage)
        {
            case 1:
                ball.transform.position = new Vector2(-13, 2);
                break;
            case 2:
                ball.transform.position = new Vector2(-15, -6);
                break;
            case 3:
                ball.transform.position = new Vector2(-15, 7);
                break;
            case 4:
                ball.transform.position = new Vector2(-15, 7);
                break;
            case 5:
                ball.transform.position = new Vector2(-15, -2);
                break;
            case 6:
                ball.transform.position = new Vector2(-13, 0);
                break;
            default:
                ball.transform.position = new Vector2(0, 0);
                break;
        }    
    }
    public void NextStageBtnClicked()
    {
        if (stageIndex == 6)
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            SceneManager.LoadScene(stageIndex + 2);
        }
    }
    public void ToListBtnClicked()
    {
        SceneManager.LoadScene(1);
    }
    public void RestartBtnClicked()
    {
        SceneManager.LoadScene(stageIndex + 1);
    }
}
