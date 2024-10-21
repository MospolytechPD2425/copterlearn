using UnityEngine;
using UnityEngine.Events;

public abstract class TaskBlock : MonoBehaviour
{
    protected Transform taskViewPrefabsParent;
    protected GameObject taskViewPrefab;

    protected TaskView currentTaskView;
    
    public UnityEvent OnComplete;
    
    [SerializeField] protected string taskBlockName;

    public string TaskBlockName => taskBlockName;

    protected bool isCompleted { get; set; }

    public bool IsCompleted => isCompleted;

    public virtual void SetUp(Transform viewPrefabsParent, GameObject viewPrefab)
    {
        taskViewPrefabsParent = viewPrefabsParent;
        taskViewPrefab = viewPrefab;
    }
    
    public virtual void Complete()
    {
        isCompleted = true;
        OnComplete?.Invoke();
    }

    public virtual void Display()
    {
        DisplayView();
    }

    public virtual void Hide()
    {
        HideView();
    }

    protected virtual void DisplayView()
    {
        if (currentTaskView != null)
        {
            currentTaskView.gameObject.SetActive(true);
        }
        else
        {
            currentTaskView = Instantiate(taskViewPrefab).GetComponent<TaskView>();
            currentTaskView.transform.SetParent(taskViewPrefabsParent);
            currentTaskView.SetUp(this);
        }
    }

    protected virtual void HideView()
    {
        if (currentTaskView != null)
        {
            currentTaskView.gameObject.SetActive(false);
        }
    }
}
