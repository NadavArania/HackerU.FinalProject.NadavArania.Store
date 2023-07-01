import { Component, OnInit } from '@angular/core';
import { ProductService } from '../../../services/product.service';

@Component({
  selector: 'app-home-hot',
  templateUrl: './home-hot.component.html',
  styleUrls: ['./home-hot.component.css']
})
export class HomeHotComponent implements OnInit {

  constructor(public service: ProductService) { }

  ngOnInit(): void {
  }

}
