using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class ComportamientoRatas : MonoBehaviour
{
    [Header("Movimiento")]
    [SerializeField] private float velocidad = 3f;
    [SerializeField] private float tiempoEsperaAntesDeHuir = 0.3f; // después de ser golpeada
    [SerializeField] private float tiempoVisible = 2f; // cuánto se queda visible antes de huir sola

    [Header("Sprites")]
   private Sprite spriteSubiendo;
   private Sprite spriteEsperando;
   private Sprite spriteGolpeada;
   private Sprite spriteHuyendo; // 🔹 nuevo sprite para huida sin golpe

    [SerializeField] private Animator _animator;

    [Header("Eventos opcionales")]
    public UnityEvent OnRataHuyo;

    private SpriteRenderer sr;
    private Vector3 puntoInicio;
    private Vector3 puntoVisible;
    private Vector3 puntoHuida;
    private bool huyendo = false;
    private bool esperando = false;

    private Coroutine bajarCoroutine;
    private Coroutine esperaCoroutine;
    private Coroutine huirCoroutine;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        if (sr == null)
        {
            Debug.LogError($"❌ El objeto '{name}' no tiene SpriteRenderer.");
            return;
        }

        puntoInicio = new Vector3(transform.position.x, 100f, 0f);
        puntoVisible = new Vector3(transform.position.x, 24f, 0f);
        puntoHuida = puntoInicio;

        transform.position = puntoInicio;
        bajarCoroutine = StartCoroutine(BajarYEsperar());
    }

    private IEnumerator BajarYEsperar()
    {
        _animator.SetBool("escapando", false);
        _animator.SetBool("mordiendoCable", false);
        esperando = false;
        huyendo = false;

        // bajar
        while (Vector3.Distance(transform.position, puntoVisible) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, puntoVisible, velocidad * Time.deltaTime);
            yield return null;
        }

        transform.position = puntoVisible;
        _animator.SetBool("mordiendoCable", true);
        esperando = true;

        // arrancamos la coroutine de espera separada para poder cancelarla
        esperaCoroutine = StartCoroutine(EsperarAntesDeHuir());
    }

    private IEnumerator EsperarAntesDeHuir()
    {
        yield return new WaitForSeconds(tiempoVisible);
        esperaCoroutine = null;

        // si aún está esperando y no huyendo → huir automáticamente
        if (esperando && !huyendo)
        {
            huyendo = true;
            esperando = false;
            huirCoroutine = StartCoroutine(Huir(false));

            _animator.SetBool("mordiendoCable", false);
            _animator.SetBool("escapando", true);
        }
    }

    public void GolpeadaYHuir()
    {
        if (huyendo) return;

        huyendo = true;
        esperando = false;

        // detener coroutines que puedan seguir activas
        if (bajarCoroutine != null)
        {
            StopCoroutine(bajarCoroutine);
            bajarCoroutine = null;
        }

        if (esperaCoroutine != null)
        {
            StopCoroutine(esperaCoroutine);
            esperaCoroutine = null;
        }

        if (sr != null && spriteGolpeada != null)
            sr.sprite = spriteGolpeada;

        huirCoroutine = StartCoroutine(Huir(true));
    }

    private IEnumerator Huir(bool fueGolpeada)
    {
        // 🔹 Cambia el sprite según el tipo de huida
        if (!fueGolpeada && spriteHuyendo != null)
        {

            _animator.SetBool("mordiendoCable", false);
            _animator.SetBool("escapando", true);
        }

        if (fueGolpeada)
            yield return new WaitForSeconds(tiempoEsperaAntesDeHuir);

        float velocidadHuida = velocidad * 3f;

        while (Vector3.Distance(transform.position, puntoHuida) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, puntoHuida, velocidadHuida * Time.deltaTime);
            yield return null;
        }

        transform.position = puntoHuida;
        OnRataHuyo?.Invoke();

        Destroy(gameObject);

        huirCoroutine = null;
    }
}