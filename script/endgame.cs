using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class endgame : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)//�˴�3D����I��
    {
        if (other.tag=="Player")//�p�G�I�����骺���Ҭ�Player,�hĲ�o�H�U�ƥ�
        {
            SceneManager.LoadScene("end");//�����ܵ���������
            Cursor.visible = true;//�N������ܳ]�����
            Cursor.lockState = CursorLockMode.None;//�����N������w��������
        }
    }
}
D