using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneButton : MonoBehaviour
{
    public GameObject phone;
    public Question questionScript;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CheckHand"))
        {
            Debug.Log("กดโทร");
            //GameController.gameStart = true;
            //GameController.timeStart = true;
            questionScript.RemovePhoneText();
            phone.SetActive(false);
        }
    }
}
