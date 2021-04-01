using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class InputCell : MonoBehaviour
{
    public Text NameText;
    public Text warningText;
    public InputField InputField;
    
    public enum InputType
    {
        Name,
        SecondName,
        Password,
        PasswordVerify,
        Mail,
        Phone_Number,
        Code
    }
    public InputType inputType;
    [HideInInspector]public string _Text;
    public List<char> BlackListChars = new List<char>();
    private string chars = "";
    void Start()
    {
        InputField.onValueChanged.AddListener(delegate(string arg0) { Edit(); });
        switch (inputType)
        {
            case InputType.Mail:
            {
                InputField.contentType = InputField.ContentType.EmailAddress; 
                break;
            }
            case InputType.SecondName:
            case InputType.Name:
            {
                InputField.contentType = InputField.ContentType.Name;
                break;
            }
            case InputType.PasswordVerify:
            case InputType.Password:
            {
                InputField.contentType = InputField.ContentType.Password;
                InputField.inputType = InputField.InputType.Password;
                break; 
            }
            case InputType.Code:
            {
                InputField.inputType = InputField.InputType.Standard;
                InputField.contentType = InputField.ContentType.IntegerNumber;
                break;
            }
            case InputType.Phone_Number:
            {
                InputField.contentType = InputField.ContentType.IntegerNumber;
                break;
            }
        }

        for (int i = 0; i < BlackListChars.Count; i++)
        {
            chars += "(" + BlackListChars[i] + ") ";
        }
        LoadInfo();
    }

    public void ChangePasswordVisibility()
    {
        if (InputField.inputType == InputField.InputType.Password)
            InputField.inputType = InputField.InputType.Standard;
        else InputField.inputType = InputField.InputType.Password;
    }

    public bool CheckCorrect()
    { 
        SaveInfo();
        switch (inputType)
        {
            case InputType.Password: { return CheckPassword();}
            
            //case InputType.Mail: { return CheckMail();}
            
            case InputType.Phone_Number: { return CheckPhoneNumber();}
            case InputType.Code:
            {
                if (_Text.Length == 6) return true;
                else
                {
                    warningText.text = "Код должен содержать 6 цифр";
                    return false;
                }
            }
            default: return true;
        }
    }
    

    void Edit()
    {
        _Text = InputField.text;
        warningText.text = "";
    }

    bool CheckPassword()
    {
        if (_Text.Length <= 5)
        {
            warningText.text = "Пароль должен иметь минимум 6 символов";
            return false;
        }
        for (int i = 0; i < _Text.Length; i++)
        {
            for (int j = 0; j < BlackListChars.Count; j++)
            {
                if (_Text[i] == BlackListChars[j])
                {
                    warningText.text = "Пароль не может содержать следующие символы \n " + chars;
                    return false;
                }
            }
        }
        return true;
    }
    bool CheckPhoneNumber()
    {
        char first = '3';
        char second = '8';
        char three = '0';

        char first2 = '0';
        if (_Text[0] == first)
        {
            if (_Text.Length > 1)
            {
                if (_Text[1] == second)
                {
                    if (_Text.Length > 2)
                    {
                        if (_Text[2] == three) return true;
                        else return false;
                    }
                    else return true;
                }
                else return false;
            }
            else return true;
        }
        else if (_Text[0] == first2) return true;
        else return false;
    }

    void SaveInfo()
    {
        switch (inputType)
        {
            case InputType.Mail:
            {
                PlayerPrefs.SetString("mail",_Text);
                PlayerPrefs.Save();
                break;
            }
            case InputType.SecondName:
            {
                PlayerPrefs.SetString("secondName", _Text);
                PlayerPrefs.Save();
                break;
            }
            case InputType.Name:
            {
                PlayerPrefs.SetString("firstName", _Text);
                PlayerPrefs.Save();
                break;
            }
            case InputType.Phone_Number:
            {
                PlayerPrefs.SetString("phoneNumber", _Text);
                PlayerPrefs.Save();
                break;
            }
            case InputType.Password:
            {
                PlayerPrefs.SetString("password", _Text);
                PlayerPrefs.Save();
                break;
            }
        }
    }

    void LoadInfo()
    {
        switch (inputType)
        {
            case InputType.Mail:
            {
                if (PlayerPrefs.HasKey("mail"))
                {
                    _Text = PlayerPrefs.GetString("mail");
                    InputField.text = _Text;
                }
                break;
            }
            case InputType.Password:
            {
                if (PlayerPrefs.HasKey("password"))
                {
                    _Text = PlayerPrefs.GetString("password");
                }
                break;
            }
            case InputType.SecondName:
            {
                if (PlayerPrefs.HasKey("secondName"))
                {
                    _Text = PlayerPrefs.GetString("secondName");
                    InputField.text = _Text;
                }
                break;
            }
            case InputType.Name:
            {
                if (PlayerPrefs.HasKey("firstName"))
                {
                    _Text = PlayerPrefs.GetString("firstName");
                    InputField.text = _Text;
                }
                break;
            }
            case InputType.Phone_Number:
            {
                if (PlayerPrefs.HasKey("phoneNumber"))
                {
                    _Text = PlayerPrefs.GetString("phoneNumber");
                    InputField.text = _Text;
                }
                break;
            }
        }
        
    }

}
