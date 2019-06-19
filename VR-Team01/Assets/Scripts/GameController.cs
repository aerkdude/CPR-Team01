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
    public bool canPush;
    public GameObject greenCube;
    public int curHp;
    public float pushHp;
    // Start is called before the first frame update
    void Start()
    {
        slideValue = curTime / maxHP;
        hpLeft = 240f;
        curTime = 240f;
        canPush = true;
        startTime = 240f;
        InvokeRepeating("GoTime", 0.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
        slideValue = hpLeft / maxHP;
        timeText.text = "Time: "+curTime;
        bar.localScale = new Vector3(slideValue, 1f);

        if (canPush)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                Heal();
                StartCoroutine(DelayPush());
                Debug.Log("Hit");
            }
        }
        if (canPush)
        {
            greenCube.gameObject.SetActive(true);
        }
        if (!canPush)
        {
            greenCube.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (canPush)
        {
            if (other.gameObject.CompareTag("CheckHand"))
            {
                Heal();
                StartCoroutine(DelayPush());
                Debug.Log("Hit");
            }
        }
        
    }
    private void FixedUpdate()
    {
    if(hpLeft>0)
        {
            hpLeft -=  curHp*Time.deltaTime;
        }
       
    }

    void GoTime()
    {
        //Debug.Log("count");
        curTime--;
        //Debug.Log("hpLeft:"+hpLeft+"slideValue"+slideValue);
    }
    void Heal()
    {
        hpLeft += pushHp;
        Debug.Log("hpleft:" + hpLeft);
        if(hpLeft>=maxHP)
        {
            hpLeft = maxHP;
        }
    }

    IEnumerator DelayPush()
    {
        canPush = false;
        yield return new WaitForSeconds(0.5f);
        canPush = true;
    }
    ///
   /* string nameA, nameB;

    void test()
    {
        for (int i = 0; i < nameA.Length; i++)
        {
            if (nameA[i] == nameB[i])
            {

            }

            }

    }*/

    ///

}