using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IngresarDatos : MonoBehaviour
{
    /*Script va en un Empty para controlar el UI donde se le pide al usuario ingresar sus datos
     * Verifica que los campos tenga la información necesaria y que esten los tres completos
     * Una vez terminado regresa a pantalla incial
     * */

    int timeLeft = 2;//Usado para contador de tiempo

    public InputField nameInput;//Input donde va el nombre
    public InputField addressInput;//Input donde va la dirección
    public InputField phoneInput;//Input donde va el telefono

    public GameObject PanelInvalid;

    public Button OKAY;//Boton

    //Booleanos usados para indicar si hay información en los campos de texto
    bool phoneIn = false;
    bool nameIn = false;
    bool addressIn = false;

    void LockInput(InputField input)//Verifica que la información sea del tipo requerido
    {
        if(input.text.Length > 2)//Texto ingresado mayor a 2 caracteres
        {
            //Debug.Log("With Text");
            //Debug.Log(input.contentType);

            if(input.contentType.ToString() == "Name")//Si es campo nombre contiene solo letras regresa true nameIn
            {
                //Debug.Log("Nombre ingresado");
                nameIn = true;
            }else if(input.contentType.ToString() == "IntegerNumber")//Si es campo telefeno contiene solo numeros regresa true phoneIn
            {
                //Debug.Log("Telefono ingresado");
                phoneIn = true;
            }else if(input.contentType.ToString() == "Standard")//Si es campo dirección contiene solo numeros y letras regresa true addressIn
            {
                //Debug.Log("Dirección ingresada");
                addressIn = true;
            }
            
            
        }
        else if(input.text.Length == 0)//Si no se ha ingresado muestra panel con mensaje
        {
            PanelInvalid.SetActive(true);
            //Debug.Log("Por favor ingrese sus datos");
        }
    }

    public void Start()
    {
        //Se manda cada Input field a la función LockInput para verificar que la información ingresada sea correcta y los campos tenga texto
        //A cada Input se le agrega un AddListener para saber cuando se esta editando y se manda la información a la función cuando el usuario da Enter
        nameInput.onEndEdit.AddListener(delegate { LockInput(nameInput); });
        addressInput.onEndEdit.AddListener(delegate { LockInput(addressInput); });
        phoneInput.onEndEdit.AddListener(delegate { LockInput(phoneInput); });
    }


    public void ButtonOK(GameObject mensaje)//Cuando se da clic en el boton se muestra mensaje en pantalla y empieza el timer para cambiar de escena
    {
        mensaje.SetActive(true);
        StartCoroutine("TimerReturn");
    }

    IEnumerator TimerReturn()//Timer usando la variable TimeLeft contara 2 segundos antes de cambiar de escena
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            timeLeft--;
            //Debug.Log(timeLeft);
        }        
    }

    private void Update()//Verifica si las tres banderas son true habilita el boton OKAY de lo contrario se queda deshabilitado
    {
        if(phoneIn == true && nameIn == true && addressIn == true)
        {
            OKAY.GetComponent<Button>().interactable = true;
        }
        else
        {
            OKAY.GetComponent<Button>().interactable = false;
        }

        if(timeLeft == 0)//Si el timeLeft es 0 se realiza cambio de escena
        {
            SceneManager.LoadScene("Menu_Inicio");
        }
    }
}
