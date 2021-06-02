using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PointerColorChange : MonoBehaviour
{
    public Sprite NormalColor;
    public Sprite EnterColor;
    public AudioSource Hover;
    private Image image;


    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

    public void EnterChange()
    {
        image.sprite = EnterColor;
        Hover.Play();
    }

    public void ExitChange()
    {
        image.sprite = NormalColor;
    }
}
