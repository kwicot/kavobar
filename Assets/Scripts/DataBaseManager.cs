using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DataBaseManager : MonoBehaviour
{
    public string URL_RegisterPHP;
    public string URL_LoginPHP;
    public string URL_VerifyCodePHP;
    private string phoneNumber;
    private string firstName;
    private string secondName;
    private string password;
    [HideInInspector]public string mail;
    Controller CC => Controller.controller;

    public void TryRegistration(string _firstName,string _secondName, string _pass, string _number,string _mail)
    {
        phoneNumber = _number;
        firstName = _firstName;
        secondName = _secondName;
        password = _pass;
        mail = _mail;
        StartCoroutine(Register());
    }

    public void TryVerifyCode(string code)
    {
        StartCoroutine(VerifyCode(code));
    }

    public void TryLogin(string phone, string pass)
    {
        password = pass;
        StartCoroutine(Login(phone));
    }

    IEnumerator VerifyCode(string code)
    {
        WWWForm form = new WWWForm();
        form.AddField("code",code);
        form.AddField("mail",mail);
        WWW request = new WWW(URL_VerifyCodePHP,form);
        yield return request;
        if (request.error != null)
        {
            Debug.LogError(request.error);
            yield break;
        }
        Logic(request.text);
    }
    private IEnumerator Register()
    {
        WWWForm form = new WWWForm();
        form.AddField("firstName", firstName);
        form.AddField("secondName", firstName);
        form.AddField("pass",password);
        form.AddField("phone",phoneNumber);
        form.AddField("mail",mail);

        WWW request = new WWW(URL_RegisterPHP,form);
        
        yield return request;
        
        if (request.error != null)
        {
            Debug.LogError(request.error);
            yield break;
        }
        
        Logic(request.text);
    }

    IEnumerator Login(string login)
    {
        WWWForm form = new WWWForm();
        form.AddField("pass",password);
        form.AddField("login",login);
        WWW request = new WWW(URL_LoginPHP,form);
        yield return request;
        
        if (request.error != null)
        {
            Debug.LogError(request.error);
            yield break;
        }
        
        Logic(request.text);
    }

    void Logic(string txt)
    {
        Debug.Log(txt);
        switch (txt)
        {
            case "1": //Пользователь с таким номером уже зарегестрирован
            {
                TextOutput.txt.Show("Пользователь с таким номером уже зарегестрирован");
                CC.registerPanelManager.ActiveButton();
                break;
            }
            case "2": //Неверный номер
            {
                TextOutput.txt.Show("Неверный номер");
                break;
            }
            case "3": //Неверный пароль
            {
                TextOutput.txt.Show("Неверный пароль");
                break;
            }
            case "4": // Успешный вход
            {
                TextOutput.txt.Show("Успешный вход");
                CC.HideLogPanel();
                CC.ShowMainPanel();
                break;
            }
            case "5": //Код успешно отправлен
            {
                TextOutput.txt.Show("Код отправлен на почту- " + mail);
                CC.HideRegPanel();
                CC.ShowVerifyPanel();
                break;
            }
            case "6": //Пользователь не найден
            {
                TextOutput.txt.Show("Пользователь не найден");
                break;
            }
            case "7": //Код успешно проверен
            {
                TextOutput.txt.Show("Код успешно проверен");
                CC.HideVerifyPanel();
                CC.ShowMainPanel();
                break;
            }
            case "8": //Неверный код
            {
                TextOutput.txt.Show("Неверный код");
                break;
            }
            case "9": //Неверно указаная почта
            {
                TextOutput.txt.Show("Неверно указана почта");
                CC.registerPanelManager.ActiveButton();
                break;
            }
            case "10": //Пользователь с такой почтой уже зарегистрирован
            {
                TextOutput.txt.Show("Пользователь с такой почтой уже зарегистрирован");
                CC.registerPanelManager.ActiveButton();
                break;
            }
            case "": //
            {
                break;
            }
        }
    }
}
