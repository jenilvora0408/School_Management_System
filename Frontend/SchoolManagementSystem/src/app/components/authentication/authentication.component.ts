import { NgClass } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-authentication',
  standalone: true,
  imports: [RouterOutlet, NgClass],
  templateUrl: './authentication.component.html',
  styleUrl: './authentication.component.scss',
})
export class AuthenticationComponent implements OnInit {
  isAdmitRequestRoute: boolean = false;

  constructor(private router: Router, private route: ActivatedRoute) {}

  ngOnInit(): void {}

  shouldRenderImage(): boolean {
    return this.router.url !== '/admit-request';
  }
}
