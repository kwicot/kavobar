using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextOutput : MonoBehaviour
{
    public static TextOutput txt;
    private GameObject GO_text;
    private Text text;
    private Animation anim;

    private void Awake()
    {
        if (!txt) txt = this;
        else Destroy(this);
    }

    private void Start()
    {
        GO_text = transform.GetChild(0).gameObject;
        text = GO_text.GetComponent<Text>();
        anim = GO_text.GetComponent<Animation>();
    }

    public void Show(string t)
    {
        text.enabled = true;
        text.text = t;
        anim.Play();
    }
}
