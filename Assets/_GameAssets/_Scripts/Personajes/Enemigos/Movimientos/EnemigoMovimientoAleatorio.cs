using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoMovimientoAleatorio : MonoBehaviour {

    [SerializeField] float tiempoCambioDireccion = 3;
    [SerializeField] float velocidadMovimiento = 5;
    CharacterController miCC;

    private void Awake()
    {
        miCC = GetComponent<CharacterController>();
    }

	void Start () {
        InvokeRepeating("CambiarDireccionMovimiento", 0, tiempoCambioDireccion);
	}
	
	// Update is called once per frame
	void Update () {
        miCC.SimpleMove(this.transform.forward * velocidadMovimiento);
	}
    void CambiarDireccionMovimiento()
    {
        float rotacionAleatoria = Random.Range(0, 360);
        Vector3 rotacionAAplicar = new Vector3(0, rotacionAleatoria, 0);
        this.transform.Rotate(rotacionAAplicar);
    }
}
