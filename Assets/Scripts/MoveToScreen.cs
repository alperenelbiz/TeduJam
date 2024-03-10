using System.Collections;
using UnityEngine;

public class MoveToScreen : MonoBehaviour
{
    public Transform hedefNesne; // Hedef nesneyi manuel olarak belirleyebilirsiniz
    public Transform hedefNesne2;
    public float hareketHizi = 5f; // Nesnenin hareket h�z�
    public float delayTime;
    public Camera playerCam;
    public GameObject player;

    

    public bool HedefeHareketEt(GameObject go)
    {
        if (hedefNesne != null)
        {
            Transform hedefNesne = go.transform;
            // Kameran�n d�n�� a��s�n� al
            float kameraDonusAcisi = playerCam.transform.eulerAngles.y;

            // Hedefe do�ru bir vekt�r olu�tur
            Vector3 hedefYon = Quaternion.Euler(0, kameraDonusAcisi, 0) * (hedefNesne.position - player.transform.position);

            // Hedefe do�ru normalle�tirilmi� bir vekt�r olu�tur
            Vector3 normalizedHedefYon = hedefYon.normalized;

            // Hedefe do�ru hareket et
            player.transform.position = Vector3.MoveTowards(player.transform.position, hedefNesne.position, hareketHizi * Time.deltaTime);

            // E�er nesne hedefe yakla�t�ysa, hareketi durdur
            if (Vector3.Distance(player.transform.position, hedefNesne.position) < 0.644f)
            {
                Debug.Log("Hedefe ula��ld�!");
                return true;
                }
            return false;
            }
            else
            {
                Debug.LogError("Hedef nesne atanmam��!");
            return false;
        }
        }

    }