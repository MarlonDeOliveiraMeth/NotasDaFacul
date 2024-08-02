import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { GradeDetailsComponent } from './grade-details/grade-details.component';
import { GradeDetailsFormComponent } from './grade-details/grade-details-form/grade-details-form.component';
import { MatTableModule } from '@angular/material/table';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatCardModule } from '@angular/material/card';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInput, MatInputModule } from '@angular/material/input';

@NgModule({
  declarations: [
    AppComponent,
    GradeDetailsComponent,
    GradeDetailsFormComponent
  ],
  imports: [
    BrowserModule, HttpClientModule,
    AppRoutingModule, MatTableModule,
    MatToolbarModule, MatCardModule,
    MatGridListModule, MatButtonModule,
    MatFormFieldModule, MatInput,
    MatInputModule
  ],
  providers: [
    provideAnimationsAsync()
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
