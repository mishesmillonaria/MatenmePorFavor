using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverCableArriba : MonoBehaviour
{
    public GameObject cableArribaPrefab; // Tu prefab o el objeto que querés crear
    public Vector3 posicion = new Vector3(0, 3f, 0); // Dónde va a aparecer

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            // Rota el prefab 90 grados para que sea vertical
            Instantiate(cableArribaPrefab, posicion, Quaternion.Euler(0, 0, 90));  // Rota 90 grados en Z
        }
    }
}
