using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Caja_Pagar : MonoBehaviour
{
    /*Script usado en un empty de la escena Cajas
     * recibe los campos de textos para mostrar la compra asi como los de el desgloce
     * se calcula el total de la compra, subtotal e IVA
     * */

    [SerializeField]
    List<Text> CantidadProductos;//mostrar cuantos se lleva de cada producto

    [SerializeField]
    List<Text> TextoSub;//mostrar cuanto es de cada producto

    [SerializeField]
    List<Text> TextosDesgloce;//mostrar el subtotal, IVA y el total

    public int[] CantidadFinal = new int []{ 0, 0, 0, 0, 0, 0, 0, 0};//arreglo donde se guarda las cantidades
    public int[] SubP = new int[] { 0, 0, 0, 0, 0, 0, 0, 0};//arreglo donde se guarda el subtotal

    double sumaSubtotal;//var donde se guarda la suma del subtotal
    double ivaCompra;//var donde se guarda el calculo del IVA
    double totalCompra;//var donde se guarda la suma total

    void Awake()
    {

        CantidadFinal = PlayerPrefsX.GetIntArray("Cantidad");//se le asigna el arreglo de la escena Tienda con la cantidad de cada producto
        SubP = PlayerPrefsX.GetIntArray("Subtotal");//se le asigna el arreglo de la escena Tienda con el subtotal de cada producto

        /*for (int i = 0; i < 8; i++)
        {
            Debug.Log(CantidadFinal[i]);
            //Debug.Log(SubP[i]);
        }*/

        for (int i = 0; i < 8; i++)//Asigna a los campos de texto la información recibida
        {
            CantidadProductos[i].text = CantidadFinal[i].ToString() + " pzas.";
            TextoSub[i].text = "$" + SubP[i].ToString();
        }

        IVA();//se manda llamar la función IVA

    }

    void IVA()//Calculoa el IVA de la compra
    {
        for(int i=0; i<8; i++)
        {
            sumaSubtotal += SubP[i];//Suma cada valor del arreglo para obtener el total del subtotal
        }

        //Debug.Log(sumaSubtotal);
        TextosDesgloce[0].text = "$" + sumaSubtotal.ToString();//asigna el resultado en su campo de texto correspondiente

        ivaCompra = (sumaSubtotal * 16)/100;//calculo el iva con el subtotal y lo guarda en ivaCompra
        TextosDesgloce[1].text = "$" + ivaCompra.ToString();//asigna el resultado en su campo de texto correspondiente

        totalCompra = sumaSubtotal + ivaCompra;//Suma el iva y el subotal para guardarlo en totalCompra
        TextosDesgloce[2].text = "$" + totalCompra.ToString();//asigna el resultado en su campo de texto correspondiente
    }

}
