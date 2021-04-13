using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginPanelManager : MonoBehaviour
{
    public List<InputCell> Cells = new List<InputCell>();
    public Button button;

    public DataBaseManager DB;

    private void Start()
    {
        if (PlayerPrefs.HasKey("password") && PlayerPrefs.HasKey("mail"))
        {
            DB.TryLogin(PlayerPrefs.GetString("mail"),PlayerPrefs.GetString(("password")));
        }
    }

    public void Login()
    {
        string _phone = "";
        string _password = "";
        for (int i = 0; i < Cells.Count; i++)
        {
            InputCell cell = Cells[i];
            if (!cell.CheckCorrect()) return;
            if (cell.inputType == InputCell.InputType.Password) _password = cell._Text;
            if (cell.inputType == InputCell.InputType.Mail) _phone = cell._Text;
        }
        DB.TryLogin(_phone,_password);

    }
}
