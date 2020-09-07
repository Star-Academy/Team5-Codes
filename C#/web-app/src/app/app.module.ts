import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MenuComponent } from './menu/menu.component';
import { HomeBodyComponent } from './home-body/home-body.component';
import { SearchBarComponent } from './home-body/search-bar/search-bar.component';

@NgModule({
  declarations: [
    AppComponent,
    MenuComponent,
    HomeBodyComponent,
    SearchBarComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
