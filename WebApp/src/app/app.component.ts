import { NgFor, NgIf } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Component, inject } from '@angular/core';
import { FormControl, ReactiveFormsModule } from '@angular/forms';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, ReactiveFormsModule, NgFor, NgIf],
  template: `
   <h1>Gerador de Tabuadas</h1>
    <form (submit)="sendNumbers($event)">
      <label for="numbers">Digite os números separados por virgula:</label>
        <input name="numbers" type="text" placeholder="Digite os números separados por virgula" [formControl]="input" />
      <input type="submit" (click)="sendNumbers($event)" />
    </form>
    <div *ngIf="isLoading; else tabuadasTemplRef">
      <span>carregando...</span>
    </div>
    <ng-template #tabuadasTemplRef>
      <ul>
        <li *ngFor="let tabuada of tabuadas">
          <h3>{{tabuada.fileName}}</h3>
          <ul>
            <li *ngFor="let line of tabuada.lines">
              <span>{{line}}</span>
            </li>
          </ul>
        </li>
      </ul>
      </ng-template>
  `,
  styles: [
    `
      form {
        display: flex;
        flex-direction: column;
        gap: 10px;
        max-width: 600px;
        margin: 0 auto;
      }
    `,
  ],
})
export class AppComponent {
  input = new FormControl('');
  isLoading = false;
  tabuadas?: Tabuadas[] = [];
  httpClient = inject(HttpClient);

  sendNumbers(event: Event) {
    event.preventDefault();
    if(!this.input.value) return alert('Digite os números separados por virgula');
    const numbers = this.input.value?.split(',').map((n) => parseInt(n));
    this.isLoading = true;
    this.httpClient.post<Tabuadas[]>('http://localhost:5116/files', { ids: numbers}).subscribe((data) => {
      this.tabuadas = data;
    }).add(()=> this.isLoading = false);
  }
}

export type Tabuadas = {
  fileName: string;
  lines : string[];
}