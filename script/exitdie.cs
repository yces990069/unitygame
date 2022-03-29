using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class exitdie : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("ChangeScene", 2f);//兩秒後觸發ChangeScene
    }
    public void ChangeScene()
    {
        SceneManager.LoadScene("again");//載入again場警
        Cursor.visible = true;//將鼠標設為可見
        Cursor.lockState = CursorLockMode.None;//取消鎖定鼠標
    }

}
