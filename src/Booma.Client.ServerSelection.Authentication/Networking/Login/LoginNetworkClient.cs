﻿using Booma.Client.Network.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GladNet.Common;
using UnityEngine.Events;
using UnityEngine;
using GladLive.Common.Payloads;
using GladNet.Serializer;

namespace Booma.Client.ServerSelection.Authentication
{
	/// <summary>
	/// The login network client for the Booma project.
	/// </summary>
	public class LoginNetworkClient : BoomaNetworkClientPeer<LoginNetworkClient>
	{
		//Note to future users. Assuming the API/Design has not changed.
		//You should use SceneJect, or some sort of DI lib, to inject
		//the response and event handlers which are properties in the base class.
		//If you don't there is no mechanism for getting info about them or handling them exposed.

		/// <summary>
		/// Called when the peer enters a connected state
		/// </summary>
		[Tooltip("Called when the peer enters a connected state.")]
		[SerializeField]
		private NetworkStatusUnityEvent OnConnectionEstablished;

		/// <summary>
		/// Called when the peer successfully establishes a secure channel.
		/// </summary>
		[Tooltip("Called when the peer successfully establishes a secure channel.")]
		[SerializeField]
		private NetworkStatusUnityEvent OnEncryptionEstablished;

		/// <summary>
		/// Called when the peer's <see cref="NetStatus"/> changed.
		/// </summary>
		[Tooltip("Called when the peer's NetStatus changed.")]
		[SerializeField]
		private NetworkStatusUnityEvent OnStatusChangedEvent;

		/// <summary>
		/// Called internally when the client peer recieves a notice of change in <see cref="NetStatus"/>.
		/// </summary>
		/// <param name="status">The new current status/event.</param>
		public override void OnStatusChanged(NetStatus status)
		{
			switch(status)
			{
				//We just invoke unity events passing in information
				//this allows designers to rig up listeners or preform actions in the inspector when certain things happen.
				case NetStatus.Connected:
					Debug.Log("NetStatus changed to Connected.");
					if (OnConnectionEstablished != null)
						OnConnectionEstablished.Invoke(this, status);
					break;
				case NetStatus.EncryptionEstablished:
					Debug.Log("NetStatus changed to EncryptionEstablished.");
					if(OnEncryptionEstablished != null)
						OnEncryptionEstablished.Invoke(this, status);
					break;
			}
		}

		public override void RegisterPayloadTypes(ISerializerRegistry registry)
		{
			registry.Register(typeof(LoginRequest));
		}
	}
}
