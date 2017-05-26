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

using System.Drawing;
using OpenMetaverse;
using OpenMetaverse.Imaging;
using OpenSim.Framework;
using OpenSim.Region.Framework.Scenes;

namespace OpenSim.Region.OptionalModules.Scripting.Minimodule
{
    class Graphics : System.MarshalByRefObject, IGraphics
    {
        private readonly Scene m_scene;

        public Graphics(Scene m_scene)
        {
            this.m_scene = m_scene;
        }

        public UUID SaveBitmap(Bitmap data)
        {
            return SaveBitmap(data, false, true);
        }

        public UUID SaveBitmap(Bitmap data, bool lossless, bool temporary)
        {
            AssetBase asset = new AssetBase(UUID.Random(), "MRMDynamicImage", (sbyte)AssetType.Texture);
            asset.Data = OpenJPEG.EncodeFromImage(data, lossless);
            asset.Description = "MRM Image";
            asset.Local = false;
            asset.Temporary = temporary;
            m_scene.AssetService.Store(asset);

            return asset.FullID;
        }

        public Bitmap LoadBitmap(UUID assetID)
        {
            AssetBase bmp = m_scene.AssetService.Get(assetID.ToString());
            ManagedImage outimg;
            Image img;
            OpenJPEG.DecodeToImage(bmp.Data, out outimg, out img);

            return new Bitmap(img);
        }
    }
}
