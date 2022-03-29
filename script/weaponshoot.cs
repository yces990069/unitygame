using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class weaponshoot : MonoBehaviour
{
    public Transform BulletPoint;//�}���I
    public GameObject BulletPre;//�l�u�w�s��
    public Text BulletText;//�s��UI�W���l�u�ƶq
    private int bulletCount = 30;//�l�u�ƶq���B��l
    private float cd = 0.1f;//�}�����j
    private float timer =0;
    
    void Update()
    {
        timer += Time.deltaTime;//�ɶ��ܤ�
        if (timer > cd && Input.GetMouseButton(0) && bulletCount >0)//�p�G�ɶ��j��
        {
            timer = 0;
            //Instantiate(FirePre, FirePoint.position, FirePoint.rotation);
            Instantiate(BulletPre, BulletPoint.position, BulletPoint.rotation);
            bulletCount--;
            BulletText.text = bulletCount +"";

        }
        if(bulletCount==0)
        {
            BulletText.text = "Reloading";
            Invoke("Reload", 1.5f);
        }   
        if(Input.GetKeyDown(KeyCode.R))
        {
            BulletText.text = "Reloading";
            Invoke("Reload", 1.5f);
        }
    }
    void Reload()
    {
        bulletCount = 30;
        BulletText.text = bulletCount+"";
    }
}
