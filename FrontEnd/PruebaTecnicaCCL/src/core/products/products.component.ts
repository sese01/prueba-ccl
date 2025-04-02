import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ProductsService } from './service/products.service';

@Component({
  selector: 'app-products',
  imports: [CommonModule],
  templateUrl: './products.component.html',
  styleUrl: './products.component.scss',
})
export class ProductsComponent implements OnInit {
  public productsList: any[] = [];
  constructor(private _service: ProductsService) {}

  public ngOnInit(): void {
    this._service.getProducts().subscribe((data) => {
      this.productsList = data
      console.info(this.productsList)
    });
  }


}
