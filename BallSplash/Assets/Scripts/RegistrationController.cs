using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class RegistrationController : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField emailInput;

    [SerializeField]
    private TMP_InputField passwordInput;

    [SerializeField]
    private Button submitButton;

    [SerializeField]
    private PlayFabManager playfabmanager; 

    // Start is called before the first frame update

    public void LoginUser()
    {
        //playfabmanager.RegisterUser(emailInput.text, passwordInput.text);
        playfabmanager.LoginUser(emailInput.text, passwordInput.text);
        //playfabmanager.ResetPassword(emailInput.text);
    }

    public void RegisterUser()
    {
        playfabmanager.RegisterUser(emailInput.text, passwordInput.text);
    }

    public void ResetPassword()
    {
        playfabmanager.ResetPassword(emailInput.text);
    }

    // Update is called once per frame
    void Update()
    {
    }

    
}
