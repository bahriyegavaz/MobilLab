import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../AuthService';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { provideHttpClient } from '@angular/common/http';
import { HttpClientModule } from '@angular/common/http';



@Component({
  standalone: true,
  imports: [CommonModule, FormsModule,HttpClientModule],
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss'],
  selector: 'app-register',
})
export class RegisterComponent {
  fullName = '';
  username = '';
  email = '';
  password = '';
  errorMessage = '';

  constructor(private authService: AuthService, private router: Router) {}

  onRegister() {
    if (!this.email || !this.password) {
      this.errorMessage = 'Missing email or password!';
      return;
    }

    this.authService.register(this.fullName,this.username,this.email, this.password ).subscribe({
      next: (res) => {
        console.log('Kayıt başarılı', res);
        // Otomatik giriş istersen token sakla:
        localStorage.setItem('token', res.token);
        this.router.navigate(['/dashboard']); // yönlendirme
      },
      error: (err) => {
        console.error('Kayıt hatası:', err);
        this.errorMessage = err.error?.message || 'Something went wrong!';
      },
    });
  }
}
