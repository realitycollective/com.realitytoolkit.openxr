// Copyright (c) Reality Collective. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using RealityCollective.ServiceFramework.Definitions.Platforms;
using RealityCollective.ServiceFramework.Interfaces;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

namespace RealityToolkit.OpenXR
{
    /// <summary>
    /// Used by the toolkit to signal that a feature is available on the OpenXR platform.
    /// </summary>
    [System.Runtime.InteropServices.Guid("72c2e15b-d4ae-4e10-83bd-6e670b37efdd")]
    public class OpenXRPlatform : BasePlatform
    {
        /// <inheritdoc />
        public override IPlatform[] PlatformOverrides { get; } =
        {
            new AndroidPlatform(),
            new WindowsStandalonePlatform()
		};

        /// <inheritdoc />
        public override bool IsAvailable
        {
            get
            {
                var displaySubsystems = new List<XRDisplaySubsystem>();
                SubsystemManager.GetSubsystems(displaySubsystems);
                var xrDisplaySubsystemDescriptorFound = displaySubsystems.Count > 0;

                // The XR Display Subsystem is not available / running,
                // the platform doesn't seem to be available.
                if (!xrDisplaySubsystemDescriptorFound)
                {
                    return false;
                }

                var inputSubsystems = new List<XRInputSubsystem>();
                SubsystemManager.GetSubsystems(inputSubsystems);
                var xrInputSubsystemDescriptorFound = false;

                for (var i = 0; i < inputSubsystems.Count; i++)
                {
                    var inputSubsystem = inputSubsystems[i];
                    if (!xrInputSubsystemDescriptorFound)
                    {
                        xrInputSubsystemDescriptorFound = inputSubsystem.running;
                    }
                }

                // The No XR Input Subsystem found / running,
                // no platforms are available.
                if (!xrInputSubsystemDescriptorFound)
                {
                    return false;
                }

                // Only if both, Display and Input XR Subsystems are available
                // and running, the platform is considered available.
                return true;
            }
        }

#if UNITY_EDITOR
        /// <inheritdoc />
        public override UnityEditor.BuildTarget[] ValidBuildTargets { get; } =
        {
			//Choose which Platforms this runtime is available for in the Editor
            //UnityEditor.BuildTarget.Android
			//UnityEditor.BuildTarget.WSAPlayer
            //UnityEditor.BuildTarget.StandaloneWindows64,
            //UnityEditor.BuildTarget.StandaloneWindows			
        };
#endif
    }
}
