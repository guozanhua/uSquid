using UnityEngine;
using System.Diagnostics.CodeAnalysis;
public class uObject
{
	public event uObjectEventArgs uAwake;
	public event uObjectEventArgs uFixedUpdate;
	public event uObjectEventArgs uLateUpdate;
	public event AnimatorIKEventArgs uAnimatorIK;
	public event AnimatorMoveEventArgs uAnimatorMove;
	public event uObjectEventArgs uApplicationFocus;
	public event uObjectEventArgs uApplicationPause;
	public event uObjectEventArgs uApplicationQuit;
	public event uObjectEventArgs uAudioFilterRead;
	public event uObjectEventArgs uBecameInvisible;
	public event uObjectEventArgs uBecameVisible;
	public event CollisionEnterEventArgs uCollisionEnter;
	public event CollisionEnter2DEventArgs uCollisionEnter2D;
	public event CollisionExitEventArgs uCollisionExit;
	public event CollisionExit2DEventArgs uCollisionExit2D;
	public event CollisionStayEventArgs uCollisionStay;
	public event CollisionStay2DEventArgs uCollisionStay2D;
	public event uObjectEventArgs uConnectedToServer;
	public event ControllerColliderHitEventArgs uControllerColliderHit;
	public event uObjectEventArgs uDestroy;
	public event uObjectEventArgs uDisable;
	public event DisconnectedFromServerEventArgs uDisconnectedFromServer;
	public event uObjectEventArgs uDrawGizmos;
	public event uObjectEventArgs uDrawGizmosSelected;
	public event uObjectEventArgs uEnable;
	public event FailedToConnectEventArgs uFailedToConnect;
	public event FailedToConnectToMasterServerEventArgs uFailedToConnectToMasterServer;
	public event uObjectEventArgs uGUI;
	public event JointBreakEventArgs uJointBreak;
	public event LevelWasLoadedEventArgs uLevelWasLoaded;
	public event MasterServerEventEventArgs uMasterServerEvent;
	public event uObjectEventArgs uMouseDown;
	public event uObjectEventArgs uMouseDrag;
	public event uObjectEventArgs uMouseEnter;
	public event uObjectEventArgs uMouseExit;
	public event uObjectEventArgs uMouseOver;
	public event uObjectEventArgs uMouseUp;
	public event uObjectEventArgs uMouseUpAsButton;
	public event NetworkInstantiateEventArgs uNetworkInstantiate;
	public event ParticleCollisionEventArgs uParticleCollision;
	public event PlayerConnectedEventArgs uPlayerConnected;
	public event PlayerDisconnectedEventArgs uPlayerDisconnected;
	public event uObjectEventArgs uPostRender;
	public event uObjectEventArgs uPreCull;
	public event uObjectEventArgs uPreRender;
	public event RenderImageEventArgs uRenderImage;
	public event uObjectEventArgs uRenderObject;
	public event SerializeNetworkViewEventArgs uSerializeNetworkView;
	public event uObjectEventArgs uServerInitialized;
	public event uObjectEventArgs uTransformChildrenChanged;
	public event uObjectEventArgs uTransformParentChanged;
	public event TriggerEnterEventArgs uTriggerEnter;
	public event TriggerEnter2DEventArgs uTriggerEnter2D;
	public event TriggerExitEventArgs uTriggerExit;
	public event TriggerExit2DEventArgs uTriggerExit2D;
	public event TriggerStayEventArgs uTriggerStay;
	public event TriggerStay2DEventArgs uTriggerStay2D;
	public event uObjectEventArgs uValidate;
	public event uObjectEventArgs uWillRenderObject;
	public event uObjectEventArgs uReset;
	public event uObjectEventArgs uStart;
	public event uObjectEventArgs uUpdate;
	
	public delegate void uObjectEventArgs(uObject uObj);
	public delegate void AnimatorIKEventArgs(uObject uObj, int layerIndex);
	public delegate void AnimatorMoveEventArgs(uObject uObj, float[] data, int channels);
	public delegate void CollisionEnterEventArgs(uObject uObj, Collision collision);
	public delegate void CollisionEnter2DEventArgs(uObject uObj, Collision2D collision);
	public delegate void CollisionExitEventArgs(uObject uObj, Collision collision);
	public delegate void CollisionExit2DEventArgs(uObject uObj, Collision2D collision);
	public delegate void CollisionStayEventArgs(uObject uObj, Collision collision);
	public delegate void CollisionStay2DEventArgs(uObject uObj, Collision2D collision);
	public delegate void ControllerColliderHitEventArgs(uObject uObj, ControllerColliderHit hit);
	public delegate void DisconnectedFromServerEventArgs(uObject uObj, NetworkDisconnection info);
	public delegate void FailedToConnectEventArgs(uObject uObj, NetworkConnectionError error);
	public delegate void FailedToConnectToMasterServerEventArgs(uObject uObj, NetworkConnectionError error);
	public delegate void JointBreakEventArgs(uObject uObj, float breakForce);
	public delegate void LevelWasLoadedEventArgs(uObject uObj, int level);
	public delegate void MasterServerEventEventArgs(uObject uObj, MasterServerEvent msEvent);
	public delegate void NetworkInstantiateEventArgs(uObject uObj, NetworkMessageInfo info);
	public delegate void ParticleCollisionEventArgs(uObject uObj, GameObject other);
	public delegate void PlayerConnectedEventArgs(uObject uObj, NetworkPlayer player);
	public delegate void PlayerDisconnectedEventArgs(uObject uObj, NetworkPlayer player);
	public delegate void RenderImageEventArgs(uObject uObj, RenderTexture src, RenderTexture dest);
	public delegate void SerializeNetworkViewEventArgs(uObject uObj, BitStream stream, NetworkMessageInfo info);
	public delegate void TriggerEnterEventArgs(uObject uObj, Collider other);
	public delegate void TriggerEnter2DEventArgs(uObject uObj, Collider2D other);
	public delegate void TriggerExitEventArgs(uObject uObj, Collider other);
	public delegate void TriggerExit2DEventArgs(uObject uObj, Collider2D other);
	public delegate void TriggerStayEventArgs(uObject uObj, Collider other);
	public delegate void TriggerStay2DEventArgs(uObject uObj, Collider2D other);
	
	[SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "Firing events is the appropriate usage of \"Fire\"")]
	public void FireAwake()
	{
		var copy = uAwake;
		if (copy != null)
		{
			copy(this);
		}
	}
	public void ClearAwake()
	{
		uAwake = null;
	}
	[SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "Firing events is the appropriate usage of \"Fire\"")]
	public void FireFixedUpdate()
	{
		var copy = uFixedUpdate;
		if (copy != null)
		{
			copy(this);
		}
	}
	public void ClearFixedUpdate()
	{
		uFixedUpdate = null;
	}
	[SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "Firing events is the appropriate usage of \"Fire\"")]
	public void FireLateUpdate()
	{
		var copy = uLateUpdate;
		if (copy != null)
		{
			copy(this);
		}
	}
	public void ClearLateUpdate()
	{
		uLateUpdate = null;
	}
	[SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "Firing events is the appropriate usage of \"Fire\"")]
	public void FireAnimatorIK(int layerIndex)
	{
		var copy = uAnimatorIK;
		if (copy != null)
		{
			copy(this, layerIndex);
		}
	}
	public void ClearAnimatorIK()
	{
		uAnimatorIK = null;
	}
	[SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "Firing events is the appropriate usage of \"Fire\"")]
	public void FireAnimatorMove(float[] data, int channels)
	{
		var copy = uAnimatorMove;
		if (copy != null)
		{
			copy(this, data, channels);
		}
	}
	public void ClearAnimatorMove()
	{
		uAnimatorMove = null;
	}
	[SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "Firing events is the appropriate usage of \"Fire\"")]
	public void FireApplicationFocus()
	{
		var copy = uApplicationFocus;
		if (copy != null)
		{
			copy(this);
		}
	}
	public void ClearApplicationFocus()
	{
		uApplicationFocus = null;
	}
	[SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "Firing events is the appropriate usage of \"Fire\"")]
	public void FireApplicationPause()
	{
		var copy = uApplicationPause;
		if (copy != null)
		{
			copy(this);
		}
	}
	public void ClearApplicationPause()
	{
		uApplicationPause = null;
	}
	[SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "Firing events is the appropriate usage of \"Fire\"")]
	public void FireApplicationQuit()
	{
		var copy = uApplicationQuit;
		if (copy != null)
		{
			copy(this);
		}
	}
	public void ClearApplicationQuit()
	{
		uApplicationQuit = null;
	}
	[SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "Firing events is the appropriate usage of \"Fire\"")]
	public void FireAudioFilterRead()
	{
		var copy = uAudioFilterRead;
		if (copy != null)
		{
			copy(this);
		}
	}
	public void ClearAudioFilterRead()
	{
		uAudioFilterRead = null;
	}
	[SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "Firing events is the appropriate usage of \"Fire\"")]
	public void FireBecameInvisible()
	{
		var copy = uBecameInvisible;
		if (copy != null)
		{
			copy(this);
		}
	}
	public void ClearBecameInvisible()
	{
		uBecameInvisible = null;
	}
	[SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "Firing events is the appropriate usage of \"Fire\"")]
	public void FireBecameVisible()
	{
		var copy = uBecameVisible;
		if (copy != null)
		{
			copy(this);
		}
	}
	public void ClearBecameVisible()
	{
		uBecameVisible = null;
	}
	[SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "Firing events is the appropriate usage of \"Fire\"")]
	public void FireCollisionEnter(Collision collision)
	{
		var copy = uCollisionEnter;
		if (copy != null)
		{
			copy(this, collision);
		}
	}
	public void ClearCollisionEnter()
	{
		uCollisionEnter = null;
	}
	[SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "Firing events is the appropriate usage of \"Fire\"")]
	public void FireCollisionEnter2D(Collision2D collision)
	{
		var copy = uCollisionEnter2D;
		if (copy != null)
		{
			copy(this, collision);
		}
	}
	public void ClearCollisionEnter2D()
	{
		uCollisionEnter2D = null;
	}
	[SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "Firing events is the appropriate usage of \"Fire\"")]
	public void FireCollisionExit(Collision collision)
	{
		var copy = uCollisionExit;
		if (copy != null)
		{
			copy(this, collision);
		}
	}
	public void ClearCollisionExit()
	{
		uCollisionExit = null;
	}
	[SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "Firing events is the appropriate usage of \"Fire\"")]
	public void FireCollisionExit2D(Collision2D collision)
	{
		var copy = uCollisionExit2D;
		if (copy != null)
		{
			copy(this, collision);
		}
	}
	public void ClearCollisionExit2D()
	{
		uCollisionExit2D = null;
	}
	[SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "Firing events is the appropriate usage of \"Fire\"")]
	public void FireCollisionStay(Collision collision)
	{
		var copy = uCollisionStay;
		if (copy != null)
		{
			copy(this, collision);
		}
	}
	public void ClearCollisionStay()
	{
		uCollisionStay = null;
	}
	[SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "Firing events is the appropriate usage of \"Fire\"")]
	public void FireCollisionStay2D(Collision2D collision)
	{
		var copy = uCollisionStay2D;
		if (copy != null)
		{
			copy(this, collision);
		}
	}
	public void ClearCollisionStay2D()
	{
		uCollisionStay2D = null;
	}
	[SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "Firing events is the appropriate usage of \"Fire\"")]
	public void FireConnectedToServer()
	{
		var copy = uConnectedToServer;
		if (copy != null)
		{
			copy(this);
		}
	}
	public void ClearConnectedToServer()
	{
		uConnectedToServer = null;
	}
	[SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "Firing events is the appropriate usage of \"Fire\"")]
	public void FireControllerColliderHit(ControllerColliderHit hit)
	{
		var copy = uControllerColliderHit;
		if (copy != null)
		{
			copy(this, hit);
		}
	}
	public void ClearControllerColliderHit()
	{
		uControllerColliderHit = null;
	}
	[SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "Firing events is the appropriate usage of \"Fire\"")]
	public void FireDestroy()
	{
		var copy = uDestroy;
		if (copy != null)
		{
			copy(this);
		}
	}
	public void ClearDestroy()
	{
		uDestroy = null;
	}
	[SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "Firing events is the appropriate usage of \"Fire\"")]
	public void FireDisable()
	{
		var copy = uDisable;
		if (copy != null)
		{
			copy(this);
		}
	}
	public void ClearDisable()
	{
		uDisable = null;
	}
	[SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "Firing events is the appropriate usage of \"Fire\"")]
	public void FireDisconnectedFromServer(NetworkDisconnection info)
	{
		var copy = uDisconnectedFromServer;
		if (copy != null)
		{
			copy(this, info);
		}
	}
	public void ClearDisconnectedFromServer()
	{
		uDisconnectedFromServer = null;
	}
	[SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "Firing events is the appropriate usage of \"Fire\"")]
	public void FireDrawGizmos()
	{
		var copy = uDrawGizmos;
		if (copy != null)
		{
			copy(this);
		}
	}
	public void ClearDrawGizmos()
	{
		uDrawGizmos = null;
	}
	[SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "Firing events is the appropriate usage of \"Fire\"")]
	public void FireDrawGizmosSelected()
	{
		var copy = uDrawGizmosSelected;
		if (copy != null)
		{
			copy(this);
		}
	}
	public void ClearDrawGizmosSelected()
	{
		uDrawGizmosSelected = null;
	}
	[SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "Firing events is the appropriate usage of \"Fire\"")]
	public void FireEnable()
	{
		var copy = uEnable;
		if (copy != null)
		{
			copy(this);
		}
	}
	public void ClearEnable()
	{
		uEnable = null;
	}
	[SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "Firing events is the appropriate usage of \"Fire\"")]
	public void FireFailedToConnect(NetworkConnectionError error)
	{
		var copy = uFailedToConnect;
		if (copy != null)
		{
			copy(this, error);
		}
	}
	public void ClearFailedToConnect()
	{
		uFailedToConnect = null;
	}
	[SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "Firing events is the appropriate usage of \"Fire\"")]
	public void FireFailedToConnectToMasterServer(NetworkConnectionError error)
	{
		var copy = uFailedToConnectToMasterServer;
		if (copy != null)
		{
			copy(this, error);
		}
	}
	public void ClearFailedToConnectToMasterServer()
	{
		uFailedToConnectToMasterServer = null;
	}
	[SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "Firing events is the appropriate usage of \"Fire\"")]
	public void FireGUI()
	{
		var copy = uGUI;
		if (copy != null)
		{
			copy(this);
		}
	}
	public void ClearGUI()
	{
		uGUI = null;
	}
	[SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "Firing events is the appropriate usage of \"Fire\"")]
	public void FireJointBreak(float breakForce)
	{
		var copy = uJointBreak;
		if (copy != null)
		{
			copy(this, breakForce);
		}
	}
	public void ClearJointBreak()
	{
		uJointBreak = null;
	}
	[SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "Firing events is the appropriate usage of \"Fire\"")]
	public void FireLevelWasLoaded(int level)
	{
		var copy = uLevelWasLoaded;
		if (copy != null)
		{
			copy(this, level);
		}
	}
	public void ClearLevelWasLoaded()
	{
		uLevelWasLoaded = null;
	}
	[SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "Firing events is the appropriate usage of \"Fire\"")]
	public void FireMasterServerEvent(MasterServerEvent msEvent)
	{
		var copy = uMasterServerEvent;
		if (copy != null)
		{
			copy(this, msEvent);
		}
	}
	public void ClearMasterServerEvent()
	{
		uMasterServerEvent = null;
	}
	[SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "Firing events is the appropriate usage of \"Fire\"")]
	public void FireMouseDown()
	{
		var copy = uMouseDown;
		if (copy != null)
		{
			copy(this);
		}
	}
	public void ClearMouseDown()
	{
		uMouseDown = null;
	}
	[SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "Firing events is the appropriate usage of \"Fire\"")]
	public void FireMouseDrag()
	{
		var copy = uMouseDrag;
		if (copy != null)
		{
			copy(this);
		}
	}
	public void ClearMouseDrag()
	{
		uMouseDrag = null;
	}
	[SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "Firing events is the appropriate usage of \"Fire\"")]
	public void FireMouseEnter()
	{
		var copy = uMouseEnter;
		if (copy != null)
		{
			copy(this);
		}
	}
	public void ClearMouseEnter()
	{
		uMouseEnter = null;
	}
	[SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "Firing events is the appropriate usage of \"Fire\"")]
	public void FireMouseExit()
	{
		var copy = uMouseExit;
		if (copy != null)
		{
			copy(this);
		}
	}
	public void ClearMouseExit()
	{
		uMouseExit = null;
	}
	[SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "Firing events is the appropriate usage of \"Fire\"")]
	public void FireMouseOver()
	{
		var copy = uMouseOver;
		if (copy != null)
		{
			copy(this);
		}
	}
	public void ClearMouseOver()
	{
		uMouseOver = null;
	}
	[SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "Firing events is the appropriate usage of \"Fire\"")]
	public void FireMouseUp()
	{
		var copy = uMouseUp;
		if (copy != null)
		{
			copy(this);
		}
	}
	public void ClearMouseUp()
	{
		uMouseUp = null;
	}
	[SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "Firing events is the appropriate usage of \"Fire\"")]
	public void FireMouseUpAsButton()
	{
		var copy = uMouseUpAsButton;
		if (copy != null)
		{
			copy(this);
		}
	}
	public void ClearMouseUpAsButton()
	{
		uMouseUpAsButton = null;
	}
	[SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "Firing events is the appropriate usage of \"Fire\"")]
	public void FireNetworkInstantiate(NetworkMessageInfo info)
	{
		var copy = uNetworkInstantiate;
		if (copy != null)
		{
			copy(this, info);
		}
	}
	public void ClearNetworkInstantiate()
	{
		uNetworkInstantiate = null;
	}
	[SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "Firing events is the appropriate usage of \"Fire\"")]
	public void FireParticleCollision(GameObject other)
	{
		var copy = uParticleCollision;
		if (copy != null)
		{
			copy(this, other);
		}
	}
	public void ClearParticleCollision()
	{
		uParticleCollision = null;
	}
	[SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "Firing events is the appropriate usage of \"Fire\"")]
	public void FirePlayerConnected(NetworkPlayer player)
	{
		var copy = uPlayerConnected;
		if (copy != null)
		{
			copy(this, player);
		}
	}
	public void ClearPlayerConnected()
	{
		uPlayerConnected = null;
	}
	[SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "Firing events is the appropriate usage of \"Fire\"")]
	public void FirePlayerDisconnected(NetworkPlayer player)
	{
		var copy = uPlayerDisconnected;
		if (copy != null)
		{
			copy(this, player);
		}
	}
	public void ClearPlayerDisconnected()
	{
		uPlayerDisconnected = null;
	}
	[SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "Firing events is the appropriate usage of \"Fire\"")]
	public void FirePostRender()
	{
		var copy = uPostRender;
		if (copy != null)
		{
			copy(this);
		}
	}
	public void ClearPostRender()
	{
		uPostRender = null;
	}
	[SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "Firing events is the appropriate usage of \"Fire\"")]
	public void FirePreCull()
	{
		var copy = uPreCull;
		if (copy != null)
		{
			copy(this);
		}
	}
	public void ClearPreCull()
	{
		uPreCull = null;
	}
	[SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "Firing events is the appropriate usage of \"Fire\"")]
	public void FirePreRender()
	{
		var copy = uPreRender;
		if (copy != null)
		{
			copy(this);
		}
	}
	public void ClearPreRender()
	{
		uPreRender = null;
	}
	[SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "Firing events is the appropriate usage of \"Fire\"")]
	public void FireRenderImage(RenderTexture src, RenderTexture dest)
	{
		var copy = uRenderImage;
		if (copy != null)
		{
			copy(this, src, dest);
		}
	}
	public void ClearRenderImage()
	{
		uRenderImage = null;
	}
	[SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "Firing events is the appropriate usage of \"Fire\"")]
	public void FireRenderObject()
	{
		var copy = uRenderObject;
		if (copy != null)
		{
			copy(this);
		}
	}
	public void ClearRenderObject()
	{
		uRenderObject = null;
	}
	[SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "Firing events is the appropriate usage of \"Fire\"")]
	public void FireSerializeNetworkView(BitStream stream, NetworkMessageInfo info)
	{
		var copy = uSerializeNetworkView;
		if (copy != null)
		{
			copy(this, stream, info);
		}
	}
	public void ClearSerializeNetworkView()
	{
		uSerializeNetworkView = null;
	}
	[SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "Firing events is the appropriate usage of \"Fire\"")]
	public void FireServerInitialized()
	{
		var copy = uServerInitialized;
		if (copy != null)
		{
			copy(this);
		}
	}
	public void ClearServerInitialized()
	{
		uServerInitialized = null;
	}
	[SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "Firing events is the appropriate usage of \"Fire\"")]
	public void FireTransformChildrenChanged()
	{
		var copy = uTransformChildrenChanged;
		if (copy != null)
		{
			copy(this);
		}
	}
	public void ClearTransformChildrenChanged()
	{
		uTransformChildrenChanged = null;
	}
	[SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "Firing events is the appropriate usage of \"Fire\"")]
	public void FireTransformParentChanged()
	{
		var copy = uTransformParentChanged;
		if (copy != null)
		{
			copy(this);
		}
	}
	public void ClearTransformParentChanged()
	{
		uTransformParentChanged = null;
	}
	[SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "Firing events is the appropriate usage of \"Fire\"")]
	public void FireTriggerEnter(Collider other)
	{
		var copy = uTriggerEnter;
		if (copy != null)
		{
			copy(this, other);
		}
	}
	public void ClearTriggerEnter()
	{
		uTriggerEnter = null;
	}
	[SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "Firing events is the appropriate usage of \"Fire\"")]
	public void FireTriggerEnter2D(Collider2D other)
	{
		var copy = uTriggerEnter2D;
		if (copy != null)
		{
			copy(this, other);
		}
	}
	public void ClearTriggerEnter2D()
	{
		uTriggerEnter2D = null;
	}
	[SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "Firing events is the appropriate usage of \"Fire\"")]
	public void FireTriggerExit(Collider other)
	{
		var copy = uTriggerExit;
		if (copy != null)
		{
			copy(this, other);
		}
	}
	public void ClearTriggerExit()
	{
		uTriggerExit = null;
	}
	[SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "Firing events is the appropriate usage of \"Fire\"")]
	public void FireTriggerExit2D(Collider2D other)
	{
		var copy = uTriggerExit2D;
		if (copy != null)
		{
			copy(this, other);
		}
	}
	public void ClearTriggerExit2D()
	{
		uTriggerExit2D = null;
	}
	[SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "Firing events is the appropriate usage of \"Fire\"")]
	public void FireTriggerStay(Collider other)
	{
		var copy = uTriggerStay;
		if (copy != null)
		{
			copy(this, other);
		}
	}
	public void ClearTriggerStay()
	{
		uTriggerStay = null;
	}
	[SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "Firing events is the appropriate usage of \"Fire\"")]
	public void FireTriggerStay2D(Collider2D other)
	{
		var copy = uTriggerStay2D;
		if (copy != null)
		{
			copy(this, other);
		}
	}
	public void ClearTriggerStay2D()
	{
		uTriggerStay2D = null;
	}
	[SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "Firing events is the appropriate usage of \"Fire\"")]
	public void FireValidate()
	{
		var copy = uValidate;
		if (copy != null)
		{
			copy(this);
		}
	}
	public void ClearValidate()
	{
		uValidate = null;
	}
	[SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "Firing events is the appropriate usage of \"Fire\"")]
	public void FireWillRenderObject()
	{
		var copy = uWillRenderObject;
		if (copy != null)
		{
			copy(this);
		}
	}
	public void ClearWillRenderObject()
	{
		uWillRenderObject = null;
	}
	[SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "Firing events is the appropriate usage of \"Fire\"")]
	public void FireReset()
	{
		var copy = uReset;
		if (copy != null)
		{
			copy(this);
		}
	}
	public void ClearReset()
	{
		uReset = null;
	}
	[SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "Firing events is the appropriate usage of \"Fire\"")]
	public void FireStart()
	{
		var copy = uStart;
		if (copy != null)
		{
			copy(this);
		}
	}
	public void ClearStart()
	{
		uStart = null;
	}
	[SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "Firing events is the appropriate usage of \"Fire\"")]
	public void FireUpdate()
	{
		var copy = uUpdate;
		if (copy != null)
		{
			copy(this);
		}
	}
	public void ClearUpdate()
	{
		uUpdate = null;
	}
}
