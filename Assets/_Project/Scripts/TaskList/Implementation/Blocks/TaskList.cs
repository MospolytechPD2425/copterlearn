using System;
using System.Collections;
using System.Collections.Generic;
using com.cyborgAssets.inspectorButtonPro;
using UnityEngine;
using UnityEngine.Serialization;

public class TaskList : TaskStage
{
    private int _currentTaskBlock = 0;
    
    private void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        SetUp(currentTaskView.transform.parent, currentTaskView.gameObject);
        Display();
    }

    [ProPlayButton]
    public void NextTaskBlock()
    {
        if (_currentTaskBlock != ChildTaskBlocks.Count - 1)
        {
            HideCurrentTaskBlock();
            _currentTaskBlock++;
            DisplayCurrentTaskBlock();
        }
    }

    [ProPlayButton]
    public void PreviousTaskBlock()
    {
        if (_currentTaskBlock != 0)
        {
            HideCurrentTaskBlock();
            _currentTaskBlock--;
            DisplayCurrentTaskBlock();
        }
    }

    public override void Complete()
    {
        base.Complete();
        Debug.Log("task list is complete");
    }

    public override void Display()
    {
        DisplayCurrentTaskBlock();
    }

    public override void Hide()
    {
        throw new NotImplementedException();
    }

    public void DisplayCurrentTaskBlock()
    {
        ChildTaskBlocks[_currentTaskBlock].Display();
    }

    public void HideCurrentTaskBlock()
    {
        ChildTaskBlocks[_currentTaskBlock].Hide();
    }
}
