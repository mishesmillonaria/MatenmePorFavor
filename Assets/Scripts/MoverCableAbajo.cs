using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverCableAbajo : MonoBehaviour
{

    private int _contador;
    private int _max = 5;
    public GameObject cableAbajoPrefab;
    public Vector3 posicion = new Vector3(0, -3f, 0);

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        { 
            if (_contador <= _max)
            {
                Instantiate(cableAbajoPrefab, posicion, Quaternion.Euler(0, 0, 90));

                _contador++;
            }
        }
    }
}
