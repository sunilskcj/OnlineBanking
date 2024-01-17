import { AbstractControl, ValidationErrors, Validator, ValidatorFn } from "@angular/forms";

export class LengthValidator {
    public static get Length(): ValidatorFn {

        const validateLength = (control: AbstractControl): ValidationErrors | null => {
            const inputData = <string>control.value
            if (inputData.length < 5 || inputData.length > 10)
                return {
                    lengtherror:
                    {
                        message: 'length should be between 10 and 13',
                        status: true,
                        maximumength: 13,
                        minimumlength: 10,
                        currentlength: inputData.length
                    }
                }
            else
                return null
        }

        return validateLength;
    }
}