using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaRaycast : Arma {

    [SerializeField] float tiempoEntreDisparos;
    [SerializeField] AudioSource audioDisparo;
    [SerializeField] int daño =100;

    [SerializeField] GameObject canvasFrancotirador;

    [SerializeField] float zoomFOV = 15;
    float inicialFOV;


    protected float tiempoUltimoDisparo;
    private Camera camara;

	void Awake()
	{
        camara = Camera.main;
        inicialFOV = camara.fieldOfView;
	}

	private void OnDisable()
	{
        DesactivarZoom();
	}

	private void Update()
	{
        if(Input.GetMouseButtonDown(1))
        {
            ActivarZoom();
        }
        if(Input.GetMouseButtonUp(1))
        {
            DesactivarZoom();
        }
	}

    void ActivarZoom()
    {
        camara.fieldOfView = zoomFOV;
        canvasFrancotirador.SetActive(true);
    }

    void DesactivarZoom()
    {
        camara.fieldOfView = inicialFOV;
        canvasFrancotirador.SetActive(false);
    }



    public override void ApretarGatillo()
    {
        DispararArma();
    }

    private void DispararArma()
    {
        if (Time.time > tiempoUltimoDisparo + tiempoEntreDisparos)
        {
            if (municionActualCargador > 0 && !estoyRecargando)
            {
                municionActualCargador -= 1;
                tiempoUltimoDisparo = Time.time;
                audioDisparo.Play();
                LanzarRaycast();
            }
            else if (municionActualCargador == 0 && !estoyRecargando)
            {
                audioRecargaFallida.Play();
            }
        }
    }

    void LanzarRaycast()
    {
        Vector3 posicionCamara = camara.transform.position;
        Vector3 forwardCamara = camara.transform.forward;

        Ray rayo = new Ray(posicionCamara, forwardCamara);

        RaycastHit infoImpacto;
        if(Physics.Raycast(rayo,out infoImpacto))
        {
            Collider colliderImpactado = infoImpacto.collider;
            Personaje personaje = colliderImpactado.GetComponentInParent<Personaje>();
            if (personaje != null && personaje.CompareTag("Enemigo"))
            {
                personaje.RecibirDaño(daño);
            }

        }
    }

}
