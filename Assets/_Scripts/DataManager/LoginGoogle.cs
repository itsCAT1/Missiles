using GooglePlayGames;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginGoogle : MonoBehaviour
{
    private void Start()
    {
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();

        Social.localUser.Authenticate((bool success) =>
        {
            if (success)
            {
                Debug.Log("Đăng nhập thành công!");
            }
            else
            {
                Debug.Log("Đăng nhập thất bại.");
            }
        });
    }
}
