using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoAtaqueSuicida : MonoBehaviour {

    [SerializeField] float distanciaAtaque = 5;
    [SerializeField] int dañoAtaque = 10;
    [SerializeField] GameObject prefabParticulasExplosion;
	void Start () {
		
	}
	
    void Update()
    {

        IntentarAtacarAlJugador();
    }

    void IntentarAtacarAlJugador()
    {
        Jugador jugador = GameManager.jugador;
        float distancia = Vector3.Distance(this.transform.position, jugador.transform.position);
        if (distancia < distanciaAtaque)
        {
            AtaqueSuicida(jugador);
        }
    }
    private void AtaqueSuicida(Jugador jugador)
    {
        jugador.RecibirDaño(dañoAtaque);
        Instantiate(prefabParticulasExplosion,
                    position: this.transform.position,
                    rotation: Quaternion.identity);
        Destroy(this.gameObject);
    }
}
