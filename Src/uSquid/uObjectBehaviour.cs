using UnityEngine;
public class uObjectBehaviour
{
	public uObject uObject;
	public void Awake ()
	{
		this.uObject.FireAwake();
	}
	public void FixedUpdate ()
	{
		this.uObject.FireFixedUpdate();
	}
	public void LateUpdate ()
	{
		this.uObject.FireLateUpdate();
	}
	public void OnAnimatorIK (int layerIndex)
	{
		this.uObject.FireAnimatorIK(layerIndex);
	}
	public void OnAnimatorMove (float[] data, int channels)
	{
		this.uObject.FireAnimatorMove(data, channels);
	}
	public void OnApplicationFocus ()
	{
		this.uObject.FireApplicationFocus();
	}
	public void OnApplicationPause ()
	{
		this.uObject.FireApplicationPause();
	}
	public void OnApplicationQuit ()
	{
		this.uObject.FireApplicationQuit();
	}
	public void OnAudioFilterRead ()
	{
		this.uObject.FireAudioFilterRead();
	}
	public void OnBecameInvisible ()
	{
		this.uObject.FireBecameInvisible();
	}
	public void OnBecameVisible ()
	{
		this.uObject.FireBecameVisible();
	}
	public void OnCollisionEnter (Collision collision)
	{
		this.uObject.FireCollisionEnter(collision);
	}
	public void OnCollisionEnter2D (Collision2D collision)
	{
		this.uObject.FireCollisionEnter2D(collision);
	}
	public void OnCollisionExit (Collision collision)
	{
		this.uObject.FireCollisionExit(collision);
	}
	public void OnCollisionExit2D (Collision2D collision)
	{
		this.uObject.FireCollisionExit2D(collision);
	}
	public void OnCollisionStay (Collision collision)
	{
		this.uObject.FireCollisionStay(collision);
	}
	public void OnCollisionStay2D (Collision2D collision)
	{
		this.uObject.FireCollisionStay2D(collision);
	}
	public void OnConnectedToServer ()
	{
		this.uObject.FireConnectedToServer();
	}
	public void OnControllerColliderHit (ControllerColliderHit hit)
	{
		this.uObject.FireControllerColliderHit(hit);
	}
	public void OnDestroy ()
	{
		this.uObject.FireDestroy();
	}
	public void OnDisable ()
	{
		this.uObject.FireDisable();
	}
	public void OnDisconnectedFromServer (NetworkDisconnection info)
	{
		this.uObject.FireDisconnectedFromServer(info);
	}
	public void OnDrawGizmos ()
	{
		this.uObject.FireDrawGizmos();
	}
	public void OnDrawGizmosSelected ()
	{
		this.uObject.FireDrawGizmosSelected();
	}
	public void OnEnable ()
	{
		this.uObject.FireEnable();
	}
	public void OnFailedToConnect (NetworkConnectionError error)
	{
		this.uObject.FireFailedToConnect(error);
	}
	public void OnFailedToConnectToMasterServer (NetworkConnectionError error)
	{
		this.uObject.FireFailedToConnectToMasterServer(error);
	}
	public void OnGUI ()
	{
		this.uObject.FireGUI();
	}
	public void OnJointBreak (float breakForce)
	{
		this.uObject.FireJointBreak(breakForce);
	}
	public void OnLevelWasLoaded (int level)
	{
		this.uObject.FireLevelWasLoaded(level);
	}
	public void OnMasterServerEvent (MasterServerEvent msEvent)
	{
		this.uObject.FireMasterServerEvent(msEvent);
	}
	public void OnMouseDown ()
	{
		this.uObject.FireMouseDown();
	}
	public void OnMouseDrag ()
	{
		this.uObject.FireMouseDrag();
	}
	public void OnMouseEnter ()
	{
		this.uObject.FireMouseEnter();
	}
	public void OnMouseExit ()
	{
		this.uObject.FireMouseExit();
	}
	public void OnMouseOver ()
	{
		this.uObject.FireMouseOver();
	}
	public void OnMouseUp ()
	{
		this.uObject.FireMouseUp();
	}
	public void OnMouseUpAsButton ()
	{
		this.uObject.FireMouseUpAsButton();
	}
	public void OnNetworkInstantiate (NetworkMessageInfo info)
	{
		this.uObject.FireNetworkInstantiate(info);
	}
	public void OnParticleCollision (GameObject other)
	{
		this.uObject.FireParticleCollision(other);
	}
	public void OnPlayerConnected (NetworkPlayer player)
	{
		this.uObject.FirePlayerConnected(player);
	}
	public void OnPlayerDisconnected (NetworkPlayer player)
	{
		this.uObject.FirePlayerDisconnected(player);
	}
	public void OnPostRender ()
	{
		this.uObject.FirePostRender();
	}
	public void OnPreCull ()
	{
		this.uObject.FirePreCull();
	}
	public void OnPreRender ()
	{
		this.uObject.FirePreRender();
	}
	public void OnRenderImage (RenderTexture src, RenderTexture dest)
	{
		this.uObject.FireRenderImage(src, dest);
	}
	public void OnRenderObject ()
	{
		this.uObject.FireRenderObject();
	}
	public void OnSerializeNetworkView (BitStream stream, NetworkMessageInfo info)
	{
		this.uObject.FireSerializeNetworkView(stream, info);
	}
	public void OnServerInitialized ()
	{
		this.uObject.FireServerInitialized();
	}
	public void OnTransformChildrenChanged ()
	{
		this.uObject.FireTransformChildrenChanged();
	}
	public void OnTransformParentChanged ()
	{
		this.uObject.FireTransformParentChanged();
	}
	public void OnTriggerEnter (Collider other)
	{
		this.uObject.FireTriggerEnter(other);
	}
	public void OnTriggerEnter2D (Collider2D other)
	{
		this.uObject.FireTriggerEnter2D(other);
	}
	public void OnTriggerExit (Collider other)
	{
		this.uObject.FireTriggerExit(other);
	}
	public void OnTriggerExit2D (Collider2D other)
	{
		this.uObject.FireTriggerExit2D(other);
	}
	public void OnTriggerStay (Collider other)
	{
		this.uObject.FireTriggerStay(other);
	}
	public void OnTriggerStay2D (Collider2D other)
	{
		this.uObject.FireTriggerStay2D(other);
	}
	public void OnValidate ()
	{
		this.uObject.FireValidate();
	}
	public void OnWillRenderObject ()
	{
		this.uObject.FireWillRenderObject();
	}
	public void Reset ()
	{
		this.uObject.FireReset();
	}
	public void Start ()
	{
		this.uObject.FireStart();
	}
	public void Update ()
	{
		this.uObject.FireUpdate();
	}
}
