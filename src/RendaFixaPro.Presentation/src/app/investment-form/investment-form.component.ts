import { Component } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-investment-form',
  templateUrl: './investment-form.component.html',
  styleUrls: ['./investment-form.component.css']
})
export class InvestmentFormComponent {
  initialValue!: number;
  months!: number;
  investmentResult: any;
  errorMessages: string[] = []; // Agora é um array para múltiplas mensagens

  constructor(private http: HttpClient) { }

  calculateInvestment() {
    const apiUrl = `https://localhost:7213/investments/calculate/cbd?initialValue=${this.initialValue}&months=${this.months}`;
    this.http.get(apiUrl).subscribe({
      next: (result) => {
        this.investmentResult = result;
        this.errorMessages = []; // Limpa as mensagens de erro anteriores
      },
      error: (error: HttpErrorResponse) => {
        if (error.status === 400 && Array.isArray(error.error)) {
          // Se a resposta de erro contém um array, use-o diretamente
          this.errorMessages = error.error;
        } else {
          // Se não for um array, apenas coloque a mensagem de erro no array
          this.errorMessages = [error.message || "Ocorreu um erro ao processar sua solicitação."];
        }
        console.error('Houve um erro na requisição:', error);
      }
    });
  }
}
