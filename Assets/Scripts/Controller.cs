using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Path.GUIFramework;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public static Controller controller;
    public RegisterPanelManager registerPanelManager;
    public RegistrationVerifyPanel registrationVerifyPanel;
    public LoginPanelManager loginPanelManager;
    public MainPanel mainPanel;
    private void Awake()
    {
        if (!controller) controller = this;
        else Destroy(this);
    }

    private void Start()
    {
        HideLogPanel();
        HideRegPanel();
        HideVerifyPanel();
        ShowRegPanel();
    }

    public void HideRegPanel()
    {
        registerPanelManager.gameObject.SetActive(false);
    }

    public void HideLogPanel()
    {
        loginPanelManager.gameObject.SetActive(false);
    }

    public void HideVerifyPanel()
    {
        registrationVerifyPanel.gameObject.SetActive(false);
    }

    public void ShowRegPanel()
    {
        registerPanelManager.gameObject.SetActive(true);
    }

    public void ShowLogPanel()
    {
        loginPanelManager.gameObject.SetActive(true);
    }

    public void ShowVerifyPanel()
    {
        registrationVerifyPanel.gameObject.SetActive(true);
    }

    public void ShowMainPanel()
    {
        mainPanel.gameObject.SetActive(true);
    }
    

}
