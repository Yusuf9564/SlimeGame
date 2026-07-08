using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public TMP_Text skorText; // Editörde karışmasın diye adını skorText yaptık
    private int score = 0;

    // --- Yeni Eklenen Kombo Değişkenleri ---
    public int komboSayisi = 0;
    public int enYuksekKombo = 0;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    private void Start()
    {
        SkoruGuncelle();
    }

    public void SkorArttır(int miktar)
    {
        score += miktar;
        SkoruGuncelle();
    }

    // --- Yeni Eklenen Kombo Fonksiyonları ---
    public void KomboArttir()
    {
        komboSayisi++;
        if (komboSayisi > enYuksekKombo)
        {
            enYuksekKombo = komboSayisi;
        }
        Debug.Log("KOMBO! x" + komboSayisi);
    }

    public void KomboSifirla()
    {
        if (komboSayisi > 0)
        {
            Debug.Log("Kombo BOZULDU! En yüksek kombon: " + enYuksekKombo);
            komboSayisi = 0;
        }
    }

    // Oyun kaybedildiğinde skoru sıfırlamak için bu fonksiyonu kullanacağız
    public void SkoruSifirla()
    {
        score = 0;
        komboSayisi = 0;
        SkoruGuncelle();
    }

    void SkoruGuncelle()
    {
        if (skorText != null)
        {
            skorText.text = "Skor: " + score;
        }
    }
}