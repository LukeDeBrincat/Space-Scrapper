using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PointerColorChange : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public Sprite NormalColor;
    public Sprite EnterColor;

    public AudioSource Hover;
    public UnityEvent OnClick = new UnityEvent();

    private Image image; 
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        image.sprite = EnterColor;
        Hover.Play();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        image.sprite = NormalColor;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnClick.Invoke();
    }
}
