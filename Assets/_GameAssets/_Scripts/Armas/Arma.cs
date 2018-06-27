using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour {

    #region Propiedades inspector


    [SerializeField] protected float tiempoRecarga = 1.5f;

    [Space]

    [SerializeField] protected int municionMaximaInventario = 32;
    [SerializeField] protected int municionActualInventario = 8;

    [SerializeField] protected int municionMaximaCargador = 8;
    protected int municionActualCargador;

    [Space]

    [Header("Audio")]
    [SerializeField] protected AudioSource audioRecarga;

    [SerializeField] protected AudioSource audioRecargaFallida;

    [SerializeField] private Sprite iconoArma;

   

    #endregion
    protected bool estoyRecargando = false;
    protected bool gatilloApretado = false;



    public int GetMunicionActualCargador()
    {
        return municionActualCargador;
    }

    public int GetMunicionActualInventario()
    {
        return municionActualInventario;
    }
    public Sprite GetIconoArma()
    {
        return iconoArma;
    }

    protected virtual void Start()
    {
        municionActualCargador = municionMaximaCargador;
        municionActualInventario = Mathf.Min(municionActualInventario, municionMaximaInventario);
    }

    public virtual void ApretarGatillo()
    {
        
    }
    public virtual void SoltarGatillo()
    {
        
    }
    public virtual void Recargar()
    {
        bool cargadorATope = (municionActualCargador == municionMaximaCargador);
        bool tengoBalas = municionActualInventario > 0;
        if (!estoyRecargando && !cargadorATope && tengoBalas)
        {
            estoyRecargando = true;
            audioRecarga.Play();
            Invoke("FinalizarRecarga", tiempoRecarga);
        }
        else if (!tengoBalas)
        {
            audioRecargaFallida.Play();
        }
    }

    private void FinalizarRecarga()
        {
            int municionARecargar = municionMaximaCargador - municionActualCargador;
        municionARecargar = Mathf.Min(municionARecargar, municionActualInventario);

        municionActualInventario -= municionARecargar;
        municionActualCargador += municionARecargar;
        estoyRecargando = false;

        }

   

}


