using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Oyun_Yoneticisi_Kodu : MonoBehaviour
{   

    GameObject donen_cember_durdurma;   //başka script te çalışan kodu durdurmak için oluşturduğumuz nesne.
    GameObject ana_cember_durdurma;     //başka script te çalışan kodu durdurmak için oluşturduğumuz nesne.

    public Animator animator;       //oyun bittiğinde çalışacak animasyon nesnesi.

    public Text donen_cember_level;     //sahnemezin ismini atamak için oluşturulan değişken.

    public Text bir;    //kalan ana çember sayısını tutmak için oluşturduğumuz değişken.
    public Text iki;    //kalan ana çember sayısını tutmak için oluşturduğumuz değişken.
    public Text uc;     //kalan ana çember sayısını tutmak için oluşturduğumuz değişken.

    public int kac_tane_kucukcember_olsun;      //levelde kaç tane küçük çember yani iğne fırlatcağımızın sayısı.

    bool kontrol = true;    //sıfır olduğunda ve yandığımızda sahne geçişini kontrol etmek için oluşturulan değişken.

    void Start()
    {
        PlayerPrefs.SetInt("kayit", int.Parse(SceneManager.GetActiveScene().name));    //oyunu kaldığımız bölümünü kaydetmek için kullanılan kod.

        donen_cember_durdurma = GameObject.FindGameObjectWithTag("donen_cember_tag");   //diğer script e ulaşıp değişkenimize atadık.

        ana_cember_durdurma = GameObject.FindGameObjectWithTag("ana_cember_tag");       //diğer script e ulaşıp değişkenimize atadık.

        donen_cember_level.text = SceneManager.GetActiveScene().name;   //değişkenimize sahnemizin adını atıyoruz. Böylece sahnenin adı çemberin üstünde çıkıyor.

        if (kac_tane_kucukcember_olsun < 2)     //kalan küçük çemberimizn kontrolü.
        {
            bir.text = kac_tane_kucukcember_olsun + "";     //2 den az çember kaldıysa sadece birince text e yazıcak sayısını.
                                                            //"" toplamamızın nedeni ifade string e çevrilsin diye.
        }
        
        else if (kac_tane_kucukcember_olsun < 3)    //kalan küçük çemberimizin kontrolü.
        {
            bir.text = kac_tane_kucukcember_olsun + "";     //3 den az çember kaldıysa bire sayısını yazcak.
            iki.text = (kac_tane_kucukcember_olsun - 1) + "";       //kalan sayının bir eksiğini de ikinci text imize yazıcak.
        }

        else        //geriye kalan durumda cember sayısı 3 veya daha fazlayı kapsıyor.
        {
            bir.text = kac_tane_kucukcember_olsun + "";         //çoktan aza doğru sıralanacağı için ilkine kalan küçük çember sayısını yazıyoruz.
            iki.text = (kac_tane_kucukcember_olsun - 1) + "";   //kalan küçük çember sayısının bir eksiğini yazıyoruz.
            uc.text = (kac_tane_kucukcember_olsun - 2) + "";    //kalan küçük çember sayısının iki eksiğini yazıyoruz.

        }

    }

    public void kucuk_cemberlerde_text_gosterme()
    {
        kac_tane_kucukcember_olsun--;   //bu metot çağırıldığında sayımızın azalması için küçük çember sayımızı bir azaltıyoruz.

        if (kac_tane_kucukcember_olsun < 2)     //kalan küçük çemberimizn kontrolü.
        {
            bir.text = kac_tane_kucukcember_olsun + "";     //2 den az çember kaldıysa sadece birince text e yazıcak sayısını.
                                                            //"" toplamamızın nedeni ifade string e çevrilsin diye.
            iki.text = "";      //sayımız azaldığında sıfır olmamaı için boş değer veriyoruz.
            uc.text = "";       //sayımız azaldığında sıfır olmamaı için boş değer veriyoruz.
        }

        else if (kac_tane_kucukcember_olsun < 3)    //kalan küçük çemberimizin kontrolü.
        {
            bir.text = kac_tane_kucukcember_olsun + "";     //3 den az çember kaldıysa bire sayısını yazcak.
            iki.text = (kac_tane_kucukcember_olsun - 1) + "";       //kalan sayının bir eksiğini de ikinci text imize yazıcak.
            uc.text = "";       //sayımız azalıcak ve sıfır yazmaması için burayı boş değer veriyoruz.
        }

        else        //geriye kalan durumda cember sayısı 3 veya daha fazlayı kapsıyor.
        {
            bir.text = kac_tane_kucukcember_olsun + "";         //çoktan aza doğru sıralanacağı için ilkine kalan küçük çember sayısını yazıyoruz.
            iki.text = (kac_tane_kucukcember_olsun - 1) + "";   //kalan küçük çember sayısının bir eksiğini yazıyoruz.
            uc.text = (kac_tane_kucukcember_olsun - 2) + "";    //kalan küçük çember sayısının iki eksiğini yazıyoruz.

        }

        if (kac_tane_kucukcember_olsun == 0)
        {
            StartCoroutine(yeni_level());   //IEnumerator türünde olduğu için fonksiyon bu şekilde çağırıyoruz.
        }
    }

    IEnumerator yeni_level()        //kodu bekletme ihtiyacımız olduğu için bu türde bir fonsiyon yazıyoruz.
    {
        donen_cember_durdurma.GetComponent<Dondurme>().enabled = false;         //yeni levele geçebilmek için diğer script deki dondurme koduna ulaşıp onu kapattık.

        ana_cember_durdurma.GetComponent<Ana_Cember_Kodu>().enabled = false;    //yeni levele geçebilmek için diğer script deki ana_cember_kodu koduna ulaşıp onu kapattık.

        yield return new WaitForSeconds(1);     //kalan küçük çember sıfır olduğu anda geçmesin diye kodu bekletiyoruz.        

        if (kontrol)        //yeni levele geçmek için yaptığımız kontrol.
        {
            animator.SetTrigger("yeni_level_trigger");      //yeni levele geçerken çalışacak animasyonu tetikledik.

            yield return new WaitForSeconds(2);     //animasyonun çalışmasını beklemek için kodu durdurduk.

            SceneManager.LoadScene(int.Parse(SceneManager.GetActiveScene().name) + 1);  //yeni levele burada geçiyoruz. Ama sahnemizin adı string türünde olduğu için
                                                                                        //öncelikle onu int türüne çevirim bir üst sahneye geçmek için 1 ile topluyoruz.
        }
    }

    public void oyun_bitti()     //oyun bittiğinde çağırılacak fonksiyon.
    {
        StartCoroutine(cagrilan_metot());   //kod çalıştığında IEnumerator metodu çağırılacak.
    }


    IEnumerator cagrilan_metot()       
    {
        donen_cember_durdurma.GetComponent<Dondurme>().enabled = false;         //diğer script deki dondurme koduna ulaşıp onu kapattık.

        ana_cember_durdurma.GetComponent<Ana_Cember_Kodu>().enabled = false;    //diğer script deki ana_cember_kodu koduna ulaşıp onu kapattık.

        animator.SetTrigger("oyun_bitti_trigger");      //nesne üzerinden animasyondaki trigger ımıza ulaşıp aktif hale getiriyoruz.

        kontrol = false;        //eğer oyunda yanarsak bu değişken false oluyo.

        yield return new WaitForSeconds(2);     //kod çalışırken 2 saniye bekleyecek. Çünkü animasyonun gösterilmesini istiyoruz.
        
        SceneManager.LoadScene("ana_menu");     //oyun bittiğinde tekrardan menüye dönme kodu.
              
    }
}
