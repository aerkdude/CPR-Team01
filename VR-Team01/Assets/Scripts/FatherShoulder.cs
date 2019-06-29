using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FatherShoulder : MonoBehaviour
{
    public Text shoulderText;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CheckHand"))
        {
            Debug.Log("ตบบ่า");
            shoulderText.text = "";
            Question.hitShoulder = true;
            this.gameObject.SetActive(false);
        }
    }
}
