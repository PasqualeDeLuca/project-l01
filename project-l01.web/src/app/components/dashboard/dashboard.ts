import { Component } from '@angular/core';

@Component({
  selector: 'app-dashboard',
  imports: [],
  templateUrl: './dashboard.html',
  styleUrl: './dashboard.css',
})
export class Dashboard {
  title = 'Inventory Dashboard';

  productCount = 10;

  hasLowStockProducts = true;

  showMessage(): void {
    console.log('Checking inventory...');
  } 
}
