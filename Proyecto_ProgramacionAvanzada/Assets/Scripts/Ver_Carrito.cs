using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class Ver_Carrito : MonoBehaviour
{
    /*Script usado en la escena Tienda, en un Empty
     * Lleva la cuenta de cuantos productos lleva el usuario
     * muestra la compra en una lista y le permite remover elementos
     * */
    public Text contador;//texto donde se muestra cuantos producto lleva en general. Texto junto a icono de canasta

    int[] price = {10, 12, 15, 30, 45, 70, 80, 20};//arreglo con el precio de cada producto
    public int[] values;//arreglo donde se guarda cuanto lleva de cada producto
    public int[] subT;//arrego donde guarda el subtotal de cada producto
    int enCarrito;//usado para guardar cuantos producto lleva en general

    [SerializeField]
    List<Text> PriceProduct;//Textos de la lista para mostrar el subtotal

    [SerializeField]
    List<Text> CuantityProduct;//Textos de la lista para mostrar las cantidades


    void Start()
    {
        if (PlayerPrefsX.GetBool("regresa") == true)//Si el usuario estaba en Cajas y regreso para añadir mas productos
        {
            enCarrito = PlayerPrefs.GetInt("Carrito");//se vuelve a asignar la cantidad que ya lleva el usuario
            PlayerPrefs.SetInt("AñadirCarrito", 0);
        }
        else
        {
            enCarrito = 0;//de lo contrario empieza en 0
            values = new int[] { 0, 0, 0, 0, 0, 0, 0, 0 };//de lo contrario empieza en 0

        }

        subT = new int[] { 0, 0, 0, 0, 0, 0, 0, 0 };//Se inicializa el arreglo en cero ya que se calcula durante la ejecucción

        contador.text = enCarrito.ToString();//muestra la cantidad numero de articulos en canasta

    }


    void Update()
    {
        if(PlayerPrefs.GetInt("AñadirCarrito") == 1)//recibe el dato de Mouse_Clic cuando se da clic en un producto
        {
            enCarrito++;//le suma a la var uno
            PlayerPrefs.SetInt("AñadirCarrito", 0);//regresa a cero la varialbe            
        }

        if(enCarrito == 0)//Verifica si esta en 0
        {
            enCarrito = 0;//si es 0 se le vuelve a asiganr cero para que se quede así y no mostrar negativos
        }

        contador.text = enCarrito.ToString();//actualiza el texto en pantalla

    }

    void Add()//Función Add para mostrar en los textos las cantidades y subtotales
    {

        CalculateSub();//Manda llamar función para calcular el subtotal

        for (int i=0; i<8; i++)//asigna los valores a sus textos correspondientes
        {
            CuantityProduct[i].text = "x" + values[i].ToString();           
            PriceProduct[i].text = "$" + subT[i].ToString();
        }

    }

    public void SeeList(GameObject panel)//Función asiganda al boton de la canasata para mostrar la lista de articulos que lleva
    {
        values = PlayerPrefsX.GetIntArray("Cantidad");//asigna a su arreglo los valores que manda Mouse_Click
        Add();//Manda a llamar la función Add para asignar los valores a sus textos        
        panel.SetActive(true);//muestra el panel con la lista
        GameObject.Find("Click_Manager").GetComponent<Mouse_Click>().enabled=false;//deshabilita el script de Mouse_Click para que no se pueda dar clic a los productos mientras se ve la lista
    }

    public void ButtonPay(string scene)//Función asiganda al boton del panel Ver_Lista
    {

        if(enCarrito > 0)//Verifica que en el carrito haya mas de un cero productos a comprar
        {
            PlayerPrefsX.SetIntArray("Cantidad", values);//asigna el arreglo de las cantidades para la escena de Cajas y/o en caso que el usuario desee regresar y añadir mas
            PlayerPrefsX.SetIntArray("Subtotal", subT); //asigna el arreglo de los subtotales para la escena de Cajas y/o en caso que el usuario desee regresar y añadir mas
            PlayerPrefs.SetInt("Carrito", enCarrito);//asigna el valor para guardarlo
            SceneManager.LoadScene(scene);//carga la escena Cajas
        }
        else//de lo contrario muestra panel con mensaje
        {
            GameObject.Find("Canvas/Panel/Panel_Invalid").SetActive(true);
            //Debug.Log("debe comprar al menos 1 articulo");
        }
        
    }

    public void CloseList(GameObject panel)//Función asignada al boton "X" del panel
    {
        panel.SetActive(false);//desactiva el panel
        GameObject.Find("Click_Manager").GetComponent<Mouse_Click>().enabled = true;//vuelve a activar el script Mouse_Click
    }

    void CalculateSub()//Func+ion calcula el subtotal de los productos
    {
        for(int i=0; i<8; i++)
        {
            subT[i] = values[i] * price[i];//los asigna al arreglo
        }
    }

    public void RemoveItem()//Función asignada a los botones de "-" en el panel para remover elementos
    {
        //Cada boton tiene un nombre para identificar a cual linea/producto le quiere restar
        string buttonName = EventSystem.current.currentSelectedGameObject.name;//convierte el nombre a un string

        switch (buttonName)//Verifica a cual le dio clic
        {
            case "Erase1":
                if(values[0] == 0)//en caso de que se le dio clic y es cero
                {
                    values[0] = 0; //se deja el cero
                }
                else
                {
                    values[0] = values[0] - 1;//se le resta uno en el arreglo
                    enCarrito--;//y se le resta en el carrito
                }
                break;

            case "Erase2":
                if (values[1] == 0)
                {
                    values[1] = 0; 
                }
                else
                {
                    values[1] = values[1] - 1;
                    enCarrito--;
                }
                break;

            case "Erase3":
                if (values[2] == 0)
                {
                    values[2] = 0;
                }
                else
                {
                    values[2] = values[2] - 1;
                    enCarrito--;
                }
                break;

            case "Erase4":
                if (values[3] == 0)
                {
                    values[3] = 0;
                }
                else
                {
                    values[3] = values[3] - 1;
                    enCarrito--;
                }
                break;

            case "Erase5":
                if (values[4] == 0)
                {
                    values[4] = 0;
                }
                else
                {
                    values[4] = values[4] - 1;
                    enCarrito--;
                }
                break;

            case "Erase6":
                if (values[5] == 0)
                {
                    values[5] = 0;
                }
                else
                {
                    values[5] = values[5] - 1;
                    enCarrito--;
                }
                break;

            case "Erase7":
                if (values[6] == 0)
                {
                    values[6] = 0;
                }
                else
                {
                    values[6] = values[6] - 1;
                    enCarrito--;
                }
                break;

            case "Erase8":
                if (values[7] == 0)
                {
                    values[7] = 0;
                }
                else
                {
                    values[7] = values[7] - 1;
                    enCarrito--;
                }
                break;
        }

        PlayerPrefsX.SetIntArray("Cantidad", values);//Le manda el arreglo actualizado a Mouse_Clic
        PlayerPrefsX.SetBool("Remove", true);//Se le indica que se removio un elemento con el bool

        CalculateSub();//se vuelve a calcular en base a el nuevo arreglo

        for (int i = 0; i < 8; i++)//se actualiza la información que se muestra en pantalla
        {
            CuantityProduct[i].text = "x" + values[i].ToString();
            PriceProduct[i].text = "$" + subT[i].ToString();
        }        
    }

}
