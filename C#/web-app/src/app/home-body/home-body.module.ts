import {CommonModule} from '@angular/common';
import {NgModule} from '@angular/core';
import {HomeBodyComponent} from './home-body.component';
import {SearchBarComponent} from './search-bar/search-bar.component';
import {SearchService} from './Service/SearchService';
import {HttpClientModule} from '@angular/common/http';
import {FormsModule} from '@angular/forms';
import {ResultContainerModule} from '../result-container/result-container.module';

@NgModule({
  declarations: [
    HomeBodyComponent,
    SearchBarComponent
  ],
  imports: [
    CommonModule,
    HttpClientModule,
    FormsModule,
    ResultContainerModule,
  ],
  exports: [
    HomeBodyComponent
  ],
  providers: [
    SearchService
  ],
})
export class HomeModule {
}
