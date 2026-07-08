using UnityEngine;

public class GemSpinning : MonoBehaviour
{
    public enum GemTuru { Normal, Hyper, Gold }
    private float donmeHizi = 0.5f;
    public Transform karakter;
    public float gidisHizi = 6f;
    public float bakisHizi = 5f;
    public GemTuru benimTurum;
    public float cekimMenzili = 4f;
    public float dusisHizi = 1f;

    private float orijinalHiz;
    private float orijinalCekim;

    void Start()
    {
        karakter = GameObject.FindWithTag("Player").transform;

        // BURASI EKLENDİ: İlk baştaki orijinal değerleri hafızaya alıyoruz
        orijinalHiz = gidisHizi;
        orijinalCekim = cekimMenzili;
    }

    void Update()
    {
        if (karakter == null) return;

        // --- HYPER MODE AYARLARI --- (Eski kodun aynen kalıyor)
        if (GameManager.instance != null && GameManager.instance.hyperModAktif)
        {
            cekimMenzili = 30f;
            gidisHizi = 14f;
        }
        else if (GameManager.instance != null && GameManager.instance.gokyuzuDursun)
        {
            cekimMenzili = 10f;
            gidisHizi = 8f;
        }
        else
        {
            cekimMenzili = orijinalCekim;
            gidisHizi = orijinalHiz;
        }
        // ----------------------------

       
        if (Vector3.Distance(transform.position, karakter.position) <= cekimMenzili)
        {
            Vector3 gidilecekYol = karakter.position - transform.position;
            Quaternion hedef = Quaternion.LookRotation(gidilecekYol);
            transform.rotation = Quaternion.Slerp(transform.rotation, hedef, bakisHizi * Time.deltaTime);
            transform.position = Vector3.MoveTowards(transform.position, karakter.position, gidisHizi * Time.deltaTime);
        }
        else
        {
            
            transform.Rotate(new Vector3(0, 360, 0) * donmeHizi * Time.deltaTime);

            
            transform.Translate(Vector3.down * dusisHizi * Time.deltaTime, Space.World);
        }
    }
}