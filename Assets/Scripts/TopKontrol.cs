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

    [SerializeField] Text scoreText, bestScoreText,messageText;
    [SerializeField] GameObject messagePAnel;

	public static int score = 0, bestScore = 0;

    public GameObject halka, renkTekeri;


    bool started = false;
    public string mevcutRenk;
    public Color topunRengi;
    public Color turkuaz, sari, mor, pembe;
  
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
      
		bestScoreText.text = "Best Score: " + PlayerPrefs.GetInt("bestScore").ToString();
		scoreText.text = "Score: " + score;
        RastgeleBirRenkBelirle();
    }
    private void Update()
    {
		if (Input.GetMouseButtonDown(0))
        {
            basildiMi = true;
            started= true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            basildiMi = false;
        }
    }
    private void FixedUpdate()
    {
        //if (Input.touchCount <= 0)
        //{
        //	rb.gravityScale = 0;
        //	return;
        //}
        if (!started)
        {
            rb.gravityScale = 0f;
            return;
        }
		if (basildiMi)
        {
            messageText.enabled = false;
            rb.gravityScale = 0.7f;
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
            score = 0;//eğer can sistemi yapacaksanız burada yapabilirisiniz
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);   
        }
        if (collision.tag == "PuanArttirici")
        {
            score += 5;
            scoreText.text = "Score: " + score;
			if (score >= bestScore)
			{
				bestScore = score;
				PlayerPrefs.SetInt("bestScore", score);
			}
			Destroy(collision.gameObject);

            Instantiate(halka, new Vector3(transform.position.x, transform.position.y + 8f, transform.position.z), Quaternion.identity);//ne oluşşun,neredeoluşsun,Rotation

            Instantiate(renkTekeri, new Vector3(transform.position.x, transform.position.y + 11.7f, transform.position.z), Quaternion.identity);//ne oluşşun,neredeoluşsun,Rotation
        }
		if (collision.gameObject.CompareTag("outside"))
		{
			score = 0;
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            

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
    public void MessageButton()
    {
        messagePAnel.SetActive(true);
    }
	public void QuitMessageButton()
	{
		messagePAnel.SetActive(false);
	}

}//class
