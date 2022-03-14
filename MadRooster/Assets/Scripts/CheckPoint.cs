using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public Player player; 


    public void UpdateCheckpoint(Transform newTransform)
    {
        player.startPoint = newTransform;
    }
}
