using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageButtonEvent : MonoBehaviour
{
    public void GoToStage1()
    {
        SceneManager.LoadScene(2);
    }
    public void GoToStage2()
    {
        SceneManager.LoadScene(3);
    }
    public void GoToStage3()
    {
        SceneManager.LoadScene(4);
    }
    public void GoToStage4()
    {
        SceneManager.LoadScene(5);
    }
    public void GoToStage5()
    {
        SceneManager.LoadScene(6);
    }
    public void GoToStage6()
    {
        SceneManager.LoadScene(7);
    }
    public void QuitBtnClick()
    {
        Application.Quit();
    }
}
