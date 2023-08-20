using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class MainMenuManager : MonoBehaviour
{
    public GameObject customizationPanel;
    public GameObject startButton;
    public GameObject customButton;

    public CinemachineVirtualCamera vCam;


    private void Start()
    {
        customizationPanel.SetActive(false);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("a");
    }

    public void OpenCharCustomization()
    {
        startButton.SetActive(false);
        customButton.SetActive(false);
        vCam.Priority = 11;
        customizationPanel.SetActive(true);

    }
    public void CloseCharCustomization()
    {
        vCam.Priority = 10;
        startButton.SetActive(true);
        customButton.SetActive(true);
        customizationPanel.SetActive(false);
    }
}
