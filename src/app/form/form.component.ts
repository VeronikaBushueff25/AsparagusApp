import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { ApiService } from '../api.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-form',
  standalone: true,
  imports: [FormsModule, RouterModule],
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})
export class FormComponent {
  user = { name: '', email: '' };

  constructor(private apiService: ApiService, private router: Router) { }

  submitForm() {
  this.apiService.createUser(this.user).subscribe(
    response => {
      console.log('Success:', response);
      this.router.navigate(['/feed']);
    },
    error => {
      console.error('Error:', error);
      // Здесь можно добавить логику обработки ошибки, например, показать сообщение пользователю
    }
  );
}
}