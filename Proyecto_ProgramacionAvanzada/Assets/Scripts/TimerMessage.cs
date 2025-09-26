using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerMessage : MonoBehaviour
{
    /*Script usado en el Panel_Invalid para mostrar a usuario mensjae y desactivarse solo despues de 1 segundo
     * Asignado dentro del mismo panel
     * */

    float timeLeft = 2.0f;//Usado para contador de tiempo


    // Update is called once per frame
    void Update()
    {
        Debug.Log(timeLeft);

        if(this.gameObject.activeSelf == true)//si el panel esta activo que empiece a contar el tiempo
        {
            timeLeft -= Time.deltaTime;
            Debug.Log(timeLeft);
        }

        if (timeLeft <= 0)//Si el timeLeft es 0 se realiza cambio de escena
        {
            this.gameObject.SetActive(false);
            timeLeft = 2.0f;//regresa la var a 1 por si se vuelve a mostrar el mensaje
        }
    }


}
