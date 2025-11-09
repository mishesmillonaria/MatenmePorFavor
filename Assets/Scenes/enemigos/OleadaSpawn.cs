using System.Collections;
using UnityEngine;

[System.Serializable]
public class Oleada
{
    public string nombre;
    public int cantidadRatas;
    public GameObject[] prefabsRatas;
    public float tiempoEntreRatas = 1f;
}

public class OleadaSpawn : MonoBehaviour
{
    [Header("Referencias")]
    public Oleada[] oleadas;
    public Transform puntoSpawn;
    public BarraProgreso barraProgreso;

    private int indiceOleada = 0;
    private int ratasRestantes;
    private ComportamientoRatas rataActual;

    void Start()
    {
        if (oleadas == null || oleadas.Length == 0)
        {
            Debug.LogWarning("⚠️ No hay oleadas configuradas.");
            return;
        }

        if (puntoSpawn == null)
        {
            Debug.LogError("❌ Falta asignar el punto de spawn en el Inspector.");
            return;
        }

        if (barraProgreso == null)
        {
            Debug.LogError("❌ Falta asignar la BarraProgreso en el Inspector.");
            return;
        }

        IniciarOleada(indiceOleada);
    }

    void Update()
    {
        // Si hay una rata activa y la barra está llena → huye
        if (rataActual != null && barraProgreso.barIsFull)
        {
            rataActual.GolpeadaYHuir();
            barraProgreso.ResetBarra(); // 🔹 Reset de la barra al golpear
            rataActual = null;
            
        }
    }

    void IniciarOleada(int indice)
    {
        Oleada actual = oleadas[indice];

        if (actual.prefabsRatas == null || actual.prefabsRatas.Length == 0)
        {
            Debug.LogError($"❌ La oleada '{actual.nombre}' no tiene prefabs asignados.");
            return;
        }

        ratasRestantes = actual.cantidadRatas;
        StartCoroutine(SpawnearRata());
    }

    IEnumerator SpawnearRata()
    {
        Oleada actual = oleadas[indiceOleada];

        if (ratasRestantes > 0)
        {
            GameObject prefab = actual.prefabsRatas[Random.Range(0, actual.prefabsRatas.Length)];
            GameObject nueva = Instantiate(prefab, puntoSpawn.position, Quaternion.identity);

            rataActual = nueva.GetComponent<ComportamientoRatas>();
            rataActual.OnRataHuyo.AddListener(OnRataHuyo);

            ratasRestantes--;
        }

        yield return null;
    }

    IEnumerator EsperarProximaRata()
    {
        yield return new WaitForSeconds(oleadas[indiceOleada].tiempoEntreRatas);

        if (ratasRestantes > 0)
        {
            StartCoroutine(SpawnearRata());
        }
        else
        {
            indiceOleada++;

            if (indiceOleada < oleadas.Length)
            {
                Debug.Log($"👉 Nueva oleada iniciada: {oleadas[indiceOleada].nombre}");
                IniciarOleada(indiceOleada);
            }
            else
            {
                Debug.Log("🎉 Todas las oleadas completadas");
            }
        }
    }

    void OnRataHuyo()
    {
        Debug.Log("🐀 Una rata huyó!");
        StartCoroutine(EsperarProximaRata());
    }
}