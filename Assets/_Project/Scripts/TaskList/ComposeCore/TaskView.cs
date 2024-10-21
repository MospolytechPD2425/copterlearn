using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public abstract class TaskView : MonoBehaviour
{
    [SerializeField] protected TextMeshPro taskBlockName;
    [SerializeField] protected GameObject completedEffectGameObject;
    
    public void SetUp(TaskBlock taskBlock)
    {
        taskBlock.OnComplete.AddListener(OnCompleteHandler);
        taskBlockName.text = taskBlock.TaskBlockName;
    }
    
    protected virtual void OnCompleteHandler()
    {
        completedEffectGameObject.SetActive(true);
    }
}
