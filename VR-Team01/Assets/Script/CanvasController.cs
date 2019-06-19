using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    public GameObject questionCanvas;
    public bool activeCancas;
    public float Timer;
    // Start is called before the first frame update
    void Start()
    {
        questionCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Timer >= 20)
        {
           
            Timer = 0;
           
        }
         if(Timer >= 10 && Timer< 20)
            {
                questionCanvas.SetActive(true);
            }
            else if (Timer>=20||Timer<10)
            {
                questionCanvas.SetActive(false);
            }
        CurTimer();
        
    }
   
    void CurTimer()
    {
        Timer+=Time.deltaTime;
    }
        
}
