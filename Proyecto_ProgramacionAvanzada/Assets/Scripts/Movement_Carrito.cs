using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Carrito : MonoBehaviour
{
    /*Script va en la canasta u objeto que va recibir los obejtos que estan cayendo
     * por medio de PlayerPrefs se le asigno a cada producto un numero que manda si este fue seleccionado
     * para indicarle a la canasta que este va a caer y lo pueda interceptar
     */
    public float speed = 1.0f;//Variable publica para ajustar la velocidad de la canasta

    private Transform target;//objetivo/target

    [SerializeField]
    List<GameObject> productos;//Lista de los productos


    void Update()
    {
        //Debug.Log(PlayerPrefs.GetInt("Falling"));

        Follow();
    }

    void Follow()//Función Follow para saber cual objeto cae y mover canasta a su coordenadas
    {
        //Recibe valor de cual objecto/producto es el que esta cayendo
        int f = PlayerPrefs.GetInt("Falling");
        //Debug.Log(f);

        //Lo asigna al target
        target = productos[f].transform;


        // Move our position a step closer to the target.
        float step = speed * Time.deltaTime; // calcula distacia a mover
        transform.position = Vector3.MoveTowards(transform.position, 
            new Vector3(target.position.x, transform.position.y, transform.position.z), step);

        
        // Checa que tan cerca o parecidas son las posiciones
        if (Vector3.Distance(transform.position, target.position) < 0.001f)
        {
            //Si esta ya muy cerca reduce velocidad
            target.position *= -5.0f;
        }
        
    }
}
