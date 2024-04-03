 
import { invalidEmail, validEmails } from "../constants";
import {regexValidatorResult} from "../types";

export function useRegexValidator(regex : string) {

 

        let rx = new RegExp(regex); // The "i" flag makes the regex case-insensitive
       
        let result : regexValidatorResult[]= [];
        validEmails.forEach((value:string) => {
             if (rx.test(value)) {
                result.push({validType: true, test:value})
            }
          
        } )
        invalidEmail.forEach((value:string) => {
            if (!rx.test(value)) {
               result.push({validType: false, test:value})
           }
         
       } )

        return result;
        

     
  
}