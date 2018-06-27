using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoTonto : Personaje {
    [SerializeField] GameObject prefabParticulasMuerte;

	protected override void Morir()
	{
        GameObject nuevasParticulasMuerte = Instantiate(prefabParticulasMuerte);
        nuevasParticulasMuerte.transform.position = this.transform.position;

        Destroy(this.gameObject);
	}

}
    