using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.TryGetComponent<Ball>(out Ball ball))
        {
            ArkanoidEvent.OnBallReachDeadZoneEvent?.Invoke(ball); 
        }   
    }
    
}
