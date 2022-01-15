using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ArkanoidEvent 
{
    public delegate void BallDeadZoneAction(Ball ball);
    public static BallDeadZoneAction OnBallReachDeadZoneEvent;

    public delegate void BlockDestroyedAction(int blockId);
    public static BlockDestroyedAction OnBlockDestroyedEvent;

}
