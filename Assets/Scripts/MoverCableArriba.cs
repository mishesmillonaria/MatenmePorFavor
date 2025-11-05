using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverCableArriba : MonoBehaviour
{

    public GameObject cableArribaPrefab;
    private int _contador;
    private int _max = 5;
    public Vector3 posicion = new Vector3(0, 3f, 0);

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {

            if (_contador <= _max)
            {
                Instantiate(cableArribaPrefab, posicion, Quaternion.Euler(0, 0, 90));

                _contador++;
            }
           
        }
    }
}
