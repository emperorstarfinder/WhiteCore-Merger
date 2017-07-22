﻿/*
 * Copyright (c) Contributors, http://opensimulator.org/
 * See CONTRIBUTORS.TXT for a full list of copyright holders.
 *
 * Redistribution and use in source and binary forms, with or without
 * modification, are permitted provided that the following conditions are met:
 *     * Redistributions of source code must retain the above copyright
 *       notice, this list of conditions and the following disclaimer.
 *     * Redistributions in binary form must reproduce the above copyright
 *       notice, this list of conditions and the following disclaimer in the
 *       documentation and/or other materials provided with the distribution.
 *     * Neither the name of the OpenSimulator Project nor the
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

using System;
using System.Runtime.Remoting.Lifetime;
using System.Threading;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using OpenSim.Framework;
using OpenSim.Region.Framework.Interfaces;
using WhiteCore.ScriptEngine.Interfaces;
using WhiteCore.ScriptEngine.Shared.Api.Interfaces;
using integer = WhiteCore.ScriptEngine.Shared.LSL_Types.LSLInteger;
using vector = WhiteCore.ScriptEngine.Shared.LSL_Types.Vector3;
using rotation = WhiteCore.ScriptEngine.Shared.LSL_Types.Quaternion;
using key = WhiteCore.ScriptEngine.Shared.LSL_Types.LSLString;
using LSL_List = WhiteCore.ScriptEngine.Shared.LSL_Types.list;
using LSL_String = WhiteCore.ScriptEngine.Shared.LSL_Types.LSLString;
using LSL_Float = WhiteCore.ScriptEngine.Shared.LSL_Types.LSLFloat;
using LSL_Integer = WhiteCore.ScriptEngine.Shared.LSL_Types.LSLInteger;

namespace WhiteCore.ScriptEngine.Shared.ScriptBase
{
    public partial class ScriptBaseClass : MarshalByRefObject
    {
        public IAA_Api m_AA_Functions;

        public void ApiTypeAA(IScriptApi api)
        {
            if (!(api is IAA_Api))
                return;

            m_AA_Functions = (IAA_Api)api;
        }

        public string aaDetectedCountry(int num)
        {
            return m_AA_Functions.aaDetectedCountry(num);
        }

        public string aaGetAgentCountry(key key)
        {
            return m_AA_Functions.aaGetAgentCountry(key);
        }
    }
}