using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCfollow : MonoBehaviour
{
    public Transform followCharacter;
    public float distanceFromCharacter;
    public List<Vector2> followCharacterPositions = new List<Vector2>();
    public float allowableSampleDistance;
    public float sampleTimeDifference;
    public float sampleTime;
    public float followSpeed;
    public float removeDistance;

    // Start is called before the first frame update
    void Start()
    {
        sampleTime = Time.time;
        followCharacterPositions.Add(followCharacter.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > sampleTime)
        {
            sampleTime = Time.time + sampleTimeDifference;
            if (Vector2.Distance(transform.position, followCharacter.position) > distanceFromCharacter && Vector2.Distance(followCharacter.position, followCharacterPositions[followCharacterPositions.Count-1]) > allowableSampleDistance)
            {
                followCharacterPositions.Add(followCharacter.position);
            }
        }

        if (Vector2.Distance(transform.position, followCharacter.position) > distanceFromCharacter)
        {
            transform.position = Vector2.MoveTowards(transform.position, followCharacterPositions[0], Time.deltaTime * followSpeed);
            if (Vector2.Distance(transform.position, followCharacterPositions[0]) < removeDistance)
            {
               if (followCharacterPositions.Count > 1)
                {
                    followCharacterPositions.RemoveAt(0);
                }
            }
        }
    }
   
        
    
     

}
