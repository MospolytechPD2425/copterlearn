using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonitorManager : MonoBehaviour
{
    [SerializeField] private bool _useBigMonitor;
    [SerializeField] private bool _useSmallMonitor;

    [SerializeField] private Monitor _bigMonitor;
    [SerializeField] private Monitor _smallMonitor;
    public void SetDetail(Detail detail)
    {
        if (_useBigMonitor) _bigMonitor.SetDetail(detail);
        if (_useSmallMonitor) _smallMonitor.SetDetail(detail);
    }
    public void Clear()
    {
        if (_useBigMonitor) _bigMonitor.Clear();
        if (_useSmallMonitor) _smallMonitor.Clear();
    }
}
