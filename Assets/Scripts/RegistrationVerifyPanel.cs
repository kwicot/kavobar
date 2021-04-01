using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegistrationVerifyPanel : MonoBehaviour
{
    public InputCell Cell;
    public Text InfoText;
    public  DataBaseManager DB;

    private void Start()
    {
        string txt = "На указаную почту " + DB.mail + " отправлен код регистрации \n Введите его в поле ниже";
        InfoText.text = txt;
    }

    public void Verify()
    {
        if (Cell.CheckCorrect())
        {
            string code = Cell._Text;
            DB.TryVerifyCode(code);
        }
    }
}
