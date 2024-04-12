using System;
using System.Collections;
using System.Net.Mail;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
    public Servidor servidor;

    [SerializeField] private TMP_InputField l_user;
    [SerializeField] private TMP_InputField l_password;
    [SerializeField] private TMP_InputField nombre;
    [SerializeField] private TMP_InputField apellido;
    [SerializeField] private TMP_InputField correo;
    [SerializeField] private TMP_InputField edad;
    [SerializeField] private TMP_InputField r_user;
    [SerializeField] private TMP_InputField r_password;

    [SerializeField] private TMP_InputField error;

    [SerializeField] private GameObject imLoading;
    [SerializeField] private GameObject iniciarSesion;
    [SerializeField] private GameObject registrarUsuario;
    public static Login singleton;

    void Awake()
    {
        if(singleton == null)
        {
            singleton = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    public DBUsuario usuario;
    public DBStats stats;
    public DBCreateUser register;
    public void IniciarSesion()
    {
        StartCoroutine(Iniciar());
    }
    public void RegistrarEstadisticas()
    {
        StartCoroutine(RegistrarPartida());
    }
    public void EndGame()
    {
        Destroy(gameObject);
    }
    public void RegistrarUsuario()
    {
        StartCoroutine(Registrar());
    }
    public void SceneIniciarSesion()
    {
        registrarUsuario.SetActive(false);
        iniciarSesion.SetActive(true);
        error.text = "";
    }
    public void SceneRegistrarUsuario()
    {
        registrarUsuario.SetActive(true);
        iniciarSesion.SetActive(false);
        error.text = "";
    }

    //consumir servicios 
    IEnumerator Iniciar()
    {
        imLoading.SetActive(true);
        string[] datos = new string[2];
        datos[0] = l_user.text;
        datos[1] = l_password.text;
        StartCoroutine(servidor.ConsumirServicio("login", datos,PosCargar));
        l_user.text = "";
        l_password.text = "";
        yield return new WaitForSeconds(1.5f);
        yield return new WaitUntil(() => !servidor.ocupado);
        imLoading.SetActive(false);
    }
    IEnumerator Registrar()
    {
        
        if (nombre.text != "" && apellido.text != "" && correo.text != "" && 
            edad.text != "" && r_user.text != "" && r_password.text != "")
        {
            if (!Regex.IsMatch(nombre.text, "^[a-zA-Z ]+$"))
            {
                error.text = "El nombre solo debe contener letras y espacios";
            }
            else
            {
                if(!Regex.IsMatch(apellido.text, "^[a-zA-Z ]+$"))
                {
                    error.text = "El apellido solo debe contener letras y espacios";
                }
                else
                {
                    if (!IsValidEmail(correo.text))
                    {
                        error.text = "El correo electrónico no es válido";
                    }
                    else
                    {
                        int edadInt;
                        if (!int.TryParse(edad.text, out edadInt))
                        {
                            error.text = "La edad debe ser un número entero";
                        }
                        else
                        {
                            if (!Regex.IsMatch(r_password.text, "^(?=.*[0-9])[A-Za-z0-9]{6,}$"))
                            {
                                error.text = "La contraseña debe tener al menos 6 caracteres y un número.";
                            }
                            else
                            {
                                imLoading.SetActive(true);

                                string[] datos = new string[10];
                                datos[0] = nombre.text;
                                datos[1] = apellido.text;
                                datos[2] = correo.text;
                                datos[3] = edad.text;
                                datos[4] = r_user.text;
                                datos[5] = r_password.text;
                                datos[6] = "";
                                datos[7] = "";
                                datos[8] = "";
                                datos[9] = "";
                                StartCoroutine(servidor.ConsumirServicio("registrar usuario", datos, PosCargar));
                                nombre.text = "";
                                apellido.text = "";
                                correo.text = "";
                                edad.text = "";
                                r_user.text = "";
                                r_password.text = "";
                            }
                        }
                    }
                }
            }
        }
        else
        {
            error.text = "Faltan datos";
        }
        yield return new WaitForSeconds(0.5f);
        yield return new WaitUntil(() => !servidor.ocupado);
        imLoading.SetActive(false);
       
    }
    IEnumerator RegistrarPartida()
    {
        string[] datos = new string[5];
        datos[0] = usuario.user ;
        datos[1] = stats.descripcion;
        datos[2] = stats.evasion.ToString();
        datos[3] = stats.penalizacion.ToString();
        datos[4] = stats.puntaje.ToString();

        StartCoroutine(servidor.ConsumirServicio("stats", datos, PosCargar));
        yield return new WaitUntil(() => !servidor.ocupado);

    }

    //función adicional, itera después de consumir el servicio 
    void PosCargar()
    {
        switch (servidor.respuesta.codigo)
        {
            case 204: //el usuario o la contraseña son incorrectos
                error.text = servidor.respuesta.mensaje;
                break;
            case 205: //inicio de sesion correcto
                Debug.Log(servidor.respuesta.respuesta);
                
                usuario = JsonUtility.FromJson<DBUsuario>(servidor.respuesta.respuesta);
                SceneManager.LoadScene(2);
                break;
            case 208: //stats subidas correctamente 
                stats = JsonUtility.FromJson<DBStats>(servidor.respuesta.respuesta);
                error.text = servidor.respuesta.mensaje;
                break;
            case 210: //registro hecho satisfactoriamente
                break;
            case 402: //faltan datos para ejecutar la acción solicitada
                error.text = servidor.respuesta.mensaje;
                break;
            case 403: //Usuario encontrado 
                error.text = servidor.respuesta.mensaje;
                break;
            case 404: //error
                error.text = servidor.respuesta.mensaje;
                break;
            case 405: //Correo encontrado 
                error.text = servidor.respuesta.mensaje;
                break;
            default:
                break;
        }
    }
    bool IsValidEmail(string email)
    {
        try
        {
            new MailAddress(email);
            return true;
        }
        catch (FormatException)
        {
            return false;
        }
    }
    
}
