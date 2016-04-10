using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;

//[XmlRoot("Datos")]
public static class Datos  {

    private static bool hayDatos = false;

    //[XmlArray("Posiciones")]
   // [XmlArrayItem("Posicion")]

    //private static List<Vector3> Posiciones = new List<Vector3>();

    public static bool GetHayDatos()
    {
        return hayDatos;
    }

    public static void SetHayDatos(bool datos)
    {
        hayDatos = datos;
    }
    
}
