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
    public Button RegisterButton;


    private Text ButtonText;
    private void Start()
    {
        string txt = "На указаную почту " + DB.mail + " отправлен код регистрации \n Введите его в поле ниже";
        InfoText.text = txt;
        ButtonText = RegisterButton.transform.GetChild(0).GetComponent<Text>();
    }

    private float t = 0;

    private void Update()
    {
        t -= Time.deltaTime;
        if (t <= 0)
        {
            RegisterButton.interactable = true;
            ButtonText.text = "Отправить код";
        }
        else
        {
            RegisterButton.interactable = false;
            ButtonText.text = Math.Round(t) + " сек";
        }
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

