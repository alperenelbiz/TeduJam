using UnityEngine;

public class HareketKontrolu : MonoBehaviour
{
    public Transform hedefNesne; // Hedef nesneyi manuel olarak belirleyebilirsiniz
    public float hareketHizi = 5f; // Nesnenin hareket hýzý

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
                enabled = false; // Script'i devre dýþý býrakabilirsiniz.
            }
        }
        else
        {
            Debug.LogError("Hedef nesne atanmamýþ!");
        }
    }
}
