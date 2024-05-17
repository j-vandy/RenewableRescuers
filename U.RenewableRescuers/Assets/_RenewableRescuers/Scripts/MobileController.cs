using System;
using UnityEngine;

public class MobileController : MonoBehaviour
{
    [SerializeField] private ButtonPressed left;
    [SerializeField] private ButtonPressed right;
    [SerializeField] private ButtonPressed up;
    [SerializeField] private GameDataSO gameData;
    public float horizontal_input = 0;
    public bool jump_key_is_down = false;
    
    void Start()
    {
        if (left == null)
            throw new NullReferenceException();
        if (right == null)
            throw new NullReferenceException();
        if (up == null)
            throw new NullReferenceException();
        if (gameData == null)
            throw new NullReferenceException();
    }

    void Update()
    {
        if (!gameData.bMobileUIEnabled)
            return;

        horizontal_input = 0;
        if (left.bIsDown)
            horizontal_input--;
        if (right.bIsDown)
            horizontal_input++;
       
        jump_key_is_down = up.bOnDown;
    }
}
