using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialKeyboard : MonoBehaviour
{
    public GameObject inputObject;
    public InputField inputField;
    public GameObject fadeIn;
    public Text guideText;
    public Text placeHolder;
    private string guess;
    // Start is called before the first frame update
    void Start()
    {
        inputObject.gameObject.SetActive(false);
        placeHolder.text = "";
        guideText.text = "สวัสดีค่ะ ยินดีต้อนรับเข้าสู่การทดสอบการเป็นสพฉ ซึ่งตอนนี้เพื่อนของคุณได้ถูกส่งไปอีกห้องนึงแล้ว คุณกับเพื่อนของคุณต้องช่วยกันทำแบบทดสอบ พวกคุณมีเวลา 2นาที ในการทดสอบ ขอให้โชคดี";
        StartCoroutine(PopIntroText());
    }

    // Update is called once per frame
    void Update()
    {
        inputField.ActivateInputField();
        if (Input.GetKeyDown(KeyCode.Return)) //Send Answer
        {
            ProcessText();
        }
    }

    IEnumerator PopIntroText()
    {
        yield return new WaitForSeconds(13.0f);
        inputObject.gameObject.SetActive(true);
        guideText.text = "กำลังจะเริ่มทำแบบทดสอบ ถ้าคุณพร้อมแล้วให้พิมพ์คำว่า “ตกลง” ";
        placeHolder.text = "“ตกลง”";
    }

    void ProcessText()
    {
        guess = inputField.text;
        if(guess == "ตกลง")
        {
            StartCoroutine(waitFade());
            Debug.Log("ตกลงsssasdads");
        }
        else
        {
            Debug.Log("พิมพ์ไม่ถูก พิใหม่จ้า");
        }
        //Debug.Log(guess);
        
    }
    IEnumerator waitFade()
    {
        fadeIn.GetComponent<FadeIn>().FadeOutAnim();
        yield return new WaitForSeconds(5.0f);
        SceneManager.LoadScene(1);
    }
}
