using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject LoginPanel;
    public GameObject RegisterPanel;
    
    




    public void OpenLoginPanel()
    {
        RegisterPanel.SetActive(false);
        LoginPanel.SetActive(true);
    }

    public void OpenRegisterPanel()
    {
        LoginPanel.SetActive(false);
        RegisterPanel.SetActive(true);
    }


    public void ActiveRegisterButton()
    {
        
    }
}
