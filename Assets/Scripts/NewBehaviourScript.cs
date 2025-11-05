using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    bool canJump;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
//         if (Input.GetKey("left"))
//         {
//             gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1000f * Time.deltaTime, 0));
//         }
//         if (Input.GetKey("right"))
//         {
//             gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(1000f * Time.deltaTime, 0));
//         }

//         //Salto de Carlos.
//         if (Input.GetKeyDown("up") && canJump)
//         {
//             canJump = false;
//             gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 100f));
//         }
//     }

//     //Añadir tag al suelo. Tag Suelo, agregar etiqueta al suelo.
//     private void OnCollisionEnter2D(Collision2D collision)
//     {
//         if (collision.transform.tag == "suelo")
//         {
//             canJump = true;
//         }
//     }
// }
