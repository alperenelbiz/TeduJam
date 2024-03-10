using System.Collections;
using UnityEngine;

public class HareketKontrolu : MonoBehaviour
{
    public Transform hedefNesne; // Hedef nesneyi manuel olarak belirleyebilirsiniz
    public Transform hedefNesne2;
    public float hareketHizi = 5f; // Nesnenin hareket hýzý
    public float delayTime;

    void Update()
    {
        HedefeHareketEt();
    }

    void HedefeHareketEt()
    {
        if (hedefNesne != null)
        {
            // Kameranýn dönüþ açýsýný al
            float kameraDonusAcisi = Camera.main.transform.eulerAngles.y;

            // Hedefe doðru bir vektör oluþtur
            Vector3 hedefYon = Quaternion.Euler(0, kameraDonusAcisi, 0) * (hedefNesne.position - transform.position);

            // Hedefe doðru normalleþtirilmiþ bir vektör oluþtur
            Vector3 normalizedHedefYon = hedefYon.normalized;

            // Hedefe doðru hareket et
            transform.position = Vector3.MoveTowards(transform.position, hedefNesne.position, hareketHizi * Time.deltaTime);

            // Eðer nesne hedefe yaklaþtýysa, hareketi durdur
            if (Vector3.Distance(transform.position, hedefNesne.position) < 0.644f)
            {
                Debug.Log("Hedefe ulaþýldý!");
                Delay(delayTime);
                if (hedefNesne2 != null)
                {
                    // Kameranýn dönüþ açýsýný al
                    float kameraDonusAcisi2 = Camera.main.transform.eulerAngles.y;

                    // Hedefe doðru bir vektör oluþtur
                    Vector3 hedefYon2 = Quaternion.Euler(0, kameraDonusAcisi2, 0) * (hedefNesne2.position - transform.position);

                    // Hedefe doðru normalleþtirilmiþ bir vektör oluþtur
                    Vector3 normalizedHedefYon2 = hedefYon.normalized;

                    // Hedefe doðru hareket et
                    transform.position = Vector3.MoveTowards(transform.position, hedefNesne2.position, hareketHizi * Time.deltaTime);
                }
            }
            else
            {
                Debug.LogError("Hedef nesne atanmamýþ!");
            }
        }

    }
    IEnumerator Delay(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
    }
}