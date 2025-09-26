using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Productos_stock : MonoBehaviour
{
    /*Script va en los productos/objetos
     * Guarda la posición y rotación original
     * Checa las colisiones y una vez que cae e intercepta con la canasta o el piso se regresa a su posicion original
     * */

    Vector3 originPos;//variable para guardar posicion inicial
    Quaternion originRot;//variable para guardar su rotacion inicial

    // Se guarda en un inicio posición y rotación inicial
    void Start()
    {
        originPos = transform.localPosition;
        originRot = transform.localRotation;
    }

    void OnTriggerEnter(Collider collider)
    {
        //Checa si toca a la canasta o el piso
        if (collider.gameObject.name == "Basket" || collider.gameObject.name == "Floor")
        {
            //Debug.Log("Toco piso");

            //Le asigna su posición y rotacioón inicial asi como una velocidad de 0 para que no caiga solo
            transform.localPosition = originPos;
            transform.localRotation = originRot;
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }
        
    }
}
