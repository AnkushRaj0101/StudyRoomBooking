import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ToastrService } from 'ngx-toastr';

@NgModule({
  declarations: [],
  imports: [CommonModule], exports: [],
})
export class SharedModule {
  constructor(private toastr: ToastrService) { }
  showToast(content: string, Titel: string, type: string) {
    if (type === 'success') {
      this.toastr.success(content, Titel, {
        timeOut: 3000, // Duration for which the toastr will be displayed
        progressBar: true, // Show a progress bar
        progressAnimation: 'increasing', // Animation type for progress bar
        positionClass: 'toast-top-right' // Position of the toastr
      });
    } else if (type === 'info') {
      this.toastr.info(content, Titel, {
        timeOut: 3000,
        progressBar: true,
        progressAnimation: 'increasing',
        positionClass: 'toast-top-right'
      });

    } else if (type === 'error') {
      this.toastr.error(content, Titel, {
        timeOut: 3000, // Duration for which the toastr will be displayed
        progressBar: true, // Show a progress bar
        progressAnimation: 'increasing', // Animation type for progress bar
        positionClass: 'toast-top-right' // Position of the toastr
      });
    }

  }
}
