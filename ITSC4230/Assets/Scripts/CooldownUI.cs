using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CooldownUI : MonoBehaviour
{
    [SerializeField] public GameObject bar;
    [SerializeField] public GameObject bg;

    public void ResetBar() {
        bar.transform.localScale = new Vector3 (0, 0.01f, 1f);
    }

    private void FixedUpdate() {
        bar.transform.localScale += new Vector3(0.06f, 0, 0) * Time.fixedDeltaTime;
    }

}
