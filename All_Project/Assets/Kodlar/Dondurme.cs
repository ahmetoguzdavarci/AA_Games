using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dondurme : MonoBehaviour       //çemberin içindeyiz
{
    public float hiz;       //çemberimizin dönüş hızı

    void Update()
    {
        transform.Rotate(0, 0, hiz * Time.deltaTime);       //çemberimizin rotasyonuna ulaşarak onu z ekseninde döndürüyoruz.
    }
}
