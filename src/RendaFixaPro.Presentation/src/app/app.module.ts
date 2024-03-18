import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http'; // Adicione esta linha
import { FormsModule } from '@angular/forms'; // Adicione esta linha para formulários

import { AppComponent } from './app.component';
import { InvestmentFormComponent } from './investment-form/investment-form.component';

@NgModule({
  declarations: [
    AppComponent,
    InvestmentFormComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule, // Adicione esta linha
    FormsModule // Adicione esta linha
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
