using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgarrarCables : MonoBehaviour
{
    public Transform puntaArriba;        
    public Transform puntaAbajo;         
    public GameObject caramelo;          
    public float distMaxima = 8f;   

    private Vector3 posArriba;  
    private Vector3 posAbajo;   
    private bool cablesUnidos = false;          

    void Start()
    {
        posArriba = puntaArriba.position;
        posAbajo = puntaAbajo.position;
    }

    void Update()
    {
        
        float dist = Vector2.Distance(puntaArriba.position, puntaAbajo.position);

        if (puntaArriba.position != posArriba || puntaAbajo.position != posAbajo)
        {

            cablesUnidos = false;
        }

        if (Input.GetKeyDown(KeyCode.C))
        {

            if (dist <= distMaxima && !cablesUnidos)
            {

                Vector3 puntoMedio = (puntaArriba.position + puntaAbajo.position) / 2f;
                
                Instantiate(caramelo, puntoMedio, Quaternion.identity);

                cablesUnidos = true;

                posArriba = puntaArriba.position;
                posAbajo = puntaAbajo.position;
            }
            else if (dist > distMaxima)
            {
                Debug.Log("Las puntas están muy lejos.");
            }
        }
    }
}
