using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
 using System.Collections.Generic;

 
public class ButtonManager : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {    
 
 Vector3 textInitialPosition;
 Vector3 textPressedPosition;
 GameObject button;

 Transform text;

 public float posY = 27f;
 
public void OnPointerDown(PointerEventData eventData){
    button = EventSystem.current.currentSelectedGameObject;
    text = button.transform.GetChild(0);
    textInitialPosition = text.localPosition;

    text.localPosition = new Vector3(textInitialPosition.x, textInitialPosition.y - posY, textInitialPosition.z);

}
 
public void OnPointerUp(PointerEventData eventData){
    text.localPosition = textInitialPosition;
}
}