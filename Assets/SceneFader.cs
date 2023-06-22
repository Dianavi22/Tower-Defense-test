using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;


public class SceneFader : MonoBehaviour
{
    public Image img;
    public AnimationCurve curve;

    private void Start()
    {
        StartCoroutine(FadeIn());
    }

    public void FadeTo(string scene)
    {
        StartCoroutine(FadeOut(scene));
    }

    //ecran noir vers scene
    IEnumerator FadeIn()
    {
        float t = 1f;
        while(t > 0f)
        {
            t -= Time.deltaTime;
            float a = curve.Evaluate(t);
            img.color = new Color(0f, 0f, 0f, t);
            yield return 0;
        }
    }

    //scene vers ecran noir  
    IEnumerator FadeOut(string scene)
    {
        Debug.Log("scene : " + scene);

        float t = 0f;
        while (t < 1f)
        {
            Debug.Log("t  : " + t   );

            t += Time.deltaTime;
            float a = curve.Evaluate(t);
            img.color = new Color(0f, 0f, 0f, t);
            yield return 0;
        }
        Debug.Log("scene : "+ scene);
        SceneManager.LoadScene(scene);
    }



}
