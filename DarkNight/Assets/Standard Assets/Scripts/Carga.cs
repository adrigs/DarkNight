using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Carga : MonoBehaviour {

    float time = 0.0f;
    float timeTo = 0.15f;
    int numLetras = 8;
    float timeToChange = 20f;
    Text texto;
    Text por;
    AsyncOperation async;
	// Use this for initialization

     void Awake()
    {
        texto = gameObject.GetComponent<Text>();
        async = new AsyncOperation();
        por = transform.parent.GetComponentsInChildren<Text>()[1];
    }
	
	// Update is called once per frame
	void Update () {

        if (timeToChange == 20f)
        {
            async = SceneManager.LoadSceneAsync("EscenaInicial");
            //async = Application.LoadLevelAdditiveAsync("EscenaInicial");
           async.allowSceneActivation = false;
        }
       
        time += Time.deltaTime * Time.timeScale;
        timeToChange -= time;
        por.text = ((int) ((20f - timeToChange) * 5f)).ToString() + "%";
        //Debug.Log(timeToChange.ToString() + " " + (async != null).ToString() + " " + async.isDone + " " + async.progress.ToString());
        if (timeToChange <= 0f && async != null /*&& async.isDone*/) async.allowSceneActivation = true;
        
        if (time >= timeTo)
        {
            switch (numLetras)
            {
                case 0: texto.text = "C"; numLetras = 1;
                    break;
                case 1: texto.text = "CA"; numLetras = 2;
                    break;
                case 2: texto.text = "CAR"; numLetras = 3;
                    break;
                case 3: texto.text = "CARG"; numLetras = 4;
                    break;
                case 4: texto.text = "CARGA"; numLetras = 5;
                    break;
                case 5: texto.text = "CARGAN"; numLetras = 6;
                    break;
                case 6: texto.text = "CARGAND"; numLetras = 7;
                    break;
                case 7: texto.text = "CARGANDO"; numLetras = 8;
                    break;
                case 8: texto.text = ""; numLetras = 0;
                    break;
            }


            time = 0f;
        }
	}
}
