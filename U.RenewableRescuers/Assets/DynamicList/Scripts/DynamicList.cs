using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class DynamicList : MonoBehaviour
{
    [BoxGroup("Settings")]
    public bool display = true;

    [BoxGroup("Width Settings")]
    [ShowIf("display")]
    public bool dynamicWidthEnabled = true;
    [BoxGroup("Width Settings")]
    [ShowIf(EConditionOperator.And, "display", "dynamicWidthEnabled")]
    public float minWidth = 0f;
    [BoxGroup("Width Settings")]
    [ShowIf(EConditionOperator.And, "display", "dynamicWidthEnabled")]
    public float maxWidth = float.MaxValue;
    [BoxGroup("Width Settings")]
    [ShowIf(EConditionOperator.And, "display", "notDynamicWidthEnabled")]
    public bool horizontalScrollBarEnabled = false;
    [BoxGroup("Width Settings")]
    [ShowIf(EConditionOperator.And, "display", "notDynamicWidthEnabled")]
    public float width = 0f;

    [BoxGroup("Height Settings")]
    [ShowIf("display")]
    public bool dynamicHeightEnabled = true;
    [BoxGroup("Height Settings")]
    [ShowIf(EConditionOperator.And, "display", "dynamicHeightEnabled")]
    public float minHeight = 0f;
    [BoxGroup("Height Settings")]
    [ShowIf(EConditionOperator.And, "display", "dynamicHeightEnabled")]
    public float maxHeight = float.MaxValue;
    [BoxGroup("Height Settings")]
    [ShowIf(EConditionOperator.And, "display", "notDynamicHeightEnabled")]
    public bool verticalScrollBarEnabled = false;
    [BoxGroup("Height Settings")]
    [ShowIf(EConditionOperator.And, "display", "notDynamicHeightEnabled")]
    public float height = 0f;

    private bool notDynamicWidthEnabled() { return !dynamicWidthEnabled; }
    private bool notDynamicHeightEnabled() { return !dynamicHeightEnabled; }

    
}

