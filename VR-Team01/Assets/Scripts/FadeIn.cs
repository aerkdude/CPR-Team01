using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIn : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetTrigger("FadeIn");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void FadeOutAnim()
    {
        Debug.Log("Fading out");
        anim.SetTrigger("FadeOut"); 
    }

}
