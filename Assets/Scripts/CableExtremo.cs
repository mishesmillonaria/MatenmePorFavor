using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CableExtremo : MonoBehaviour
{
    [SerializeField] private GameObject _caramelo;
    [SerializeField] private string _tag;

    private GameObject _objetivo;
  
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && _objetivo != null) {

            Vector3 puntoMedio = (transform.position + _objetivo.transform.position) / 2f;

            Instantiate(_caramelo, puntoMedio, Quaternion.identity);
       } 
    }

    private void OnTriggerEnter2D(Collider2D collision) {

        if (collision.CompareTag(_tag))
        {
            _objetivo = collision.gameObject;

        }
    }

    private void OnTriggerExit2D(Collider2D collision) {

        if (_objetivo == collision.gameObject)
        {
            _objetivo = null;

        }
    }
}
