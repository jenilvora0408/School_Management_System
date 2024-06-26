import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-authentication',
  templateUrl: './authentication.component.html',
  styleUrls: ['./authentication.component.scss'],
})
export class AuthenticationComponent implements OnInit {
  isAdmitRequestRoute: boolean = false;

  constructor(private router: Router, private route: ActivatedRoute) {}

  ngOnInit(): void {}

  shouldRenderImage(): boolean {
    // Check if the current route's path is not equal to "/admit-request"
    return this.router.url !== '/admit-request';
  }
}
