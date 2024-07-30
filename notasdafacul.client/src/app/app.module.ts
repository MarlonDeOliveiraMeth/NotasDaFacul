import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { GradeDetailsComponent } from './grade-details/grade-details.component';
import { GradeDetailsFormComponent } from './grade-details/grade-details-form/grade-details-form.component';

@NgModule({
  declarations: [
    AppComponent,
    GradeDetailsComponent,
    GradeDetailsFormComponent
  ],
  imports: [
    BrowserModule, HttpClientModule,
    AppRoutingModule
  ],
  providers: [
    provideAnimationsAsync()
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
