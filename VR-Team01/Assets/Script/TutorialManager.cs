using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public TextMesh guideText;
    public GameObject remoteLeft;
    public GameObject remoteRight;
    public GameObject hands;
    public GameObject startButton;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LookAround());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator LookAround()
    {
        yield return new WaitForSeconds(10.0f);
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
        guideText.text = "ลองผสานมือตามภาพ";
        hands.gameObject.SetActive(true);
        yield return new WaitForSeconds(10.0f);
        guideText.text = "";
        hands.gameObject.SetActive(false);
        ShowButton();
    }
    void ShowButton()
    {
        startButton.gameObject.SetActive(true);
    }
}
