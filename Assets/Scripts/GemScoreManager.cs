using UnityEngine;

public class GemScoreManager : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Gem"))
        {
            Destroy(other.gameObject);

            // Eğer kombo 0 ise OYUN BİTER
            if (ScoreManager.instance.komboSayisi == 0)
            {
                Debug.Log("Kaybettiniz");
                ScoreManager.instance.SkoruSifirla(); // Skoru ve komboyu tertemiz sıfırlıyor
            }
            else
            {
                // Kombo varsa sadece kombo sıfırlanır, oyuncu yanmaz
                ScoreManager.instance.KomboSifirla();
            }
        }
    }
}
