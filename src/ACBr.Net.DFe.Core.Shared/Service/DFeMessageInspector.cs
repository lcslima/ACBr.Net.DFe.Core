// ***********************************************************************
// Assembly         : ACBr.Net.DFe.Core
// Author           : RFTD
// Created          : 07-28-2016
//
// Last Modified By : RFTD
// Last Modified On : 07-28-2016
// ***********************************************************************
// <copyright file="DFeMessageInspector.cs" company="ACBr.Net">
//		        		   The MIT License (MIT)
//	     		    Copyright (c) 2016 Grupo ACBr.Net
//
//	 Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the "Software"),
// to deal in the Software without restriction, including without limitation
// the rights to use, copy, modify, merge, publish, distribute, sublicense,
// and/or sell copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following conditions:
//	 The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//	 THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
// IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM,
// DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
// ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
// DEALINGS IN THE SOFTWARE.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using ACBr.Net.Core.Logging;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using ACBr.Net.Core.Extensions;

namespace ACBr.Net.DFe.Core.Service
{
	internal class DFeMessageInspector : IClientMessageInspector, IACBrLog
	{
		#region Events

		public EventHandler<DFeMessageEventArgs> BeforeSendDFeRequest;

		public EventHandler<DFeMessageEventArgs> AfterReceiveDFeReply;

		#endregion Events

		#region Methods

		public object BeforeSendRequest(ref Message request, IClientChannel channel)
		{
			var dfeArgs = new DFeMessageEventArgs(request.ToString());
			this.Log().Debug(dfeArgs.Message);
			BeforeSendDFeRequest.Raise(this, dfeArgs);
			return null;
		}

		public void AfterReceiveReply(ref Message reply, object correlationState)
		{
			var dfeArgs = new DFeMessageEventArgs(reply.ToString());
			this.Log().Debug(dfeArgs.Message);
			AfterReceiveDFeReply.Raise(this, dfeArgs);
		}

		#endregion Methods
	}
}