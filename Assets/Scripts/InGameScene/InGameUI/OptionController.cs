using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionController : MonoBehaviour
{
    public GameObject optionScreen;
    public GameObject optionButton;
    public GameObject fade;

    public GameObject resetMenu;
    public GameObject stopMenu;
    public GameObject settingMenu;

    public Slider volumeSlider;
    private float prevValue;

    private void Update()
    {
        AudioListener.volume = volumeSlider.value;
    }

    public void OpenOptionScreen()
    {
        Time.timeScale = 0f;
        optionScreen.SetActive(true);
        optionButton.SetActive(false);
    }

    public void ContinueButton()
    {
        Time.timeScale = 1f;
        optionButton.SetActive(true);
        optionScreen.SetActive(false);
    }

    public void ResetButton()
    {
        fade.SetActive(true);
        resetMenu.SetActive(true);
    }

    public void SettingButton()
    {
        fade.SetActive(true);
        settingMenu.SetActive(true);
        prevValue = volumeSlider.value;
    }

    public void StopButton()
    {
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

    public void SettingSaveButton()
    {
        settingMenu.SetActive(false);
        fade.SetActive(false);
    }

    public void SettingCancelButton()
    {
        volumeSlider.value = prevValue;
        AudioListener.volume = volumeSlider.value;
        settingMenu.SetActive(false);
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
