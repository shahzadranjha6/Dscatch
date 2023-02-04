using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JS_ReturnCheck : MonoBehaviour
{
    public Text ResponseText;

    public bool isLoggedIn = false;


    // Start is called before the first frame update
    void Start()
    {
        ResetTxt();
    }

    void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartCoroutine(CheckUserStatus());
            }
        }

    public void ResetTxt()
    {
        ResponseText.text = "Waiting for response...";
    }


    public void SetUserStatus(bool status)
        {
            isLoggedIn = status;
        }


    public IEnumerator CheckUserStatus()
        {
            Application.ExternalCall("CheckUserStatus");
            
            yield return new WaitForSeconds(1f);


            if (isLoggedIn)
                {
                    ResponseText.text = "Logged in: TRUE";
                }
            else
                {
                    ResponseText.text = "Logged in: FALSE";
                }

            yield return new WaitForSeconds(2f);

            ResetTxt();
        }
}
