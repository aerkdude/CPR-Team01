using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Question : MonoBehaviour
{
    public GameObject questionCanvas;
    public GameObject canvasTimer;
    public GameObject paperCanvas;
    
    public GameObject phone;
    public GameObject shoulder;
    public GameObject hintPanel;
    public GameObject guidePanel;
    public GameObject quizPanel;
    public GameObject lightGuide;
    public Animator lightObject;
    public Text quizScoreText;
    public Text questionText;
    public Text hintText;
    public Text guideText;

    public static bool hitShoulder;
    public bool activeCancas;
    private bool activateQuestion;
    public bool canShowHint;
    public string[] question;
    private string guess;
    private string guess1;
    private string guess2;
    private string guess3;
    private string guess4;
    public string hint;
    public static int quizScore;
    public bool showQuizScore;
    public bool canLightOff;
    public bool canLightOn;
    public static bool canAnswerPreQuiz;

    //select paper
    public GameObject paper1;
    public GameObject paper2;
    public GameObject paper3;
    public GameObject paper4;
    public GameObject paper1Select;
    public GameObject paper2Select;
    public GameObject paper3Select;
    public GameObject paper4Select;
    public Text question1Text;
    public Text question2Text;
    public Text question3Text;
    public Text question4Text;
    public InputField paper1InputField;
    public InputField paper2InputField;
    public InputField paper3InputField;
    public InputField paper4InputField;
    public GameObject paper1InputObj;
    public GameObject paper2InputObj;
    public GameObject paper3InputObj;
    public GameObject paper4InputObj;

    public static int paperOnScreen;
    public int curSelect;
    public bool slot1Full;
    public bool slot2Full;
    public bool slot3Full;
    public bool slot4Full;

    public int questionNo;

    public int question1No;
    public int question2No;
    public int question3No;
    public int question4No;

    public InputField InputAnswer;
   // public int[] answer;

    //private Text answerText;

    // Start is called before the first frame update
    void Start()
    {
        paperCanvas.SetActive(true);
        canvasTimer.SetActive(false);
        canAnswerPreQuiz = true;
        canLightOn = false;
        lightGuide.SetActive(false);
        canLightOff = true;
        showQuizScore = false;
        quizPanel.SetActive(false);
        quizScore = 0;
        quizScoreText.text = "";

        paper1Select.SetActive(false);
        paper2Select.SetActive(false);
        paper3Select.SetActive(false);
        paper4Select.SetActive(false);

        guidePanel.SetActive(false);
        hintPanel.SetActive(false);
        canShowHint = false;
        guideText.text = "";
        hitShoulder = false;
        hint = "";
        guess = "";
        hintText.text = "";

        guess1 = "";
        guess2 = "";
        guess3 = "";
        guess4 = "";
        StartCoroutine(preQuestion1());

        //paper system
        paperOnScreen = 0;
        curSelect = 0;

        slot1Full = false;
        slot2Full = false;
        slot3Full = false;
        slot4Full = false;
        paper1.SetActive(false);
        paper2.SetActive(false);
        paper3.SetActive(false);
        paper4.SetActive(false);

        question1Text.text = "";
        question2Text.text = "";
        question3Text.text = "";
        question4Text.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.gameStart)
        {
            canvasTimer.SetActive(true);
            CprStart();
        }
        if (!GameController.gameStart)
        {
            if (Input.GetKeyDown(KeyCode.Return) && canShowHint && canAnswerPreQuiz) //Send Answer
            {
                ProcessText();
                //ShowHint();
                questionCanvas.SetActive(false);
                
            }
        }
        if (GameController.gameEnd)
        {
            guidePanel.SetActive(false);
            paperCanvas.SetActive(false);
            guideText.text = "";
        }
        //Shoulder Check
        if (hitShoulder)
        {
            StartCoroutine(preQuestion2());
            hitShoulder = false;
        }
        InputAnswer.ActivateInputField();
        //show UI quiz score
        if (showQuizScore)
        {
            quizScoreText.text = "Quiz Score: " + quizScore;
        }
    }

    void LightOff()
    {
        canLightOn = true;
        lightObject.SetBool("LightOff", true);
        lightGuide.SetActive(true);
    }
    void LightOn()
    {
        canLightOff = false;
        canLightOn = false;
        lightObject.SetBool("LightOff", false);
        lightObject.SetTrigger("TurnOn");
        StartCoroutine(WaitLightTurnOff());
    }
    IEnumerator WaitLightTurnOff()
    {
        yield return new WaitForSeconds(10.0f);
        canLightOff = true;
    }
    private void CprStart()
    {
        if (Input.GetKeyDown(KeyCode.L) && canLightOn)
        {
            Debug.Log("trun light");
            lightGuide.SetActive(false);
            LightOn();
        }

        if (paperOnScreen < 1)
        {
            if (Input.GetKeyDown(KeyCode.Return) && canShowHint) //Send Answer
            {
                ProcessText();
                InputAnswer.clearInputField();
                questionCanvas.SetActive(false);
            }
        }

        //paper select
        if(paperOnScreen > 0)
        {
            if(paperOnScreen >= 3 && canLightOff)
            {
                LightOff();
            }
            if(paperOnScreen < 3)
            {
                lightObject.SetBool("LightOff", false);
            }
            
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (slot1Full)
                {
                    Debug.Log("select left");
                    curSelect = 1;
                    paper1InputObj.SetActive(true);
                    paper2InputObj.SetActive(false);
                    paper3InputObj.SetActive(false);
                    paper4InputObj.SetActive(false);
                    paper1InputField.ActivateInputField();
                }
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (slot2Full)
                {
                    Debug.Log("select up");
                    curSelect = 2;
                    paper1InputObj.SetActive(false);
                    paper2InputObj.SetActive(true);
                    paper3InputObj.SetActive(false);
                    paper4InputObj.SetActive(false);
                    paper2InputField.ActivateInputField();
                }
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (slot3Full)
                {
                    Debug.Log("select bottom");
                    curSelect = 3;
                    paper1InputObj.SetActive(false);
                    paper2InputObj.SetActive(false);
                    paper3InputObj.SetActive(true);
                    paper4InputObj.SetActive(false);
                    paper3InputField.ActivateInputField();
                }
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (slot4Full)
                {
                    Debug.Log("select right");
                    curSelect = 4;
                    paper1InputObj.SetActive(false);
                    paper2InputObj.SetActive(false);
                    paper3InputObj.SetActive(false);
                    paper4InputObj.SetActive(true);
                    paper4InputField.ActivateInputField();
                }
            }

            if (curSelect == 1)
            {
                paper1Select.SetActive(true);
                paper2Select.SetActive(false);
                paper3Select.SetActive(false);
                paper4Select.SetActive(false);
                if (slot1Full)
                {
                    if (Input.GetKeyDown(KeyCode.Return))
                    {
                        ProcessQuestion1();
                        CancelInvoke("spawnPaperEvery10Sec");
                        InvokeRepeating("spawnPaperEvery10Sec", 2.0f, 5.0f);
                    }
                }
            }
            if (curSelect == 2)
            {
                paper1Select.SetActive(false);
                paper2Select.SetActive(true);
                paper3Select.SetActive(false);
                paper4Select.SetActive(false);
                if (slot2Full)
                {
                    if (Input.GetKeyDown(KeyCode.Return))
                    {
                        ProcessQuestion2();
                        CancelInvoke("spawnPaperEvery10Sec");
                        InvokeRepeating("spawnPaperEvery10Sec", 2.0f, 5.0f);
                    }
                }
            }
            if (curSelect == 3)
            {
                paper1Select.SetActive(false);
                paper2Select.SetActive(false);
                paper3Select.SetActive(true);
                paper4Select.SetActive(false);
                if (slot1Full)
                {
                    if (Input.GetKeyDown(KeyCode.Return))
                    {
                        ProcessQuestion3();
                        CancelInvoke("spawnPaperEvery10Sec");
                        InvokeRepeating("spawnPaperEvery10Sec", 2.0f, 5.0f);
                    }
                }
            }
            if (curSelect == 4)
            {
                paper1Select.SetActive(false);
                paper2Select.SetActive(false);
                paper3Select.SetActive(false);
                paper4Select.SetActive(true);
                if (slot1Full)
                {
                    if (Input.GetKeyDown(KeyCode.Return))
                    {
                        ProcessQuestion4();
                        CancelInvoke("spawnPaperEvery10Sec");
                        InvokeRepeating("spawnPaperEvery10Sec", 2.0f, 5.0f);
                    }
                }
            }
            if(curSelect < 1 || curSelect > 4)
            {
                NoneSelect();
            }
        }
        if(paperOnScreen < 1 || paperOnScreen > 4)
        {
            curSelect = 0;
        }

        //paper slot
        if (slot1Full)
        {
            paper1.SetActive(true);
        }
        else if(!slot1Full)
        {
            paper1.SetActive(false);
        }
        if (slot2Full)
        {
            paper2.SetActive(true);
        }
        else if(!slot2Full)
        {
            paper2.SetActive(false);
        }
        if (slot3Full)
        {
            paper3.SetActive(true);
        }
        else if (!slot3Full)
        {
            paper3.SetActive(false);
        }
        if (slot4Full)
        {
            paper4.SetActive(true);
        }
        else if (!slot4Full)
        {
            paper4.SetActive(false);
        }
    }
    void NoneSelect()
    {
        paper1Select.SetActive(false);
        paper2Select.SetActive(false);
        paper3Select.SetActive(false);
        paper4Select.SetActive(false);
    }
    void ProcessText()
    {
        guess = InputAnswer.text;
        //Debug.Log(guess);
        switch (questionNo)
        {
                //Pre question before CPR
            case 101:
                if (guess == "4")
                {
                    AnswerCorrect();
                    ResetAnswer();
                    StartCoroutine(DelayShoulderText());
                    canShowHint = false;
                }
                else
                {
                    Debug.Log("Wrong");
                    ResetAnswer();
                    StartCoroutine(DelayShoulderText());
                    canShowHint = false;
                }
                break;
            case 102:
                if (guess == "1669")
                {
                    AnswerCorrect();
                    ResetAnswer();
                    StartCoroutine(PrepareCall());
                    canShowHint = false;
                }
                else
                {
                    Debug.Log("Wrong");
                    ResetAnswer();
                    StartCoroutine(PrepareCall());
                    canShowHint = false;
                }
                break;
        }
    }
    void ProcessQuestion1()
    {
        guess1 = paper1InputField.text;
        Debug.Log(guess1);
        paper1InputField.clearInputField();
        curSelect = 0;
        NoneSelect();
        paper1.SetActive(false);
        slot1Full = false;
        paperOnScreen--;
        //Checker
        switch (question1No)
        {
            case 0:
                if (guess1 == "4")
                {
                    AnswerCorrect();
                }
                else
                {
                    Debug.Log("Wrong");
                }
                break;
            case 1:
                if (guess1 == "100")
                {
                    AnswerCorrect();
                }
                else
                {
                    Debug.Log("Wrong");
                }
                break;
            case 2:
                if (guess1 == "120")
                {
                    AnswerCorrect();
                }
                else
                {
                    Debug.Log("Wrong");
                }
                break;
            case 3:
                if (guess1 == "5")
                {
                    AnswerCorrect();
                }
                else
                {
                    Debug.Log("Wrong");
                }
                break;
        }
    }
    void ProcessQuestion2()
    {
        guess2 = paper2InputField.text;
        Debug.Log(guess2);
        paper2InputField.clearInputField();
        curSelect = 0;
        NoneSelect();
        paper2.SetActive(false);
        slot2Full = false;
        paperOnScreen--;
        //Checker
        switch (question2No)
        {
            case 0:
                if (guess2 == "4")
                {
                    AnswerCorrect();
                }
                else
                {
                    Debug.Log("Wrong");
                }
                break;
            case 1:
                if (guess2 == "100")
                {
                    AnswerCorrect();
                }
                else
                {
                    Debug.Log("Wrong");
                }
                break;
            case 2:
                if (guess2 == "120")
                {
                    AnswerCorrect();
                }
                else
                {
                    Debug.Log("Wrong");
                }
                break;
            case 3:
                if (guess2 == "5")
                {
                    AnswerCorrect();
                }
                else
                {
                    Debug.Log("Wrong");
                }
                break;
        }
    }
    void ProcessQuestion3()
    {
        guess3 = paper3InputField.text;
        Debug.Log(guess3);
        paper3InputField.clearInputField();
        curSelect = 0;
        NoneSelect();
        paper3.SetActive(false);
        slot3Full = false;
        paperOnScreen--;
        //Checker
        switch (question3No)
        {
            case 0:
                if (guess3 == "4")
                {
                    AnswerCorrect();
                }
                else
                {
                    Debug.Log("Wrong");
                }
                break;
            case 1:
                if (guess3 == "100")
                {
                    AnswerCorrect();
                }
                else
                {
                    Debug.Log("Wrong");
                }
                break;
            case 2:
                if (guess3 == "120")
                {
                    AnswerCorrect();
                }
                else
                {
                    Debug.Log("Wrong");
                }
                break;
            case 3:
                if (guess3 == "5")
                {
                    AnswerCorrect();
                }
                else
                {
                    Debug.Log("Wrong");
                }
                break;
        }
    }
    void ProcessQuestion4()
    {
        guess4 = paper4InputField.text;
        Debug.Log(guess4);
        paper4InputField.clearInputField();
        curSelect = 0;
        NoneSelect();
        paper4.SetActive(false);
        slot4Full = false;
        paperOnScreen--;
        //Checker
        switch (question4No)
        {
            case 0:
                if (guess4 == "4")
                {
                    AnswerCorrect();
                }
                else
                {
                    Debug.Log("Wrong");
                }
                break;
            case 1:
                if (guess4 == "100")
                {
                    AnswerCorrect();
                }
                else
                {
                    Debug.Log("Wrong");
                }
                break;
            case 2:
                if (guess4 == "120")
                {
                    AnswerCorrect();
                }
                else
                {
                    Debug.Log("Wrong");
                }
                break;
            case 3:
                if (guess4 == "5")
                {
                    AnswerCorrect();
                }
                else
                {
                    Debug.Log("Wrong");
                }
                break;
        }
    }

    public void SpawnQuestion()
    {
        if (slot1Full) //if slot 1 full
        {
            if (slot2Full) // if slot 2 full
            {
                if (slot3Full) // if slot 3 full
                {
                    if (!slot4Full) // if slot 4 empty place into slot 4
                    {
                        slot4Full = true;
                        question4No = Random.Range(0, question.Length);
                        question4Text.text = question[question4No];
                    }
                }
                if (!slot3Full) //if slot 3 empty place into slot 3
                {
                    slot3Full = true;
                    question3No = Random.Range(0, question.Length);
                    question3Text.text = question[question3No];
                }
            }
            if (!slot2Full)//if slot 2 is empty place into slot 2
            {
                slot2Full = true;
                question2No = Random.Range(0, question.Length);
                question2Text.text = question[question2No];
            }
        }
        if (!slot1Full) //if slot 1 is empty place in slot 1
        {
            slot1Full = true;
            question1No = Random.Range(0, question.Length);
            question1Text.text = question[question1No];
        }
    }
    public void ShowHint()
    {
        hintText.text = "เฉลย: "+hint;
        hintPanel.SetActive(true);
        StartCoroutine(ClearHint());
    }
    private void ResetAnswer()
    {
        ShowHint();
        guess = "";
        questionCanvas.SetActive(false);
        //canShowHint = false;
        InputAnswer.clearInputField();
    }

    IEnumerator ClearHint()
    {
        yield return new WaitForSeconds(3.0f);
        hintPanel.SetActive(false);
        hintText.text = "";
    }
    IEnumerator preQuestion1()
    {
        yield return new WaitForSeconds(3.0f);
        questionCanvas.gameObject.SetActive(true);
        canShowHint = true;
        InputAnswer.ActivateInputField();
        questionNo = 101;
        questionText.text = "เวลาการเชคสติไม่ควรเกินกี่นาที";
        hint = "4";
    }
    IEnumerator preQuestion2()
    {
        guidePanel.SetActive(false);
        yield return new WaitForSeconds(2.0f);
        canAnswerPreQuiz = true;
        questionCanvas.gameObject.SetActive(true);
        canShowHint = true;
        InputAnswer.ActivateInputField();
        questionNo = 102;
        questionText.text = "เบอร์โทรสพฉ.คือ?";
        hint = "1669"; 
    }
    IEnumerator DelayShoulderText()
    {
        canAnswerPreQuiz = false;
        yield return new WaitForSeconds(3.0f);
        shoulder.SetActive(true);
        guidePanel.SetActive(true);
        guideText.text = "P1 ตบบ่าสะกิดผู้ป่วย";
    }
    IEnumerator PrepareCall()
    {
        yield return new WaitForSeconds(3.0f);
        ReadyToCall();
    }
    void ReadyToCall()
    {
        Debug.Log("Phpne spawn");
        guidePanel.SetActive(true);
        guideText.text = "P1 ใช้โทรศัพท์ที่พื้นโทรเรียกสพฉ.";
        phone.SetActive(true);
    }
    
    public void RemovePhoneText()
    {
        StartCoroutine(ReadyCpr());
        guideText.text = "หน่วยแพทย์กำลังมา เตรียมนับเวลาถอยหลัง";
        hint = "";
    }
    IEnumerator ReadyCpr()
    {
        yield return new WaitForSeconds(3.0f);
        guideText.text = "";
        StartCoroutine(CprBegin());
    }
    IEnumerator CprBegin()
    {
        yield return new WaitForSeconds(1.0f);
        GameController.gameStart = true;
        GameController.timeStart = true;
        quizPanel.SetActive(true);
        showQuizScore = true;
        canShowHint = false;
        InvokeRepeating("spawnPaperEvery10Sec", 5.0f, 5.0f);
        guideText.text = "เริ่มนับบเวลาถอยหลัง 2 นาที";
        StartCoroutine(CprContinue());
    }
    IEnumerator CprContinue()
    {
        yield return new WaitForSeconds(3.0f);
        guideText.text = "P1 ทำ CPR / P2 คอยตอบคำถาม";
    }
    void spawnPaperEvery10Sec()
    {
        if (paperOnScreen < 4)
        { 
            Debug.Log("SpawnQuestion");
            SpawnQuestion();
            paperOnScreen++;
        }
    }
    void removePaper()
    {
        Debug.Log("remove 1 paper");
        paperOnScreen--;
    }
    void AnswerCorrect()
    {
        Debug.Log("Correct");
        quizScore++;
    }
}

public static class Extension
{
    public static void clearInputField(this InputField inputField)
    {
        inputField.Select();
        inputField.text = "";
        //Debug.Log("clear");
    }
}

