import { ClientBase } from './client-base';

//----------------------
// <auto-generated>
//     Generated using the NSwag toolchain v13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v11.0.0.0)) (http://NSwag.org)
// </auto-generated>
//----------------------

/* tslint:disable */
/* eslint-disable */
// ReSharper disable InconsistentNaming

export class Client extends ClientBase {
    private http: { fetch(url: RequestInfo, init?: RequestInit): Promise<Response> };
    private baseUrl: string;
    protected jsonParseReviver: ((key: string, value: any) => any) | undefined = undefined;

    constructor(baseUrl?: string, http?: { fetch(url: RequestInfo, init?: RequestInit): Promise<Response> }) {
        super();
        this.http = http ? http : window as any;
        this.baseUrl = baseUrl !== undefined && baseUrl !== null ? baseUrl : "";
    }

    /**
     * @return Success
     */
    getAll(version: string): Promise<List_Order_ClientVm> {
        let url_ = this.baseUrl + "/api/{version}/Order_Client";
        if (version === undefined || version === null)
            throw new Error("The parameter 'version' must be defined.");
        url_ = url_.replace("{version}", encodeURIComponent("" + version));
        url_ = url_.replace(/[?&]$/, '');

        let options_= <RequestInit> {
            method: "GET",          
            headers: {
               "Accept" : "application/json"
            },
        };

        return this.transformOptions(options_)
        .then(transformedOptions_ => {
            return this.http.fetch(url_, transformedOptions_);
        })
        .then((_response: Response) => {
            return this.processGetAll(_response);
        });
    }

    protected processGetAll(response: Response): Promise<List_Order_ClientVm> {
        const status = response.status;
        let _headers: any = {};
         if (response.headers && response.headers.forEach) { response.headers.forEach((v: any, k: any) => _headers[k] = v); };
         if (status === 201 || status === 200) {
            return response.text().then((_responseText) => {
            let result201: any = null;
            result201 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver) as List_Order_ClientVm;
            return result201;
            });
        } else if (status === 401) {
            return response.text().then((_responseText) => {
            let result401: any = null;
            result401 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver) as ProblemDetails;
            return throwException("Unauthorized", status, _responseText, _headers, result401);
            });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            });
        }
        return Promise.resolve<List_Order_ClientVm>(null as any);
    }

    /**
     * @param body (optional) 
     * @return Success
     */
    create(version: string, body: Create_Order_ClientDto | undefined): Promise<string> {
        let url_ = this.baseUrl + "/api/{version}/Order_Client";
        if (version === undefined || version === null)
            throw new Error("The parameter 'version' must be defined.");
        url_ = url_.replace("{version}", encodeURIComponent("" + version));
        url_ = url_.replace(/[?&]$/, "");

        const content_ = JSON.stringify(body);

        let options_: RequestInit = {
            body: content_,
            method: "POST",
            headers: {
                "Content-Type": "application/json",
                "Accept": "application/json"
            }
        };

        return this.transformOptions(options_).then(transformedOptions_ => {
            return this.http.fetch(url_, transformedOptions_);
        }).then((_response: Response) => {
            return this.processCreate(_response);
        });
    }

    protected processCreate(response: Response): Promise<string> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v: any, k: any) => _headers[k] = v); };
        if (status === 201) {
            return response.text().then((_responseText) => {
            let result201: any = null;
            result201 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver) as string;
            return result201;
            });
        } else if (status === 401) {
            return response.text().then((_responseText) => {
            let result401: any = null;
            result401 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver) as ProblemDetails;
            return throwException("Unauthorized", status, _responseText, _headers, result401);
            });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            });
        }
        return Promise.resolve<string>(null as any);
    }

    /**
     * @param body (optional) 
     * @return Success
     */
    update(version: string, body: Update_Order_ClientDto | undefined): Promise<void> {
        let url_ = this.baseUrl + "/api/{version}/Order_Client";
        if (version === undefined || version === null)
            throw new Error("The parameter 'version' must be defined.");
        url_ = url_.replace("{version}", encodeURIComponent("" + version));
        url_ = url_.replace(/[?&]$/, "");

        const content_ = JSON.stringify(body);

        let options_: RequestInit = {
            body: content_,
            method: "PUT",
            headers: {
                "Content-Type": "application/json",
            }
        };

        return this.transformOptions(options_).then(transformedOptions_ => {
            return this.http.fetch(url_, transformedOptions_);
        }).then((_response: Response) => {
            return this.processUpdate(_response);
        });
    }

    protected processUpdate(response: Response): Promise<void> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v: any, k: any) => _headers[k] = v); };
        if (status === 204) {
            return response.text().then((_responseText) => {
            return;
            });
        } else if (status === 401) {
            return response.text().then((_responseText) => {
            let result401: any = null;
            result401 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver) as ProblemDetails;
            return throwException("Unauthorized", status, _responseText, _headers, result401);
            });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            });
        }
        return Promise.resolve<void>(null as any);
    }

    /**
     * @return Success
     */
    get(id: number, version: string): Promise<Order_Client_DetailsVm> {
        let url_ = this.baseUrl + "/api/{version}/Order_Client/{id}";
        if (id === undefined || id === null)
            throw new Error("The parameter 'id' must be defined.");
        url_ = url_.replace("{id}", encodeURIComponent("" + id));
        if (version === undefined || version === null)
            throw new Error("The parameter 'version' must be defined.");
        url_ = url_.replace("{version}", encodeURIComponent("" + version));
        url_ = url_.replace(/[?&]$/, "");

        let options_: RequestInit = {
            method: "GET",
            headers: {
                "Accept": "application/json"
            }
        };

        return this.transformOptions(options_).then(transformedOptions_ => {
            return this.http.fetch(url_, transformedOptions_);
        }).then((_response: Response) => {
            return this.processGet(_response);
        });
    }

    protected processGet(response: Response): Promise<Order_Client_DetailsVm> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v: any, k: any) => _headers[k] = v); };
        if (status === 200) {
            return response.text().then((_responseText) => {
            let result200: any = null;
            result200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver) as Order_Client_DetailsVm;
            return result200;
            });
        } else if (status === 401) {
            return response.text().then((_responseText) => {
            let result401: any = null;
            result401 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver) as ProblemDetails;
            return throwException("Unauthorized", status, _responseText, _headers, result401);
            });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            });
        }
        return Promise.resolve<Order_Client_DetailsVm>(null as any);
    }

    /**
     * @return Success
     */
    delete(id: number, version: string): Promise<void> {
        let url_ = this.baseUrl + "/api/{version}/Order_Client/{id}";
        if (id === undefined || id === null)
            throw new Error("The parameter 'id' must be defined.");
        url_ = url_.replace("{id}", encodeURIComponent("" + id));
        if (version === undefined || version === null)
            throw new Error("The parameter 'version' must be defined.");
        url_ = url_.replace("{version}", encodeURIComponent("" + version));
        url_ = url_.replace(/[?&]$/, "");

        let options_: RequestInit = {
            method: "DELETE",
            headers: {
            }
        };

        return this.transformOptions(options_).then(transformedOptions_ => {
            return this.http.fetch(url_, transformedOptions_);
        }).then((_response: Response) => {
            return this.processDelete(_response);
        });
    }

    protected processDelete(response: Response): Promise<void> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v: any, k: any) => _headers[k] = v); };
        if (status === 204) {
            return response.text().then((_responseText) => {
            return;
            });
        } else if (status === 401) {
            return response.text().then((_responseText) => {
            let result401: any = null;
            result401 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver) as ProblemDetails;
            return throwException("Unauthorized", status, _responseText, _headers, result401);
            });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            });
        }
        return Promise.resolve<void>(null as any);
    }
}

export class GetAllClient extends ClientBase {
    private http: { fetch(url: RequestInfo, init?: RequestInit): Promise<Response> };
    private baseUrl: string;
    protected jsonParseReviver: ((key: string, value: any) => any) | undefined = undefined;

    constructor(baseUrl?: string, http?: { fetch(url: RequestInfo, init?: RequestInit): Promise<Response> }) {
        super();
        this.http = http ? http : window as any;
        this.baseUrl = baseUrl !== undefined && baseUrl !== null ? baseUrl : "";
    }

    /**
     * @return Success
     */
    personnal(version: string): Promise<List_PersonnalVm> {
        let url_ = this.baseUrl + "/api/{version}/Order_Client/allpersonnal";
        if (version === undefined || version === null)
            throw new Error("The parameter 'version' must be defined.");
        url_ = url_.replace("{version}", encodeURIComponent("" + version));
        url_ = url_.replace(/[?&]$/, "");

        let options_: RequestInit = {
            method: "GET",
            headers: {
                "Accept": "application/json"
            }
        };

        return this.transformOptions(options_).then(transformedOptions_ => {
            return this.http.fetch(url_, transformedOptions_);
        }).then((_response: Response) => {
            return this.processPersonnal(_response);
        });
    }

    protected processPersonnal(response: Response): Promise<List_PersonnalVm> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v: any, k: any) => _headers[k] = v); };
        if (status === 201) {
            return response.text().then((_responseText) => {
            let result201: any = null;
            result201 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver) as List_PersonnalVm;
            return result201;
            });
        } else if (status === 401) {
            return response.text().then((_responseText) => {
            let result401: any = null;
            result401 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver) as ProblemDetails;
            return throwException("Unauthorized", status, _responseText, _headers, result401);
            });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            });
        }
        return Promise.resolve<List_PersonnalVm>(null as any);
    }
}

export class GetClient extends ClientBase {
    private http: { fetch(url: RequestInfo, init?: RequestInit): Promise<Response> };
    private baseUrl: string;
    protected jsonParseReviver: ((key: string, value: any) => any) | undefined = undefined;

    constructor(baseUrl?: string, http?: { fetch(url: RequestInfo, init?: RequestInit): Promise<Response> }) {
        super();
        this.http = http ? http : window as any;
        this.baseUrl = baseUrl !== undefined && baseUrl !== null ? baseUrl : "";
    }

    /**
     * @return Success
     */
    personnal(id: string, version: string): Promise<PersonnalVm> {
        let url_ = this.baseUrl + "/api/{version}/Order_Client/personal/{id}";
        if (id === undefined || id === null)
            throw new Error("The parameter 'id' must be defined.");
        url_ = url_.replace("{id}", encodeURIComponent("" + id));
        if (version === undefined || version === null)
            throw new Error("The parameter 'version' must be defined.");
        url_ = url_.replace("{version}", encodeURIComponent("" + version));
        url_ = url_.replace(/[?&]$/, "");

        let options_: RequestInit = {
            method: "GET",
            headers: {
                "Accept": "application/json"
            }
        };

        return this.transformOptions(options_).then(transformedOptions_ => {
            return this.http.fetch(url_, transformedOptions_);
        }).then((_response: Response) => {
            return this.processPersonnal(_response);
        });
    }

    protected processPersonnal(response: Response): Promise<PersonnalVm> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v: any, k: any) => _headers[k] = v); };
        if (status === 200) {
            return response.text().then((_responseText) => {
            let result200: any = null;
            result200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver) as PersonnalVm;
            return result200;
            });
        } else if (status === 401) {
            return response.text().then((_responseText) => {
            let result401: any = null;
            result401 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver) as ProblemDetails;
            return throwException("Unauthorized", status, _responseText, _headers, result401);
            });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            });
        }
        return Promise.resolve<PersonnalVm>(null as any);
    }
}

export interface Create_Order_ClientDto {
    iD_Client?: number;
    name_Client?: string | undefined;
    lastName_Client?: string | undefined;
    email_Client?: string | undefined;
    telefon?: string | undefined;
    type_technology?: string | undefined;
    model_technology?: string | undefined;
    breaking_info?: string | undefined;
}

export interface List_Order_Client {
    iD_Order?: number;
    name_Client?: string | undefined;
    lastName_Client?: string | undefined;
    email_Client?: string | undefined;
    telefon?: string | undefined;
    price?: number;
    status_Order?: string |undefined;
    issue_date?: Date | undefined;
}

export interface List_Order_ClientVm {
    orders?: List_Order_Client[] | undefined;
}

export interface List_Personnal {
    iD_Personnal?: string;
    name?: string | undefined;
    last_Name?: string | undefined;
    telefon?: string | undefined;
    position?: string | undefined;
}

export interface List_PersonnalVm {
    list_Personnals?: List_Personnal[] | undefined;
}

export interface Order_Client_DetailsVm {
    name_Client?: string | undefined;
    lastName_Client?: string | undefined;
    email_Client?: string | undefined;
    telefon?: string | undefined;
    type_technology?: string | undefined;
    model_technology?: string | undefined;
    breaking_info?: string | undefined;
    status_Order?: string | undefined;
    iD_Personnel_dispatcher?: string;
    iD_Personnel_master?: string;
    receipt_date?: Date;
    issue_date?: Date | undefined;
    price?: number;
}

export interface PersonnalVm {
    name?: string | undefined;
    last_Name?: string | undefined;
    email?: string | undefined;
    telefon?: string | undefined;
    position?: string | undefined;
}

export interface ProblemDetails {
    type?: string | undefined;
    title?: string | undefined;
    status?: number | undefined;
    detail?: string | undefined;
    instance?: string | undefined;
}

export interface Update_Order_ClientDto {
    iD_Order?: string;
    status_Order?: string | undefined;
}

export class ApiException extends Error {
    override message: string;
    status: number;
    response: string;
    headers: { [key: string]: any; };
    result: any;

    constructor(message: string, status: number, response: string, headers: { [key: string]: any; }, result: any) {
        super();

        this.message = message;
        this.status = status;
        this.response = response;
        this.headers = headers;
        this.result = result;
    }

    protected isApiException = true;

    static isApiException(obj: any): obj is ApiException {
        return obj.isApiException === true;
    }
}

function throwException(message: string, status: number, response: string, headers: { [key: string]: any; }, result?: any): any {
    if (result !== null && result !== undefined)
        throw result;
    else
        throw new ApiException(message, status, response, headers, null);
}