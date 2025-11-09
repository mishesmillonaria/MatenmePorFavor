using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuInicial : MonoBehaviour
{
 
    public void Jugar()
    {         
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}