using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamemanager : MonoBehaviour
{
    public void OnStartGame(string ScneneName)//轉跳場景
    {
        Application.LoadLevel(ScneneName);//轉跳至ScneneName場景 ScneneName可在Unity中設定為自己想要的場景名稱
    }
}
