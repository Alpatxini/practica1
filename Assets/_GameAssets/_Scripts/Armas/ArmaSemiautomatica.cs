using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaSemiautomatica : ArmaProyectiles {
    
    public override void ApretarGatillo()
    {

        float tiempoActual = Time.time;
        float tiempoDesdeUltimoDisparo = tiempoActual - tiempoUltimoDisparo;

        bool puedoDisparar = tiempoDesdeUltimoDisparo > tiempoEntreDisparos; 

        DispararArma();
    }

}
