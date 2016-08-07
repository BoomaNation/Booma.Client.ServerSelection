﻿using GladBehaviour.Common;
using GladNet.Common;
using GladNet.Engine.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Booma.Client.ServerSelection.Authentication
{
	/// <summary>
	/// Component is capable of sending gameserver list requests through the
	/// peer to the currently connected network.
	/// </summary>
	public class GameServerListRequestGenerator : GladMonoBehaviour, IRequestSender
	{
		//TODO: Put this in a base class.
		[SerializeField]
		private IClientPeerPayloadSender messageSender;

		public void SendRequest()
		{
			SendRequestWithResult();
		}

		public SendResult SendRequestWithResult()
		{
			//TODO: Send shiplist request when the payload exists.
			return SendResult.Invalid;
		}
	}
}
