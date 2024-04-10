using UnityEngine;

public class Powerable : MonoBehaviour
{
    public bool bIsOn = false;

    public virtual void PowerOn()
    {
        bIsOn = true;
    }

    public virtual void PowerOff()
    {
        bIsOn = false;
    }
}
