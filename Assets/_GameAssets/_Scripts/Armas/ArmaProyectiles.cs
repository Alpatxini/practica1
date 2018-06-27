using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaProyectiles : Arma {

    [SerializeField] protected Rigidbody prefabProyectil;
    [SerializeField] protected Transform puntoDisparo;

    [SerializeField] protected float fuerzaDisparo = 50;
    [SerializeField] protected float tiempoEntreDisparos = 1;

    [SerializeField] protected AudioSource audioDisparo;

    protected float tiempoUltimoDisparo = 0;


    protected void DispararArma()
    {

        if (municionActualCargador > 0 && !estoyRecargando)
        {
            LanzarProyectil();
        }
        else if (municionActualCargador == 0 && !estoyRecargando)
        {
            audioRecargaFallida.Play();
        }
    }

    protected virtual void LanzarProyectil()
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
