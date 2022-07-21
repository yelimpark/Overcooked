using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionController : MonoBehaviour
{
    public GameObject optionScreen;
    public GameObject optionButton;
    public GameObject fade;

    public GameObject resetMenu;
    public GameObject stopMenu;

    public void OpenOptionScreen()
    {
        optionScreen.SetActive(true);
        optionButton.SetActive(false);
    }

    public void ContinueButton()
    {
        optionButton.SetActive(true);
        optionScreen.SetActive(false);
    }

    public void ResetButton()
    {
        fade.SetActive(true);
        resetMenu.SetActive(true);
    }

    public void StopButton()
    {
        Debug.Log("stop");
        fade.SetActive(true);
        stopMenu.SetActive(true);
    }

    public void ResetApproveButton()
    {
        SceneManager.LoadScene("LoadingScene");
    }

    public void ResetCancelButton()
    {
        resetMenu.SetActive(false);
        fade.SetActive(false);
    }

    public void StopApproveeButton()
    {
        SceneManager.LoadScene("WorldScene");
    }

    public void StopCancelButton()
    {
        stopMenu.SetActive(false);
        fade.SetActive(false);
    }
}
