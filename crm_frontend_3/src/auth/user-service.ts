import { UserManager, UserManagerSettings } from 'oidc-client';
import { setAuthHeader } from './auth-headers';

const userManagerSettings: UserManagerSettings = {
    client_id: 'CRMWebAPI',
    redirect_uri: 'http://localhost:3000/signin-oidc',
    response_type: 'code',
    scope: 'openid profile CRMWebAPI',
    authority: 'https://localhost:44335/',
    post_logout_redirect_uri: 'http://localhost:3000/signout-oidc',
};

const userManager = new UserManager(userManagerSettings);

type role= {
    role: string;
};

export async function getrole() {
    return new Promise<role>( async(resolve) => {
        const user = await userManager.getUser();
        resolve({role:user?.profile.role})
       
        return user?.profile.role;
    });
}

export async function getrole2() {
        const user = await userManager.getUser();
        return user?.profile.role;
}


export async function getname() {
   
    const user = await userManager.getUser();
   // console.log('User: ', user?.profile.name);  
    return user?.profile.name;
}

export async function admin() {
    let x = "admin";
    return x;
}
export async function dispatcher() {
    let x = "dispatcher";
    return x;
}

export async function storekeeper() {
    let x = "storekeeper";
    return x;
}

export async function master() {
    let x = "serviceman";
    return x;
}

export async function loadUser() {
    const user = await userManager.getUser();
    console.log('User: ', user);
    const token = user?.access_token;
    setAuthHeader(token);
}

//авторизация
export const signinRedirect = () =>{ userManager.signinRedirect()};

export const signinRedirectCallback = () =>
    userManager.signinRedirectCallback();

//выход из системв
export const signoutRedirect = (args?: any) => {
    userManager.clearStaleState();
    userManager.removeUser();
    return userManager.signoutRedirect(args);
};


export const signoutRedirectCallback = () => {
    userManager.clearStaleState();
    userManager.removeUser();
    return userManager.signoutRedirectCallback();
};

export default userManager;