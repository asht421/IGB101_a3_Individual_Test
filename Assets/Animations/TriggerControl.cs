using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerControl : MonoBehaviour
{
    [SerializeField] private Animator Door = null;

    [SerializeField] private bool openTrigger = false;
    [SerializeField] private bool closeTrigger = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            if(openTrigger)
            {
                Door.Play("open door", 0, 0.0f);
                gameObject.SetActive(false);
            }

            else if (closeTrigger)
            {
                Door.Play("close door", 0, 0.0f);
                gameObject.SetActive(false);
            }
        }
    }
}
