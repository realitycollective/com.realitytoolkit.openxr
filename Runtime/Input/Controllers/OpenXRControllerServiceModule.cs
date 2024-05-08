// Copyright (c) Reality Collective. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using RealityCollective.ServiceFramework.Attributes;
using RealityToolkit.Input.Controllers;
using RealityToolkit.Input.Interfaces;
using UnityEngine;

namespace RealityToolkit.OpenXR.Input.Controllers
{
    [RuntimePlatform(typeof(OpenXRPlatform))]
    [System.Runtime.InteropServices.Guid("a5099f91-b390-4155-894a-309fbd73febb")]
    public class OpenXRControllerServiceModule : BaseControllerServiceModule, IOpenXRControllerServiceModule
    {
        /// <inheritdoc />
        public OpenXRControllerServiceModule(string name, uint priority, OpenXRControllerServiceModuleProfile profile, IInputService parentService)
            : base(name, priority, profile, parentService) { }
    }
}
