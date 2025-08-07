// frontend/src/app/login/login.component.ts
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { AuthService } from '../AuthService';
import { HttpClientModule } from '@angular/common/http';
import { HttpClient } from '@angular/common/http';
import { provideHttpClient } from '@angular/common/http';

@Component({
  standalone: true,
  selector: 'app-login',
  imports: [CommonModule,
    FormsModule,],
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {
  email = '';
  password = '';
  loading = false;

  constructor(private router: Router, private authService: AuthService) {}

  onSubmit() {
    if (!this.email || !this.password) {
      alert('Email ve şifre boş bırakılamaz 😅');
      return;
    }
  
    this.loading = true;
  
    this.authService.login(this.email, this.password).subscribe({
      next: (res) => {
        this.authService.saveToken(res.token);
        this.router.navigate(['/dashboard']);
      },
      error: (err) => {
        alert('Wrong e-mail or password! 😢');
      },
      complete: () => {
        this.loading = false;
      }
    });
  }

  checkUser() {
    if (!this.authService.isLoggedIn()) return;

    this.authService.getProfile().subscribe({
      next: (res) => console.log('Kullanıcı bulundu', res),
      error: () => console.log('Token geçersiz')
    });
  }

  navigate(route: string[]) {
    this.router.navigate(route);
  }
}
