using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public abstract class TaskViewCore : MonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI taskBlockName;
    [SerializeField] protected GameObject completedEffectGameObject;
    
    public void SetUp(TaskBlockCore taskBlockCore)
    {
        taskBlockCore.OnComplete.AddListener(OnCompleteHandler);
        taskBlockName.text = taskBlockCore.TaskBlockName;
    }
    
    protected virtual void OnCompleteHandler()
    {
        completedEffectGameObject.SetActive(true);
    }
}