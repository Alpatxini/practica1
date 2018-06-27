using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoAtaqueADistancia : MonoBehaviour {

    [SerializeField] Transform cañon;
    [SerializeField] Transform puntoDisparo;

    [SerializeField] float distanciaAtaque = 50;
    [SerializeField] float tiempoEntreDisparos = 2;
    [SerializeField] float fuerzaDisparo = 10;
    [SerializeField] float velocidadRotacion = 90;
    float tiempoUltimoDisparo = 0;

    [SerializeField] Rigidbody prefabProyectil;
    Quaternion rotacionInicialCañon;

	void Start () 
    {

        rotacionInicialCañon = cañon.rotation;
		
	}
	
	
	void Update () 
    {

        Vector3 miPosicion = this.transform.position;
        Vector3 posicionJugador = GameManager.jugador.transform.position;
        float distancia = Vector3.Distance(miPosicion, posicionJugador);

        if(distancia<distanciaAtaque)
        {
            AtacarAlJugador();
        }
        else
        {
            VolverARotacionInicial();
        }
    } 

    void AtacarAlJugador()
    {
        cañon.LookAt(GameManager.jugador.transform);
        float tiempoActual = Time.time;
        if(tiempoActual>tiempoUltimoDisparo+tiempoEntreDisparos)
        {
            tiempoUltimoDisparo = tiempoActual;
            Rigidbody nuevoProyectil = Instantiate(prefabProyectil);
            nuevoProyectil.transform.position = puntoDisparo.transform.position;
            nuevoProyectil.transform.rotation = puntoDisparo.transform.rotation;
            nuevoProyectil.AddForce(puntoDisparo.transform.forward * fuerzaDisparo,ForceMode.Impulse);
        }
    }

    void VolverARotacionInicial()
    {
           cañon.rotation = Quaternion.RotateTowards(
            from: cañon.rotation, 
            to: rotacionInicialCañon, 
            maxDegreesDelta: velocidadRotacion*Time.deltaTime);
    }
}
