using System.Collections;
using UnityEngine;

public class GemSpawner : MonoBehaviour
{
    
    public GameObject[] gemPrefableri;
    public float spawnSuresi = 2f;
    public float maksX = 8f;
    public float minX = -8f;
    public float eksenZ = -10.8f;
    public float eksenY = 8f;
    
    void Start()
    {
        StartCoroutine(Dongu());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Dongu()
    {
        while (true) 
        {
            float rastgeleX = Random.Range(minX, maksX);
            Vector3 spawnPosition = new Vector3(rastgeleX, eksenY, eksenZ);
            int gemOrani = Random.Range(0, 101);


            if (GameManager.instance.gokyuzuDursun == true) 
            {
                yield return null;
            }
            else if(GameManager.instance.hyperModAktif == true)
            {
                int rastgeleNormalIndex = Random.Range(0, 4);
                Instantiate(gemPrefableri[rastgeleNormalIndex], spawnPosition, Quaternion.identity);
                yield return new WaitForSeconds(0.08f);
            }
            else
            {
                if (gemOrani <= 5)
                {
                    Instantiate(gemPrefableri[4], spawnPosition, Quaternion.identity);

                }
                else
                {
                    int rastgeleNormalIndex = Random.Range(0, 4);
                    Instantiate(gemPrefableri[rastgeleNormalIndex], spawnPosition, Quaternion.identity);
                }
                yield return new WaitForSeconds(spawnSuresi);

            }


        }

    }

    
}
