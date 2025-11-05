using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverCableAbajo : MonoBehaviour
{
    public GameObject cableAbajoPrefab; // Este es el campo que debería aparecer en el Inspector
    public Vector3 posicion = new Vector3(0, -3f, 0); // Este también

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Instantiate(cableAbajoPrefab, posicion, Quaternion.Euler(0, 0, 90));  // Rota 90 grados en Z
        }
    }
}
