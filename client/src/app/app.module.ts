import { HttpClientModule } from '@angular/common/http'; 
import{FormsModule,ReactiveFormsModule} from '@angular/forms'
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PersonComponent } from './person/person.component';
import { ShowPersonComponent } from './persons/show-person/show-person.component';
import { AddEditPersonComponent } from './persons/add-edit-person/add-edit-person.component';
import {PersonApiService  } from './person-api.service';

@NgModule({
  declarations: [
    AppComponent,
    PersonComponent,
    ShowPersonComponent,
    AddEditPersonComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  
  ],
  providers: [PersonApiService],
  bootstrap: [AppComponent]
})
export class AppModule { }
