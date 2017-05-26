/*
 * Copyright (c) Contributors, http://whitecore-sim.org/
 * See CONTRIBUTORS.TXT for a full list of copyright holders.
 *
 * Redistribution and use in source and binary forms, with or without
 * modification, are permitted provided that the following conditions are met:
 *     * Redistributions of source code must retain the above copyright
 *       notice, this list of conditions and the following disclaimer.
 *     * Redistributions in binary form must reproduce the above copyright
 *       notice, this list of conditions and the following disclaimer in the
 *       documentation and/or other materials provided with the distribution.
 *     * Neither the name of the WhiteCore-Sim Project nor the
 *       names of its contributors may be used to endorse or promote products
 *       derived from this software without specific prior written permission.
 *
 * THIS SOFTWARE IS PROVIDED BY THE DEVELOPERS ``AS IS'' AND ANY
 * EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
 * WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
 * DISCLAIMED. IN NO EVENT SHALL THE CONTRIBUTORS BE LIABLE FOR ANY
 * DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
 * (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
 * LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
 * ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
 * (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
 * SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 */

using System.Collections.Generic;
using OpenMetaverse;
using OpenSim.Framework;
using Caps=OpenSim.Framework.Capabilities.Caps;

namespace OpenSim.Region.Framework.Interfaces
{
    public interface ICapabilitiesModule
    {
        void NewUserConnection(AgentCircuitData agent);
        
        /// <summary>
        /// Add a caps handler for the given agent.  If the CAPS handler already exists for this agent,
        /// then it is replaced by a new CAPS handler.
        ///
        /// FIXME: On login this is called twice, once for the login and once when the connection is made.
        /// This is somewhat innefficient and should be fixed.  The initial login creation is necessary
        /// since the client asks for capabilities immediately after being informed of the seed.
        /// </summary>
        /// <param name="agentId"></param>
        /// <param name="capsObjectPath"></param>
        void AddCapsHandler(UUID agentId);
        
        /// <summary>
        /// Remove the caps handler for a given agent.
        /// </summary>
        /// <param name="agentId"></param>
        void RemoveCapsHandler(UUID agentId);
        
        /// <summary>
        /// Will return null if the agent doesn't have a caps handler registered
        /// </summary>
        /// <param name="agentId"></param>
        Caps GetCapsHandlerForUser(UUID agentId);
        
        Dictionary<ulong, string> GetChildrenSeeds(UUID agentID);
        
        string GetChildSeed(UUID agentID, ulong handle);
        
        void SetChildrenSeed(UUID agentID, Dictionary<ulong, string> seeds);
        
        void DropChildSeed(UUID agentID, ulong handle);

        string GetCapsPath(UUID agentId);
    }
}
