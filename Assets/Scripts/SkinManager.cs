using Unity.VisualScripting;
using UnityEngine;

public class SkinManager : MonoBehaviour
{
    public GameObject[] slimeDizisi;
    private int slimeIndexNum = 0;
    void Start()
    {
        slimeIndexNum = PlayerPrefs.GetInt("SecilenSlime", 0);
        SlimeAktiflestirme(slimeIndexNum);
    }


    void Update()
    {
        // TEST AMAÇLI: Space tuşuna basınca sıradaki slime'a geç
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            // Sıradaki index numarasını hesapla (Dizinin sonuna gelirse 0'a döner)
            int sonrakiIndex = (slimeIndexNum + 1) % slimeDizisi.Length;

            // Kendi yazdığın fonksiyonu çağır
            SlimeAktiflestirme(sonrakiIndex);
        }
    }


    public void SlimeAktiflestirme(int yeniIndex)
    {
        for (int i = 0; i < slimeDizisi.Length; i++)
        {
            slimeDizisi[i].SetActive(false);
        }

        slimeDizisi[yeniIndex].SetActive(true);
        slimeIndexNum = yeniIndex;
        PlayerPrefs.SetInt("SecilenSlime", yeniIndex);

        Animator yeniAnimator = slimeDizisi[yeniIndex].GetComponent<Animator>();
        Animator anaAnimator = GetComponent<Animator>(); 
        
        if (yeniAnimator != null && anaAnimator != null)
        {
            
        }
       
    }

}
