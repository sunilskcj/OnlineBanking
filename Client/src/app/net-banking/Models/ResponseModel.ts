import { Account } from "./Account";
export interface ResponseModel {
    statusCode: number;
    response: any;
   
    data:  Account | Account[]  | null | undefined
}