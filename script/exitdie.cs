using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class exitdie : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("ChangeScene", 2f);//����Ĳ�oChangeScene
    }
    public void ChangeScene()
    {
        SceneManager.LoadScene("again");//���Jagain��ĵ
        Cursor.visible = true;//�N���г]���i��
        Cursor.lockState = CursorLockMode.None;//������w����
    }

}
