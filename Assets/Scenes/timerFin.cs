using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Countdown : MonoBehaviour
{
    [SerializeField] private float tiempoParaTerminar = 0f;
    [SerializeField] private string escenaPerdiste;
    [SerializeField] private string escenaGanaste;
    private float tiempoQuePaso;

    void Update()
    {
        tiempoQuePaso += Time.deltaTime;
        
        if (tiempoQuePaso > tiempoParaTerminar)
        {
            SceneManager.LoadScene(escenaPerdiste);
        }
    }
}
// video: https://www.youtube.com/watch?v=Oe9BZVnoedE