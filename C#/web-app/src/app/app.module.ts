import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MenuComponent } from './menu/menu.component';
import { HomeBodyComponent } from './home-body/home-body.component';
import { SearchBarComponent } from './home-body/search-bar/search-bar.component';
import { ResultComponent } from './result/result.component';
import {FormsModule} from '@angular/forms';
import { ResultContainerComponent } from './result-container/result-container.component';

@NgModule({
  declarations: [
    AppComponent,
    MenuComponent,
    HomeBodyComponent,
    SearchBarComponent,
    ResultComponent,
    ResultContainerComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
