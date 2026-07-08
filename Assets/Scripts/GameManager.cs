using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int skor = 0;
    public bool hyperModAktif = false;
    public bool gokyuzuDursun = false;
    public bool goldModActive = false; 

    private void Awake()
    {
        if(instance == null ) instance = this;
    }
    void Start()
    {
        
    }

    public IEnumerator HyperModuTetikle()
    {
        hyperModAktif =true;
        yield return new WaitForSeconds(5f);
        hyperModAktif=false;
        gokyuzuDursun=true;
        yield return new WaitForSeconds(2f);
        gokyuzuDursun = false;
    }

    public IEnumerator GoldModuTetikle()
    {
        goldModActive = true;
        Debug.Log("ALTIN ELMAS AKTİF! 2X SKOR BAŞLADI!");

        yield return new WaitForSeconds(5f);

        goldModActive = false;
        Debug.Log("Gold Mod Bitti, skor normale döndü.");
    }
    void Update()
    {
        
    }
}
