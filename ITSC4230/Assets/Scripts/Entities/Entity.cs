using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{

    [SerializeField] public Transform vibrationSpawnPoint;
    [SerializeField] public GameObject vibrations;
    //[SerializeField] public float vibrationRate;

    [SerializeField] public TypeEnum vibrationType;

    public enum TypeEnum {
        Active,
        Sensory,
        Environmental
    }

    protected bool canVibrate = true;

    /*public IEnumerator CreateVibrations() {
        canVibrate = false;
        Instantiate(vibrations, vibrationSpawnPoint);
        StartCoroutine(CreateVibrationsHandler());
        yield return null;
    }

    public IEnumerator CreateVibrationsHandler() {
        yield return new WaitForSeconds(vibrationRate);
        canVibrate = true;
    }*/

}
