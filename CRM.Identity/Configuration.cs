using IdentityServer4.Models;
using System;
using IdentityServer4;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityModel;

namespace CRM.Identity
{
    //содержит информацию о клиентах и сервисах которым разрешено использовать Identity Srvere
    public class Configuration
    {
        //ApiScopes — это то, что вы запрашиваете как клиент и как пользователь, на что вы даете согласие. 
        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope("CRMWebAPI", "CRM_Role")
            };
        // это области, которые будут включены в токен ID и ресурсы которые может запрашивать клиент.
        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),//это специальная область, которая всегда должна быть включена и которая будет запрашивать у пользователей (суб) уникальный идентификатор (userid).
                new IdentityResources.Profile(),//запросит данные профиля (веб-страница, пол...) пользователя
                //new IdentityResources.Email(),
                //new IdentityResource {
                //Name = "role",
                //UserClaims = new List<string> {"role"}
                //}
                new IdentityResource("CRM_Role",new []{ "role", "admin", "user" } ),

            };
        //указывает, что будет содержать утверждение aud в токене доступа.
        public static IEnumerable<ApiResource> ApiResources =>
            new List<ApiResource>
            {
                  new ApiResource("CRMWebAPI", "Web API")
                {
                    Scopes = { "CRMWebAPI" },
                    UserClaims = { "CRM_Role", "admin", "user" }
                }
                //new ApiResource
                //{
                //Name = "CRMWebAPI",
                //DisplayName = "Web Api",
                //Description = "Web Api Access",
                //UserClaims = new List<string> {"role"},
                //Scopes={ "CRMWebAPI" }
                   
                //}
                //("CRMWebAPI", "Web Api", new []
                //{JwtClaimTypes.Name})
                //{
                //    Scopes={ "CRMWebAPI" }
                //}
            };

        //собственное приложение, веб-приложение или приложение на основе JS.
        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    //  ClientId и   ClientName должны совпадать между сервисом и клиентами
                    ClientId="CRMWebAPI",
                    ClientName="Web API",
                    AllowedGrantTypes = GrantTypes.Code,//Определяет типы гранта клиент разрешено использовать. https://www.oauth.com/oauth2-servers/server-side-apps/authorization-code/
                    RequireClientSecret=false,//Указывает, является ли это клиент требуется секрет для запроса токенов из конечной точки токена 
                    RequirePkce=true,//Указывает,клиентs, использующие тип гранта на основе кода авторизации, должны отправить ключ подтверждения
                    RedirectUris=
                    {
                        "http://localhost:3000/signin-oidc"
                    }, //случи авторизации клиента перекинет на следующий адрес.
                    AllowedCorsOrigins=
                    {
                        "http://localhost:3000"
                    },//Если указано, будет использоваться реализациями службы политик CORS по умолчанию
                    PostLogoutRedirectUris=
                    {
                        "http://localhost:3000/signout-oidc"
                    },//Указывает разрешенные URI для перенаправления после выхода из системы.
                    AllowedScopes=
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        //IdentityServerConstants.StandardScopes.Email,
                        "CRM_Role",
                        "CRMWebAPI",
                       
                    },//По умолчаниюклиентне имеет доступа ни к каким ресурсам - укажите разрешенные ресурсы, добавив соответствующие имена областей
                    AllowAccessTokensViaBrowser=true//Указывает, является ли этоклиентразрешено получать токены доступа через браузер.
                }
            };
    
    }
}
