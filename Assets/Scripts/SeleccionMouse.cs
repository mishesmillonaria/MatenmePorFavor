using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeleccionMouse : MonoBehaviour

{
    public bool isSelected = false;
    [SerializeField] private string CablesTag = "Cables";



    void OnMouseDown()
    {

        if (CompareTag(CablesTag))
        {
            if (isSelected)
            {
                isSelected = false;
                Debug.Log("No se seleccionó");
            }
            else
            {
                isSelected = true;
                Debug.Log("Se seleccionó");
            }
        }
    }
}




