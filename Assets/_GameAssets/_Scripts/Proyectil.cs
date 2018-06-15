using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour {

    [SerializeField] float tiempoVida = 3;

    private void Start()
	{
        Destroy(this.gameObject, tiempoVida);
	}

	private void OnTriggerEnter(Collider other)
	{
        Destroy(this.gameObject);
	}
}
