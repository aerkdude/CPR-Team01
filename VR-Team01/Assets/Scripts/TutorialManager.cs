using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public TextMesh guideText;
    public GameObject bgpanel;
    public GameObject remoteLeft;
    public GameObject remoteRight;
    public GameObject hands;
    public GameObject startButton;
    
   
    void Start()
    {
        StartCoroutine(LookAround());
    }

    
    void Update()
    {
        
    }

    IEnumerator LookAround()
    {
        yield return new WaitForSeconds(10.0f);
        bgpanel.SetActive(true);
        guideText.text = "ลองมองรอบ ๆ นะ";
        StartCoroutine(LookAroundEnd());
    }
    IEnumerator LookAroundEnd()
    {
        yield return new WaitForSeconds(8.0f);
        guideText.text = "";
        removeRemote();
        StartCoroutine(moveHand());
    }
    void removeRemote()
    {
        remoteLeft.gameObject.SetActive(false);
        remoteRight.gameObject.SetActive(false);
    }
    IEnumerator moveHand()
    {
        guideText.text = "ลองขยับมือ";
        yield return new WaitForSeconds(8.0f);
        StartCoroutine(stickHand());
    }
    IEnumerator stickHand()
    {
        guideText.text = "ลองประสานมือตามภาพ";
        hands.gameObject.SetActive(true);
        yield return new WaitForSeconds(10.0f);
        guideText.text = "";
        bgpanel.SetActive(false);
        hands.gameObject.SetActive(false);
        ShowButton();
    }
    void ShowButton()
    {
        startButton.gameObject.SetActive(true);
    }
}
