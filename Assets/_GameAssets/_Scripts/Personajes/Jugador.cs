using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Jugador : Personaje {



    Arma []armas;
    Arma armaEquipada;

    int indiceArmaEquipada;

    public Arma GetArmaEquipada()
    {
        return armaEquipada;
    }

    private void Awake()
	{
        GameManager.jugador = this;

        armas = GetComponentsInChildren<Arma>(includeInactive:true); 
        EquiparArma(0);
    }


	private void Update ()
    {
        ComprobarInputDisparo();

        ComprobarCambioArma();
    }

    private void ComprobarCambioArma()
    {
        Vector2 inputRueda = Input.mouseScrollDelta;
        float inputRuedaVertical = inputRueda.y;

        if(inputRuedaVertical>0)
        {
            indiceArmaEquipada += 1;
            if (indiceArmaEquipada >= armas.Length)
            { indiceArmaEquipada = 0; }
            EquiparArma(indiceArmaEquipada);
        }

        if (inputRuedaVertical < 0)
        {
            indiceArmaEquipada -= 1;
            if (indiceArmaEquipada < 0)
            { indiceArmaEquipada = armas.Length - 1;}
            EquiparArma(indiceArmaEquipada);
        }

        for (int teclaArma = 1; teclaArma <= armas.Length; teclaArma++)
        {
            if (Input.GetKeyDown(teclaArma.ToString()))
            {
                indiceArmaEquipada = teclaArma - 1;
                    EquiparArma(indiceArmaEquipada);
            }
        }
    }

    private void ComprobarInputDisparo()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            armaEquipada.ApretarGatillo();
        }
        if (Input.GetButtonUp("Fire1"))
        {
            armaEquipada.SoltarGatillo();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            armaEquipada.Recargar();
        }
    }

    private void EquiparArma(int indiceArma)
    {
        for (int i = 0; i < armas.Length; i++)
        {
            armas[i].gameObject.SetActive(false);
        }

        armas[indiceArma].gameObject.SetActive(true);
        armaEquipada = armas[indiceArma];
    
    }
	protected override void Morir()
	{
        this.enabled = false;
        this.GetComponent<CharacterController>().enabled = false;
        this.GetComponent<FirstPersonController>().enabled = false;
        Debug.Log("FIN DE PARTIDA");
	}
}
