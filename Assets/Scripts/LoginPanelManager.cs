using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginPanelManager : MonoBehaviour
{
    public InputField Phone_Input;
    public InputField Password_Input;
    public Button button;

    public DataBaseManager DB;

    public void Edit()
    {
        string obj1 = Phone_Input.text;
        string obj2 = Password_Input.text;

        if (obj1.Length == 12 && obj2.Length >= 6) button.interactable = true;
        else button.interactable = false;
    }

    public void Login()
    {
        string _phone = Phone_Input.text;
        string _password = Password_Input.text;
        bool phoneCor = false;
        bool passCor = false;
        if (_phone != null && _phone.Length > 2 && _phone[0] == '3' && _phone[1] == '8' && _phone[2] == '0')
        {
            if (_phone != null &&  _phone.Length == 12) phoneCor = true;
        }
        if (_password != null && _password.Length >= 6) passCor = true;
        
        if(passCor && phoneCor) DB.TryLogin(_phone, _password); 
    }
}
