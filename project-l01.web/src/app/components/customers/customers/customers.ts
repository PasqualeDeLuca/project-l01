import { Component, inject, OnInit, signal } from '@angular/core';
import { RouterLink } from '@angular/router';

import { Customer } from '../../../models/customer/customer.model';
import { CustomerService } from '../../../services/customer.service';

@Component({
  selector: 'app-customers',
  imports: [RouterLink],
  templateUrl: './customers.html',
  styleUrl: './customers.css',
})
export class Customers implements OnInit {
  private readonly customerService = inject(CustomerService);

  customers = signal<Customer[]>([]);
  isLoading = signal(false);
  errorMessage = signal('');

  ngOnInit(): void {
    this.loadCustomers();
  }

  loadCustomers(): void {
    this.isLoading.set(true);
    this.errorMessage.set('');

    this.customerService.getCustomers().subscribe({
      next: (customers) => {
        console.log('Customers ricevuti:', customers);
        this.customers.set(customers);
        this.isLoading.set(false);
      },
      error: (error) => {
        console.error('Error loading customers:', error);

        this.errorMessage.set('Unable to load customers.');
        this.isLoading.set(false);
      },
    });
  }
}
