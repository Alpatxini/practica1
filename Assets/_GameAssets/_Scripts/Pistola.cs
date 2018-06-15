using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistola : MonoBehaviour
{

    [SerializeField] Rigidbody prefabProyectil;
    [SerializeField] Transform puntoDisparo;

    [SerializeField] float fuerzaDisparo = 50;
    [SerializeField] float tiempoEntreDisparos= 1;
    [SerializeField] float tiempoRecarga = 1.5f;

    [SerializeField]int municionMaximaInventario=32;
    [SerializeField]int municionActualInventario=8;

    [SerializeField]int municionMaximaCargador=8;
    [SerializeField] AudioSource audioRecarga;
    [SerializeField] AudioSource audioDisparo;

    int municionActualCargador;

    bool estoyRecargando =false;
    bool gatilloApretado = false;

    float tiempoUltimoDisparo = 0;

    // Use this for initialization
    void Start()
    {
        municionActualCargador = municionMaximaCargador;
        municionActualInventario = Mathf.Min(municionActualInventario, municionMaximaInventario);
    }

    public void ApretarGatillo()
    {
        float tiempoActual = Time.time;
        float tiempoDesdeUltimoDisparo = tiempoActual - tiempoUltimoDisparo;



        if( tiempoDesdeUltimoDisparo>tiempoEntreDisparos &&
            municionActualCargador > 0)
        {
            DispararProyectil();
        }
    }
    public void SoltarGatillo()
    {
        
    }
    public void Recargar()
    {
        bool cargadorATope = (municionActualCargador == municionMaximaCargador);
        bool tengoBalas = municionActualInventario > 0;
        if (!estoyRecargando && !cargadorATope && tengoBalas)
        {
            estoyRecargando = true;
            audioRecarga.Play();
            Invoke("FinalizarRecarga", tiempoRecarga);
        }
        else if(!tengoBalas)
        {
            
        }
    }

    void FinalizarRecarga()
    {
        int municionARecargar = municionMaximaCargador - municionActualCargador;
        municionARecargar = Mathf.Min(municionARecargar, municionActualInventario);

        municionActualInventario -= municionARecargar;
        municionActualCargador += municionARecargar;
        estoyRecargando = false;
    }
    private void DispararProyectil()
    {
        tiempoUltimoDisparo = Time.time;

        municionActualCargador -= 1;
        audioDisparo.PlayOneShot(audioDisparo.clip);

        Rigidbody nuevoProyectil = Instantiate(prefabProyectil);
        nuevoProyectil.transform.position = puntoDisparo.position;
        nuevoProyectil.transform.rotation = puntoDisparo.rotation;

        nuevoProyectil.AddForce(nuevoProyectil.transform.forward * fuerzaDisparo, ForceMode.Impulse);
    }
}
