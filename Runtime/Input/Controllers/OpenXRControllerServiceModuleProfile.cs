// Copyright (c) Reality Collective. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using RealityToolkit.Definitions.Controllers;

namespace RealityToolkit.OpenXR.Input.Controllers
{
    /// <summary>
    /// Configuration profile for <see cref="OpenXRControllerServiceModule"/>.
    /// </summary>
    public class OpenXRControllerServiceModuleProfile : BaseControllerServiceModuleProfile
    {
        /// <inheritdoc />
        public override ControllerDefinition[] GetDefaultControllerOptions()
        {
            return null;
        }
    }
}
