using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gerakKamera : MonoBehaviour
{

    public GameObject Bola;
    public bool gameOver;
    Vector3 jarak;
    // Start is called before the first frame update
    void Start()
    {
        jarak = Bola.transform.position - transform.position;
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!gameOver){
            Ikuti();
        }
    }

    void Ikuti()
    {
        Vector3 pos = transform.position;
        Vector3 targetPos = Bola.transform.position - jarak;
        transform.position = Vector3.Lerp(pos, targetPos, Time.deltaTime);
    }
}
