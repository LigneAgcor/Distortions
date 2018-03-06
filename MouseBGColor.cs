using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MouseBGColor : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
	
	public Color color;
	public Camera bgcam;
	
	public void OnPointerEnter(PointerEventData data)
    {
        // If your mouse hovers over the GameObject with the script attached, output this message
        Debug.Log("Mouse is over Button: " + this.name);
		bgcam.backgroundColor = color;
		RenderSettings.ambientLight = color;
		GlobalVariables.acolor = color;
    }

    public void OnPointerExit(PointerEventData eventdata)
    {
        //The mouse is no longer hovering over the GameObject so output this message each frame
        Debug.Log("Mouse is no longer on Button: " + this.name);
		RenderSettings.ambientLight = new Color(0.7f,0.7f,0.7f,1.0f);
		bgcam.backgroundColor = new Color(0.5f,0.5f,0.5f,1.0f);
    }
}
