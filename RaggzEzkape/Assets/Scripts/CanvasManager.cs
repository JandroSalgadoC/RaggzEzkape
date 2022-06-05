using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public enum CanvasType
{
    MainMenu,
    RegisterMenu
}

public class CanvasManager : Singleton<CanvasManager>
{
    List<CanvasController> canvasControllerList;
    CanvasController lastActiveCanvas;

    protected override void Awake()
    {
        base.Awake();
        canvasControllerList = GetComponentsInChildren<CanvasController>().ToList();
        canvasControllerList.ForEach(x => x.gameObject.SetActive(false));
        SwitchCanvas(CanvasType.MainMenu);
    }

    public void SwitchCanvas(CanvasType _type)
    {
        if (lastActiveCanvas != null)
        {
            lastActiveCanvas.gameObject.SetActive(false);
        }

        CanvasController desiredCanvas = canvasControllerList.Find(x => x.canvasType == _type);
        if (desiredCanvas != null)
        {
            desiredCanvas.gameObject.SetActive(true);
            lastActiveCanvas = desiredCanvas;
            if(_type== CanvasType.MainMenu ){
                Debug.Log("Menu Principal Activo");
                try{
                    PlayFabClientAPI.GetUserData(new GetUserDataRequest(), OnSuccess, OnError);
                }catch(PlayFabException e){
                    Debug.Log("No logeado");
                }
                
            }
        }
        else { Debug.LogWarning("The desired canvas was not found!"); }
    }
    public void OnSuccess(GetUserDataResult result){
        Debug.Log("Logeado");
        Debug.Log(result);
    }
    void OnError(PlayFabError error){
        Debug.Log("error");
        Debug.Log(error.GenerateErrorReport());
    }
 }