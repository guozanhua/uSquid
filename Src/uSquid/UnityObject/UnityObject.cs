using System;
using UnityEngine;
using uSquid;
using uSquid.Assets;

public class UnityObject
{
    public MonoBehaviourMessages u { get; private set; }
    public GameObject GameObject { get; private set; }
    public Transform Transform { get { return GameObject.transform; } }
    public Vector3 WorldPosition { get { return Transform.position; } set { Transform.position = value; } }
    public Vector3 LocalPosition { get { return Transform.localPosition; } set { Transform.localPosition = value; } }
    public Quaternion WorldRotation { get { return Transform.rotation; } set { Transform.rotation = value; } }
    public Quaternion LocalRotation { get { return Transform.localRotation; } set { Transform.localRotation = value; } }
    public Vector3 LocalScale { get { return Transform.localScale; } set { Transform.localScale = value; } }
    public event Action<UnityObject> BeginDestroy;
    
    private UnityObjectBehaviour _behaviour;

    public UnityObject(GameObject sceneObject)
    {
        if (sceneObject == null)
            throw new Exception("UnityObject sceneObject is null");

        u = new MonoBehaviourMessages(this);
        GameObject = sceneObject;

        _behaviour = sceneObject.GetComponent<UnityObjectBehaviour>() ?? sceneObject.AddComponent<UnityObjectBehaviour>();
        _behaviour.SetUnityObject(this);
    }

    public UnityObject()
        : this(new GameObject("Unnamed UnityObject"))
    {
        GameObject.name = GetType().ToString();
    }

    public UnityObject(string name)
        : this(new GameObject(name))
    {
    }

    public UnityObject(Asset<GameObject> asset)
        : this(asset.Clone())
    {
    }
        
    public bool IsDestroyed
    {
        get
        {
            return GameObject == null;
        }
    }

    public virtual void Destroy()
    {
        if (IsDestroyed)
        {
            return;
        }

        if (BeginDestroy != null)
            BeginDestroy(this);

        if (GameObject != null)
            UnityEngine.Object.Destroy(GameObject);
    }

    public void SetActive(bool active)
    {
        GameObject.SetActive(active);
    }

    public void SetLayer(int layer, bool recursive)
    {
        if (recursive)
            GameObject.PerformRecursive(gameObj => gameObj.layer = layer);
        else
            GameObject.layer = layer;
    }

    public static implicit operator Transform(UnityObject unityObject)
    {
        return unityObject.Transform;
    }
}