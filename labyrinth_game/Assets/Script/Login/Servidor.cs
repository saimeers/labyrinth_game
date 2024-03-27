using System.Collections;
using UnityEngine.Events;
using UnityEngine;
using UnityEngine.Networking;
[CreateAssetMenu(fileName = "Servidor", menuName = "JS/Servidor", order = 1)]
public class Servidor : ScriptableObject
{
    public string servidor;
    public Servicio[] servicios;
    public bool ocupado = true;
    public Respuesta respuesta;

    public IEnumerator ConsumirServicio(string nombre, string[] datos, UnityAction e)
    {
        ocupado = false;
        WWWForm form = new WWWForm();
        Servicio s = new Servicio();
        for (int i = 0; i < servicios.Length; i++)
        {
            if (servicios[i].nombre.Equals(nombre))
            {
                s = servicios[i];
            }
        }
        for (int i = 0; i < s.parametros.Length; i++)
        {
            form.AddField(s.parametros[i], datos[i]);
        }

        UnityWebRequest www = UnityWebRequest.Post(servidor + "/" + s.URL, form);
        Debug.Log(servidor + "/" + s.URL);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            respuesta = new Respuesta();
        }
        else
        {
            Debug.Log(www.downloadHandler.text);
            respuesta = JsonUtility.FromJson<Respuesta>(www.downloadHandler.text);
            respuesta.LimpiarRespuesta();
        }
        ocupado = false;
        e.Invoke();
    }
}

[System.Serializable]
public class Servicio
{
    public string nombre;
    public string URL;
    public string[] parametros;
}
[System.Serializable]
public class Respuesta
{
    public int codigo;
    public string mensaje;
    public string respuesta; 

    public void LimpiarRespuesta()
    {
        respuesta = respuesta.Replace('#','"');
    }

    public Respuesta()
    {
        codigo  = 404;
        mensaje = "error";
    }
}
[System.Serializable]
public class DBUsuario
{
    public int id;
    public string nombre;
    public string apellido;
    public string correo;
    public int edad;
    public string user;
    public string password;
    public string descripcion;
    public int evasion;
    public int penalizacion;
    public int puntaje;

}
[System.Serializable]
public class DBStats
{
    public string user;
    public string descripcion;
    public int evasion;
    public int penalizacion;
    public int puntaje;
}
[System.Serializable]
public class DBCreateUser
{
    public int id;
    public string nombre;
    public string apellido;
    public string correo;
    public int edad;
    public string user;
    public string password;
    public string descripcion;
    public int evasion;
    public int penalizacion;
    public int puntaje;

}
