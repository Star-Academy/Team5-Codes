import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MenuComponent } from './menu/menu.component';
import { ResultComponent } from './result/result.component';
import {FormsModule} from '@angular/forms';
import { ResultContainerComponent } from './result-container/result-container.component';
import {HomeModule} from './home-body/home-body.module'

@NgModule({
  declarations: [
    AppComponent,
    MenuComponent,
    ResultComponent,
    ResultContainerComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HomeModule
  ],
  providers: [],
  exports: [
    ResultContainerComponent
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
