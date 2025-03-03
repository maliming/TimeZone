﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace TimeZoneApp.Web.Pages;

public class IndexModel : TimeZoneAppPageModel
{
    public void OnGet()
    {

    }

    public async Task OnPostLoginAsync()
    {
        await HttpContext.ChallengeAsync("oidc");
    }
}
