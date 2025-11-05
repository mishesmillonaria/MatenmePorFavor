using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AgarrarCables : MonoBehaviour
{
    public Transform puntaArriba;        // La punta del primer rectángulo
    public Transform puntaAbajo;         // La punta del segundo rectángulo
    public GameObject caramelo;          // El círculo que aparecerá al conectar
    public float distanciaMaxima = 1f;   // Qué tan cerca deben estar las puntas

    private Vector3 ultimaPosPuntaArriba;  // Última posición de la punta de arriba
    private Vector3 ultimaPosPuntaAbajo;   // Última posición de la punta de abajo
    private bool yaUnido = false;          // Flag para saber si ya se unieron estas puntas

    void Start()
    {
        // Inicializar las posiciones de las puntas al principio
        ultimaPosPuntaArriba = puntaArriba.position;
        ultimaPosPuntaAbajo = puntaAbajo.position;
    }

    void Update()
    {
        // Calculamos la distancia entre las dos puntas
        float distancia = Vector2.Distance(puntaArriba.position, puntaAbajo.position);

        // Verificamos si las puntas han cambiado de lugar
        if (puntaArriba.position != ultimaPosPuntaArriba || puntaAbajo.position != ultimaPosPuntaAbajo)
        {
            // Si las puntas han cambiado, se permite generar el círculo
            yaUnido = false;
        }

        // Si presionamos la tecla C y las puntas están lo suficientemente cerca y no han sido unidas
        if (Input.GetKeyDown(KeyCode.C))
        {
            // Si las puntas están lo suficientemente cerca y no han sido unidas antes
            if (distancia <= distanciaMaxima && !yaUnido)
            {
                // Calculamos el punto medio entre ambas puntas
                Vector3 puntoMedio = (puntaArriba.position + puntaAbajo.position) / 2f;

                // Creamos el círculo en el punto medio
                Instantiate(caramelo, puntoMedio, Quaternion.identity);

                // Marcamos que ya se unieron estas puntas
                yaUnido = true;

                // Actualizamos las posiciones anteriores de las puntas
                ultimaPosPuntaArriba = puntaArriba.position;
                ultimaPosPuntaAbajo = puntaAbajo.position;

                Debug.Log("Círculo creado entre las puntas.");
            }
            else if (distancia > distanciaMaxima)
            {
                Debug.Log("Las puntas están demasiado lejos para conectarse.");
            }
        }
    }
}






    
//     public GameObject cable;
//     public Transform mano;

//     private bool activado;

    

//     // Update is called once per frame
//     void Update() {

//         if (activado){
//             if (Input.GetKeyDown(KeyCode.E))
//             {
//                 cable.transform.SetParent(mano);
//                 cable.transform.position = mano.position;
//                 cable.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
//             }
//         }
//     }



//     private void OnTriggerEnter2D(Collider2D other)


//     {

//         if (other.tag == "Cable")
//         {
//             activado = true;

//             cable = other.gameObject;
//         }
//     }

//     private void OnTriggerExit2D(Collider2D other)
//     {
//         if (other.tag == "Cable")
//         {
//             activado = false;
//         }
//     }
// }