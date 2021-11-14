import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {MatIconModule} from '@angular/material/icon';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';


@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']

  
})

export class ProductsComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
    
  }

}


