using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DataBaseManager : MonoBehaviour
{
    public string phoneNumber;
    public string name;
    public string password;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TryRegister()
    {
        if (name.Length > 4 && password.Length > 6 && phoneNumber.Length >= 10)
        {
            StartCoroutine(Register());
        }
    }

    public void TryLogin()
    {
        
    }


    private IEnumerator Register()
    {
        WWWForm form = new WWWForm();
        form.AddField("Name", name);
        form.AddField("Pass",password);
        form.AddField("phoneNumber",phoneNumber);
        WWW request = new WWW("http://kavobar@k82451.hostua5.fornex.host/KavoBar/index.php",form);
        yield return request;
        if (request.error != null)
        {
            Debug.Log("Error" + request.error);
            yield break;

        }
        LogError(request.text);
    }

    void LogError(string id)
    {
        switch (id)
        {
            case "1": //Такой пользователь уже есть
            {
                Debug.Log("This user already registered");
                break;
            }
            case "2": //Неверный формат имени
            {
                
                break;
            }
            case "3":     //Неверный пароль
            {
                
                break;
            }
            case "4":
            {
                
                break;
            }
            case "5":
            {
                
                break;
            }
        }
    }
}
