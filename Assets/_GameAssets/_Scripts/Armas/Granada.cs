using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granada : MonoBehaviour {

    public enum TipoDetonacion{
        PorTiempo,PorColision
    }

    [SerializeField] int daño;
    [SerializeField] float radioExplosion;
    [SerializeField] float retardoExplosion;
    [SerializeField] TipoDetonacion detonacion;
    [SerializeField] GameObject prefabExplosion;

    [SerializeField] LayerMask layersExplosion;


    float temporizador;

	void Start () {
        temporizador = Time.time + retardoExplosion;
        this.transform.forward = Random.insideUnitSphere;
		
	}
	
	// Update is called once per frame
	void Update () {

        if(detonacion==TipoDetonacion.PorTiempo && Time.time>temporizador)
        {
            Explotar();
        }
		
	}


	private void OnCollisionEnter(Collision collision)
	{
        if(detonacion==TipoDetonacion.PorColision)
        {
            Explotar();
        }
	}
    void Explotar()
    {

        dañarEnemigos();
        Instantiate(prefabExplosion,
                    position: this.transform.position,
                    rotation: Quaternion.identity);
        Destroy(this.gameObject);
        
    }
    void dañarEnemigos()
    {
        Collider[]collidersAfectados= Physics.OverlapSphere(
            position: this.transform.position, 
            radius:radioExplosion,
            layerMask: layersExplosion);
        for (int i = 0; i < collidersAfectados.Length; i++)
        {
            Personaje posiblePersonaje = collidersAfectados[i].GetComponentInParent<Personaje>();
            if(posiblePersonaje!=null)
            {
                posiblePersonaje.RecibirDaño(daño);
                Debug.Log("Granada haciendo daño a " + posiblePersonaje.name);
            }
        }
    }
}
