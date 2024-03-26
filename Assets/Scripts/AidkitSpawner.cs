using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AidkitSpawner : MonoBehaviour
{
    public Aidkit aidkidPrefab;

    private Aidkit _aidkit;

    public float delayMin = 3;

    public float delayMax = 9;

    public List<Transform> spawnerPoints;

    private void Start()
    {
        spawnerPoints = new List<Transform>(transform.GetComponentsInChildren<Transform>());
    }

    private void Update()
    {
        if (_aidkit != null) return;

        if(IsInvoking()) return;

        Invoke("CreateAidlit", Random.Range(delayMin, delayMax));
    }

    private void CreateAidlit()
    {
      _aidkit = Instantiate (aidkidPrefab);

      _aidkit.transform.position = spawnerPoints[Random.Range(0, spawnerPoints.Count)].position;
    }
}
