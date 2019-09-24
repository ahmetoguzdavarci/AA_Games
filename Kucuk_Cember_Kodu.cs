using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kucuk_Cember_Kodu : MonoBehaviour      //Küçük çemberin içindeyiz.
{
    Rigidbody2D fizik;      //nesnemize erişmek için oluşturduğumuz değişken.

    public float hiz;       //nesnemizin hareketinde kullanmak için oluşturulan değişken.

    bool hareket_kontrol = false;       //nesnemizin hareketini kontrol için oluşturulan değişken.

    GameObject oyun_yoneticisine_ulasma;        //oyun yöneticisi script ine ulaşmak için oluşturduğumuz değişken.

    void Start()
    {
        fizik = GetComponent<Rigidbody2D>();    //değişkenimize nesnemizin özelliklerini atıyoruz.

        oyun_yoneticisine_ulasma = GameObject.FindGameObjectWithTag("oyun_yoneticisi_tag");     //nesnemize parametredeki script i atadık.
        
    }

    void FixedUpdate()      //hareket olayları daha düzgün çalışsın diye yazılan metot.
    {
        if (!hareket_kontrol)   //kontrol false ise çalışacak.
        {
            fizik.MovePosition(fizik.position + Vector2.up * hiz * Time.deltaTime);     //nesnemize hareketini veren kod.
        }
        

    }

    void OnTriggerEnter2D(Collider2D collision)     //nasnemizin trigger lı bir collider a çarptığında yazılan kod.
    {
        if (collision.tag == "donen_cember_tag")    //çarpılan collider ın tag kontrolü.
        {
            transform.SetParent(collision.transform);   //nesnemiz çarpışmanın olduğu nesnenin child ı oluyor ve böylelikle beraber hareket ediyorlar.

            hareket_kontrol = true;     //bu nesneye çarpıldığında değişkenimiz true oluyor ve hareketi yukarıda durduruluyor.
        }

        if (collision.tag=="kucuk_cember_tag")      //çarpılan collider ın tag kontrolü.
        {
            oyun_yoneticisine_ulasma.GetComponent<Oyun_Yoneticisi_Kodu>().oyun_bitti();     //ulaştığımız diğer script deki kodu çağırdık.
        }
        
    }
}
