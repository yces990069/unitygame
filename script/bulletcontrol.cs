using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletcontrol : MonoBehaviour
{
    public float bulletSpeed = 1600f;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

}

