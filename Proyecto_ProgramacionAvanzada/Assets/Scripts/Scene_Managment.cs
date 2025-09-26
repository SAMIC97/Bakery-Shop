using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Scene_Managment : MonoBehaviour
{
    /*Script usado para los botones, puesto en un Empty
     * Recibe el nombre del botón al que se dio clic y dependiendo de este realiza una acción
     * */

    public void ButtonPressed(string scene)//recibe un string con un nombre usado ya sea para cambio de escena o cerrar paneles
    {
        string buttonName = EventSystem.current.currentSelectedGameObject.name;//asigna nombre del boton a una var local

        if(buttonName == "Home")//Usado para mostrar mensaje en pantalla antes de regresar a menu inical
        {
            //Debug.Log("Rgresar a Menu_Inicio");
            GameObject.Find("Canvas/Panel/Panel_warning").SetActive(true);//activa panel
            
        }

        else if(buttonName == "Return")//usado cuando el usuario esta en caja pero quiere agregar mas productos por lo que se regresa a la escena de tienda
        {
            //Debug.Log("Regresar a Tienda");
            PlayerPrefsX.SetBool("regresa", true);//Indica el usuario ya tiene una compra y quiere añadir más
            SceneManager.LoadScene(scene);//carga escena Tienda
        }

        else if(buttonName == "Pay")//Usado en escena Caja una vez que el usuario ya quiere finalizar compra
        {
            Debug.Log("Pasar a datos");//cambia de escena para que ingrese sus datos
            PlayerPrefsX.SetBool("regresa", false);//Indica que el usaurio ya no va regresar a añador mas productos
            PlayerPrefs.SetInt("Carrito", 0);//Vacia el carrito
            SceneManager.LoadScene(scene);//cambia de escena a IngresarDatos
        }
        else if(buttonName == "Entrar")//Usado en menu Inicial para ingresar a la tienda
        {
            //Debug.Log("Boton entrar tienda");
            PlayerPrefsX.SetBool("regresa", false);//Para garatizar que no hay información extra guardada y empiece la compra en 0
            PlayerPrefs.SetInt("Carrito", 0);////Para garatizar que no hay información extra guardada y empiece la compra en 0
            SceneManager.LoadScene(scene);//carga escena de Tienda
        }
        else if(buttonName == "Salir")//Usado en Menu_Inicial si el usuario quiere cerrar la aplicación
        {
            Application.Quit();//cierra la app
        }
        else if(buttonName == "Extras")//Usado en Menu_Inicial para mostrar datos del proyecto
        {
            GameObject.Find("Canvas/Panel/Panel_creditos").SetActive(true);//muestra el panel con la información
        }
        else if(buttonName == "Yes")//Usado en el panel_Warning, se le pregunat si desea abandonar compra
        {
            SceneManager.LoadScene(scene);//Cambia a escena Menu_Incial
        }
        else if(buttonName == "No")//Usado en el panel_Warning, se le pregunat si desea abandonar compra
        {
            GameObject.Find(scene).SetActive(false);//Cierra el panel y continua
        }


    }

}
