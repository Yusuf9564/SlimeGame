using Unity.VisualScripting;
using UnityEngine;

public class HareketSistemi : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField]  private float kuvvetMiktari = 15f;
    float yatayGirdi;
    private float donusHizi = 5f;
    private Quaternion hedefDonus;
    private GameManager gameManager;
    private SkinManager skinManager;
    private bool yerdeMi = true;
    private float jumpForce = 15f;
    private int kalanZiplamaHakki = 2;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        hedefDonus = transform.rotation;
        gameManager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
        skinManager = GetComponent<SkinManager>();
        
    }

    void Update()
    {
        yatayGirdi = Input.GetAxis("Horizontal");
        DonusHareketi();

        int aktifSlime = PlayerPrefs.GetInt("SecilenSlime", 0);

        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Space'e basıldı! Yerde mi: " + yerdeMi + " | Kalan Hak: " + kalanZiplamaHakki);
        }

        if (yerdeMi)
        {
            if (aktifSlime == 4) kalanZiplamaHakki = 2;      
            else if (aktifSlime == 2) kalanZiplamaHakki = 1; 
            else kalanZiplamaHakki = 0;                      
        }

       
        if (Input.GetKeyDown(KeyCode.Space) && kalanZiplamaHakki > 0)
        {
            
            if (!yerdeMi)
            {
                rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
            }

            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            kalanZiplamaHakki--;
            yerdeMi = false;
        }
    }

    private void FixedUpdate()
    {
        MovementHandler();
    }

    private void MovementHandler()
    {
      
        Vector3 kuvvet = new Vector3(yatayGirdi * kuvvetMiktari, 0f, 0f);
        rb.AddForce(kuvvet, ForceMode.Force);
    }

    
    private void DonusHareketi()
    {
        
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
           hedefDonus = Quaternion.Euler(0f, 0f, 0f);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            hedefDonus = Quaternion.Euler(0f, -180f, 0f);
        }
        else
        {
            hedefDonus = Quaternion.Euler(0f, -90f, 0f);
        }

        transform.rotation = Quaternion.Slerp(transform.rotation, hedefDonus, donusHizi * Time.deltaTime);
    }


    private void OnTriggerEnter(Collider other)
    {
       
        if (other.CompareTag("Gem"))
        {
            GemSpinning elmasScripti = other.GetComponent<GemSpinning>();

            
            if (elmasScripti != null)
            {
                ScoreManager.instance.KomboArttir();


                if (elmasScripti.benimTurum == GemSpinning.GemTuru.Hyper)
                {
                    GameManager.instance.StartCoroutine(GameManager.instance.HyperModuTetikle());
                }
                else if(elmasScripti.benimTurum == GemSpinning.GemTuru.Gold)
                {
                    GameManager.instance.StartCoroutine(GameManager.instance.GoldModuTetikle());
                    ScoreManager.instance.SkorArttır(5);
                }
                else
                {
                    if (GameManager.instance.goldModActive)
                    {
                        ScoreManager.instance.SkorArttır(2);
                    }
                    else
                    {
                        ScoreManager.instance.SkorArttır(1);
                    }
                }
            }

            Destroy(other.gameObject);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            yerdeMi = true;
        }
    }
}
