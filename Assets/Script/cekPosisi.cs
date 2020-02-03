using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cekPosisi : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerExit(Collider obj)
    {
        if (obj.gameObject.tag == "Bola")
        {
            Invoke("jalanJatuh", -0.5f);
        }
    }

    void jalanJatuh()
    {
        GetComponentInParent<Rigidbody>().useGravity = true;
        GetComponentInParent<Rigidbody>().isKinematic = false;
        Destroy(transform.parent.gameObject, 2f);
    }
}
