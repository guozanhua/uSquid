# uSquid
Unity 5.1.2 Prototyping tools

Getting Started
----------------
Copy Src\uSquid to your Assets Directory

C# events instead of Unity Messages
----------------
Create a new UnityObject passing in a target GameObject (Behind the scenes a `UnityObjectBehaviour will be added to the GameObject)

All of Unity's GameObject Messages will be fired as as proper C# events under ``UnityObject.u.*```

This allows you to seperate your resuable logic from Monobehaviours and still have access to critical engine events like OnTriggerEnter/OnTriggerExit
```cs
static void CreateSineCube()
{
	var anyGameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);

	var unityObject = new UnityObject(anyGameObject);
	unityObject.u.Update += MoveInSinWave;
}

static void MoveInSinWave(UnityObject obj)
{
	obj.WorldPosition = Vector3.up * Mathf.Sin(Time.time);
}
```

You can neatly bundle a gameobject initialisation and functionality together
```cs
public class SineCube : UnityObject
{
	public SineCube()
		: base(GameObject.CreatePrimitive(PrimitiveType.Cube))
	{
		u.Update += MoveInSinWave;
	}

	private void MoveInSinWave(UnityObject obj)
	{
		obj.WorldPosition = Vector3.up * Mathf.Sin(Time.time);
	}
}
```
```cs
var sineCube = new SineCube();
```

Traditional Resources in Unity, Problems
----------------

Traditional asset loading in Unity
```cs
var oldPagePrefab = Resources.Load("UI/GameObjects/RecipePage");
var oldPageInstance = (GameObject)UnityEngine.Object.Instantiate(oldPagePrefab);
```
Loading assets via strings has some weaknesses, especially at game jams where you have 48 hours and your assets and asset layout is constantly evolving
* Renaming directories can break every asset beneath it
* Asset my be renamed, be spelled incorrectly or inconsistent Capitalisation
* Need manage loading / unloading of Prefabs


Intellisense Assets / No more static strings
----------------
In Unity use the "uSquid/Regenerate MyAssets.cs" menu item
![RegenerateMyAssets](https://github.com/sleepyparadox/uSquid/blob/master/Img/Examples/EditorRegenerateMyAssets.png "RegenerateMyAssets")


This will generate a MyAssets.cs code file in your assets directory

Including the MyAssets.cs in your project will expose Resources via intellisense
```cs
var page = MyAssets.Resources.UI.GameObjects.RecipePage.prefab.Clone();
```


Now that assets are exposed via code you can quickly catch missing assets when compiling

![MissingAsset](https://github.com/sleepyparadox/uSquid/blob/master/Img/Examples/MissingAsset.png "MissingAsset")
(Regenerating MyAssets.cs is a manual step, allowing you to choose when to resolve asset changes)

Directories expose assets as collections, allowing you to easily preload / unload groups resources
```cs
var uiIcons = MyAssets.Resources.UI.Icons.GetAssets().Where(asset => asset is Asset<Texture2D>)
													.Select(asset => asset as Asset<Texture2D>)
													.ToList();
foreach(var uiIcon in uiIcons)
{
	uiIcon.Load();
}
```

When Unity Updates and Unity Messages Change
----------------
Unity Messages definitions are stored in [MonoBehaviourMessages.txt]{https://github.com/sleepyparadox/uSquid/blob/master/Src/uSquid/Editor/Resources/MonoBehaviourMessages.txt}

The formatting for messages is "MessageName, Arg0Type Arg0Name, Arg1Type Arg1Name, Arg2Type Arg2Name"

Update them to match http://docs.unity3d.com/ScriptReference/MonoBehaviour.html

Uncomment line 13 of [UnityObjectBuild.cs](https://github.com/sleepyparadox/uSquid/blob/master/Src/uSquid/Editor/UnityObjectBuilder.cs#L13) ```[MenuItem("uSquid/BehindTheCurtain/Regenerate UnityObject.cs")]```

This will exposed the "uSquid/BehindTheCurtain/Regenerate UnityObject.cs" menu item in the unity editor

Press "Regenerate UnityObject.cs" to regenerate the generate Unity Message events