using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buatJalan : MonoBehaviour
{

    public bool gameOver;
    public GameObject Jalan;
    public GameObject Koin;
    public bool tapAwal;
    Vector3 posAkhir;
    float ukuran;
    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        tapAwal = false;

        posAkhir = Jalan.transform.position;
        ukuran = Jalan.transform.localScale.x;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(tapAwal){
            for (int i = 0; i < 20; i++)
            {
                BuatJalanAcak();
            }
            InvokeRepeating("BuatJalanAcak", 2f, 5f);
            tapAwal = false;
        }

        if(gameOver){
            CancelInvoke("BuatJalanAcak");
        }
    }

    void BuatJalanAcak()
    {
        int rand = Random.Range(0, 6);
        int putar = Random.Range(1, 36) * 10;
        Vector3 pos = posAkhir;

        if (rand <= 3)
        {
            pos.x += ukuran;
        }
        else
        {
            pos.z += ukuran;
        }


        Instantiate(Jalan, pos, Quaternion.identity);

        if(putar > 90){
            Instantiate(Koin, new Vector3(pos.x, pos.y+1, pos.z), Quaternion.Euler(putar, putar, 0));
        }

        posAkhir = pos;
    }
}
