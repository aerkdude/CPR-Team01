using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    Animator anim;
    public GameObject fadeIn;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "CheckHand")
        {
            Debug.Log("hitStart");
            StartCoroutine(waitFade());
        }
    }
    IEnumerator waitFade()
    {
        fadeIn.GetComponent<FadeIn>().FadeOutAnim();
        FadeButton();
        yield return new WaitForSeconds(5.0f);
        SceneManager.LoadScene(2);
    }
    public void FadeButton()
    {
        anim.SetTrigger("fadeButton");
    }
}
