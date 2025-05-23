﻿using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TimeZoneApp.Localization;
using TimeZoneApp.MultiTenancy;
using TimeZoneApp.Permissions;
using Volo.Abp.Account.Localization;
using Volo.Abp.Identity.Blazor;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.SettingManagement.Blazor.Menus;
using Volo.Abp.TenantManagement.Blazor.Navigation;
using Volo.Abp.UI.Navigation;
using Volo.Abp.Users;

namespace TimeZoneApp.Blazor.Menus;

public class TimeZoneAppMenuContributor : IMenuContributor
{
    private readonly IConfiguration _configuration;

    public TimeZoneAppMenuContributor(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
        else if (context.Menu.Name == StandardMenus.User)
        {
            await ConfigureUserMenuAsync(context);
        }
    }

    private async Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var administration = context.Menu.GetAdministration();
        var l = context.GetLocalizer<TimeZoneAppResource>();

        context.Menu.Items.Insert(
            0,
            new ApplicationMenuItem(
                TimeZoneAppMenus.Home,
                l["Menu:Home"],
                "/",
                icon: "fas fa-home",
                order: 0
            )
        );

        if (await context.IsGrantedAsync(TimeZoneAppPermissions.Meetings.Default))
        {
            context.Menu.Items.Insert(
                1,
                new ApplicationMenuItem(
                    "Meeting",
                    l["Menu:Meeting"],
                    "~/Meetings",
                    icon: "fa fa-coffee"
                )
            );
        }

        if (MultiTenancyConsts.IsEnabled)
        {
            administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
        }
        else
        {
            administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
        }

        administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
        administration.SetSubItemOrder(SettingManagementMenus.GroupName, 3);
    }

    private Task ConfigureUserMenuAsync(MenuConfigurationContext context)
    {
        var l = context.GetLocalizer<TimeZoneAppResource>();
        var accountStringLocalizer = context.GetLocalizer<AccountResource>();
        var authServerUrl = _configuration["AuthServer:Authority"] ?? "";

        context.Menu.AddItem(new ApplicationMenuItem("Account.Manage", accountStringLocalizer["MyAccount"],
                $"{authServerUrl.EnsureEndsWith('/')}Account/Manage?returnUrl={_configuration["App:SelfUrl"]}", icon: "fa fa-cog", order: 1000, null, "_blank").RequireAuthenticated());
        context.Menu.AddItem(new ApplicationMenuItem("Account.Logout", l["Logout"], url: "~/Account/Logout", icon: "fa fa-power-off", order: int.MaxValue - 1000).RequireAuthenticated());

        return Task.CompletedTask;
    }
}
