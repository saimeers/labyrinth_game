using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimacionUI : MonoBehaviour
{

   public GameObject Logo;
   public GameObject LogoU;
   public GameObject LogoS;
    [SerializeField] private GameObject inicioGrupo;
    [SerializeField] private GameObject grupoU;
    [SerializeField] private GameObject grupoS;


    private void Start()
    {
        LeanTween.moveX(Logo.GetComponent<RectTransform>(), 0, 4f).setDelay(16f).setEase(LeanTweenType.easeOutElastic).setOnComplete(bajarAlpha);
        LeanTween.moveX(LogoU.GetComponent<RectTransform>(), 0, 3).setDelay(9f).setEase(LeanTweenType.easeOutElastic).setOnComplete(bajarAlpha1);
        LeanTween.moveX(LogoS.GetComponent<RectTransform>(), 0, 4).setDelay(2f).setEase(LeanTweenType.easeOutElastic).setOnComplete(bajarAlpha2);
    }

    public void cambiarEscena()
    {
        SceneManager.LoadScene(1);
    }
    private void bajarAlpha()
    {
        LeanTween.alpha(inicioGrupo.GetComponent<RectTransform>(), 0f, 1).setDelay(2f).setOnComplete(cambiarEscena);
        inicioGrupo.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
    private void bajarAlpha1()
    {
        LeanTween.alpha(grupoU.GetComponent<RectTransform>(), 0f, 1).setDelay(2f);
        inicioGrupo.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
    private void bajarAlpha2()
    {
        LeanTween.alpha(grupoS.GetComponent<RectTransform>(), 0f, 1).setDelay(2f);
        inicioGrupo.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
}
