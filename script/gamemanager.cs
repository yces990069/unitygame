using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamemanager : MonoBehaviour
{
    public void OnStartGame(string ScneneName)//�������
    {
        Application.LoadLevel(ScneneName);//�����ScneneName���� ScneneName�i�bUnity���]�w���ۤv�Q�n�������W��
    }
}
