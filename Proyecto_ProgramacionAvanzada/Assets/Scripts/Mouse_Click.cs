using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mouse_Click : MonoBehaviour
{
    /*Script usado en la escena Tienda, en un empty
     * Checa a que producto se le dio click para agregarle una fuerza 
     * y guarda la información para pasarsela al script Ver_Carrito
     * */
    public Camera mainCamera;//camara usada durante la escena
    public float force;//la fuerza que se le aplicara a los objetos/productos

    [SerializeField]
    List<Text> text_contador;//Mostrar en pantalla el stock de cada porducto

    //Cuanto hay disponible de cada producto
    int[] stock = new int[] { 20, 11, 5, 8, 5, 4, 1, 17 };

    public int[] cantidad;//arreglo que guarda cuanto lleva de cada producto


    void Start()
    {
        if(PlayerPrefsX.GetBool("regresa") == true)//Si el usuario estaba en Cajas y regreso para añadir mas productos
        {
            //Debug.Log("entro regresa mouse_click");
            cantidad = PlayerPrefsX.GetIntArray("Cantidad");//Se vuelven a asignar las cantidades que ya tenia
        }
        else
        {
            cantidad = new int[] { 0, 0, 0, 0, 0, 0, 0, 0 };//De lo contrario empieza en ceros
        }

        for(int i=0; i< stock.Length; i++)
        {
            text_contador[i].text = stock[i].ToString();//muestra el stock de cada producto
        }
        
    }


    void Update()
    {
        if(Input.GetMouseButtonDown(0))//Si se dio clic derecho
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);//localiza las coordenadas donde se dio clic
            RaycastHit hit;

            //Lanza un ray, desde el punto de origen(mouse clic) contra todos los colisionadores de la escena
            if(Physics.Raycast(ray, out hit))
            {

                if (hit.transform.tag == "Producto")//Si este colisionador tiene el tag de Producto
                {
                    hit.collider.attachedRigidbody.AddForce(transform.forward * force);//se la añade una fuerza hacia adelante para que este caiga
                    PlayerPrefs.SetInt("AñadirCarrito", 1);//Se usa para indicar que se debe añadir +1 en el carrito
                }

                //Debug.Log(hit.transform.name);
                if(PlayerPrefsX.GetBool("Remove") == true)//Checa si decidio remover un producto de la lista
                {
                    cantidad = PlayerPrefsX.GetIntArray("Cantidad");//se le asigna de nuevo para actualizar las cantidades
                    PlayerPrefsX.SetBool("Remove", false);//se regresa la bandera a false
                }

                InStock(hit.transform.name);//se le manda el nombre del producto al que se dio clic a la función InStock

                for(int i=0; i<stock.Length; i++)//Esta verificando cuando ya se agoto un articulo
                {
                    int[] stockAgain = new int[] { 20, 11, 5, 8, 5, 4, 1, 17 };//usado para volver a surtir

                    if (stock[i] == 0)//si es igual a cero
                    {
                        switch(i)//recibe cual es el que esta en cero
                        {
                            case 0:
                                GameObject.Find("Galleta").SetActive(false);//desactiva el gameobject para que no se pueda seleccionar mas
                                break;
                            case 1:
                                GameObject.Find("Cuernito").SetActive(false);
                                break;
                            case 2:
                                GameObject.Find("Strudel").SetActive(false);
                                break;
                            case 3:
                                GameObject.Find("Pay").SetActive(false);
                                break;
                            case 4:
                                GameObject.Find("PastelC").SetActive(false);
                                break;
                            case 5:
                                GameObject.Find("PastelV").SetActive(false);
                                break;
                            case 6:
                                GameObject.Find("PastelE").SetActive(false);
                                break;
                            case 7:
                                GameObject.Find("Muffin").SetActive(false);
                                break;
                        }

                        text_contador[i].text = "XXX";//muestra XXX en pantalla para inicar que se acabo el producto
                        stock[i] = stockAgain[i];//vuelve a surtir para que no entre de nuevo en el if, pero no se muestra en pantalla hasta que se inicie de nuevo la escena
                    }
                }

                PlayerPrefsX.SetIntArray("Cantidad", cantidad);//le manda a Ver_Carrito la información de cuanto va de cada producto
            }
        }

        
    }

    void InStock(string ClickOn)//funcion para mantener conteo de los productos en stock y cuantas veces se les ha dado clic
    {
        switch (ClickOn)
        {
            //Cada producto tiene un un numero como idetificador tanto para los arreglos, como indicadores y los textos

            case "Galleta":

                PlayerPrefs.SetInt("Falling", 0);//le indica a la canasta que el producto 0(galleta) se le dio clic y va a caer
                cantidad[0]++;//se suma uno al arreglo

                if (stock[0] > 0)//si es mayor que cero su stock
                {
                    stock[0] = stock[0] - 1;//se le resta uno
                    text_contador[0].text = stock[0].ToString();//se actualiza la información que se muestra en pantalla
                }             
                break;

            case "Cuernito":

                PlayerPrefs.SetInt("Falling", 1);
                cantidad[1]++;

                if (stock[1] > 0)
                {
                    stock[1] = stock[1] - 1;
                    text_contador[1].text = stock[1].ToString();
                }
                break;

            case "Strudel":

                PlayerPrefs.SetInt("Falling", 2);
                cantidad[2]++;

                if (stock[2] > 0)
                {
                    stock[2] = stock[2] - 1;
                    text_contador[2].text = stock[2].ToString();
                }
                break;

            case "Pay":

                PlayerPrefs.SetInt("Falling", 3);
                cantidad[3]++;

                if (stock[3] > 0)
                {
                    stock[3] = stock[3] - 1;
                    text_contador[3].text = stock[3].ToString();
                }                    
                break;

            case "PastelC":

                PlayerPrefs.SetInt("Falling", 4);
                cantidad[4]++;

                if (stock[4] > 0)
                {
                    stock[4] = stock[4] - 1;
                    text_contador[4].text = stock[4].ToString();
                }
                break;

            case "PastelV":

                PlayerPrefs.SetInt("Falling", 5);
                cantidad[5]++;

                if (stock[5] > 0)
                {
                    stock[5] = stock[5] - 1;
                    text_contador[5].text = stock[5].ToString();
                }
                break;

            case "PastelE":

                PlayerPrefs.SetInt("Falling", 6);
                cantidad[6]++;

                if (stock[6] > 0)
                {
                    stock[6] = stock[6] - 1;
                    text_contador[6].text = stock[6].ToString();
                }
                break;

            case "Muffin":

                PlayerPrefs.SetInt("Falling", 7);
                cantidad[7]++;

                if (stock[7] > 0)
                {
                    stock[7] = stock[7] - 1;
                    text_contador[7].text = stock[7].ToString();
                }
                break;
        }


    }
}
