using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoTonto : MonoBehaviour {

    [SerializeField] float velocidadMovimiento = 5;
    [SerializeField] float tiempoCambioDireccion = 3;

    [SerializeField] GameObject prefabParticulasMuerte;

     CharacterController miCC;

	private void Awake()
	{
        miCC = GetComponent<CharacterController>();
	}

	void Start () {
        InvokeRepeating("CambiarDireccionMovimiento", 0, tiempoCambioDireccion);
		
	}
	
	
	void Update () {
        miCC.SimpleMove(this.transform.forward * velocidadMovimiento);
		
	}
    void CambiarDireccionMovimiento()
    {
        float rotacionAleatoria = Random.Range(0, 360);
        Vector3 rotacionAAplicar = new Vector3(0, rotacionAleatoria, 0);
        this.transform.Rotate(rotacionAAplicar);
    }

    public void RecibirDaño(int daño)
    {
        GameObject nuevasParticulasMuerte = Instantiate(prefabParticulasMuerte);
        nuevasParticulasMuerte.transform.position = this.transform.position;

        Destroy(this.gameObject);
    }
	
}
