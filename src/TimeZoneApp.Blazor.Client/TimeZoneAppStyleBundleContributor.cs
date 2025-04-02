﻿using Volo.Abp.AspNetCore.Mvc.UI.Bundling;

namespace TimeZoneApp.Blazor.Client;

public class TimeZoneAppStyleBundleContributor : BundleContributor
{
    public override void ConfigureBundle(BundleConfigurationContext context)
    {
        context.Files.Add(new BundleFile("main.css", true));
    }
}
