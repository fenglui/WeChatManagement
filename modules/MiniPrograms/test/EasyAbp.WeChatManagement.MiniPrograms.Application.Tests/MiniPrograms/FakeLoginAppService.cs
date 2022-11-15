﻿using System.Net.Http;
using System.Threading.Tasks;
using EasyAbp.Abp.WeChat.MiniProgram.Infrastructure.OptionsResolve.Contributors;
using EasyAbp.Abp.WeChat.MiniProgram.Services.ACode;
using EasyAbp.Abp.WeChat.MiniProgram.Services.Login;
using EasyAbp.WeChatManagement.Common.WeChatApps;
using EasyAbp.WeChatManagement.Common.WeChatAppUsers;
using EasyAbp.WeChatManagement.MiniPrograms.Login;
using EasyAbp.WeChatManagement.MiniPrograms.UserInfos;
using IdentityModel.Client;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Volo.Abp.Caching;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Identity;
using Volo.Abp.Identity.AspNetCore;

namespace EasyAbp.WeChatManagement.MiniPrograms.MiniPrograms;

[ExposeServices(typeof(LoginAppService), typeof(FakeLoginAppService), typeof(ILoginAppService))]
[Dependency(ReplaceServices = true)]
public class FakeLoginAppService : LoginAppService
{
    public FakeLoginAppService(LoginService loginService, ACodeService aCodeService, AbpSignInManager signInManager,
        IDataFilter dataFilter, IConfiguration configuration, IHttpClientFactory httpClientFactory,
        IUserInfoRepository userInfoRepository, IWeChatMiniProgramAsyncLocal weChatMiniProgramAsyncLocal,
        IWeChatAppRepository weChatAppRepository, IWeChatAppUserRepository weChatAppUserRepository,
        IMiniProgramLoginNewUserCreator miniProgramLoginNewUserCreator,
        IMiniProgramLoginProviderProvider miniProgramLoginProviderProvider,
        IDistributedCache<MiniProgramPcLoginAuthorizationCacheItem> pcLoginAuthorizationCache,
        IDistributedCache<MiniProgramPcLoginUserLimitCacheItem> pcLoginUserLimitCache,
        IOptions<IdentityOptions> identityOptions, IdentityUserManager identityUserManager) : base(loginService,
        aCodeService, signInManager, dataFilter, configuration, httpClientFactory, userInfoRepository,
        weChatMiniProgramAsyncLocal, weChatAppRepository, weChatAppUserRepository, miniProgramLoginNewUserCreator,
        miniProgramLoginProviderProvider, pcLoginAuthorizationCache, pcLoginUserLimitCache, identityOptions,
        identityUserManager)
    {
    }

    protected override Task<TokenResponse> RequestAuthServerLoginAsync(string appId, string unionId, string openId)
    {
        return Task.FromResult(new TokenResponse());
    }
}