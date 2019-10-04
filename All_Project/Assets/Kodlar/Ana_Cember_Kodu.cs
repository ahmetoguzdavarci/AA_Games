using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ana_Cember_Kodu : MonoBehaviour
{
    public GameObject kucuk_cember;     //oluşturmak istediğimiz GameObject türündeki nesne değişkeni.

    GameObject oyun_yoneticisi;     //oyun yöneticisi scriptine ulaşmak için oluşturulan nesne.
 
    void Start()
    {
        oyun_yoneticisi = GameObject.FindGameObjectWithTag("oyun_yoneticisi_tag");  //diğer scriptimize ulaşıp nesnemize atadık.
    }


    void Update()
    {
        if (Input.GetButtonDown("Fire1"))   //fareke tıklanığında çalışacak koşul.
        {
            kucuk_cember_olustur();     //çalıştığında fonksiyonumuzu çağıracak.
        }
        
    }

    void kucuk_cember_olustur()     //küçük çember oluşturmak için yazdığımız fonksiyon.
    {
        Instantiate(kucuk_cember, transform.position, transform.rotation);      //küçük çemberi oluşturma kodu.

        oyun_yoneticisi.GetComponent<Oyun_Yoneticisi_Kodu>().kucuk_cemberlerde_text_gosterme();     //diğer scriptimizin içinden istediğimiz metodu çağırdık.
    }
}
