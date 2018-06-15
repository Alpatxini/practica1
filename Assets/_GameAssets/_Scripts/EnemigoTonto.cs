using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoTonto : MonoBehaviour {

    [SerializeField] float velocidadMovimiento = 5;

     CharacterController miCC;

	private void Awake()
	{
        miCC = GetComponent<CharacterController>();
	}

	void Start () {
		
	}
	
	
	void Update () {
        
		
	}
    public void RecibirDaño(int daño)
    {
        
    }
}
