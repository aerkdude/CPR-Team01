using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public float curTime;
    public float maxHP = 480f;
    public Text timeText;
    private float slideValue;
    private float hpLeft;
    public Transform bar;
    public float startTime;
    public float healValue;
    // Start is called before the first frame update
    void Start()
    {
        slideValue = curTime / maxHP;
        hpLeft = 240f;
        curTime = 240f;

        startTime = 240f;
        InvokeRepeating("GoTime", 0.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
        slideValue = hpLeft / maxHP;
        timeText.text = "Time: "+curTime;
        bar.localScale = new Vector3(slideValue, 1f);

        if (Input.GetKeyDown(KeyCode.A))
        {
            Heal();
        }
    }
    private void FixedUpdate()
    {
        hpLeft -=  Time.deltaTime;
    }

    void GoTime()
    {
        //Debug.Log("count");
        curTime--;
        Debug.Log("hpLeft:"+hpLeft+"slideValue"+slideValue);
    }
    void Heal()
    {
        hpLeft += 5.0f;
        Debug.Log("hpleft:" + hpLeft);
    }
}