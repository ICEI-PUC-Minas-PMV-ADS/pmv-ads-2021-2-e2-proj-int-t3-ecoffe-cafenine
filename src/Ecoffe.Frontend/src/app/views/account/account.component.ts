import { Component, OnInit } from '@angular/core';
@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.css']
})
export class AccountComponent implements OnInit {
  areaType: number = 1;

  constructor() { }

  ngOnInit(): void {
    
  }

  changeArea(type: number){
    this.areaType = type;
  }

}
