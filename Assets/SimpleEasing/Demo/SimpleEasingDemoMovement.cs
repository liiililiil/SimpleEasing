using UnityEngine;

// Required to use Easing
using SimpleEasing;

public class SimpleEasingDemoMovement : MonoBehaviour
{
    [SerializeField]
    private EaseType ease;

    [Space(20)]
    [SerializeField, Range(1,10)]
    private float duration;

    [Space(20), Header("Position")]
    [SerializeField]
    private Vector2 startPosition;

    [SerializeField]
    private Vector2 targePosition;
    
    [Space(20), Header("Rotation")]
    [SerializeField]
    private Vector3 startRotation;

    [SerializeField]
    private Vector3 targetRotation;

    float elapsed;

    private void Update() {
        elapsed += Time.deltaTime;
        if(elapsed >= duration) elapsed -= duration;

        float t = elapsed / duration;
        
        //Use Easing
        float easeT = Ease.Easing(t, ease);

        //Position
        transform.position = Vector2.LerpUnclamped(startPosition, targePosition, easeT); 

        //Rotation
        Quaternion startQuaternion = Quaternion.Euler(startRotation);
        Quaternion targetQuaternion = Quaternion.Euler(targetRotation);
        transform.rotation = Quaternion.LerpUnclamped(startQuaternion, targetQuaternion, easeT);

    }


}
