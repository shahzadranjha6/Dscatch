using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class SliderControls : MonoBehaviour, IPointerDownHandler, IPointerUpHandler 
{
        // We need 3 Events, to inform other Scripts if the Slider is changed 
    public UnityAction OnPointerDownEvent;
    public UnityAction<float> OnPointerDragEvent;
    public UnityAction OnPointerUpEvent;

    [SerializeField]private Slider UI_Slider;

    void Start()
        {
            UI_Slider = GetComponent<Slider>();
            UI_Slider.onValueChanged.AddListener(OnSliderValueChanged); // the function added as a Lisener should get some value as Arguments 
        }

    // Hover on the  IPointerDownHandler and Quick Fix and select implement All Members Explicitly
    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        // 
        if(OnPointerDownEvent != null)
            {
                OnPointerDownEvent.Invoke();
            }

        if(OnPointerDragEvent != null)
            {
                OnPointerDragEvent.Invoke(UI_Slider.value); // as its Generic Type is  Float  so we have ti pass a Value as Parameter
            }
    }
    void OnSliderValueChanged(float value)
    {
        if(OnPointerDragEvent != null)
            {
                OnPointerDragEvent.Invoke(UI_Slider.value); // as its Generic Type is  Float  so we have ti pass a Value as Parameter
            }
    }

    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        //
        if(OnPointerUpEvent != null)
            {
                OnPointerUpEvent.Invoke();
            }

        // Reset Slider Value
        UI_Slider.value = 0f;
    }

    void OnDestroy()
        {
            // remove Listeners to avoid memory leaksx
            UI_Slider.onValueChanged.RemoveListener(OnSliderValueChanged); 
        }
}
