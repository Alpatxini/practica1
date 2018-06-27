using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoMovimientoSeguimiento : MonoBehaviour {

    [SerializeField] float velocidadMovimiento;

    CharacterController miCC;

	private void Awake()
	{
        miCC = GetComponent<CharacterController>();
	}
	
	void Update () {

        this.transform.LookAt(GameManager.jugador.transform);

        //SimpleMove ya aplica por si mismo el time.deltaTime
        miCC.SimpleMove(this.transform.forward * velocidadMovimiento);
		
	}
}
