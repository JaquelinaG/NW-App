import { Component, OnInit } from '@angular/core';
import { Customer } from '../entities/customer.entity';
import {CUSTOMERS} from '../mock-customers';

@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html',
  styleUrls: ['./customers.component.css']
})
export class CustomersComponent implements OnInit {
  
  selectedCustomer: Customer ;

  customers = CUSTOMERS;

  onSelect(customer: Customer): void {
    this.selectedCustomer = customer;
  }

  constructor() { }

  ngOnInit() {
  }
}
