﻿// Copyright (c) Microsoft. All rights reserved.

using Microsoft.SemanticKernel.AI.ImageGeneration;
using Microsoft.SemanticKernel.Services;

// Use base namespace for better discoverability and to avoid conflicts with other extensions.
namespace Microsoft.SemanticKernel;

public static class ImageGenerationServiceExtensions
{
    /// <summary>
    /// Get the <see cref="IImageGeneration"/> matching the given <paramref name="serviceId"/>, or the default
    /// if the <paramref name="serviceId"/> is not provided or not found.
    /// </summary>
    /// <param name="services">The service provider.</param>
    /// <param name="serviceId">Optional identifier of the desired service.</param>
    /// <returns>The <see cref="IImageGeneration"/> id matching the given id or the default.</returns>
    /// <exception cref="KernelException">Thrown when no suitable service is found.</exception>
    public static IImageGeneration GetImageGenerationServiceOrDefault(
        this IAIServiceProvider services,
        string? serviceId = null) => services.GetNamedServiceOrDefault<IImageGeneration>(serviceId)
            ?? throw new KernelException(KernelException.ErrorCodes.ServiceNotFound, "Image generation service not found");

    /// <summary>
    /// Returns true if a <see cref="IImageGeneration"/> exist with the specified ID.
    /// </summary>
    /// <param name="services">The service provider.</param>
    /// <param name="serviceId">The service ID to search for. If null, it will look for a default service.</param>
    /// <returns>True if the service ID is registered, false otherwise.</returns>
    public static bool HasImageGenerationService(
        this IAIServiceProvider services,
        string? serviceId = null)
            => services.TryGetService<IImageGeneration>(serviceId, out _);
}