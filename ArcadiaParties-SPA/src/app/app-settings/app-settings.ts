export interface AppSettings {
    apiUrl: string;
    oauth: {
        clientId: string;
        tenant: string;
        redirectUri: string;
    };
}
