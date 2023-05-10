using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TopKontrol : MonoBehaviour
{
    Rigidbody2D rb;//zıplama fiziksel işlemi
    public float ziplamaKuvveti = 3f;//ne kadar zıplayacak

    bool basildiMi = false;//input yaptı mı onu anlamak için

    [SerializeField] Text scoreText;
    
    public static int score = 0;

    public string mevcutRenk;
    public Color topunRengi;
    public Color turkuaz, sari, mor, pembe;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        scoreText.text = "Score: " + score;
        RastgeleBirRenkBelirle();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            basildiMi = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            basildiMi = false;
        }
    }
    private void FixedUpdate()
    {
        if (basildiMi)
        {
            rb.velocity = Vector2.up * ziplamaKuvveti;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="RenkTekeri")
        {
            RastgeleBirRenkBelirle();
            Destroy(collision.gameObject);
            return;//üsttekini yaptıysan çık ontriggerdan
        }
        if (collision.tag != mevcutRenk && collision.tag !="PuanArttirici" && collision.tag != "RenkTekeri")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);   
        }
        if (collision.tag=="PuanArttirici")
        {
            score += 5;
            scoreText.text = "Score" + score;
            Destroy(collision.gameObject);
        }
    }
    void RastgeleBirRenkBelirle()
    {
       // int ilk, son=0;
        
        int rastgeleSayi = Random.Range(0, 4);//0,1,2,3
        //ilk = rastgeleSayi;
        
        //if (son==ilk)
        //{
          //  RastgeleBirRenkBelirle();
       // }
        switch (rastgeleSayi)
        {
            case 0:
                mevcutRenk = "Turkuaz";
                topunRengi = turkuaz;
                break;
            case 1:
                mevcutRenk = "Sari";
                topunRengi = sari;
                break;
            case 2:
                mevcutRenk = "Pembe";
                topunRengi = pembe;
                break;
            case 3:
                mevcutRenk = "Mor";
                topunRengi = mor;
                break;
            default:
                break;
        }
        //son = ilk;
        GetComponent<SpriteRenderer>().color = topunRengi;
    }

}//class
