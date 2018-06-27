using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour {

    [SerializeField] protected int vidaMaxima = 100;

    protected int vidaActual;
    protected bool estoyMuerto = false;

    protected virtual void Start()
    {
        vidaActual = vidaMaxima;
    }
	
	void Update () {
		
	}
    public int GetVidaActual()
    {
        return vidaActual;
    }

    public int GetVidaMaxima()
    {
        return vidaMaxima;
    }
    public void RecibirDaño(int dañoAtaque)
    {
        vidaActual = Mathf.Max(0, vidaActual - dañoAtaque);
        if (vidaActual == 0)
        {
            ComprobarMuerte();
        }
    }
    private void ComprobarMuerte()
    {
        if (!estoyMuerto)
        {
            estoyMuerto = true;
            Morir();
        }
    }

    protected virtual void Morir()
    {
        
    }
}
