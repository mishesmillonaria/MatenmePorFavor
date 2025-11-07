using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverCableAbajo : MonoBehaviour
{
    public GameObject cableAbajoPrefab;
    private int _contador;
    private int _max = 5;
   [ SerializeField] private Vector3 posicion = new (0, -3f, 0);

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {

            if (_contador <= _max)
            {
                Vector3 nuevaPos = posicion + new Vector3(0 + _contador, 0, 0);
                Instantiate(cableAbajoPrefab, nuevaPos, Quaternion.Euler(0, 0, -90));
                _contador++;

                Debug.Log("Cable Abajo: " + _contador);
            }
           
        }
    }
}
