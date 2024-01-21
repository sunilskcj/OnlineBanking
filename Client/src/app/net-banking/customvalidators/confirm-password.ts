import { FormGroup } from '@angular/forms';
    
export function ConfirmedValidator(controlName: string, matchingControlName: string){
    return (formGroup: FormGroup) => {
        const control = formGroup.controls['SetTransactionPassword'];
        const matchingControl = formGroup.controls['ConfirmTransactionPassword'];
        if (matchingControl.errors && !matchingControl.errors?.['confirmedValidator']) {
            return;
        }
        if (control.value !== matchingControl.value) {
            matchingControl.setErrors({ confirmedValidator: true});
        } else {
            matchingControl.setErrors(null);
        }
    }
} 