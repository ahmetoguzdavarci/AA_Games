using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Kontrol_Kodu : MonoBehaviour
{
    void Start()
    {
        //PlayerPrefs.DeleteAll();    //oyunumuzu kodlarken eski kayıtları silmemiz gerek yoksa önceki levellere gidemeyiz. Bu kodu bir kere çalıştırıp
                                    //tekrardan yorum satırı haline getirmemiz gerekiyor. Yoksa hep kayıtları siler kayıt tutamayız bu seferde. Build ederken de
                                    //bu kod yorum satırı haline getirilmeli.
    }

    public void oyuna_git()     //oyuna başla butonu tıklandığında çağırılacak fonksiyonu yazıyoruz. Butondan trigger özelliğini açmak gerek.
    {
        int kayitli_level = PlayerPrefs.GetInt("kayit");    //ilk levele geçebilmemiz için kontrol yapıcaz. bu yüzden değişken oluşturduk.

        if (kayitli_level == 0)     //eğer hiç kayıt yoksa kontrolü.
        {
            SceneManager.LoadScene(kayitli_level + 1);      //hiç kayıt yoksa sayımızı bir arttırıp diğer levele geçicek yani birinci levele.
        }

        else
        {
            SceneManager.LoadScene(kayitli_level);      //bu fonksiyon çalıştığında son kaydedilen level çalışacak.
        }

       

    }

    public void oyundan_cik()   //çıkış butonu tıklandığında çağırılacak fonksiyon. Butondan trigger özelliğini açmak gerek.
    {
        Application.Quit();     //uygulamdan komple çıkış yapan kod.

    }
   
}
