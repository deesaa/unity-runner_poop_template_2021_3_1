using System;
using System.Collections;
using System.Collections.Generic;
using PathCreation;
using UnityEditor;
using UnityEngine;

[ExecuteInEditMode]
public class RunnerCreator : MonoBehaviour
{
    public PathCreator RoadPath;
    public LevelCreatorConfigWrap LevelCreatorConfigWrap;

    private List<Transform> _carriages = new List<Transform>();
    private List<Animator> _animators = new List<Animator>();

    public GateIconsDatabase IconsDatabase;
    public RoadResourcesDatabase RoadResourcesDatabase;
    public RoadObstaclesDatabase RoadObstaclesDatabase;
    public FinishDatabase FinishDatabase;
    public MaterialDatabase MaterialDatabase;

    public bool Autoupdate;
    public bool UpdateAnimators;

    private void Update()
    {
#if !UNITY_EDITOR
        return;
#endif
        if(Application.isPlaying)
            return;
        
        if(Autoupdate)
            UpdateRunner();

        if (UpdateAnimators)
        {
            Debug.Log(Time.deltaTime);
            _animators.ForEach(x =>
            {
                x.Update(Time.deltaTime);
            });
        }
    }

    public void UpdateRunner()
    {
        if (!RoadPath)
            RoadPath = GetComponent<PathCreator>();

        Clear();

        float distance = 0f;
        foreach (var element in LevelCreatorConfigWrap.Elements)
        {
            distance += element.OffsetZ;
            var newCarriage = new GameObject($"Carriage {distance}").transform;
            newCarriage.SetParent(RoadPath.transform);
            newCarriage.position = RoadPath.path.GetPointAtDistance(distance);
            newCarriage.rotation = RoadPath.path.GetRotationAtDistance(distance);
            
            _carriages.Add(newCarriage);

            var elementView = element.RoadElement.CreateNew(this);
            elementView.SetParent(newCarriage, false);
            elementView.transform.TranslateLocalX(element.OffsetX);

            foreach (Transform t in elementView)
            {
                if(t.TryGetComponent(out Animator a))
                    _animators.Add(a);
            }
        }
    }

    public void Clear()
    {
        foreach (Transform t in _carriages)
        {
            if(t)            
                DestroyImmediate(t.gameObject);
        }
        
        foreach (Transform t in transform)
        {
            DestroyImmediate(t.gameObject);
        }
        
        _animators.Clear();
        _carriages.Clear();
    }
}