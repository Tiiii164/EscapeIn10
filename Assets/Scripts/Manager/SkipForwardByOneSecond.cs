using UnityEngine;
using UnityEngine.Playables;

public class SkipForwardByOneSecond : MonoBehaviour
{
    public PlayableDirector timelineDirector;
    public float skipAmount = 1.0f; 

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (timelineDirector != null && timelineDirector.state == PlayState.Playing)
            {
                double newTime = timelineDirector.time + skipAmount;

               
                if (newTime > timelineDirector.duration)
                    newTime = timelineDirector.duration;

                timelineDirector.time = newTime;
                timelineDirector.Evaluate(); 
            }
        }
    }
}
