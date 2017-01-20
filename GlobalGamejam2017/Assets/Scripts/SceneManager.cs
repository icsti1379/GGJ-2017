using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

/* Variables:
 * 
 * buildIndex	        Returns the index of the scene in the Build Settings. Always returns -1 if the scene was loaded through an AssetBundle.
 * isDirty	            Returns true if the scene is modifed.
 * isLoaded	            Returns true if the scene is loaded.
 * name	                Returns the name of the scene.
 * path	                Returns the relative path of the scene. Like: "Assets/MyScenes/MyScene.unity".
 * rootCount	        The number of root transforms of this scene.
 */

/* Public functions:
 * 
 * GetRootGameObjects	Returns all the root game objects in the scene.
 * IsValid              Whether this is a valid scene. A scene may be invalid if, for example, you tried to open a scene that does not exist. 
 *                      In this case, the scene returned from EditorSceneManager. OpenScene would return False for IsValid.
 */

/* Operator:
 * 
 * operator !=	        Returns true if the Scenes are different.
 * operator ==	        Returns true if the Scenes are equal. * 
 */

public class SceneManager : MonoBehaviour
{
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
