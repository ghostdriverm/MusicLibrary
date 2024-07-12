﻿namespace MusicLibrary.WebAPI.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static void AddPresentation(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
    }
}
