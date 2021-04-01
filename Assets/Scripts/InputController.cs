using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngineInternal;

public class InputController : MonoBehaviour
{
    private InputField _InputField;
    public enum InputType
    {
        Name,
        Password,
        Mail,
        Phone_Number
    }
    public InputType inputType;
    public bool Correct;
    public string _Text;

    public Text InputTextField;
    public Text WarningText;

    private string lastText;
    private void Update()
    {
        string txt = InputTextField.text;
        if (txt == lastText) return;
        else Edit();
        lastText = InputTextField.text;
    }

    private void Start()
    {
        _InputField = GetComponent<InputField>();
    }

    public void Edit()
    {
        string text = _InputField.text;
        if (text != null && text.Length > 0)
        {
            char lastSymbol = text[text.Length - 1];
            switch (inputType)
            {
                case InputType.Phone_Number:{EditNumber(text,lastSymbol); break;}
                case InputType.Name:{EditName(text,lastSymbol); break;}
                case InputType.Mail:{EditMail(text,lastSymbol); break;}
                case InputType.Password: {EditPassword(text,lastSymbol); break;}
            }
            
        }
        
    }

    void EditNumber(string allText, char last)
    {
        bool corr = CheckNumber(allText);
        if (corr)
        {
            if (allText.Length == 10) _Text = "38" + allText;
            else if (allText.Length == 12) _Text = allText;
            else WarningText.text = "Неправильно указаный номер";
        }
        else WarningText.text = "Неправильный формат номера";
    }

    void EditName(string allText, char last)
    {
        if(allText[0] >= 'А' && allText[0] <= 'Я') Debug.Log("Буква заглавная");
    }

    void EditPassword(string allText, char last)
    {
        
    }

    void EditMail(string allText, char last)
    {
        
    }

    bool CheckNumber(string number)
    {
        char first = '3';
        char second = '8';
        char three = '0';

        char first2 = '0';
        if (number[0] == first)
        {
            if (number.Length > 1)
            {
                if (number[1] == second)
                {
                    if (number.Length > 2)
                    {
                        if (number[2] == three) return true;
                        else return false;
                    }
                    else return true;
                }
                else return false;
            }
            else return true;
        }
        else if (number[0] == first2) return true;
        else return false;
    }
    
    
}
