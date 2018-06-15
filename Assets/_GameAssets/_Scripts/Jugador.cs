using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour {

    Pistola pistola;
	
    private void Awake()
	{
        pistola = GetComponentInChildren<Pistola>();
	}

	
	private void Update () {
        
        if(Input.GetButtonDown("Fire1"))
        {
            pistola.ApretarGatillo();
        }
        if(Input.GetButtonUp("Fire1"))
        {
            pistola.SoltarGatillo();
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            pistola.Recargar();
        }
	}
}
