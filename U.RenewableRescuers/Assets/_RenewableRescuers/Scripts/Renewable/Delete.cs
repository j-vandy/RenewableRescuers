using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delete : MonoBehaviour
{
    public LeverQuestion leverQuestion;
    public void TurnOffStuff()
    {
        leverQuestion.Close();
        DeleteObj();
    }
    public void DeleteObj() => Destroy(gameObject);
}
