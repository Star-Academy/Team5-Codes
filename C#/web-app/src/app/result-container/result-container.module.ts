import { ResultContainerComponent } from './result-container.component';
import { ResultComponent } from './result/result.component';
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

@NgModule({
  declarations: [
    ResultContainerComponent,
    ResultComponent
  ],
  imports: [
    CommonModule
  ],
  exports: [
    ResultContainerComponent
  ],
  providers: [],
})
export class ToursModule { }
