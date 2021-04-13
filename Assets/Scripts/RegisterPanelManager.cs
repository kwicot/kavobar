using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class RegisterPanelManager : MonoBehaviour
{
    public UIManager UI;
    public DataBaseManager DB;

    public List<InputCell> Cells = new List<InputCell>();
    public Button RegisterButton;


    
    /*public void NameEdit()
    {
        
        string obj = UserName_input.text;
        if (obj.Length >= 1)
        {


            char last = obj[obj.Length - 1];
            if (last == ' ' | last == '_')
            {
                UserName_input.text = _name;
                //TODO Вывод сообщения (Имя может содержать только латинскией буквы)

            }
            else
            {
                _name = obj;
            }
        }

        CheckInput();
    }

    public void EndNameEdit()
    {
        CheckInput();
    }

    public void PhoneEdit()
    {
        string obj = PhoneNumber_input.text;
        if (obj.Length > 0)
        {
            char last = obj[obj.Length - 1];
            if (last >= '0' && last <= '9' && obj.Length <= 12)
            {
                _phone = obj;
            }
            else
            {
                PhoneNumber_input.text = _phone;
                //TODO Вывод сообщения (Номер телефона может содержать только цифры от 0 до 9)
            }

            if (obj.Length > 2)
            {
                if (obj[0] != '3' || obj[1] != '8' || obj[2] != '0')
                    PhoneNumber_InputError.text = "Номер должен начинаться с 380";
                else
                    PhoneNumber_InputError.text = "";
            }
        }
        CheckInput();
    }

    public void PasswordEdit()
    {
        _password = Password_input.text;
        CheckInput();
    } */

    
    private void Update()
    {
        
    }

    public void Register()
    {
        string _name = "";
        string _secondName = "";
        string _password = "";
        string _phone = "";
        string _mail = "";

        string firstPass = " ";
        string secondPass = "    ";
        for (int i = 0; i < Cells.Count; i++)
        {
            InputCell cell = Cells[i];
            
            if (!cell.CheckCorrect()) return;
            switch (cell.inputType)
            {
                case InputCell.InputType.Mail:
                {
                    _mail = cell._Text;
                    break;
                }
                case InputCell.InputType.Name:
                {
                    _name = cell._Text;
                    break;
                }
                case InputCell.InputType.SecondName:
                {
                    _secondName = cell._Text;
                    break;
                }
                case InputCell.InputType.Password:
                {
                    _password = cell._Text;
                    firstPass = cell._Text;
                    break;
                }
                case InputCell.InputType.PasswordVerify:
                {
                    secondPass = cell._Text;
                    break;
                }
                case InputCell.InputType.Phone_Number:
                {
                    _phone = cell._Text;
                    break;
                }
            }
        }
        if (firstPass != secondPass)
        {
            for (int i = 0; i < Cells.Count; i++)
            {
                InputCell cell = Cells[i];
                if (cell.inputType == InputCell.InputType.Password | cell.inputType == InputCell.InputType.PasswordVerify)
                {
                    cell.warningText.text = "Пароли не совпадают";
                    return;
                }
            }
        }
        
        DB.TryRegistration(_name,_secondName,_password,_phone,_mail);
        RegisterButton.interactable = false;
    }

    public void ActiveButton()
    {
        RegisterButton.interactable = true;
    }


   /* void CheckInput()
    {
        bool nameCor = false;
        bool phoneCor = false;
        bool passCor = false;

        if (_name != null && _name.Length > 4) nameCor = true;
        if (_phone != null && _phone.Length > 2 && _phone[0] == '3' && _phone[1] == '8' && _phone[2] == '0')
        {
            if (_phone != null &&  _phone.Length == 12) phoneCor = true;
        }
        if (_password != null && _password.Length >= 6) passCor = true;

        if (nameCor && phoneCor && passCor) RegisterButton.interactable = true;
        else RegisterButton.interactable = false;
            
    } */
}
