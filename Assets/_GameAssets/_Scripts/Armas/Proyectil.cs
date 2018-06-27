using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour {

    [SerializeField] float tiempoVida = 3;
    [SerializeField] int daño = 1;
    [SerializeField] bool dañaAEnemigos = true;
    [SerializeField] bool dañaAJugador = false;

    [SerializeField] GameObject prefabParticulasImpacto;

    private void Start()
	{
        Destroy(this.gameObject, tiempoVida);
	}

	private void OnTriggerEnter(Collider other)
	{
        HacerDañoAPersonaje(other);

        GenerarParticulasImpacto();

        Destroy(this.gameObject);
	}

    private void GenerarParticulasImpacto()
    {
        GameObject nuevasParticulasImpacto = Instantiate(prefabParticulasImpacto);
        nuevasParticulasImpacto.transform.position = this.transform.position;
    }

    private void HacerDañoAPersonaje(Collider other)
    {
        Personaje personaje = other.GetComponentInParent<Personaje>();

        if (personaje != null)
        {
            if (dañaAEnemigos && personaje.CompareTag("Enemigo") ||
                dañaAJugador && personaje.CompareTag("Jugador"))
            {
                personaje.RecibirDaño(daño);
            }
        }
    }
}
