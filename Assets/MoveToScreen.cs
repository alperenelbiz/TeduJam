using System.Collections;
using UnityEngine;

public class HareketKontrolu : MonoBehaviour
{
    public Transform hedefNesne; // Hedef nesneyi manuel olarak belirleyebilirsiniz
    public Transform hedefNesne2;
    public float hareketHizi = 5f; // Nesnenin hareket h�z�
    public float delayTime;

    void Update()
    {
        HedefeHareketEt();
    }

    void HedefeHareketEt()
    {
        if (hedefNesne != null)
        {
            // Kameran�n d�n�� a��s�n� al
            float kameraDonusAcisi = Camera.main.transform.eulerAngles.y;

            // Hedefe do�ru bir vekt�r olu�tur
            Vector3 hedefYon = Quaternion.Euler(0, kameraDonusAcisi, 0) * (hedefNesne.position - transform.position);

            // Hedefe do�ru normalle�tirilmi� bir vekt�r olu�tur
            Vector3 normalizedHedefYon = hedefYon.normalized;

            // Hedefe do�ru hareket et
            transform.position = Vector3.MoveTowards(transform.position, hedefNesne.position, hareketHizi * Time.deltaTime);

            // E�er nesne hedefe yakla�t�ysa, hareketi durdur
            if (Vector3.Distance(transform.position, hedefNesne.position) < 0.644f)
            {
                Debug.Log("Hedefe ula��ld�!");
                Delay(delayTime);
                if (hedefNesne2 != null)
                {
                    // Kameran�n d�n�� a��s�n� al
                    float kameraDonusAcisi2 = Camera.main.transform.eulerAngles.y;

                    // Hedefe do�ru bir vekt�r olu�tur
                    Vector3 hedefYon2 = Quaternion.Euler(0, kameraDonusAcisi2, 0) * (hedefNesne2.position - transform.position);

                    // Hedefe do�ru normalle�tirilmi� bir vekt�r olu�tur
                    Vector3 normalizedHedefYon2 = hedefYon.normalized;

                    // Hedefe do�ru hareket et
                    transform.position = Vector3.MoveTowards(transform.position, hedefNesne2.position, hareketHizi * Time.deltaTime);
                }
            }
            else
            {
                Debug.LogError("Hedef nesne atanmam��!");
            }
        }

    }
    IEnumerator Delay(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
    }
}