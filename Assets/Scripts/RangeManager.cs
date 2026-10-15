using UnityEngine;
using UnityEngine.InputSystem;

public class RangeManager : MonoBehaviour
{
    [SerializeField] GameObject[] targets;

    void Update()
    {
        if (Keyboard.current != null && Keyboard.current.rKey.wasPressedThisFrame)
        {
            ResetTargets();
        }
    }

    void ResetTargets()
    {
        foreach (GameObject target in targets)
        {
            if (target == null)
            {
                continue;
            }

            target.SetActive(true);
            Target targetComponent = target.GetComponent<Target>();
            if (targetComponent != null)
            {
                targetComponent.ResetHitPoints();
            }
        }
    }
}
