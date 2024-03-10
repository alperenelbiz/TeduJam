using System.Collections;
using UnityEngine;

public class MoveToScreen : MonoBehaviour
{
    public Transform hedefNesne; // Hedef nesneyi manuel olarak belirleyebilirsiniz
    public Transform hedefNesne2;
    public float hareketHizi = 5f; // Nesnenin hareket hýzý
    public float delayTime;
    public Camera playerCam;
    public GameObject player;

    

    public bool HedefeHareketEt(GameObject go)
    {
        if (hedefNesne != null)
        {
            Transform hedefNesne = go.transform;
            // Kameranýn dönüþ açýsýný al
            float kameraDonusAcisi = playerCam.transform.eulerAngles.y;

            // Hedefe doðru bir vektör oluþtur
            Vector3 hedefYon = Quaternion.Euler(0, kameraDonusAcisi, 0) * (hedefNesne.position - player.transform.position);

            // Hedefe doðru normalleþtirilmiþ bir vektör oluþtur
            Vector3 normalizedHedefYon = hedefYon.normalized;

            // Hedefe doðru hareket et
            player.transform.position = Vector3.MoveTowards(player.transform.position, hedefNesne.position, hareketHizi * Time.deltaTime);

            // Eðer nesne hedefe yaklaþtýysa, hareketi durdur
            if (Vector3.Distance(player.transform.position, hedefNesne.position) < 0.644f)
            {
                Debug.Log("Hedefe ulaþýldý!");
                return true;
                }
            return false;
            }
            else
            {
                Debug.LogError("Hedef nesne atanmamýþ!");
            return false;
        }
        }

    }