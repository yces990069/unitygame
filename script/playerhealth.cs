using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerhealth : MonoBehaviour
{
    public int PlayerHealth;//���a��q
    public Text health;//���a��q(�bUI�W��ܪ�)
    public int ph=100;//���a��q(�@���B��l��)
    bool alive = true;//�O�_�s��
    private void Start()
    {
        alive = true;//�N�s�����A�]���u
    }
    void Update()
    {
        if (ph<=0)//�p�G��q<=0
        {
            alive = false;//�N�s�����A�]���_
            SceneManager.LoadScene("die");//�����즺�`������
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="BulletE" && alive)//�p�G�I�����Ҭ�BulletE�B���s�����A
        {
            ph = ph - 10;//�ͩR��10
            health.text = ph + "";//��sUI�W��ܪ���q
        }
    }
}
