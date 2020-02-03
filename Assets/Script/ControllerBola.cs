using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerBola : MonoBehaviour
{
    [SerializeField]
    private float speed = 8;
    public GameObject Bola;
    public GameObject buatJalan;
    public GameObject Efek;
    // Start is called before the first frame update
    Rigidbody rb;
    bool mulaiGame;
    int jumlahKoin;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        // rb.velocity = new Vector3(speed, 0, 0);
        mulaiGame = false;
        PlayerPrefs.SetInt("koin", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            GantiArah();
            if(!mulaiGame){
                gameManager.instance.GameStart();
                buatJalan.GetComponent<buatJalan>().tapAwal = true;
            }
        }

        // Debug.DrawRay(transform.position, Vector3.down, Color.red);
        if (!Physics.Raycast(transform.position, Vector3.down, 1))
        {
            gameManager.instance.GameOver();
            rb.velocity = new Vector3(0, -15, 0);
            Camera.main.GetComponent<gerakKamera>().gameOver = true;
            buatJalan.GetComponent<buatJalan>().gameOver = true;
            Destroy(Bola, 1f);
        }
    }

    void GantiArah()
    {
        if (rb.velocity.x > 0)
        {
            rb.velocity = new Vector3(0, 0, speed);
        }
        else
        {
            rb.velocity = new Vector3(speed, 0, 0);
        }
    }

    void OnTriggerEnter(Collider obj) {
        if(obj.gameObject.tag == "Koin"){
            GameObject Efeks = Instantiate(Efek, obj.gameObject.transform.position, Quaternion.identity);
            Destroy(obj.gameObject);
            Destroy(Efeks, 1f);
            jumlahKoin += 1;
            PlayerPrefs.SetInt("koin", jumlahKoin);
        }
    }
}
