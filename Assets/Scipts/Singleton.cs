//using Sirenix.OdinInspector;
using UnityEngine;

/// <summary>
/// A singleton implementation where the Instance property can return another type R (derived from T)
/// </summary>
public class Singleton<T, R> : Singleton<T> 
	where T : MonoBehaviour, R
{
	public static new R Instance
	{
		get
		{
			return (R)Singleton<T>.Instance;
		}
	}
}

/// <summary>
/// Be aware this will not prevent a non singleton constructor
///   such as `T myT = new T();`
/// To prevent that, add `protected T () {}` to your singleton class.
/// 
/// As a note, this is made as MonoBehaviour because we need Coroutines.
/// </summary>
public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
	protected static T _instance;
	
	private static object _lock = new object();

	public static bool InstanceExists
	{
		get { return _instance != null; }
	}

	private static bool isQuitting;

	public static T Instance
	{
		get
		{
			lock(_lock)
			{
				if (_instance == null)
				{
					if (isQuitting)
					{
						return null;
					}

					_instance = (T) FindObjectOfType(typeof(T));

					if (_instance == null)
					{
						GameObject singleton = new GameObject();
						_instance = singleton.AddComponent<T>();
						singleton.name = "(singleton) " + typeof(T).ToString();
					}

#if UNITY_EDITOR
					if (Application.isPlaying)
#endif
					{
						DontDestroyOnLoad(_instance);
					}
				}

				return _instance;
			}
		}
	}

	void OnApplicationQuit()
	{
		isQuitting = true;
	}
}